using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
	private int count;
	private float timer;
	private TextMesh countText;
	private bool hasStarted;
	public string textName;
	public int timeLimit;
	public GameObject door;


    Transform player;
    UnityEngine.AI.NavMeshAgent nav;

	void Start () 
	{
		count = timeLimit;
		timer = timeLimit;
		hasStarted = false;
		countText = GameObject.Find(textName).GetComponent<TextMesh>();
		SetCountText ();
	}

    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player").transform;
        nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
    }


    void Update ()
    {
		timer -= Time.deltaTime;
		count = (int)timer;

		if (count >= 0) {
			SetCountText ();
		} else if (!hasStarted) {
			door.transform.Rotate (new Vector3 (0, 90, 0));
			hasStarted = true;
		}

		if (hasStarted) {
			nav.SetDestination (player.position * 0.5f);
			countText.gameObject.SetActive(false);
		}
    }

	void SetCountText ()
	{
		countText.text = count.ToString ();
	}
}
