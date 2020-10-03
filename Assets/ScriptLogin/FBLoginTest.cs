using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;
using Firebase.Auth;
using UnityEngine.UI;

public class FBLoginTest : MonoBehaviour
{
    public GameObject DialogLoggedIn;
    public GameObject DialogLoggedOut;
    public GameObject DialogUsername;

    public GameObject DialogTest;

    public Text DialogName;
    public Text DialogName2;

    public Text userID;
    private FirebaseAuth facebookAuth;

    private void Awake()
    {
        if (!FB.IsInitialized)
            FB.Init();
        else
            FB.ActivateApp();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void logIn()
    {
        FB.LogInWithReadPermissions(callback: onLogIn);
    }

    private void onLogIn(ILoginResult result)
    {
        if (FB.IsLoggedIn)
        {
            DialogLoggedIn.SetActive(true);
            DialogLoggedOut.SetActive(false);
            FB.API("/me?fields=first_name", HttpMethod.GET, DisplayUsername);


            AccessToken tocken = result.AccessToken;//received access token
            userID.text = tocken.UserId;
            Credential credential = FacebookAuthProvider.GetCredential(tocken.TokenString);
            accessToken(credential);//invoke auth method
        }
        else
            Debug.Log("log failed");
    }

    public void accessToken(Credential firebaseResult)
    {
        FirebaseAuth auth = FirebaseAuth.DefaultInstance;

        //if (FB.IsLoggedIn)
        //    return;

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

            Firebase.Auth.FirebaseUser user = auth.CurrentUser;
            if (user != null)
            {
                string namee = user.DisplayName;
                string emaill = user.Email;
                System.Uri photo_url = user.PhotoUrl;
                // The user's Id, unique to the Firebase project.
                // Do NOT use this value to authenticate with your backend server, if you
                // have one; use User.TokenAsync() instead.
                string uid = user.UserId;
            }
        });
    }
    void DisplayUsername(IResult result)
    {

        Text UserName = DialogUsername.GetComponent<Text>();

        if (result.Error == null)
        {
            UserName.text = "Hi there, " + result.ResultDictionary["first_name"];

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
    // Update is called once per frame
    void Update()
    {
        
    }
}
