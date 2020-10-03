using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class User2
{
    public string nombre;
    public string apellido;

    public string email;


    public User2()
    {
    }

    public User2(string nombre, string apellido, string email)
    {
        this.nombre = nombre;
        this.apellido = apellido;
        this.email = email;
    }
}

public class BDScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://unitydatabase-5c183.firebaseio.com/");

        // Get the root reference location of the database.
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
        /*
        string aaa = "gaaaaaaa";
        string bbb = "gaaaaa";
        string ccc = "gaaa";


        //User2 user = new User2(aaa, bbb,ccc);
        User2 user = new User2(aaa, bbb, ccc);
        string json = JsonUtility.ToJson(user);
        string nomm = "gagaga";
        string ddd = "gaaaa@gmail";
        reference.Child("users").Child(nomm).SetRawJsonValueAsync(json);*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
