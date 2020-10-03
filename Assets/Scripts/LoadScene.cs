using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadScene : MonoBehaviour
{
    private AssetBundle myLoadedAssetBundle;
    private string[] scenePaths;
    
    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GotoMainScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void GotoMenuScene()
    {
        SceneManager.LoadScene("menu");
    }
}
