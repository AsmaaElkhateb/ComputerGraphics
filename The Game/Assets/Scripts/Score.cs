using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // 3shan a5od el text mn el ui w a7ot el score bta3y(have a reference on text)

public class Score : MonoBehaviour
{


    public Text scoreText;
    private float score = 0.0f;
    private int difficultyLevel = 1;
    private int maxDifficultyLevel = 10;
    private int scoreToNextLevel = 10;
    private bool isDead = false;
    public DeathMenu deathMenu;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            return;
        }
        if (score >= scoreToNextLevel)
        {
            LevelUp();
        }
        score += Time.deltaTime * difficultyLevel;

        scoreText.text = ((int)score).ToString();
        
    }

    private void LevelUp()
    {
        if (difficultyLevel == maxDifficultyLevel)
        {
            return;
        }
        scoreToNextLevel *= 2;
        difficultyLevel++;
        //changing the speed of the player
       GetComponent<Player>().SetSpeed(difficultyLevel);
    }
    public void OnDeath()
    {
        isDead = true;
        deathMenu.ToggleEndMenu(score);//lma ymot hnb3at el score lel deathmenu
    }

}
