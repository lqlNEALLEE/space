﻿using System.Collections;
using UnityEngine;

public class RandomRotator : MonoBehaviour {
    public float tumble;

	// Use this for initialization
	void Start () {
        GetComponent <Rigidbody> ().angularVelocity = Random.insideUnitSphere * tumble;
	  }
	
	}

