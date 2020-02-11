using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebViewController : MonoBehaviour
{
    UniWebView webView;
    public string loadingURL;

    // Use this for initialization
    void Start()
    {
        // Create a game object to hold UniWebView and add component.
        var webViewGameObject = new GameObject("UniWebView");
        webView = webViewGameObject.AddComponent<UniWebView>();

        // More to add...
        webView.Frame = new Rect(0, 0, Screen.width*2, Screen.height*2); //defines frame of web view
        webView.Load(loadingURL); //loads this page on new frame 
        webView.Show();

        //webView.OnPageFinished += (view, statusCode, url) => {
        //    webView.EvaluateJavaScript("startGame();", (payload) => {
        //        if (payload.resultCode.Equals("0"))
        //        {
        //            Debug.Log("Game Started!");
        //        }
        //        else
        //        {
        //            Debug.Log("Something goes wrong: " + payload.data);
        //        }
        //    });
        //};

        //webView.OnShouldClose += (view) => {
        //    Debug.Log("miao");
        //    webView = null;
        //    return true;
        //};

        //webView.OnMessageReceived += (view, message) => {
        //    if (message.Path.Equals("game-over"))
        //    {
        //        var score = message.Args["score"];
        //        Debug.Log("Your final score is: " + score);

        //        webView.EvaluateJavaScript("getStars(" + score + ");", (payload) => {
        //            Debug.Log("You got " + payload.data + " stars!");
        //        });

        //        Invoke("Restart", 3.0f);
        //    }

        //    if (message.Path.Equals("close"))
        //    {
        //        Destroy(webView);
        //        webView = null;
        //    }
        //};
    }

    //void Restart()
    //{
    //    if (webView != null)
    //    {
    //        webView.Reload();
    //    }
    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}
}
