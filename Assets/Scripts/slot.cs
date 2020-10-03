using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slot : MonoBehaviour
{
    private GameObject m_Player;
    private GameObject m_onHand;
    private GameObject m_Wall;
    private List<GameObject> m_puzzleSlot;

    private bool m_pickedUp = false;

    // Start is called before the first frame update
    void Start()
    {

        //Initializing GameObjects
        m_Player = GameObject.FindGameObjectWithTag("Player");
        m_onHand = GameObject.FindGameObjectWithTag("OnHandPosition");
        m_Wall = GameObject.Find("Wall");
 
        m_puzzleSlot = new List<GameObject>(4);
        m_puzzleSlot.Add(GameObject.Find("Slot001"));
        m_puzzleSlot.Add(GameObject.Find("Slot002"));
        m_puzzleSlot.Add(GameObject.Find("Slot003"));
        m_puzzleSlot.Add(GameObject.Find("Slot004"));        
    }

    // Update is called once per frame
    void Update()
    {
        //Local Variables
        float distance_block;
        float distance_wall;
 
        //Initializing distances
        distance_block = Vector3.Distance(m_Player.transform.position, transform.position);
        distance_wall = Vector3.Distance(m_Player.transform.position, m_Wall.transform.position);
 
        //Pickup item Handler
        if (Input.GetButtonDown("Fire3") && distance_block < 3)
        {
            m_pickedUp = !m_pickedUp;
        }
 
        if (m_pickedUp)
        {
            GetComponent<Rigidbody>().useGravity = false;
            transform.position = m_onHand.transform.position;
 
            if (Input.GetButtonDown("PlaceBlock"))
            {
                float shortestDistance = float.MaxValue;
                GameObject closestEmpty = null;
 
                for(int i = 0; i < m_puzzleSlot.Count; i++)
                {
                    float dist = Vector3.Distance(transform.position, m_puzzleSlot[i].transform.position);
 
                    if( dist < shortestDistance)
                    {
                        //check if it's already occupied
                        shortestDistance = dist;
                        closestEmpty = m_puzzleSlot[i];                    
                        //end check if occupied
                    }
                }
                m_pickedUp = false;
                transform.position = closestEmpty.transform.position;
            }
        }
        else
        {
            GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
