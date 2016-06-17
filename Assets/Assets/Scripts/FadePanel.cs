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
	public GameObject container;
	protected Canvas containerCanvas;

	void Start () {
		
		//Get Canvas component from target
		containerCanvas = transform.GetComponent<Canvas> ();
		//Place target behind the scene
		containerCanvas.sortingOrder = 1;

		//Set panel and bg Alpha = 0
		//panel.GetComponent<CanvasRenderer>().SetAlpha(0f);
		background.GetComponent<CanvasRenderer>().SetAlpha(0f);

		//Set for each panel's child Alpha = 0
	/**	childrenCanvas = panel.GetComponentsInChildren<CanvasRenderer>();
		foreach (CanvasRenderer child in childrenCanvas) {
			child.SetAlpha(0f);
		}
	*/	

		//Get Graphic component in panel's children (Images and Texts)
		childrenImage = panel.GetComponentsInChildren<Graphic>();
	}


	public void ShowPanel() {
		containerCanvas.sortingOrder = 3;
		background.GetComponent<CanvasRenderer>().SetAlpha(0f);

		panel.CrossFadeAlpha (1f, .3f, false);
		background.CrossFadeAlpha (0.4f, 0.3f, false);

		foreach (Graphic child in childrenImage) {
			child.CrossFadeAlpha(1f, .3f, false);
		}
	}

	public void HidePanel() {

		//Put target behind the scene
		containerCanvas.sortingOrder = 1;

		//Fade panel and bg color to 0
		panel.CrossFadeAlpha (0f, .3f, false);
		background.CrossFadeAlpha (0f, .3f, false);

		//Fade alpha for each panel's child
		foreach (Graphic child in childrenImage) {
			child.CrossFadeAlpha (0f, .3f, false);
		}

		//panel.GetComponent<CanvasRenderer>().SetAlpha(0);
	}


}
