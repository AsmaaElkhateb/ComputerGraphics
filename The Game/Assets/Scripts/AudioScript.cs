﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour {

    public AudioClip musicClip;
    public AudioSource musicSource;
	// Use this for initialization
	void Start () {
        musicSource.clip = musicClip;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            musicSource.Play();
        }
	}
}
