using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private CharacterController controller;
    private float speed = 5.0f;
    private Vector3 moveVector; //da hnzbat be etgah el 7araka shmal w ymen
    private float verticalVelocity = 0.0f;
    private float gravity = 12.0f;

    private float animationDuration = 2.0f; // for the camera
    private bool isDead = false;

    // Use this for initialization
    void Start () {

        controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {

        if (isDead)
        {
            return;
        }

        if (Time.time< animationDuration)
        {
            controller.Move(Vector3.forward * speed * Time.deltaTime);
            return; //3shan myd5olsh felly ta7t l7d awl 3 seconds
        }
        moveVector = Vector3.zero; // da 3shan a3ml reset lel vector kol frame


        if (controller.isGrounded)
        {
            verticalVelocity = -0.5f;
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        //x value (left and right)
        moveVector.x = Input.GetAxis("Horizontal") * speed ;

        //y value (up and down )
        moveVector.y = verticalVelocity;

        //z value (forward and backward)
        moveVector.z = speed; // to walk forward only and the speed is a positive value

        controller.Move(moveVector * Time.deltaTime);
	}

   public void SetSpeed(float modifier)
    {
        speed = 5.0f + modifier;
    }

    //it is begin called every time our capsule hits something
   private void OnControllerColliderHit(ControllerColliderHit hit)
    {
     /*   if (hit.gameObject.tag == "Ground")
        {
            return;
        }*/
        //check if we hit an object that is in fornt of us
        if (hit.point.z > transform.position.z + controller.radius)
        {
            Death();
        }
    }
   private void Death()
    {
        Debug.Log("Dead");
        isDead = true;
        GetComponent<Score>().OnDeath(); //bnnadi 3la fun ondeath mn script el score bel getcomponent

    }
}
