using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swim : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(-1*Time.deltaTime, 0, Time.deltaTime, Camera.main.transform);
	}
}
	