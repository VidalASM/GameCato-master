using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Drag : MonoBehaviour
{
	public static event Action PuzzleDone = delegate {};

	[SerializeField]
	private Transform standPosition;
	private Vector3 initialPosition;
	private Renderer rend;
	private float deltaX, deltaY;
	private bool moveAlowed;
	private bool locked;

	private Vector3 mOffset;
	private float mZCoord;

    // Start is called before the first frame update
    void Start()
    {
		initialPosition = transform.position;
		rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.touchCount > 0 && !locked)
		{
			Touch touch = Input.GetTouch(0);
			Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

			switch (touch.phase)
			{
			case TouchPhase.Began:
				if (GetComponent<Collider>() == Physics2D.OverlapPoint(touchPos))
				{
					moveAlowed = true;
					rend.sortingOrder = 3;
					deltaX = touchPos.x - transform.position.x;
					deltaY = touchPos.y - transform.position.y;
				}

				break;
			
			case TouchPhase.Moved:
				if (moveAlowed)
					transform.position = new Vector3(touchPos.x - deltaX, touchPos.y - deltaY, 0f);

				break;

			case TouchPhase.Ended:
				moveAlowed = false;
				rend.sortingOrder = 2;
				if (Mathf.Abs(transform.position.x - standPosition.position.x) <= 1f && 
					Mathf.Abs(transform.position.y - standPosition.position.y) <= 5f)
				{
					switch (PyramidControl.slotsOccupied)
					{
					case 0:
						transform.position = new Vector3(standPosition.position.x, -3.15f, 0f);
						PyramidControl.slotsOccupied = 1;
						break;
					case 1:
						transform.position = new Vector3(standPosition.position.x, -1.5f, 0f);
						PyramidControl.slotsOccupied = 2;
						break;
					case 2:
						transform.position = new Vector3(standPosition.position.x, 0.15f, 0f);
						PyramidControl.slotsOccupied = 3;
						break;
					case 3:
						transform.position = new Vector3(standPosition.position.x, 1.7f, 0f);
						PuzzleDone();
						break;
					}

					locked = true;
				}

				else
					transform.position = new Vector2(initialPosition.x, initialPosition.y);

				break;
			}
		}
    }

	void OnMouseDown()
	{
		mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
		mOffset = gameObject.transform.position - GetMouseWorldPos();
	}

	private Vector3 GetMouseWorldPos()
	{
		Vector3 mousePoint = Input.mousePosition;
		mousePoint.z = mZCoord;
		return Camera.main.ScreenToWorldPoint(mousePoint);
	}

	void OnMouseDrag()
	{
		transform.position = GetMouseWorldPos() + mOffset;
	}
}
