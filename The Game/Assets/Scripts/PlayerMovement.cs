using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody rb;
    [SerializeField] // to be visible
    private float speed;
    private Animator anim;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0f,0f,speed);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space ) )  
        {
            rb.AddForce(0f, .7f, 0f, ForceMode.Impulse);
            anim.Play("Jumping");
        } 



    }
}




