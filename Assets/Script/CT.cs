using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CT : MonoBehaviour {

	public float movespeed = 1.0f;
	public Vector2 xCon;
	public Vector2 yCon;
	Vector2 wantaBePos;
	
	// Update is called once per frame
	void Update () {
		wantaBePos += new Vector2 (Input.GetAxis ("Horizontal") * movespeed * Time.deltaTime, Input.GetAxis ("Vertical") * movespeed * Time.deltaTime);
		transform.position = new Vector3 (Mathf.Clamp (wantaBePos.x, xCon.x, xCon.y), Mathf.Clamp (wantaBePos.y, yCon.x, yCon.y), transform.position.z);

		if (wantaBePos.x < xCon.x) {
			wantaBePos = new Vector2 (xCon.x, wantaBePos.y);
		}
		if (wantaBePos.x > xCon.y) {
			wantaBePos = new Vector2 (xCon.y, wantaBePos.y);
		}
		if (wantaBePos.y < yCon.x) {
			wantaBePos = new Vector2 (wantaBePos.x, yCon.x);
		}
		if (wantaBePos.y < yCon.y) {
			wantaBePos = new Vector2 (wantaBePos.x, yCon.y);
		}
	}
}
