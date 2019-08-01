using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class goToStart : MonoBehaviour {
	private IEnumerator coroutine;
	public Text creditText;
	string[] Laozi = new string[] {"The usefulness of a pot comes from its emptiness.",};
	//public a creditAlpha;
	// Use this for initialization
	void Start () {
		coroutine = reStart (0.1f);
		StartCoroutine (coroutine);

	}

	private IEnumerator reStart(float waitTime){
		for (float f = 0f; f <= 1.0f; f += 0.1f) {
			Color c = creditText.color;
			c.a = f;
			creditText.color = c;
			yield return new WaitForSeconds (waitTime);
		}
		yield return new WaitForSeconds (2f);
		for (float f = 1.0f; f >= 0; f -= 0.1f) {
			Color c = creditText.color;
			c.a = f;
			creditText.color = c;
			yield return new WaitForSeconds (waitTime);
		}
		//yield.return null;
		SceneManager.LoadScene (0);



	}
}
