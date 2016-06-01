using UnityEngine;
using System.Collections;

namespace Vuforia {

	public class Autofocus : MonoBehaviour {

		void Start () 
		{
			VuforiaBehaviour.Instance.RegisterVuforiaStartedCallback(OnVuforiaStarted);
			VuforiaBehaviour.Instance.RegisterOnPauseCallback(OnPaused);
			Debug.Log ("start");
		}

		private void OnVuforiaStarted()
		{
			bool focusModeSet = CameraDevice.Instance.SetFocusMode( 
				CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);

			if (!focusModeSet) {
				Debug.Log ("Failed to set focus mode (unsupported mode).");
			} else {
				Debug.Log ("Ok");		
			}
		}

		private void OnPaused(bool paused)
		{
			if (!paused) // resumed
			{
				// Set again autofocus mode when app is resumed
				CameraDevice.Instance.SetFocusMode (
					CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
			}
		}
	}
}