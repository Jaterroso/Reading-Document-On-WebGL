using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeSinceLaunch : MonoBehaviour
{
    private Text myText;
    private float runTime;
    private void Start()
    {
        myText = GetComponent<Text>();
    }
    private void Update()
    {
        runTime += Time.deltaTime;
        myText.text = runTime.ToString();
    }
}
