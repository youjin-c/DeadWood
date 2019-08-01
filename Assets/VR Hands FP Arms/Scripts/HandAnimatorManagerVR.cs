using UnityEngine;
using System.Collections;
using System;

public class HandAnimatorManagerVR : MonoBehaviour
{
	public StateModel[] stateModels;
	Animator handAnimator;

	public int currentState = 4;
	int lastState = -1;

	public bool action = false;
	public bool hold = false;

	//trackpad keys 8 or 9
	public string changeKey = "joystick button 9";
	//trigger keys 14 or 15
	public string actionKey = "Fire1";//"joystick button 15";

	//grip axis 11 or 12
	public string holdKey = "Fire2";//"Axis 11";


	public int numberOfAnimations = 8;

	// Use this for initialization
	void Start ()
	{
		string[] joys = UnityEngine.Input.GetJoystickNames ();
		foreach (var item in joys) {
			Debug.Log (item);
		}
		handAnimator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
//		if (enermyScript.Kill) {
//			currentState = 5;
//		} else {
//			currentState = 4;
//		}
		//4 : fail 5 : success
		if (Input.GetKeyUp (changeKey)) {
			currentState = (currentState + 1) % (numberOfAnimations + 1);
		}

		//if (Input.GetKeyDown (holdKey)) {
		if (Input.GetButton("Fire2")) {
			hold = true;
		} else
			hold = false;

		//if (Input.GetKey (actionKey)) {
		if (Input.GetButton("Fire1")) {
			action = true;
		} else
			action = false;


		if (lastState != currentState) {
			lastState = currentState;
			handAnimator.SetInteger ("State", currentState);
			TurnOnState (currentState);
		}

		handAnimator.SetBool ("Action", action);
		handAnimator.SetBool ("Hold", hold);

	}

	void TurnOnState (int stateNumber)
	{
		foreach (var item in stateModels) {
			if (item.stateNumber == stateNumber && !item.go.activeSelf)
				item.go.SetActive (true);
			else if (item.go.activeSelf)
				item.go.SetActive (false);
		}
	}


}

