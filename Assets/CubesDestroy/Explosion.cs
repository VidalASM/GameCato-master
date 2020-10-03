using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Explosion : MonoBehaviour
{
    public GameObject cube;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "floor")
            Explode();
        
        //explode();
    }
    public void Explode()
    {   
        cube.transform.gameObject.SetActive(false);
        //CreatePiece();
    }

    void CreatePiece()
    {
        GameObject piece;
        piece = GameObject.CreatePrimitive(PrimitiveType.Cube);

        piece.transform.position = transform.position;
        piece.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);

        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = 0.2f;
    }

}
