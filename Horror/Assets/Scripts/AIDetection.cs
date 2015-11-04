using UnityEngine;
using System.Collections;

public class AIDetection : MonoBehaviour {
    public DynamicWaypointSeek enemyAI;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("detected");
            enemyAI.playerInSight = true;
        }
    }
}
