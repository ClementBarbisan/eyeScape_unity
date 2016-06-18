using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class changeColor : MonoBehaviour {
	public List<MeshRenderer> list;
	public List<textureChange> tex;
	public Color col;
	public Color colBase;
	private int index = 0;

	IEnumerator opacityIncrease(MeshRenderer render, Color col, float max, float value)
	{
		for (int i = 0; i < value; i++) {
			render.material.color = new Vector4 (col.r, col.g, col.b, max / (value - i));
			yield return null;
		}
	}

	void resetColor(MeshRenderer render, Color col)
	{
		render.material.color = new Color (col.r, col.g, col.b, col.a);
	}

	void makeTransparent(float min, MeshRenderer render, Color col)
	{
		render.material.color = new Vector4 (col.r, col.g, col.b, min);
	}

	public void animateColor()
	{
		index = (index + 1) % 100;
		float multiple = (100.0f - index) / 100.0f;
		foreach (MeshRenderer r in list) {
			Color tmp = r.material.color;
			if (index == 0)
				tmp = colBase;
			r.material.color = new Vector4 (col.r * (1.0f - multiple) + tmp.r * multiple, col.g * (1.0f - multiple) + tmp.g * multiple, col.b * (1.0f - multiple) + tmp.b * multiple, col.a * (1.0f - multiple) + tmp.a * multiple);
		}
	}

	public void initColor()
	{
		foreach (MeshRenderer r in list)
			resetColor (r, colBase);
	}

	public void changeOpacity()
	{
		foreach (MeshRenderer r in list)
			StartCoroutine (opacityIncrease (r, col, col.a, 20f));
	}

	public void texChange()
	{
		foreach (textureChange texture in tex)
			texture.changeTexture ();
	}

	public void changeTransparency()
	{
		foreach (MeshRenderer r in list)
			makeTransparent (0.0f, r, col);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
