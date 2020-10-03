using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;
using Firebase.Auth;
using UnityEngine.UI;

//using Firebase.Database;

public class FBAuth : MonoBehaviour
{
    public GameObject DialogLoggedIn;
    public GameObject DialogLoggedOut;
    public GameObject DialogUsername;

    public GameObject DialogTest;

    public Text DialogName;
    public Text DialogName2;

    bool flagLogout = false;
    // Start is called before the first frame update
    public Text userID;
    private FirebaseAuth facebookAuth;


    FirebaseAuth auth;

    void Start()
    {
        auth = FirebaseAuth.DefaultInstance;
    }


    private void Awake()
    {
        if (!FB.IsInitialized)
            FB.Init();
        else
            FB.ActivateApp();
    }

    public void LogIn()
    {
        Debug.Log("Presione Log");
        List<string> permissions = new List<string>();

        //asks facebook for the users profile
        permissions.Add("public_profile");
        permissions.Add("email");

        FB.LogInWithReadPermissions(permissions,callback: OnLogIn);//N3xtL1m1t view
    }
    /*
    private void OnLogIn(ILoginResult result)
    {
        if (FB.IsLoggedIn)
        {
            AccessToken tocken = AccessToken.CurrentAccessToken;
            userID.text = tocken.UserId;
            Credential credential = FacebookAuthProvider.GetCredential(tocken.TokenString);
        }
        else
            Debug.Log("log failed");
    }*/

    public void AccessTokenN(Credential firebaseResult)
    {
        //FirebaseAuth auth = FirebaseAuth.DefaultInstance;  borrado hoy

        //if (FB.IsLoggedIn)
          //  return;

        auth.SignInWithCredentialAsync(firebaseResult).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithCredentialAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInWithCredentialAsync encountered an error: " + task.Exception);
                return;
            }

            FirebaseUser newUser = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
        });
    }

    private void OnLogIn(ILoginResult result)
    {
        //userID.text = "ENTREE";
        if (FB.IsLoggedIn)
        {

            DialogLoggedIn.SetActive(true);
            DialogLoggedOut.SetActive(false);
            FB.API("/me?fields=first_name", HttpMethod.GET, DisplayUsername);
            FB.API("/me?fields=last_name", HttpMethod.GET, DisplayUsername);


            //AccessToken tocken = result.AccessToken;//received access token
            AccessToken tocken = Facebook.Unity.AccessToken.CurrentAccessToken;//received access token
            //AccessToken tocken = AccessToken.CurrentAccessToken;//received access token
            //userID.text = "ENTREX2";
            //string tokn = result.AccessToken.TokenString;
            Firebase.Auth.Credential credential = Firebase.Auth.FacebookAuthProvider.GetCredential(tocken.TokenString);

            //AccessTokenN(credential);//invoke auth method
            auth.SignInWithCredentialAsync(credential).ContinueWith(task => {
                if (task.IsCanceled)
                {
                    Debug.LogError("SignInWithCredentialAsync was canceled.");
                    return;
                }
                if (task.IsFaulted)
                {
                    Debug.LogError("SignInWithCredentialAsync encountered an error: " + task.Exception);
                    return;
                }
                if (task.IsCompleted)
                {
                    userID.text = "ENTREX3";
                }
                Firebase.Auth.FirebaseUser newUser = task.Result;
                Debug.LogFormat("User signed in successfully: {0} ({1})",
                    newUser.DisplayName, newUser.UserId);
            });




        }
        else
        {
            DialogLoggedIn.SetActive(false);
            DialogLoggedOut.SetActive(true);
            Debug.Log("log failed");
        }

    }

    void DisplayUsername(IResult result)
    {

        Text UserName = DialogUsername.GetComponent<Text>();

        if (result.Error == null)
        {
            UserName.text = "Hi there, " + result.ResultDictionary["last_name"];

            Text aux2 = DialogTest.GetComponent<Text>();
            aux2.text = "ENTRERE";
            Text aux = (Text)result.ResultDictionary;
            DialogName = aux;
            DialogName2.text = "ENTREEEEEE";
        }
        else
        {
            Debug.Log(result.Error);
        }
    }

    void Update()
    {
        if (flagLogout)
        {
            DialogLoggedIn.SetActive(false);
            DialogLoggedOut.SetActive(true);
            flagLogout = false;
        }
    }

}