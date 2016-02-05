using UnityEngine;
using System.Collections;

public class elevator : MonoBehaviour {
	

	public Animator elevatorUp;
	public AudioClip elev;
	private AudioSource source;

	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource>();
		//animator = GetComponent<Animator> ();
	}
	
	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Player") 
		{
			Debug.Log("yes");
			elevatorUp.SetBool ("up", true);
			source.PlayOneShot (elev);

		}
	}



	void OnTriggerExit(Collider col)
	{
		if (col.gameObject.tag == "Player") 
		{

		}
			

	}

	// Update is called once per frame
	void Update () {
		
	}
}
