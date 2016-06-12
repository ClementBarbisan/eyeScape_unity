using UnityEngine;
using System.Collections;

public class changeMat : MonoBehaviour {

	IEnumerator colorChange(MeshRenderer render, Color col)
	{
		Color tmp = render.material.color;
		for (int i = 0; i < 200; i++) {
			float multiple = (200.0f - i) / 200.0f;
			render.material.color = new Vector4 (col.r * (1.0f - multiple) + tmp.r * multiple, col.g * (1.0f - multiple) + tmp.g * multiple, col.b * (1.0f - multiple) + tmp.b * multiple, 1.0f);
			yield return null;
		}
	}

	IEnumerator opacityIncrease(MeshRenderer render, Color col, float max)
	{
		for (int i = 0; i < 40; i++) {
			render.material.color = new Vector4 (col.r, col.g, col.b, max / (40.0f - i));
			yield return null;
		}
	}

	public void resetColor(MeshRenderer render, Color col)
	{
		render.material.color = new Color (col.r, col.g, col.b, 1.0f);
	}

	public void makeTransparent(float min, MeshRenderer render, Color col)
	{
		render.material.color = new Vector4 (col.r, col.g, col.b, min);
	}

	public void changeColor(MeshRenderer render, Color col)
	{
		StartCoroutine (colorChange(render, col));
	}

	public void makeOpaque(float max, MeshRenderer render, Color col)
	{
		StartCoroutine (opacityIncrease(render, col, max));
	}
}
