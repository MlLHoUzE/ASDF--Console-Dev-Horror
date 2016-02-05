using UnityEngine;
using System.Collections;

public class Doors : MonoBehaviour {

	public GameObject trigger;
	public Animator animator;
	bool doorOpen;
	// Use this for initialization
	void Start () {
		doorOpen = false;
		//animator = GetComponent<Animator> ();
	}
	
	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Player") {
			doorOpen = true;
			DoorControl ("Open");

		}
	}
	
	void OnTriggerExit(Collider col)
	{
		if (doorOpen && col.gameObject.tag == "Player") {
			doorOpen = false;
			DoorControl ("Close");
		}
	}
	
	
	void DoorControl(string Direction)
	{
		animator.SetTrigger(Direction);
	}
	// Update is called once per frame
	void Update () {
		
	}
}
