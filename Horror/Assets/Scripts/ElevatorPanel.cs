using UnityEngine;
using System.Collections;

public class ElevatorPanel : MonoBehaviour {

	public GameObject panelcanvas;
	public GameObject panelcanvasText;


    // Use this for initialization
    void Start () {
		panelcanvas.SetActive (false);
		panelcanvasText.SetActive (false);
    }
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter(Collider col)
	{
        if (col.gameObject.tag == "Player")
        {
            if (GameObject.FindGameObjectWithTag("panel"))
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                panelcanvas.SetActive(true);
                panelcanvasText.SetActive(true);
                Time.timeScale = 0;

            }
        }

	}
	/*void OnTriggerStay(Collider col)
	{
		if (col.gameObject.tag == "Player")
		{
			if (GameObject.FindGameObjectWithTag("panel"))
			{
				Cursor.visible = true;
				Cursor.lockState = CursorLockMode.None;
				panelcanvas.SetActive(true);
				panelcanvasText.SetActive(true);
				Time.timeScale = 0;
				
			}
		}

	}*/

	//void OnTriggerExit(Collider col)
	//{
	//	if (GameObject.FindGameObjectWithTag("panel"))
	//	{
	//		Cursor.visible = false;
	//		Cursor.lockState = CursorLockMode.Locked;  
	//		panelcanvas.SetActive(false);

	//	}
		
	//}
}
