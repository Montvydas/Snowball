using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour {
	public GameObject player;
	private Vector3 offset;
	public Button resetButton;

	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position;
		Screen.orientation = ScreenOrientation.LandscapeLeft;
		resetButton.onClick.AddListener(ResetOnClick);
	}

	void ResetOnClick (){
		Application.LoadLevel (Application.loadedLevel);
	}

	// Update is called once per frame
	void Update () {
		transform.position = player.transform.position + offset;
	}

	void LateUpdate() {
		if (Input.GetKeyDown ("r")) {
			Application.LoadLevel (Application.loadedLevel);
		}
	}
}
