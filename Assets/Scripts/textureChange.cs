using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class textureChange : MonoBehaviour {
	public List<Texture2D> list;
	Renderer render;
	// Use this for initialization
	void Start () {
		Random.seed = (int)(Time.time * 100.0f);
		render = GetComponent<Renderer> ();
		changeTexture ();
	}

	public void changeTexture()
	{
		render.material.mainTexture =  list [Random.Range (0, list.Count - 1)];
	}

	// Update is called once per frame
	void Update () {
	
	}
}
