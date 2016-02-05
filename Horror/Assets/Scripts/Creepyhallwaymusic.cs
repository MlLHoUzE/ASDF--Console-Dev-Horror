using UnityEngine;
using System.Collections;

public class Creepyhallwaymusic : MonoBehaviour {

	
	public AudioClip hallwayMusic;
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
			source.clip = hallwayMusic;
			source.Play();
			//source.Play (flicker);
			
			
		}
	}
	void OnTriggerExit (Collider other)
	{
		if (other.gameObject.tag == "Player") {
			source.Pause ();
		}}
}
