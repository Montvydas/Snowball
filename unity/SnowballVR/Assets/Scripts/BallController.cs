using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {
	public float speed;
	private Rigidbody ball;
	private int count;
//	private TextMesh countText;
	private bool canJump;
	private float timeToJump = 0.5f;
	public GameObject explosion;
	public GameObject collectExplosion;
	public Joystick joystick;
	public Button jumpButton;

	// Use this for initialization
	void Start () 
	{
		ball = GetComponent<Rigidbody> ();
		count = 0;
//		countText = GameObject.Find("Count Text").GetComponent<TextMesh>();
//		countText.alignment = TextAlignment.Center;
//		countText.transform.position = new Vector3 (1, 15, 5);
		SetCountText ();
		canJump = true;
		jumpButton.onClick.AddListener(JumpOnClick);
	}

	// Update is called once per frame
	void Update () 
	{
		timeToJump -= Time.deltaTime;
		if ( timeToJump < 0 )
		{
			canJump = true;
		}
	}

	void JumpOnClick(){
		if ( canJump ) {
			Vector3 jumpSize = new Vector3 (0.0f, 7.0f, 0.0f);
			ball.AddForce (jumpSize, ForceMode.Impulse);
			canJump = false;
			timeToJump = 0.5f;
		}
	}

	// All physics go there
	void FixedUpdate() 
	{
		Vector3 moveVector = Vector3.zero;
		moveVector.x = Input.acceleration.y;
		moveVector.z = -Input.acceleration.x;
		if (moveVector.sqrMagnitude > 1)
			moveVector.Normalize();
		ball.AddForce (moveVector * speed * 3);

		moveVector = new Vector3(joystick.Vertical, 0.0f, -joystick.Horizontal).normalized;
//		Vector3 moveVector = (transform.right * joystick.Horizontal + transform.forward * joystick.Vertical).normalized;
//		transform.Translate(moveVector * speed);
		ball.AddForce (moveVector * speed);

//		dir *= Time.deltaTime;
//		transform.Translate(dir * speed);
//		ball.AddForce (dir * speed);

		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		moveVector = new Vector3 (moveVertical, 0.0f, -moveHorizontal);
		ball.AddForce (moveVector * speed);

		if (( Input.GetKeyDown ("space") ) && canJump) {
//		if ( jump && canJump) {
//			myAnimator.SetBool("letsJump", true );
			Vector3 jumpSize = new Vector3 (0.0f, 7.0f, 0.0f);
			ball.AddForce (jumpSize, ForceMode.Impulse);
			canJump = false;
			timeToJump = 0.5f;
//			transform.Translate(Vector3.up * 20 * Time.deltaTime, Space.World);
		}
	}

	void OnTriggerEnter(Collider other) 
	{
		canJump = true;
		if (other.gameObject.CompareTag ("Present"))
		{
			other.gameObject.SetActive (false);
			Instantiate(collectExplosion, other.transform.position, other.transform.rotation);
			count++;
			transform.localScale += new Vector3 (.2f, .2f, .2f);
			SetCountText ();
		}
		if (other.gameObject.CompareTag ("Zombie"))
		{
			ball.gameObject.SetActive (false);
			Instantiate(explosion, transform.position, transform.rotation);
//			Destroy(ball);
		}
	}

	void OnCollisionEnter (Collision other) 
	{
//		canJump = true;
	}

	void SetCountText ()
	{
		if (count >= 17) {
			Application.LoadLevel (Application.loadedLevel);
		}
//		countText.text = count.ToString ();
//		if (count >= 2)
//		{
//			countText.text = "Win!";
//		}
	}
}
