using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
//using System.Diagnostics;
using UnityEngine.Networking;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class DragTransform : MonoBehaviour
{
    // GameObject myEventSystem;
    public Transform[] rings;
    private Vector3[] locations;
    private int occupied;
    // private Color mouseOverColor = Color.blue;
    // private Color originalColor = Color.yellow;
    private bool dragging = false;
    private float distance; 
    // public Vector3 slot_pos;
    public int TextScore;
    public GameObject Stand;
    public GameObject StandBase;
    public GameObject TextCalification;
    public Button TextResult;
    public float PosDifOrigin;
    public float PosDistance;
    
    public float timeStart;
    // public Text textBox;    // Timer Text
    bool timerActive = true;

    private float starttime, endtime;
    int score = 0;
	public Text textshowed = null;  // Score Text

	public void changeWord (string word) {
		textshowed.text = word;
	}

    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.Landscape;
        // textBox.text = timeStart.ToString("F2");
        locations = new Vector3[rings.Length];
        occupied = 0;
		float Origin = StandBase.transform.position.y - PosDifOrigin;
		for (int i = 0; i < rings.Length; i++)
		{
			locations[i] = new Vector3(Stand.transform.position.x, Origin + ((i + 1) * PosDistance), 0f);
		}
    }
   
    void OnMouseEnter()
    {
        // GetComponent<Renderer>().material.color = mouseOverColor;
    }
 
    void OnMouseExit()
    {
        // GetComponent<Renderer>().material.color = originalColor;
    }
 
    void OnMouseDown()
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;
    }
 
    void OnMouseUp()
    {
        dragging = false;
    }

    void OnEnable()
    {
        //Register Button Events
        TextResult.onClick.AddListener(() => buttonCallBack(TextResult));
    }

    private void buttonCallBack(Button buttonPressed)
    {
        if (buttonPressed == TextResult)
        {
            //Your code for button 1
            // Debug.Log("Clicked: " + TextResult.name);
            TextResult.gameObject.SetActive(false);
        }
    }

    void OnDisable()
    {
        //Un-Register Button Events
        TextResult.onClick.RemoveAllListeners();
    }

    public bool IsWithin(float value, float objetive, float variation)
    {
        float minimum = objetive - variation;
        float maximum = objetive + variation;
        return value >= minimum && value <= maximum;
    }
 
    void Update()
    {
        // myEventSystem = GameObject.Find("EventSystem");
        // Time execution
        timeStart += Time.deltaTime;
        // textBox.text = timeStart.ToString("F2");
        // Calification Status
        if (score == TextScore)
        {
            TextCalification.SetActive(true);
            // TextResult.gameObject.SetActive(true);
        }
        // Debug.Log(myEventSystem.name);
        // Score update
        if (Input.GetMouseButtonDown (0))
            starttime = Time.time;
        if (Input.GetMouseButtonUp (0))
            endtime = Time.time;
        if (endtime - starttime > 0.5f) {
            score++;
            // Debug.Log ("Long click");
            changeWord (score.ToString());
            starttime = 0f;
            endtime = 0f;
        }
        if (dragging)
        {
            // Debug.Log("Posiciones: " + Stand.transform.position.x + ", " + Stand.transform.position.y);
            // Debug.Log("Posiciones: " + StandBase.transform.position.x + ", " + StandBase.transform.position.y);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            transform.position = rayPoint;
            transform.position = new Vector3(transform.position.x, transform.position.y, 0f);

            // Comparacion de ubicaciones
            float xPos = transform.position.x;
            float yPos = transform.position.y;

            occupied = 0;
            for (int i = 0; i < locations.Length; i++)
            {
                if (i == occupied)
                {
                    for (int j = 0; j < rings.Length; j++)
                    {
                        if (rings[j].position == locations[i])
                        {
                            occupied = occupied + 1;
                            break;
                        }
                    }
                }
            }
            if (IsWithin(xPos, Stand.transform.position.x, 1f))
            {
                // Debug.Log("Esta en el rango");
                // for (int i = 1; i <= TextScore; i++)
                // {
                //     float Origin = StandBase.transform.position.y - PosDifOrigin;
                //     if (IsWithin(yPos, Origin + (i * PosDistance), 0.5f))
                //     {
                //         transform.position = new Vector3(Stand.transform.position.x, Origin + (i * PosDistance), 0f);
                //     }
                // }
                float Origin = StandBase.transform.position.y - PosDifOrigin;
                transform.position = new Vector3(Stand.transform.position.x, Origin + ((occupied + 1) * PosDistance), 0f);
                // EventSystem.current.SetSelectedGameObject(null);
            }

            // if (transform.position.x >= -4.5f && transform.position.x <= -3.55f)
            // {
            //     Debug.Log("X: " + transform.position.x);
            //     Debug.Log(slot_pos);
            //     if(slot_pos.x == 0.0 && slot_pos.y == 0.0 && slot_pos.z == 0.0)
            //     {
            //         Debug.Log(slot_pos);
            //         transform.position = new Vector3(-4f, -3.15f, 0f);
            //     }
            //     if(slot_pos.x == -4.0 && slot_pos.y == -3.2 && slot_pos.z == 0.0)
            //     {
            //         Debug.Log(slot_pos);
            //         transform.position = new Vector3(-4f, -1.5f, 0f);
            //     }
            //     if(Physics.Raycast(transform.position,new Vector3(-4f, -3.15f, 0f),1) == false)
            //     {
            //         slot_pos = new Vector3(-4f, -3.15f, 0f);
            //     }
            // }
        }
        
        // WWWForm form = new WWWForm();
        // //Debug.Log("Uploaddddddd");
        // form.AddField("usuario", "demo");
        // form.AddField("juego", "demo");
        // form.AddField("nivel",  "1");
        // // form.AddField("tiempo", textBox.ToString());
        // form.AddField("scores", textshowed.ToString());
        // // form.AddField("dificultad", "1");
        // form.AddField("grado", "1");

        // Debug.Log("DATOS");
        // Debug.Log(form);
        // Debug.Log("Uploaddddddd", form);
        // String url = "https://herokudjangoappaqp.herokuapp.com/api/agregar/";
        // UnityWebRequest.Post(String url, List<IMultipartFormSection> formSections);
    }

    public void timerButton()
    {
        timerActive = !timerActive;
    }
}