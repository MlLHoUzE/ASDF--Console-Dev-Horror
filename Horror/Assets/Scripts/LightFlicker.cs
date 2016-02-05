using UnityEngine;
using System.Collections;

public class LightFlicker : MonoBehaviour {
	public Light pointLight;
	private float randomNumber;
	public AudioClip flicker;
	private AudioSource source;
	int count = 1;
	public bool enter;
	void Start(){
		source = GetComponent<AudioSource>();
		pointLight.enabled = false;
		//secondFlashingLight.enabled = false;
	}

	void Update () {
		
		randomNumber = Random.value;
		
		if (randomNumber <= 0.95f) {
			
			pointLight.enabled = true;
			// secondFlashingLight.enabled = true;
		} else {
			
			pointLight.enabled = false;
			//  secondFlashingLight.enabled = false;
			
		}
		
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") {
			enter = true;
			// Play the sound only on the trigger
			if (enter && count == 1) {
				source.PlayOneShot (flicker);
				count -= 1;
			}
		}
	}
			void OnTriggerExit (Collider other)
			{
				if (other.gameObject.tag == "Player") {
			enter = false;
			count = 1;
		}}
	
}

