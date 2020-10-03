using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Move_object : MonoBehaviour
{
    private bool started;
    private Vector3 startPoint;
    private Vector3 endPoint;
    private Vector3 targetPos;
    private float startTime;

    // Use this for initialization
    void Start()
    {
        startPoint = transform.position;
        endPoint = new Vector3(15.0f, 3.0f, 0.0f);
        startTime = Time.time;
        started = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            MoveTowardClick();
        }
    }

    private void MoveTowardClick()
    {

        if (!started)
        {
            Ray r1 = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(r1, out hit, Mathf.Infinity))
            {
                if (targetPos != hit.point)
                {
                    targetPos = hit.point;
                }
            }
        }
    }
}