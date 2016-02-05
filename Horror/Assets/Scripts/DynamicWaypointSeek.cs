﻿using UnityEngine;
using System.Collections;

public class DynamicWaypointSeek : MonoBehaviour {
	public Camera sourceCam;
	public GameObject targetObj;
    private GameObject player;
		
	public float slowDistPerc; // Percentage of distance away from target location to toggle slow down.
	private float slowDist;
	public float stopDist;
	public float slowRotPerc; // Percentage of rotation away from target rotation to toggle slow down.
	private float slowRot;
	private float rotLeft; // Rotation remaining to destination rotation.
    public float waitTime;
	
	private float velocity = 0.0F; // Linear velocity.
	private float rotation = 0.0F; // Angular velocity.
	public float velocityMax;
	public float rotationMax;
	private float accelLinear;
	private float accelAngular;
	public float accelLinearInc;
	public float accelAngularInc;
	public float accelLinearMax;
	public float accelAngularMax;
    public bool atWP = false;
		
	public bool hasTarget = false;
    public bool hasObstacle = false;
	
	private Vector3 moveTarget;
    private Vector3 avoidTarget;
	private Vector3 destVect;
    private Vector3 avoidVect;
	private Quaternion destRot;
	private float distTo;
	
	private int wpIndex = 0;
	public GameObject[] waypoints;
	public bool stopAtLastWP;

    public bool playerInSight = false;
	
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
		//waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
		//System.Array.Reverse(waypoints);
		moveTarget = waypoints[ wpIndex ].transform.position;
		targetObj.transform.position = moveTarget;
		hasTarget = true;
		StartMoving();
	}
	
	void Update () {

        if (playerInSight)
        {
			//GetComponent<Animation>().Play("creature1Attack1", PlayMode.StopAll);
            moveTarget = player.transform.position;
            targetObj.transform.position = moveTarget;
            hasTarget = false;
            destVect = moveTarget - transform.position;
            if(hasObstacle)
            {
                avoidVect = transform.position - avoidTarget;
                float avoidDist = Vector3.Distance(transform.position, moveTarget);
                destRot = Quaternion.LookRotation(destVect.normalized + avoidVect.normalized);
            }
            else
            {
                destRot = Quaternion.LookRotation(destVect);
            }
            distTo = destVect.magnitude; // Vector3.Distance(transform.position, moveTarget) does the same thing.

            
            rotLeft = Quaternion.Angle(transform.rotation, destRot);

            transform.Translate(Vector3.forward * GetMoveSpeed() * Time.deltaTime);
            velocity = Mathf.Clamp(velocity + accelLinear, 0.0F, velocityMax);
            accelLinear = Mathf.Clamp(accelLinear + accelLinearInc, 0.0F, accelLinearMax);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, destRot, GetRotSpeed() * Time.deltaTime);
            rotation = Mathf.Clamp((rotation + accelAngular), 0.0F, rotationMax);
            accelAngular = Mathf.Clamp((accelAngular + accelAngularInc), 0.0F, accelAngularMax);

            transform.eulerAngles = new Vector3(0.0F, transform.eulerAngles.y, 0.0F); // Ensure no rotation on X-Z axes.

            if(distTo < 1.5)
            {
                velocity = 0;
            }
            
        }else	
		if ( hasTarget ) {
            // Set the destination vector and rotation.
            //Debug.Log(velocity);
			//GetComponent<Animation>().Play("creature1walkright", PlayMode.StopAll);
			destVect = moveTarget - transform.position;
            if (hasObstacle)
            {
                avoidVect = transform.position - avoidTarget;
                float avoidDist = Vector3.Distance(transform.position, avoidTarget);
                destRot = Quaternion.LookRotation(destVect.normalized + avoidVect.normalized);
                //distTo = destVect.magnitude; // Vector3.Distance(transform.position, moveTarget) does the same thing.
            }
            else
            {
                destRot = Quaternion.LookRotation(destVect);
            }
            distTo = destVect.magnitude;
            destRot = Quaternion.LookRotation( destVect );
			rotLeft = Quaternion.Angle(transform.rotation, destRot);
			
			transform.Translate( Vector3.forward * GetMoveSpeed() * Time.deltaTime );
			velocity = Mathf.Clamp(velocity + accelLinear, 0.0F, velocityMax);
			accelLinear = Mathf.Clamp(accelLinear + accelLinearInc, 0.0F, accelLinearMax);
					
			transform.rotation = Quaternion.RotateTowards( transform.rotation, destRot, GetRotSpeed() * Time.deltaTime );
			rotation = Mathf.Clamp((rotation + accelAngular), 0.0F, rotationMax);
			accelAngular = Mathf.Clamp((accelAngular + accelAngularInc), 0.0F, accelAngularMax);
									
			transform.eulerAngles = new Vector3( 0.0F, transform.eulerAngles.y, 0.0F ); // Ensure no rotation on X-Z axes.
			if (distTo < stopDist && stopAtLastWP && wpIndex == waypoints.Length-1) {
				hasTarget = false;
				velocity = 0.0F;
			}
			else if (distTo < stopDist) {
                atWP = true;
                velocity = 0;
			}
            if (atWP)
            {
                StartCoroutine(Wait());
                moveTarget = waypoints[wpIndex].transform.position;
                targetObj.transform.position = moveTarget;
                
                StartMoving();
            }
		}
	}
	
	void StartMoving()
	{
		accelLinear = 0.0F;
		accelAngular = 0.0F;
		rotation = 0.0F;
		
		destVect = moveTarget - transform.position;
		distTo = destVect.magnitude; // Vector3.Distance(transform.position, moveTarget) does the same thing.
		slowDist = distTo * slowDistPerc;
		
		destRot = Quaternion.LookRotation( destVect );
		rotLeft = Quaternion.Angle(transform.rotation, destRot);
		slowRot = rotLeft * slowRotPerc;
	}
	
	float GetMoveSpeed()
	{
		return ((stopAtLastWP && distTo >= slowDist)?Mathf.Lerp(0.0F, velocity, distTo/slowDist):velocity);
	}
	
	float GetRotSpeed()
	{
		return (rotLeft >= slowRot?rotation:Mathf.Lerp(0.0F, rotation, rotLeft/slowRot));
	}

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitTime);
        velocity = 1;
        wpIndex++;
        if (wpIndex > waypoints.Length - 1) wpIndex = 0;
        atWP = false;

        
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Obstacle")
        {
            hasObstacle = true;
            avoidTarget = other.transform.position;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Obstacle")
        {
            hasObstacle = false;
        }
    }

    public void findClosest()
    {
        Transform tmin = null;
        float minDist = Mathf.Infinity;
        Vector3 curentPos = transform.position;
        int i;
        for ( i= 0;i<waypoints.Length;i++)
        {
            float dist = Vector3.Distance(waypoints[i].transform.position, curentPos);
            if(dist < minDist)
            {
                tmin = waypoints[i].transform;
                minDist = dist;

            }
        }
        targetObj.transform.position = tmin.transform.position;
        wpIndex = i;
    }
}
