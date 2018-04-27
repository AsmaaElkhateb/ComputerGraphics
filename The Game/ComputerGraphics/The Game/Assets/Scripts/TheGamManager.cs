using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TheGamManager : MonoBehaviour
{
    public static TheGamManager instance = null ;
    public GameObject scoreTextObject;
    private int score;
    private Text scoreText;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(gameObject);

        scoreText = scoreTextObject.GetComponent<Text>() ; //3shan na5od klmt score elly bara w a8yar fe
        scoreText.text = "Score : " + score.ToString();
    }

    public void collect(int passedValue , GameObject passedObject)
    {
        //destroy our collectable
        passedObject.GetComponent<Renderer>().enabled = false;
       // passedObject.GetComponent<Renderer>().enabled = false; /*de 3shan lw 3adet 3al frute marten wna bnot msln my7sb4 el value marten

        Destroy(passedObject , 1.0f);
        //update score range
        score = score + passedValue;
        scoreText.text = "Score : " + score.ToString();
        //update our score ui
    }

}
