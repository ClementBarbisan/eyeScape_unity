using UnityEngine;
using System.Collections;

public class initReflectionProbe : MonoBehaviour {
	ReflectionProbe probe;
	// Use this for initialization
	void Start () {
		probe = gameObject.GetComponent<ReflectionProbe> ();

	}
	
	// Update is called once per frame
	void Update () {
		probe.RenderProbe();
	}
}
