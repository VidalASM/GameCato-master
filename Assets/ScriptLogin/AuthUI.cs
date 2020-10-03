using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

using UnityEngine;
using UnityEngine.SceneManagement;
public class AuthUI : MonoBehaviour
{
    // Start is called before the first frame update


    public GameObject loginPanel;
    public GameObject signupPanel;
    public GameObject loggedinPanel;

    public GameObject panelGame01;
    public GameObject panelGame02;

    private GameObject panelActual;

    public InputField loginEmail;
    public InputField loginPassword;


    public InputField colegio;
    public InputField grado;
    public InputField nombres;
    public InputField apellidos;
    public InputField username;
    public InputField signupEmail;
    public InputField signupPassword;
    public InputField signupConfirmPassword;

    public Text loggedinUserEmail;

    MidEscene midEscene;
    bool game01 = true;



    static public bool actualPanel = true;


    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        ShowLoginPanel();
    }

    public void ShowLoginPanel()
    {
        Debug.Log("LOGIIINNNNN");
        try
        {
            loginPanel.SetActive(true);
            ShowPanel(loginPanel);
        }
        catch (Exception e) { Debug.Log(e.Message); }

    }

    public void ShowSignupPanel()
    {
        ShowPanel(signupPanel);

    }

    public void ShowLoggedinPanel()
    {
        ShowPanel(loggedinPanel);

    }
    public void ShowGame01Panel()
    {
        PlayerPrefs.SetString("lastLoadedScene",  SceneManager.GetActiveScene().name);

        ShowPanel(panelGame01);

    }
    /*
    public void ShowGame02Panel()
    {
        //PlayerPrefs.SetString("lastLoadedScene", SceneManager.GetActiveScene().name);

        //ShowPanel(panelGame01);


    }*/



    public void ShowGame02Panel()
    {
        //ShowPanel(panelGame02);
        SceneManager.LoadScene("Login");

    }
    public void ShowGame01PanelBack()
    {
        ShowPanel(loggedinPanel);
    }
    /*************/
    public void OcultarView()
    {
        loginPanel.SetActive(false);
    }
    public void ActivarView()
    {
        loginPanel.SetActive(true);
    }

    public void DesactiveGame01Nivel03()
    {
        //game01 = true;
        //midEscene.OcultarView();
        panelGame01.SetActive(false);
        game01 = false;
        SceneManager.LoadScene(1, LoadSceneMode.Additive);



    }
    public void ActivarGame01()
    {
        game01 = true;
        Screen.orientation = ScreenOrientation.Portrait;
        SceneManager.UnloadScene(1);

        panelGame01.SetActive(true);
    }

    public void ShowPanel(GameObject panel)
    {
        loginPanel.SetActive(false);
        signupPanel.SetActive(false);
        loggedinPanel.SetActive(false);
        panelGame01.SetActive(false);
        panelGame02.SetActive(false);

        panel.SetActive(true);
        panelActual = panel;

    }
    // Update is called once per frame
    public void getPanelActual(bool tempPanel)
    {
        actualPanel = tempPanel;
    }


    void Update()
    {
        if (actualPanel)
        {
            panelActual.SetActive(true);
        }
       
    }
}
