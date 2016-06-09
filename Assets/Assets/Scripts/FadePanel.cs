using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class FadePanel : MonoBehaviour {

	public Image panel;
	public Image background;
	protected CanvasRenderer[] childrenCanvas;
	protected Graphic[] childrenImage;
	protected Button button;
	bool shown = false;
	protected GameObject container;
	protected Canvas containerCanvas;

	void Start () {
		
		container = GameObject.Find("TravellerContacted");
		containerCanvas = container.GetComponent<Canvas>();
		containerCanvas.sortingOrder = 0;

		if (EventSystem.current.currentSelectedGameObject != null)
		{
			Debug.Log(EventSystem.current.currentSelectedGameObject.name);
		}
		//Set panel and bg Alpha = 0
		panel.GetComponent<CanvasRenderer>().SetAlpha(0f);
		background.GetComponent<CanvasRenderer>().SetAlpha(0f);
		//panel.enabled = false;
		//background.enabled = false;

		Debug.Log ("panel: "+panel.isActiveAndEnabled);

		//Set for each children Alpha = 0
		childrenCanvas = panel.GetComponentsInChildren<CanvasRenderer>();
		foreach (CanvasRenderer child in childrenCanvas) {
			child.SetAlpha(0f);
		}
			
		childrenImage = panel.GetComponentsInChildren<Graphic>();

		button = GetComponent<Button>();	
	}

	public void ChangeAlpha() {


		Debug.Log ("clicked");
		Debug.Log ("Change Alpha");
		Debug.Log ("shown : " + shown);	
		Debug.Log ("alpha : " + panel.GetComponent<CanvasRenderer> ().GetAlpha ());

	if ((panel.GetComponent<CanvasRenderer>().GetAlpha() == 0f) & (shown == false)) {
			
			Debug.Log ("avant");
			containerCanvas.sortingOrder = 3;
			Debug.Log ("après");
			panel.CrossFadeAlpha (1f, .3f, false);
			//background.enabled = true;
			//panel.enabled = true;
			background.CrossFadeAlpha (0.4f, .3f, false);

			foreach (Graphic child in childrenImage) {
				child.CrossFadeAlpha (1f, .3f, false);
			}

			Debug.Log ("aprespres");
			button.interactable = false;
			shown = true;

		} else {
			Debug.Log ("else");

			containerCanvas.sortingOrder = 1;
		//	Debug.Log ("hide");
			panel.CrossFadeAlpha (0f, .3f, false);
			background.CrossFadeAlpha (0f, .3f, false);
		
			//background.enabled = false;
			//panel.enabled = false;
			foreach (Graphic child in childrenImage) {
				child.CrossFadeAlpha (0f, .3f, false);
			}

			panel.GetComponent<CanvasRenderer>().SetAlpha(0);
			Debug.Log ("alpha 2: " + panel.GetComponent<CanvasRenderer> ().GetAlpha ());

		}
	}

}
