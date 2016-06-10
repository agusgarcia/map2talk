using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent (typeof(Button))]
public class SlideTraveller : MonoBehaviour
{

	public Scrollbar Target;
	public Button TheOtherButton;
	public Transform content_1;
	public Transform content_2;

	private float step;
	public float speed;

	//For content_1 
	private bool keepMoving_1 = false;
	private Vector3 newPosition_1;

	//For content_2
	private bool keepMoving_2 = false;
	private Vector3 newPosition_2;


	public void Update() {


		//Content_1
		if (keepMoving_1) {
			step = speed * Time.deltaTime;

			//Move content towards its new position
			content_1.transform.position = Vector3.MoveTowards (content_1.transform.position, new Vector3(newPosition_1.x, content_1.transform.position.y, 
				content_1.transform.position.z), step);

			//Debug.Log (content.transform.position.x +" / "+ newPosition.x);

			if (Math.Abs(content_1.transform.position.x - newPosition_1.x) <= 1.5) {
				keepMoving_1 = false;
				Debug.Log (keepMoving_1);
			}
		}

		//Content_2
		if (keepMoving_2) {
			step = speed * Time.deltaTime;

			//Move content towards its new position
			content_2.transform.position = Vector3.MoveTowards (content_2.transform.position, new Vector3(newPosition_2.x, content_2.transform.position.y, 
				content_2.transform.position.z), step);

			//Debug.Log (content.transform.position.x +" / "+ newPosition.x);

			if (Math.Abs(content_2.transform.position.x - newPosition_2.x) <= 1) {
				keepMoving_2 = false;
				Debug.Log (keepMoving_2);
			}
		}
	}
		

	//TODO : Do Decrement() + both coroutines !


	public void MoveFirstContent (float value) {

		newPosition_1.x = content_1.position.x + value;
		newPosition_1.y = content_1.position.y;
		newPosition_1.z = content_1.position.z;

		if (content_1.transform.position != newPosition_1) {
			keepMoving_1 = true;
		} 	
	}

	public void Increment ()
	{

		MoveFirstContent(-400);
		
		StartCoroutine (MoveSecondContent (0.15f, -400));

		/*	if (Target == null || TheOtherButton == null)
			throw new Exception ("Setup ScrollbarIncrementer");
		Target.value = Mathf.Clamp (Target.value + Step, 0, 1);
		GetComponent<Button> ().interactable = Target.value != 1;
		TheOtherButton.interactable = true;
		
		print ("Starting " + Time.time);
		StartCoroutine (WaitAndPrint (2.0F));
		print ("Before WaitAndPrint Finishes " + Time.time);

		*/		
	}

	IEnumerator MoveSecondContent (float waitTime, float value)
	{
		yield return new WaitForSeconds (waitTime);
		print ("WaitAndPrint " + Time.time);
		newPosition_2.x = content_2.position.x + value;
		newPosition_2.y = content_2.position.y;
		newPosition_2.z = content_2.position.z;

		Debug.Log ("1-2 ! " + content_2.transform.position);

		if (content_2.transform.position != newPosition_2) {
			keepMoving_2 = true;
		} 
	}	

	IEnumerator WaitAndPrint2 (float waitTime)
	{
		yield return new WaitForSeconds (waitTime);
		print ("WaitAndPrint " + Time.time);
	/*	newPosition.x = content2.position.x + 300;
		newPosition.y = content2.position.y;
		newPosition.z = content2.position.z;

		content2.transform.position = newPosition;
*/
	}


	public void Decrement ()
	{
		MoveFirstContent(400);
		StartCoroutine (MoveSecondContent (0.15f, 400));

		/*	if (Target == null || TheOtherButton == null)
			throw new Exception ("Setup ScrollbarIncrementer");
		Target.value = Mathf.Clamp (Target.value - Step, 0, 1);
		GetComponent<Button> ().interactable = Target.value != 0;
		TheOtherButton.interactable = true;
		*/
	}


}
