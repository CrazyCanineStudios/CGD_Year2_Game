﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour {

	// Use this for initialization
	void Start () {
		ParticleSystem exp = GetComponent<ParticleSystem>();
		exp.Play ();
		Destroy(gameObject, exp.duration);
	}
}
