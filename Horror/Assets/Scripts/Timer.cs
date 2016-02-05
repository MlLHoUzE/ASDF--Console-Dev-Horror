using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {
	public string timer;
	public float minutes = 3;
	public float seconds = 0;
	public Text countText;
	public GameObject TimerText;
	bool county = false;
	public static bool countyflamer = false;
	public GameObject flames;
	
	float miliseconds = 0;

	// Use this for initialization
	void Start () {
		flames.SetActive (false);
	}
	
	// Update is called once per frame

		
	void awake()
	{
			countText = TimerText.GetComponentInChildren<Text> ();
		}
		void Update(){

		if (county == true) {

			if (miliseconds <= 0) {
				if (seconds <= 0) {
					minutes--;
					seconds = 59;
				} else if (seconds >= 0) {
					seconds--;
				}
				
				miliseconds = 100;
			}
			
			
			miliseconds -= Time.deltaTime * 100;
			
			timer = string.Format ("{0}:{1}", minutes, (int)seconds);
			countText.text = "Time: " + timer;
			
			if (minutes == 0 && seconds == 0) {
				Cursor.visible = true;
				Cursor.lockState = CursorLockMode.None;
				Application.LoadLevel ("finishscene");

			}
		}
	}
		



	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Player") {
			county = true;
			countyflamer = true;
			flames.SetActive(true);
		}
	}
}
