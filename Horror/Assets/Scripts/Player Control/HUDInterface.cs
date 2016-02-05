using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class HUDInterface : MonoBehaviour 
{
    [SerializeField] private float UseRange = 4f;
    [SerializeField] private Image Reticule;
    [SerializeField] private Slider StaminaBar;

    private Camera m_Camera;
    private GameObject m_UseObject;
    private FirstPersonController m_CharacterController;
	public AudioClip flicker;
	private AudioSource source;
	void Start () 
    {
        m_Camera = transform.GetChild(0).GetComponent<Camera>();
        m_CharacterController = GetComponent<FirstPersonController>();
		source = GetComponent<AudioSource>();
	}

    void FixedUpdate()
    {
        RaycastHit rayHit;
        Color retCol = Reticule.color;
        if (Physics.Raycast(m_Camera.transform.position, m_Camera.transform.forward, out rayHit, UseRange))
        {
            if (rayHit.collider.GetComponent<UseObject>())
            {
                m_UseObject = rayHit.collider.gameObject;
                retCol = Color.black;
                retCol.a = (0.1f);
            }
            else
            {
                m_UseObject = null;
                retCol = Color.white;
                retCol.a = (0.1f);
            }
        }
        else
        {
            m_UseObject = null;
            retCol = Color.white;
            retCol.a = (0.1f);
        }
        Reticule.color = retCol;
    }
	
	void Update () 
    {

        if(( Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown("joystick button 0")) && ( m_UseObject != null ) )
        {

            m_UseObject.SendMessage("Use");
			source.PlayOneShot (flicker);
        }

        StaminaBar.value = m_CharacterController.m_Stamina;
	}
}
