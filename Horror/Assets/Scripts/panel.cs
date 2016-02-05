using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class panel : MonoBehaviour {

	Text text;
	string num1 = "-";
	string num2 = "-";
	string num3 = "-";
	string num4 = "-";
	public Animator doorOpens;
	public GameObject panelcanvas;
	public GameObject panelcanvasText;
    public EventSystem eventManager;
    public GameObject yourControl;


    void Awake()
	{
		text = GetComponent<Text> ();
	}

    void OnEnable()
    {

        eventManager.SetSelectedGameObject(yourControl);

    }

    // Use this for initialization
    void Start () {
		text = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {

		text.text = "" + num1 + num2 + num3 + num4;

	}

	public void button1()
	{
		if (num1 == "-") 
		{
			num1 = "1";
		} 
		else if (num2 == "-") 
		{
			num2 = "1";
		}
		else if (num3 == "-")
		{
			num3 = "1";
		}
		else if(num4 == "-")
		{
			num4 = "1";
		}
	}
	public void button2()
	{
		if (num1 == "-") 
		{
			num1 = "2";
		} 
		else if (num2 == "-") 
		{
			num2 = "2";
		}
		else if (num3 == "-")
		{
			num3 = "2";
		}
		else if(num4 == "-")
		{
			num4 = "2";
		}
	}
	public void button3()
	{
		if (num1 == "-") 
		{
			num1 = "3";
		} 
		else if (num2 == "-") 
		{
			num2 = "3";
		}
		else if (num3 == "-")
		{
			num3 = "3";
		}
		else if(num4 == "-")
		{
			num4 = "3";
		}
	}
	public void button4()
	{
		if (num1 == "-") 
		{
			num1 = "4";
		} 
		else if (num2 == "-") 
		{
			num2 = "4";
		}
		else if (num3 == "-")
		{
			num3 = "4";
		}
		else if(num4 == "-")
		{
			num4 = "4";
		}
	}
	public void button5()
	{
		if (num1 == "-") 
		{
			num1 = "5";
		} 
		else if (num2 == "-") 
		{
			num2 = "5";
		}
		else if (num3 == "-")
		{
			num3 = "5";
		}
		else if(num4 == "-")
		{
			num4 = "5";
		}
	}
	public void button6()
	{
		if (num1 == "-") 
		{
			num1 = "6";
		} 
		else if (num2 == "-") 
		{
			num2 = "6";
		}
		else if (num3 == "-")
		{
			num3 = "6";
		}
		else if(num4 == "-")
		{
			num4 = "6";
		}
	}
	public void button7()
	{
		if (num1 == "-") 
		{
			num1 = "7";
		} 
		else if (num2 == "-") 
		{
			num2 = "7";
		}
		else if (num3 == "-")
		{
			num3 = "7";
		}
		else if(num4 == "-")
		{
			num4 = "7";
		}
	}
	public void button8()
	{
		if (num1 == "-") 
		{
			num1 = "8";
		} 
		else if (num2 == "-") 
		{
			num2 = "8";
		}
		else if (num3 == "-")
		{
			num3 = "8";
		}
		else if(num4 == "-")
		{
			num4 = "8";
		}
	}
	public void button9()
	{
		if (num1 == "-") 
		{
			num1 = "9";
		} 
		else if (num2 == "-") 
		{
			num2 = "9";
		}
		else if (num3 == "-")
		{
			num3 = "9";
		}
		else if(num4 == "-")
		{
			num4 = "9";
		}
	}
	public void buttonEnter()
	{
        if (num1 == "0" && num2 == "6" && num3 == "1" && num4 == "0")
        {
            doorOpens.SetBool("open", true);
        }
        else
        {
            num1 = "-";
            num2 = "-";
            num3 = "-";
            num4 = "-";
        }
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        panelcanvas.SetActive(false);
        panelcanvasText.SetActive(false);
        Time.timeScale = 1;
    }
	public void button0()
	{
		if (num1 == "-") 
		{
			num1 = "0";
		} 
		else if (num2 == "-") 
		{
			num2 = "0";
		}
		else if (num3 == "-")
		{
			num3 = "0";
		}
		else if(num4 == "-")
		{
			num4 = "0";
		}
	}
	public void buttonDelete()
	{
		if (num4 != "-") 
		{
			num4 = "-";
		} 
		else if (num3 != "-") 
		{
			num3 = "-";
		}
		else if (num2 != "-")
		{
			num2 = "-";
		}
		else if(num1 != "-")
		{
			num1 = "-";
		}
	}

}
