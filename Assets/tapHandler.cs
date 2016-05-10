using UnityEngine;
using System.Collections;

public class tapHandler : MonoBehaviour {
	GameObject[] list;
	int index;

	// Use this for initialization
	void Start () {
		index = 0;
		list = GameObject.FindGameObjectsWithTag ("model1");
		for (int i = 0; i < list.Length; i++) 
		{
			if (i == index)
				list [i].SetActive(true);
			else
				list [i].SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetTouch(0).phase == TouchPhase.Began)
		{
			index = (index + 1) % list.Length;
			for (int i = 0; i < list.Length; i++) 
			{
				if (i == index)
					list [i].SetActive(true);
				else
					list [i].SetActive(false);
			}
		}
	}
}
