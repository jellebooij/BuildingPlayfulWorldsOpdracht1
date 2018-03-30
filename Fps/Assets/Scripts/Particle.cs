using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour {

    // Use this for initialization

    public AudioClip s;

	void Start () {
        Destroy(gameObject, 3);
        AudioSource sr;
        sr = GetComponent<AudioSource>();
        sr.pitch = Random.Range(0.9f, 1.1f);
        sr.PlayOneShot(s);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
