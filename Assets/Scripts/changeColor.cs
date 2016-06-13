using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class changeColor : MonoBehaviour {
	public List<MeshRenderer> list;
	public Color col;
	public Color colBase;

	IEnumerator colorChange(MeshRenderer render, Color col)
	{
		Color tmp = render.material.color;
		for (int i = 0; i < 200; i++) {
			float multiple = (200.0f - i) / 200.0f;
			render.material.color = new Vector4 (col.r * (1.0f - multiple) + tmp.r * multiple, col.g * (1.0f - multiple) + tmp.g * multiple, col.b * (1.0f - multiple) + tmp.b * multiple, 1.0f);
			yield return null;
		}
	}

	IEnumerator opacityIncrease(MeshRenderer render, Color col, float max, float value)
	{
		for (int i = 0; i < value; i++) {
			render.material.color = new Vector4 (col.r, col.g, col.b, max / (value - i));
			yield return null;
		}
	}

	void resetColor(MeshRenderer render, Color col)
	{
		render.material.color = new Color (col.r, col.g, col.b, 1.0f);
	}

	void makeTransparent(float min, MeshRenderer render, Color col)
	{
		render.material.color = new Vector4 (col.r, col.g, col.b, min);
	}

	public void animateColor()
	{
		foreach (MeshRenderer r in list)
			StartCoroutine (colorChange(r, Color.blue));
	}

	public void initColor()
	{
		foreach (MeshRenderer r in list)
			resetColor (r, colBase);
	}

	public void changeOpacity()
	{
		foreach (MeshRenderer r in list)
			StartCoroutine (opacityIncrease (r, Color.blue, 1.0f, 30f));
	}

	public void changeTransparency()
	{
		foreach (MeshRenderer r in list)
			makeTransparent (0.0f, r, Color.blue);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
