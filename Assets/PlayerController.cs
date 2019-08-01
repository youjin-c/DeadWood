using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public static bool Kill = false;
	private IEnumerator coroutine;
	public GameObject remains;

	public const float DEATH_RADIUS = 7F;
	private const float DEATH_RADIUS_SQ = DEATH_RADIUS * DEATH_RADIUS;

	//public float speed;
	public Text countText;
	public Text winText;

	AudioSource enemyAudio;   

	public static int count = 0 ;

	void Start ()
	{
		//rb = GetComponent<Rigidbody>();
		count = 0;
		SetCountText ();
		winText.text = "";
		enemyAudio = GetComponent <AudioSource> ();

	}

	/*void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
	}*/

	void Update(){
		//if (Input.GetMouseButton(0)||Input.GetKey(KeyCode.Joystick1Button1)){

		if (Input.GetButton("Fire1")) {

			if (FindClosestDis() <= DEATH_RADIUS_SQ) {
				count += 1;
				Kill = true;
				Destroy (FindClosestEnemy());
				Instantiate (remains, FindClosestEnemy().transform.position, FindClosestEnemy().transform.rotation);
				enemyAudio.Play ();
//				GlitchEffect.intensity = count / 10.0;
//				GlitchEffect.flipIntensity = count /20.0;
//				GlitchEffect.colorIntensity = count / 20.0;
					
//				switch (count) {
//				case 1: 
//					GlitchEffect.intensity = 0.1;
//					break;
//				case 2:
//					break;
//				case 3:
//					GlitchEffect.intensity = 0.3;
//					break;
//				case 4: 
//					break;
//				case 5:
//					break;
//				case 6:
//					break;
//				case 7: 
//					break;
//				case 8:
//					break;
//				case 9:
//					break;
//				case 10: 
//					break;
//				}
				if (count >= 10) {
					coroutine = goToEnding(10f);
					StartCoroutine (coroutine);
				}
			} else {
				//Debug.Log ("fail");
				Kill = false;
			}
			Debug.Log ("Count : "+count);
		}
		if (transform.position.y < -400) {
			coroutine = goToEnding(10f);
			StartCoroutine (coroutine);
		}
	}

    void SetCountText ()
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= 14)
		{
			winText.text = "You Win!";
		}
	}

	float FindClosestDis()
	{
		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag("Enemy");
		float distance = Mathf.Infinity;
		Vector3 position = transform.position;
		foreach (GameObject go in gos)
		{
			Vector3 diff = go.transform.position - position;
			float curDistance = diff.sqrMagnitude;
			if (curDistance < distance)
			{
				distance = curDistance;
			}
		}
		return distance;
	}
	GameObject FindClosestEnemy()
	{
		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag("Enemy");
		GameObject closest = null;
		float distance = Mathf.Infinity;
		Vector3 position = transform.position;
		foreach (GameObject go in gos)
		{
			Vector3 diff = go.transform.position - position;
			float curDistance = diff.sqrMagnitude;
			if (curDistance < distance)
			{
				closest = go;
				distance = curDistance;
			}
		}
		return closest;
	}

	private IEnumerator goToEnding(float waitTime){
			yield return new WaitForSeconds (waitTime);
		//yield.return null;
		SceneManager.LoadScene (1);



	}
}