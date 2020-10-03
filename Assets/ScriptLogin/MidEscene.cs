using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
public class MidEscene : MonoBehaviour
{
    public GameObject ViewNiveles;

    // Start is called before the first frame update
    bool activo = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OcultarView()
    {
        ViewNiveles.SetActive(false);
        activo = false;
        SceneManager.LoadScene(1, LoadSceneMode.Additive);

    }
    public void MostrarView()
    {
        activo = true;
        Screen.orientation = ScreenOrientation.Portrait;
        SceneManager.UnloadScene(1);
        ViewNiveles.SetActive(true);


    }

}
