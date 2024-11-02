using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class IntegerHolder : MonoBehaviour
{
	public int holding=0;
	public int errored=0;
	
	public void AddingListener()
	{
		gameObject.GetComponent<Button>().onClick.AddListener(ButtonsClickListeners);
	}
	
	public void ButtonsClickListeners()
	{
		if(holding == errored)
		{
			GameObject panel = GameObject.Find("Panel");
			panel.GetComponent<PuzzleGenerator>().RestartLevel(1);
		}else
		{
			Debug.Log("Try Again Time Remaining: ");			
		}
	}
}
