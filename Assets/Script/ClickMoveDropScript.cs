using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMoveDropScript : MonoBehaviour {

    public bool moveableObjectGrabbled = false;

    Ray moRay;
    public Transform moTransform;
    public LayerMask whatIsMoveableObject;
    RaycastHit moHit;

    public LayerMask whatIsGround;
    public Transform ground;
    RaycastHit groundHit;

    public Transform mousePosMarket;
    RaycastHit mousePosHit;
    public float moYOffsetFromGround = 0f;
    public float mousePosYOffsetFromGround = 0f;
    public Vector3 mousePosRelToGround;

	// Use this for initialization
	void Start () {
        moHit = new RaycastHit();
        groundHit = new RaycastHit();
        mousePosMarket.gameObject.SetActive(false);
	}

    // Update is called once per frame
    void Update() {
        moRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            FindAndGrabMoveableObject();
        }
        if(Input.GetMouseButtonUp(0))
        {
            DropMoveableObject();
        }

        moveableObjectGrabbled = moTransform != null;
        mousePosMarket.gameObject.SetActive(moveableObjectGrabbled);

		//FirebaseAnalytic.Instance().logEvent();

        if(moveableObjectGrabbled)
        {
            TraceMousePosRelativeToGround();
        }
	}

    void FindAndGrabMoveableObject()
    {
        if(Physics.Raycast(
            moRay,
            out moHit,
            Mathf.Infinity,
            whatIsMoveableObject))
        {
            moTransform = moHit.transform;
            moTransform.GetComponent<Rigidbody>().isKinematic = true;
            FindGroundBelowMoveableObject();
        }
    }

    void FindGroundBelowMoveableObject()
    {
        if (Physics.Raycast(
            moTransform.position,
            Vector3.down,
            out groundHit,
            Mathf.Infinity,
            whatIsGround))
        {
            ground = groundHit.transform;
        }
    }

    void TraceMousePosRelativeToGround()
    {
        if (Physics.Raycast(
            moRay,
            out mousePosHit,
            Mathf.Infinity,
            whatIsGround))
        {
            mousePosRelToGround = mousePosHit.point;
            moTransform.position = new Vector3(
                mousePosRelToGround.x,
                mousePosRelToGround.y + moYOffsetFromGround,
                mousePosRelToGround.z);
            mousePosMarket.position = new Vector3(
                mousePosRelToGround.x,
                mousePosRelToGround.y + mousePosYOffsetFromGround,
                mousePosRelToGround.z);
        }
    }

    void DropMoveableObject()
    {
        if (moTransform != null)
            moTransform.GetComponent<Rigidbody>().isKinematic = false;
        moTransform = null;
        ground = null;
    }
}
