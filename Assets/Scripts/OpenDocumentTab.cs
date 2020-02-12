using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class OpenDocumentTab : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void Hello();

    [DllImport("__Internal")]
    private static extern void HelloString(string str);

    [DllImport("__Internal")]
    private static extern void PrintFloatArray(float[] array, int size);

    [DllImport("__Internal")]
    private static extern int AddNumbers(int x, int y);

    [DllImport("__Internal")]
    private static extern string StringReturnValueFunction();

    [DllImport("__Internal")]
    private static extern void OpenInNewWindow(string str);

    public Text addText;
    public Text strReturn;
    public string url;
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

    public void ButtonClicked()
    {
        //Time.timeScale = 0;
        //HelloString("redirecting to '"+ url+"'");
        OpenInNewWindow(url);
        //Application.OpenURL(url,);
        //Application.ExternalEval("window.open(" + url + ");");
    }

    public void MouseOverPage()
    {
        Time.timeScale = 1;
    }
}
