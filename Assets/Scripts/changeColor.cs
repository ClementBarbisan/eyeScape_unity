using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class changeColor : MonoBehaviour {
	public changeMat eventCall;
	public List<MeshRenderer> list;
	public Color col;
	public Color colBase;

	public void animateColor()
	{
		foreach (MeshRenderer r in list)
			eventCall.changeColor (r, Color.blue);
	}

	public void initColor()
	{
		foreach (MeshRenderer r in list)
			eventCall.resetColor (r, colBase);
	}

	public void changeOpacity()
	{
		foreach (MeshRenderer r in list)
			eventCall.makeOpaque (1.0f, r, Color.blue);
	}

	public void changeTransparency()
	{
		foreach (MeshRenderer r in list)
			eventCall.makeTransparent (0.0f, r, Color.blue);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
