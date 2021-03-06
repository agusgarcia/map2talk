﻿using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent (typeof(Button))]
public class ScrollButtons : MonoBehaviour
{

	public Scrollbar Target;
	public Button TheOtherButton;
	public float Step = 0.1f;

	public void Start() {
		GetComponent<Button> ().interactable = Target.value != 0;
	}


	public void Increment ()
	{
		if (Target == null || TheOtherButton == null) {
			throw new Exception ("Setup ScrollbarIncrementer");
		}
		Target.value = Mathf.Clamp (Target.value + Step, 0, 1);
		GetComponent<Button> ().interactable = true;
		TheOtherButton.interactable = Target.value != 1;
	}
		
	public void Decrement ()
	{
		if (Target == null || TheOtherButton == null) {
			throw new Exception ("Setup ScrollbarIncrementer");
		}
		Target.value = Mathf.Clamp (Target.value - Step, 0, 1);
		GetComponent<Button> ().interactable = Target.value != 0;
		TheOtherButton.interactable = true;
	}


}
