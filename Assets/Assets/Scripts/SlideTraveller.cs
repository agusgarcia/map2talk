using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent (typeof(Button))]
public class SlideTraveller : MonoBehaviour {

	//public Scrollbar Target;
	//public Button TheOtherButton;
	public Transform content_1;
	public Transform content_2;

	private float step;
	public float speed;
	//Tablet = 2000 // Unity = 500
	public float distance = 400;
	//Tablet = 1150 // Unity = 220
  
	//For content_1
	private bool keepMoving_1 = false;
	private Vector3 newPosition_1;

	//For content_2
	private bool keepMoving_2 = false;
	private Vector3 newPosition_2;

	private int nbChildren;
	private int counter;



	public void Start () {
		nbChildren = content_1.transform.childCount;
	}

	public void Update () {

	/**	
	//Test if content can keep moving depending on its position

	  if ((Math.Abs (content_1.transform.position.x - startPosition) <= 1) & (newPosition_1.x >= startPosition)) {
			keepMoving_1 = false;
			StartCoroutine (StopSecondContent ());
		}
	*/		

	/**	//Content_1
		if (keepMoving_1) {

			//Move according to time
			step = speed * Time.deltaTime;

			//Move content towards its new position
			content_1.transform.position = Vector3.MoveTowards (content_1.transform.position, new Vector3 (newPosition_1.x, content_1.transform.position.y, 
				content_1.transform.position.z), step);

			//If content position is (almost) equal to the new position, stop moving
			if (Math.Abs (content_1.transform.position.x - newPosition_1.x) <= 1) {
				keepMoving_1 = false;
			}
		}
		//Content_2
		if (keepMoving_2) {
			step = speed * Time.deltaTime;
			content_2.transform.position = Vector3.MoveTowards (content_2.transform.position, new Vector3 (newPosition_2.x, content_2.transform.position.y, content_2.transform.position.z), step);

			if (Math.Abs (content_2.transform.position.x - newPosition_2.x) <= 1) {
				keepMoving_2 = false;
			}
		}
		*/

		if (keepMoving_1) {
			TestKeepMoving (content_1, newPosition_1, keepMoving_1);
		}

		if (keepMoving_2) {
			TestKeepMoving (content_2, newPosition_2, keepMoving_2);
		}

	}

	public void Increment () {

		//Test if the content has shown all its components (its children)
		//If it hasn't, move
		if (counter < nbChildren-1) {
			counter += 1;
			MoveFirstContent (-distance);
			StartCoroutine (MoveSecondContent (-distance));
		}
	}

	public void Decrement () {
		
		//Test if the content is at its start position
		//If it isn't, move
		if (counter > 0) {
			counter -= 1;
			MoveFirstContent (distance);
			StartCoroutine (MoveSecondContent (distance));
		}
	}

	public void MoveFirstContent (float value) {

		//Calculate de new position according to the distance value
		newPosition_1.x = content_1.position.x + value;
		newPosition_1.y = content_1.position.y;
		newPosition_1.z = content_1.position.z;

		keepMoving_1 = true;

		//Turn keepMoving boolean to true when there's a new position
	//	if (content_1.transform.position != newPosition_1) {
	//	} 	
	}

	IEnumerator MoveSecondContent (float value) {
		yield return new WaitForSeconds (0.12f);
		newPosition_2.x = content_2.position.x + value;
		newPosition_2.y = content_2.position.y;
		newPosition_2.z = content_2.position.z;

		keepMoving_2 = true;
		/**
		if (content_2.transform.position != newPosition_2) {
		} */
	}

	public void TestKeepMoving (Transform content, Vector3 newPosition, bool keepMoving) {

		//Move according to time
		step = speed * Time.deltaTime;

		//Move content towards its new position
		content.transform.position = Vector3.MoveTowards (content.transform.position, new Vector3 (newPosition.x, content.transform.position.y, 
			content.transform.position.z), step);

		//If content position is (almost) equal to the new position, stop moving
		if (Math.Abs (content.transform.position.x - newPosition.x) <= 1) {
			keepMoving = false;
		}
	}
	
}