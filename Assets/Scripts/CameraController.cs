using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public float cameraSpeed = 10f;
	private bool _dragging = false;

	public bool dragging {
		get{
			return _dragging;
		}
	}

	void Start () {
		
	}

	void Update () {

		if (Input.GetMouseButtonDown (0)) {
			_dragging = false;
		}

		if (Input.GetMouseButton (0)) {
			float angle = Input.GetAxis ("Mouse X")*cameraSpeed;
			if (angle != 0) {
				_dragging = true;
			}
			Camera.main.transform.RotateAround (Vector3.zero, Vector3.up, angle);
		}
	}
}
