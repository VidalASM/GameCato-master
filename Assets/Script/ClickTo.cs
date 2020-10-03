using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickTo : MonoBehaviour {

	private NavMeshAgent mNavMeshAgent;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

		RaycastHit hit;

		if (Input.GetMouseButtonDown (0)) {
			if (Physics.Raycast(ray, out hit, 100)) {
				mNavMeshAgent.destination = hit.point;
			}
		}
		
	}
}
