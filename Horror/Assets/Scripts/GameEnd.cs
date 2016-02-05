using UnityEngine;
using System.Collections;

public class GameEnd : MonoBehaviour {

	public GameObject shipcamera;
	public GameObject maincamera;
	public Animator move;
	public AudioClip ship;
	public AudioClip explosion;
	private AudioSource source;
	public GameObject bigshit;
    public GameObject Timer;
	// Use this for initialization
	void Start () {
		shipcamera.SetActive (false); 
		bigshit.SetActive (false);
		source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () 
	{

		   
	}

	IEnumerator explode()
	{
		yield return new WaitForSeconds (3.6f);
		source.PlayOneShot (explosion);
		bigshit.SetActive(true);




	}
	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Player") 
		{
            Timer.SetActive(false);
			source.PlayOneShot (ship);
			maincamera.SetActive(false);
			shipcamera.SetActive(true);
			move.SetBool ("move", true);
			StartCoroutine(explode());
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;

			
			
		}
	}
}
