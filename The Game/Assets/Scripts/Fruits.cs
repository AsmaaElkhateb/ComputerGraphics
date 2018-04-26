using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits : MonoBehaviour {

    public int value ;
    public float rotateSpeed;

	
	// Update is called once per frame
	void Update () {
        gameObject.transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);
	}

    private void OnTriggerEnter(Collider other)
    {
        //collect function 
        TheGamManager.instance.collect(value, gameObject);

        //play sound
        AudioSource source = GetComponent<AudioSource>();
        source.Play();
        
    }
}
