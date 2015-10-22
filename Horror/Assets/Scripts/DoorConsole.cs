using UnityEngine;
using System.Collections;

public class DoorConsole : UseObject
{
    [SerializeField] private Animator Door;

	void Start () 
    {

	}
	
	void Update () 
    {

	}

    public void Use()
    {
        if (Door)
        {
            Door.SetTrigger("Open/Close");
        }
    }
}
