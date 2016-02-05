using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class HelpMenuSelector : MonoBehaviour
{
    public EventSystem eventManager;
    public GameObject yourControl;



    void OnEnable()
    {

        eventManager.SetSelectedGameObject(yourControl);

    }


}
