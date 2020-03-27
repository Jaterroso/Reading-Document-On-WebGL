using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class OpenDocumentTab : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void Hello(); // no returns

    [DllImport("__Internal")]
    private static extern void HelloString(string str); // no returns

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

    public Text addText;
    public Text strReturn;
    public string spreadSheetUrl;
    public string documentUrl;
    public string presentationUrl;
    void Start()
    {
        float[] myArray = { 2.4f, 2.7f, 3.2f, 6.3f, 4, 15f, 5.23f};
        PrintFloatArray(myArray, myArray.Length);

        //int result = AddNumbers(5, 7);
        //Debug.Log(result);
        //addText.text = result.ToString();
        //Debug.Log(StringReturnValueFunction());
        //strReturn.text = StringReturnValueFunction();
    }

    public void OpenSpreadSheet()
    {
        OpenInNewWindow(spreadSheetUrl);
    }

    public void OpenDocument()
    {
        OpenInNewWindow(documentUrl);
    }

    public void OpenSlides()
    {
        OpenInNewWindow(presentationUrl);
    }

    public void MouseOverPage()
    {
        Time.timeScale = 1;
    }

    public void OpenThePopUp()
    {
        openPopUp();
    }
}