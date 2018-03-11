using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTimer : MonoBehaviour {
	private int count;
	private float timer;
	private TextMesh countText;
	private bool hasStarted;
	public string textName;
	public float rotation;

	// Use this for initialization
	void Start () 
	{
		count = 20;
		timer = 20f;
		hasStarted = false;
		countText = GameObject.Find(textName).GetComponent<TextMesh>();
		SetCountText ();
//		transform.Rotate (new Vector3 (0, 90, 0));
	}

	// Update is called once per frame
	void Update () 
	{
		timer -= Time.deltaTime;
		count = (int)timer;

		if (count >= 0) {
			SetCountText ();
		} else if (!hasStarted) {
			transform.Rotate (new Vector3 (0, rotation, 0));
			hasStarted = true;
		}
	}
		
	void SetCountText ()
	{
		countText.text = count.ToString ();
	}
}
