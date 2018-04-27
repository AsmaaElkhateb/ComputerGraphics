using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    private Transform lookAt;
    private Vector3 startOffset;
    private Vector3 moveVector;

    private float transition = 0.0f;
    private float animationDuration = 2.0f;
    Vector3 animationOffset = new Vector3(0, 5, 5);

    // Use this for initialization
    void Start()
    {

        lookAt = GameObject.FindGameObjectWithTag("Player").transform;
        startOffset = transform.position - lookAt.position;//3shan el camera tbda2 mn wra el player

    }

    // Update is called once per frame
    void Update()
    {
        moveVector = lookAt.position + startOffset;
        //x
        moveVector.x = 0; //3shan el camera tfdal in the center
        //y
        moveVector.y = Mathf.Clamp(moveVector.y, 3, 5); //********de tet3adel fel jump*******************************

        if (transition > 1.0f)
        {
            //normal camera movement
            transform.position = moveVector; //mkan el camera hwa mkan el player
        }
        else
        {
            //Animation at the start of the game
            transform.position = Vector3.Lerp(moveVector + animationOffset, moveVector, transition);
            transition += Time.deltaTime * 1 / animationDuration; // hna bn3ml increment lel transition 3shan yd5ol fel if w el cam tkaml 3adi
            transform.LookAt(lookAt.position + Vector3.up);

        }


    }
}
