using UnityEngine;
using UnityEngine.EventSystems;

using System.Collections;

public class MenuButtonManager : MonoBehaviour {
	
	public GameObject mainmenu;
	public GameObject helpmenu;
    public EventSystem eventManager;
    public GameObject yourControl;


    // Use this for initialization
    void Start () {
		mainmenu.SetActive (true);
		helpmenu.SetActive (false);
	}

    void OnEnable()
    {

        eventManager.SetSelectedGameObject(yourControl);

    }

    public void Play()
	{

		Application.LoadLevel ("CharacterMovement");
	}
	
	public void Help()
	{
		mainmenu.SetActive (false);
		helpmenu.SetActive (true);
	}

	public void Back()
	{
		mainmenu.SetActive (true);
		helpmenu.SetActive (false);
	}
	
	public void Quit()
	{
		Application.Quit ();
	}
	

}
