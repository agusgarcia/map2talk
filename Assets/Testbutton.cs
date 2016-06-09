using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Testbutton : MonoBehaviour {


	public Image im;

	// Use this for initialization
	void Start () {
		im.GetComponent<CanvasRenderer>().SetAlpha(0f);
		Debug.Log (im.GetComponent<CanvasRenderer> ().GetAlpha());
	}

	public void ChangeAlpha() {

		if (im.GetComponent<CanvasRenderer> ().GetAlpha() == 0f) {


			//im.GetComponent<CanvasRenderer> ().SetAlpha (0.5f);
			im.CrossFadeAlpha (1f, .3f, false);
			Debug.Log ("here");

		} else {
			Debug.Log ("Alpha "+ im.GetComponent<CanvasRenderer> ().GetAlpha());

			//im.GetComponent<CanvasRenderer> ().SetAlpha (0f);
			im.CrossFadeAlpha (0f, .3f, false);
			Debug.Log ("there");
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
