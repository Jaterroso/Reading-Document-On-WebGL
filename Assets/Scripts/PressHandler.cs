using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEngine.Events;
using System.Collections;

public class PressHandler : MonoBehaviour, IPointerDownHandler
{
	[Serializable]
	public class ButtonPressEvent : UnityEvent { }

	public ButtonPressEvent OnPress = new ButtonPressEvent();

	public void OnPointerDown(PointerEventData eventData)
	{
		 //StartCoroutine(InvokeIn3Seconds());
		Invoke("InvokeIn3Seconds", 3.0f);
	}

	void InvokeIn3Seconds()
	{
        //yield return new waitforSec
		//OnPress.Invoke();
	}
}