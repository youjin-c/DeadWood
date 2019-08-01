using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enermyScript : MonoBehaviour {

	private const string PLAYER_TAG = "Player";
	public static bool Kill = false;

	// precalculate the squared death radius to optimize
	public const float DEATH_RADIUS = 7F;
	private const float DEATH_RADIUS_SQ = DEATH_RADIUS * DEATH_RADIUS;

	private GameObject playerGameObject;

	void Start () {
		playerGameObject = GameObject.FindWithTag(PLAYER_TAG);
	}
	

	void Update () {
		if (Input.GetMouseButton(0)) {
			
			Vector3 distanceToPlayer = playerGameObject.transform.position - this.transform.position;
			//Debug.Log (distanceToPlayer.sqrMagnitude + " ; " +  DEATH_RADIUS_SQ);
			if (distanceToPlayer.sqrMagnitude <= DEATH_RADIUS_SQ) {
				Kill = true;
				
				//Destroy (this.gameObject);
				Debug.Log ("success");
			
			} else {
				//Debug.Log ("fail");
				Kill = false;
			}
			Debug.Log ("Kill : "+Kill);
		}
	}
}
