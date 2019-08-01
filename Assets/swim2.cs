using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swim2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Time.deltaTime, -1*Time.deltaTime, 0, Camera.main.transform);
	}
}
