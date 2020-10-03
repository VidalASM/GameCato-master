
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escena : MonoBehaviour
{
    // Start is called before the first frame update

    string id;
    AuthUI refeAuth;
    public GameObject ViewOcultar;
    bool CambioEscena = true;

    private AuthUI auth;

    void Start()
    {
        //id = GetComponent<Usuario>().id;
        //id = gameObject.GetComponent<AuthManager>().iden;

    }
    void Awake()
    {
        auth = GameObject.FindObjectOfType<AuthUI>();
        //escenaLogIn = GameObject.FindObjectOfType<EscenaLogIn>();
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log(id);
    }
    //abrir nivel G01 N03
    public void EscenaGame01Nivel03()
    {
        //Application.LoadLevelAdditiveAsync(1);
        auth.getPanelActual(false);
        ViewOcultar.SetActive(false);

        SceneManager.LoadScene(1, LoadSceneMode.Additive);



    }
    //abrir nivel G01 N02
    public void EscenaGame01Nivel02()
    {
        auth.getPanelActual(false);
        ViewOcultar.SetActive(false);
        SceneManager.LoadScene(2, LoadSceneMode.Additive);
    }
    //abrir nivel G01 N01
    public void EscenaGame01Nivel01()
    {
        //        AuthUI
        auth.getPanelActual(false);
        ViewOcultar.SetActive(false);
        SceneManager.LoadScene(3, LoadSceneMode.Additive);
    }


    public void EscenaGame01Niveles()
    {
        //refeAuth.ActivarView();
        auth.getPanelActual(true);

        Screen.orientation = ScreenOrientation.Portrait;
        SceneManager.UnloadScene(1);
        //ViewOcultar.SetActive(true);

    }

    public void EscenaGame01Niveles2()
    {
        auth.getPanelActual(true);
        Screen.orientation = ScreenOrientation.Portrait;
        SceneManager.UnloadScene(2);

    }
    public void EscenaGame01Niveles1()
    {
        auth.getPanelActual(true);
        Screen.orientation = ScreenOrientation.Portrait;
        SceneManager.UnloadScene(3);

    }



    public void Cambiarescena2(string nombredeescena)
    {

        SceneManager.LoadScene(1);
    }


    /***********************/

        // mostrar G1 Niveles
    public void PressBackG1N1()
    {
        auth.getPanelActual(true);
        Screen.orientation = ScreenOrientation.Portrait;
        SceneManager.UnloadScene(3);
    }
    public void ReloadG1N1()
    {
        auth.getPanelActual(false);
        ViewOcultar.SetActive(false);
        SceneManager.LoadScene(3, LoadSceneMode.Additive);
    }

    public void PressBackG1N2()
    {
        auth.getPanelActual(true);
        Screen.orientation = ScreenOrientation.Portrait;
        SceneManager.UnloadScene(2);
    }

    public void ReloadG1N2()
    {
        auth.getPanelActual(false);
        ViewOcultar.SetActive(false);
        SceneManager.LoadScene(2, LoadSceneMode.Additive);
    }

    public void PressBackG1N3()
    {
        auth.getPanelActual(true);
        Screen.orientation = ScreenOrientation.Portrait;
        SceneManager.UnloadScene(1);
    }

    public void ReloadG1N3()
    {
        auth.getPanelActual(false);
        ViewOcultar.SetActive(false);
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
    }

}
