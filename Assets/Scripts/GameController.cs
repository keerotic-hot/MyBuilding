using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public int sizeX = 5;
	public int sizeY = 5;
	public int sizeZ = 5;

	private float maxX, minX;
	private float maxY, minY;
	private float maxZ, minZ;

	public float maxDistance = 100f;

	public string blockMask = "Block";
	private int blockMaskHash;

	private CameraController cameraController;

	void Start () {
		cameraController = GetComponent<CameraController> ();

		blockMaskHash = LayerMask.GetMask (blockMask);

		//GetComponent<MeshRenderer> ().enabled = false;

		int numFloors = sizeX * sizeZ;
		minX = -Mathf.Floor (sizeX / 2);
		minZ = -Mathf.Floor (sizeZ / 2);
		maxX = minX + sizeX - 1;
		maxZ = minZ + sizeZ - 1;
		minY = 1;
		maxY = sizeY;

		//Camera.main.transform.LookAt (Vector3.zero);
	}

	void Update(){
		createBlock ();
	}
	
	void createBlock () {
		if (cameraController 
		&& cameraController.dragging)
			return;
		
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		Physics.Raycast (ray, out hit, maxDistance, blockMaskHash);
	}
}
