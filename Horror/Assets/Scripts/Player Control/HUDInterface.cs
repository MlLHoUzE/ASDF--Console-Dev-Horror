using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDInterface : MonoBehaviour 
{
    [SerializeField] private float UseRange = 4f;
    [SerializeField] private Image Reticule;

    private Camera m_Camera;
    private GameObject m_UseObject;

	void Start () 
    {
        m_Camera = transform.GetChild(0).GetComponent<Camera>();
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

        if( Input.GetKeyDown(KeyCode.E) && ( m_UseObject != null ) )
        {
            m_UseObject.SendMessage("Use");
        }

        Debug.DrawRay(m_Camera.transform.position, m_Camera.transform.forward * UseRange);
	}
}
