using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public int sizeX = 5;
	public int sizeY = 5;
	public int sizeZ = 5;

	public GameObject Block;
	public GameObject FirstFloorBlock;
	public GameObject GroundBlock;

	private float maxX, minX;
	private float maxY, minY;
	private float maxZ, minZ;

	public float maxDistance = 100f;

	public string blockMask = "Block";
	private int blockMaskHash;

	private int numFloors;

	private CameraController cameraController;	

	private GameObject[] grounds;
	private GameObject[,,] blocks;


	void Start () {
		cameraController = GetComponent<CameraController> ();

		blockMaskHash = LayerMask.GetMask (blockMask);

		numFloors = sizeX * sizeZ;
		minX = -Mathf.Floor (sizeX / 2);
		minZ = -Mathf.Floor (sizeZ / 2);
		maxX = minX + sizeX - 1;
		maxZ = minZ + sizeZ - 1;
		minY = 1;
		maxY = sizeY;

		//Camera.main.transform.LookAt (Vector3.zero);

		createGroundBlocks ();
	}

	void createGroundBlocks(){
		GetComponent<MeshRenderer> ().enabled = false;

		grounds = new GameObject[numFloors];
		blocks = new GameObject[sizeX,sizeY,sizeZ];

		for (int i = 0; i < numFloors; i++) {
			float x = minX + (i % sizeX);
			float z = minZ + Mathf.Floor (i / sizeZ);
			grounds [i] = Instantiate (GroundBlock,transform);
			grounds [i].transform.localPosition = new Vector3 (x, 0, z);
		}

	}

	void Update(){
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		Physics.Raycast (ray, out hit, maxDistance, blockMaskHash);

		UpdateCursor (hit);

		if (Input.GetMouseButtonUp (0) 
		&& !cameraController.dragging) {
			TryCreateBlock (hit);
		}
	}

	void UpdateCursor(RaycastHit hit){
	}
	
	void TryCreateBlock (RaycastHit hit) {
		
		if (hit.collider) {

			Vector3 pos = hit.transform.localPosition + hit.normal;

			Block block = CreateBlock(pos);
		}
	}

	Block CreateBlock(Vector3 pos){
		int iX = (int)(pos.x - minX);
		int iY = (int)(pos.y - minY);
		int iZ = (int)(pos.z - minZ);

		if(iX >= 0 && iX < sizeX
		&& iY >= 0 && iY < sizeY
		&& iZ >= 0 && iZ < sizeZ) {

			GameObject Obj = Block;
			if (iY == 0)
				Obj = FirstFloorBlock;

			Block block = Instantiate (Obj,transform).GetComponent<Block> ();
			block.transform.localPosition = pos;

			return block;
		}

		return null;
	}
}
