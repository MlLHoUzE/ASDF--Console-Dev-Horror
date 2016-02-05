using UnityEngine;
using System.Collections;

public class BarrelFireSound : MonoBehaviour {

	public AudioClip fire;
	private AudioSource source;

	void Start(){
		source = GetComponent<AudioSource>();
	
	}
	void Update () {
		
	
		
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") {

			// Play the sound only on the trigger
			source.clip = fire;
			source.Play();
			//source.Play (flicker);
				
		
		}
	}
	void OnTriggerExit (Collider other)
	{
		if (other.gameObject.tag == "Player") {
			source.Stop ();
		}}

}
