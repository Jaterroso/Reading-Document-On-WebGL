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

    void Start()
    {
        float[] myArray = { 2.4f, 2.7f, 3.2f, 6.3f, 4, 15f, 5.23f};
        PrintFloatArray(myArray, myArray.Length);
    }

    public void OpenSpreadSheet()
    {
        videoPlayer.Pause();
        OpenInNewWindow(spreadSheetUrl);
    }

    public void OpenDocument()
    {
        videoPlayer.Pause();
        OpenInNewWindow(documentUrl);
    }

    public void OpenSlides()
    {
        videoPlayer.Pause();
        OpenInNewWindow(presentationUrl);
    }

    public void MouseOverPage()
    {
        Time.timeScale = 1;
    }

    public void OpenThePopUp()
    {
        videoPlayer.Pause();
        audioPlayer.Play();
        openPopUp();
    }

    public void ResetTimer()
    {
        showText.SetActive(true);
        timerRef.runTime = 0;
        PageIsFocused();
        OnConsole("received in Reset Timer of TestingObject");
    }

    public void PageIsFocused()
    {
        videoPlayer.Play();
        audioPlayer.Stop();
    }

    public void PageIsNotFocused()
    {
        videoPlayer.Pause();
        audioPlayer.Stop();
    }
}