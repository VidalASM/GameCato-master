using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class change_scene : MonoBehaviour
{
    public string sceneName; 
    public string sceneName2; 
    public string sceneName3; 
    public string sceneName4; 
    // public Button loadSceneBtn;
    // public GameObject LoadGameMenu;

    // Start is called before the first frame update
    void Start()
    {
        // loadSceneBtn.onClick.Addlistner(ChangeScene);
    }

    public void ChangeScene(){ 
        SceneManager.LoadScene(sceneName); 
    }
    public void ChangeScene2(){ 
        SceneManager.LoadScene(sceneName2); 
    }
    public void ChangeScene3(){ 
        SceneManager.LoadScene(sceneName3); 
    }
    public void ChangeScene4(){ 
        SceneManager.LoadScene(sceneName4); 
    }

    // public void OpenLoadGameMenu()
    // {
    //     LoadGameMenu.SetActive(true);
    // }
}
