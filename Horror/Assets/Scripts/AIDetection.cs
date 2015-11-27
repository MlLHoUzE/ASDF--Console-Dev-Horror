using UnityEngine;
using System.Collections;

public class AIDetection : MonoBehaviour {
    public DynamicWaypointSeek enemyAI;
    public GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        //Vector3 rightRay = transform.TransformPoint(Vector3.right * -0.25F);
        if (Physics.Raycast(transform.parent.position + Vector3.up * 1.5f,  player.transform.position - transform.parent.position, out hit))
        {
            Debug.DrawRay(transform.parent.position + Vector3.up * 1.5f, player.transform.position - transform.parent.position, Color.red);
            if (hit.transform.gameObject.tag != "Player")
            {
                enemyAI.playerInSight = false;
                enemyAI.hasTarget = true;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("detected");
            player = other.gameObject;
            enemyAI.playerInSight = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //enemyAI.playerInSight = false;

        }
    }
}
