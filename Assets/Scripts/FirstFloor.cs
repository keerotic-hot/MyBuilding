using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstFloor : MonoBehaviour {

	private MeshFilter mf;
	// Use this for initialization
	void Start () {
		mf = GetComponent<MeshFilter> ();
		Vector3[] vertices = mf.mesh.vertices;
		for (int i = 0; i < vertices.Length; i++) {
			if(vertices [i].y < 0)
				vertices [i].y = -0.9f;
		}
		mf.mesh.vertices = vertices;
		mf.mesh.RecalculateBounds ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
