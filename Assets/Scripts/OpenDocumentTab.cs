using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class OpenDocumentTab : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void Hello(); // no returns

    [DllImport("__Internal")]
    private static extern void HelloString(string str); // no returns

    [DllImport("__Internal")]
    private static extern void OnConsole(string str); //prints string in console

    [DllImport("__Internal")]
    private static extern void PrintFloatArray(float[] array, int size); // no returns

    [DllImport("__Internal")]
    private static extern int AddNumbers(int x, int y); // returns a integer

    [DllImport("__Internal")]
    private static extern string StringReturnValueFunction(); // gives a string of length 4 with first 3 lettters being 'bla'

    [DllImport("__Internal")]
    private static extern void OpenInNewWindow(string str); //opens the url passed in new webpage

    [DllImport("__Internal")]
    private static extern void openPopUp();

    [Header("Documents URL")]
    public string spreadSheetUrl;
    public string documentUrl;
    public string presentationUrl;

    [Header("time Text")]
    public GameObject showText;
    public TimeSinceLaunch timerRef;

    [Header("Media Files")]
    public VideoPlayer videoPlayer;
    public AudioSource audioPlayer;

    private float timePerFrame = 0.4f;
    public float timeScaleAmount;


    private bool showDeltaTime;
    void Start()
    {
        Application.targetFrameRate = 60;
        timeScaleAmount = 0.3f;
        Time.maximumDeltaTime = timeScaleAmount;
        OnConsole("at start maximumDeltaTime: " + Time.maximumDeltaTime.ToString());
        float[] myArray = { 2.4f, 2.7f, 3.2f, 6.3f, 4, 15f, 5.23f};
        PrintFloatArray(myArray, myArray.Length);
    }

    public void OpenSpreadSheet()
    {
        //videoPlayer.Pause();
        OpenInNewWindow(spreadSheetUrl);
    }

    public void OpenDocument()
    {
        //videoPlayer.Pause();
        OpenInNewWindow(documentUrl);
    }

    public void OpenSlides()
    {
        //videoPlayer.Pause();
        OpenInNewWindow(presentationUrl);
    }

    public void MouseOverPage()
    {
        Time.timeScale = 1;
    }

    public void OpenThePopUp()
    {
        //videoPlayer.Pause();
        audioPlayer.Play();
        openPopUp();
    }

    public void ResetTimer()
    {
        showText.SetActive(true);
        timerRef.runTime = 0;
        //PageIsFocused();
        //videoPlayer.Play();
        audioPlayer.Stop();
        OnConsole("received in Reset Timer of TestingObject");
    }

    public void PageIsFocused()
    {
        showDeltaTime = false;
        OnConsole("after hiding : maximumDeltaTime: " + Time.maximumDeltaTime.ToString());
        return;

        videoPlayer.Play();
        audioPlayer.Stop();
        OnConsole("page is focused so playing video and stopped pop up audio");
    }

    public void PageIsNotFocused()
    {
        showDeltaTime = true;
        return;

        videoPlayer.Pause();
        audioPlayer.Stop();
        OnConsole("page is not focused so stopping video and stopped pop up audio");
    }


    public void SetTimeScale(Slider SliderRef)
    {
        timeScaleAmount = SliderRef.value;

        Time.maximumDeltaTime = timeScaleAmount * timePerFrame; //this should make it so, with a lower timeScaleAmount, the Time.maximumDeltaTime will be lower as well
        //if (Time.maximumDeltaTime > timePerFrame)
        //{
        //    Time.maximumDeltaTime = timePerFrame; // when the timeScaleAmount is greater than 1, make no changes to the Time.maximumDeltaTime (Because it works fine)
        //}
        OnConsole("maximumDeltaTime: " + Time.maximumDeltaTime.ToString());
        //OnConsole("Supposed Value: " + (timeScaleAmount * timePerFrame).ToString());
        Time.timeScale = timeScaleAmount; // assign the Time.timeScale Value
    }

    private void Update()
    {
        if (showDeltaTime)
        {
            OnConsole("during hiding : maximumDeltaTime: " + Time.maximumDeltaTime.ToString());
        }
    }
}
