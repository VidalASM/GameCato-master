using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
//using System.Diagnostics;
using UnityEngine.Networking;
using System;

public class Datos
{
    public string id;
    public int movimientos;
    public int tiempo;
}

public class button_manage : MonoBehaviour
{
    

    static public string ident;
    static public string grado;
    static public string aciertos;
    DatabaseReference reference;
    Datos data = new Datos();

    public Button newGameButton;
    public Button newGameButton2;
    public Button newGameButton3;
    public string newGameSceneName;
    public string newGameSceneName2;
    public string newGameSceneName3;
    public float timeStart;
    public Text timeBox;    // Timer Text
    private bool gamePaused = true;

    public string Level;
    public Text Moves;

    public Text setUser;

    public Text TextInfo;
    public GameObject BtnLink;

    // Start is called before the first frame update
    void Start()
    {
        // textBox.text = timeStart.ToString("F2");
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        TextInfo.text = "Recomendación";
        timeBox.text = timeStart.ToString("F1");
    }

    // Update is called once per frame
    void Update()
    {
        // setUser = ident;
        setUser.text = ident;
        if (ident == null) {
            setUser.text = "0 - " + aciertos;
            ident = "0";
        }
        if (grado == null) {
            grado = "1";
        }
        // Time execution
        if(gamePaused == false){
            timeStart += Time.deltaTime;
            timeBox.text = timeStart.ToString("F1");
        }
        // textBox.text = timeStart.ToString("F2");        
    }

    public void GetUserId(string userId, string userGrado)
    {
        ident = userId;
        grado = userGrado;
    }

    public void GetScore(string score)
    {
        aciertos = score;
    }

    public void GetRecommendation()
    {
        data.id = ident;
        data.movimientos = 4;
        data.tiempo = 60;
        // GuardarDatos guardarDatos = new GuardarDatos(ident, "4", "60");
        string json = JsonUtility.ToJson(data);
        // reference.Child("usersData").Child(ident).Child("Game2").Child("Nivel2").SetRawJsonValueAsync(json);

        // SceneManager.LoadScene(newGameSceneName);
        gamePaused = true;

        // Debug.Log(www.SendWebRequest());

        StartCoroutine(GetText());
        // Debug.Log("Respuesta--->");
        // Debug.Log(TextInfo.text);
        newGameButton.gameObject.SetActive(false);
    }

    IEnumerator GetText() {
        
        WWWForm form = new WWWForm();
        form.AddField("usuario", ident);
        form.AddField("juego", "2");
        form.AddField("nivel",  Level);
        form.AddField("tiempo", timeStart.ToString("F2"));
        form.AddField("scores", Moves.text);
        form.AddField("grado", grado);
        form.AddField("Content-Type", "application/json");

        UnityWebRequest www = UnityWebRequest.Post("https://herokudjangoappaqp.herokuapp.com/api/agregar/", form);
        
        yield return www.SendWebRequest();
        Debug.Log("Respuesta -----> " + " | " +
            ident + " | " +
            Level + " | " +
            timeStart.ToString("F2") + " | " +
            Moves.text + " | " +
            grado
        );
        Debug.Log(form);

        if(www.isNetworkError || www.isHttpError) {
            // Debug.Log("Respuesta--");
            Debug.Log(www.error);
            TextInfo.text = "Error--->";
        }
        else {

            MyClass myObject = new MyClass();
            myObject = JsonUtility.FromJson<MyClass>(www.downloadHandler.text);
            // Debug.Log("----->>");
            // Debug.Log(myObject.resultado);
            TextInfo.text = myObject.resultado;
            if (myObject.resultado == "No Aprendio.")
            {
                // TextInfo.text += myObject.ayuda;
                TextInfo.text = "No logró aprender, para mejorar sus aprendizaje ingrese al siguiente link: ";
                BtnLink.GetComponentInChildren<Text>().text = myObject.ayuda;
                if (newGameButton3) {newGameButton3.gameObject.SetActive(false);}
            }
            else{
                TextInfo.text = "Completó el nivel satisfactoriamente. Puede jugar el siguiente nivel o regresar al menú principal";
                if (newGameButton2) {newGameButton2.gameObject.SetActive(false);}
            }

            // // Show results as text
            // Debug.Log("Respuesta----->");
            // Debug.Log(www.downloadHandler.text);
 
            // // Or retrieve results as binary data
            // byte[] results = www.downloadHandler.data;
             // Debug.Log(results);
        }
    }

    public void NewGame()
    {
        // GuardarDatos guardarDatos = new GuardarDatos(ident, "4", "60");
        SceneManager.LoadScene(newGameSceneName);
    }

    public void NewGame2()
    {
        // GuardarDatos guardarDatos = new GuardarDatos(ident, "4", "60");
        SceneManager.LoadScene(newGameSceneName2);
    }

    public void NewGame3()
    {
        data.id = ident;
        data.movimientos = 4;
        data.tiempo = 60;
        // GuardarDatos guardarDatos = new GuardarDatos(ident, "4", "60");
        string json = JsonUtility.ToJson(data);

        SceneManager.LoadScene(newGameSceneName3);
    }

    public void Reload()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void OpenHelp()
    {
        Application.OpenURL(BtnLink.GetComponentInChildren<Text>().text);
    }

    public void BeginGame()
    {
        gamePaused = false;
        // newGameButton.gameObject.SetActive(false);
    }
}
