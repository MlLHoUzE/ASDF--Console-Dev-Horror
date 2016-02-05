using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class Explosion : MonoBehaviour {
	public float radius = 5.0f;
	public float power = 10.0f;
    public GameObject victoryCanvas;
    public GameObject yourControl;
    public EventSystem eventSystem;
	private GameObject[] parts;

    private float tick;
	// Use this for initialization
	void OnEnable () {
		Debug.Log ("debug");
		parts = GameObject.FindGameObjectsWithTag ("Explode");
		for (int i=0; i<parts.Length; i++)
		{
			parts[i].AddComponent<BoxCollider>();
			parts[i].AddComponent<Rigidbody>();
			parts[i].GetComponent<Rigidbody>().useGravity = false;
		}
		parts = GameObject.FindGameObjectsWithTag ("Obstacle");
		for (int i=0; i<parts.Length; i++)
		{
			parts[i].AddComponent<BoxCollider>();
			parts[i].AddComponent<Rigidbody>();
			parts[i].GetComponent<Rigidbody>().useGravity = false;
		}
		
		Vector3 explosionPos = transform.position;
		Collider[] colliders = Physics.OverlapSphere (explosionPos, radius);
		foreach (Collider hit in colliders) {
			Rigidbody rb = hit.GetComponent<Rigidbody> ();
			
			if (rb != null)
				rb.AddExplosionForce (power, explosionPos, radius, 3.0F);
		}
	}
	
	// Update is called once per frame
	void Update () {
        tick += Time.deltaTime;

        if(tick > 4)
        {
            eventSystem.SetSelectedGameObject(yourControl);
            victoryCanvas.SetActive(true);
        }
	}
}
