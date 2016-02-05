using UnityEngine;
using System.Collections;

public class countyflame : MonoBehaviour {
	public GameObject fires;
	// Use this for initialization
	void Start () {
		fires.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Player" && Timer.countyflamer == true) {
			Debug.Log("flames");
			fires.SetActive(true);
		}
	}
}
