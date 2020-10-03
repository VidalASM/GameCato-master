using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;
public class EscenaLogIn : MonoBehaviour
{
    public Text userNameText;


    static public string id;
    static public string correo;

    // Start is called before the first frame update
    void Start()
    {
        userNameText.text = correo;
    }


    public void GetUserId(string userId, string correoUser)
    {

        id = userId;
        correo = correoUser;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
