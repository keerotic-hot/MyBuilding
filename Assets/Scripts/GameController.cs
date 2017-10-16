using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject Floor;
	public GameObject Ground;
	public GameObject FirstFloor;

	public GameObject cursor;

	public int sizeX = 5;
	public int sizeY = 5;
	public int sizeZ = 5;

	private float maxX, minX;
	private float maxY, minY;
	private float maxZ, minZ;

	public float cameraSpeed = 10f;
	public float maxDistance = 100f;
	public string blockMask = "Block";

	private GameObject[] grounds;
	private GameObject[,,] blocks;

	private int blockMaskHash;

	private bool dragging = false;

	void Start () {
		blockMaskHash = LayerMask.GetMask (blockMask);

		GetComponent<MeshRenderer> ().enabled = false;

		int numFloors = sizeX * sizeZ;
		minX = -Mathf.Floor (sizeX / 2);
		minZ = -Mathf.Floor (sizeZ / 2);
		maxX = minX + sizeX - 1;
		maxZ = minZ + sizeZ - 1;
		minY = 1;
		maxY = sizeY;

		grounds = new GameObject[numFloors];
		blocks = new GameObject[sizeX,sizeY,sizeZ];

		for (int i = 0; i < numFloors; i++) {
			float x = minX + (i % sizeX);
			float z = minZ + Mathf.Floor (i / sizeZ);
			grounds [i] = Instantiate (Ground,transform);
			grounds [i].transform.localPosition = new Vector3 (x, 0, z);
		}

		//Camera.main.transform.LookAt (Vector3.zero);
	}
	
	void Update () {

		if (Input.GetMouseButtonDown (0)) {
			dragging = false;
		}

		if (Input.GetMouseButton (0)) {
			float angle = Input.GetAxis ("Mouse X")*cameraSpeed;
			if (angle != 0) {
				dragging = true;
			}
			Camera.main.transform.RotateAround (Vector3.zero, Vector3.up, angle);
		}

		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		Physics.Raycast (ray, out hit, maxDistance, blockMaskHash);

		if (hit.collider) {
			cursor.SetActive (true);
			cursor.transform.parent = hit.collider.transform;
			Vector3 pos = hit.normal;
			cursor.transform.localPosition = pos*0.55f;
			cursor.transform.rotation = Quaternion.LookRotation (-hit.normal);
			cursor.transform.localScale = Vector3.one;
		} else {
			cursor.SetActive(false);
		}

		if (Input.GetMouseButtonUp (0) 
		&& !dragging) {

			if (hit.collider) {

				Vector3 pos = hit.collider.transform.localPosition + hit.normal;

				Floor block = createBlock (pos);
				Debug.Log (block);
			}
		}
	}

	GameObject getBlock(Vector3 pos){
		if (pos.x >= minX && pos.x <= maxX 
			&& pos.z >= minZ && pos.z <= maxZ) {
			int iX = (int)(pos.x - minX);
			int iY = (int)(pos.y - minY);
			int iZ = (int)(pos.z - minZ);
			Debug.Log (iX +","+ iY +","+ iZ);
			return blocks [iX,iY,iZ];
		}
		return null;
	}

	Floor createBlock(Vector3 pos){
		if (pos.x >= minX && pos.x <= maxX 
			&& pos.z >= minZ && pos.z <= maxZ) {
			int iX = (int)(pos.x - minX);
			int iY = (int)(pos.y - minY);
			int iZ = (int)(pos.z - minZ);


			if (blocks [iX, iY, iZ] == null) {
				GameObject Obj = Floor;
				if (iY == 0)
					Obj = FirstFloor;
				GameObject block = Instantiate (Obj, transform);
				block.transform.localPosition = pos;
				blocks [iX,iY,iZ] = block; 

				Floor floor = block.GetComponent<Floor> ();
				floor.index = pos;

				GameObject nBlock = getBlock (new Vector3(pos.x, pos.y, pos.z + 1));
				Debug.Log (nBlock);
				if (nBlock != null) {
					Floor nFloor = nBlock.GetComponent<Floor> ();
					nFloor.sWall.gameObject.SetActive (false);

					//nFloor.esWall.gameObject.SetActive (false);
					Destroy(nFloor.esWall.gameObject);
					nFloor.esWall = Instantiate (nFloor.WallLeft, nFloor.transform).transform;
					nFloor.esWall.RotateAround(nFloor.transform.position,Vector3.up,nFloor.w);

					//nFloor.wsWall.gameObject.SetActive (false);
					Destroy(nFloor.wsWall.gameObject);
					nFloor.wsWall = Instantiate (nFloor.WallRight, nFloor.transform).transform;
					nFloor.wsWall.RotateAround(nFloor.transform.position,Vector3.up,nFloor.e);

					floor.nWall.gameObject.SetActive (false);

					//floor.enWall.gameObject.SetActive (false);
					Destroy(floor.enWall.gameObject);
					floor.enWall = Instantiate (floor.WallLeft, floor.transform).transform;
					floor.enWall.RotateAround(floor.transform.position,Vector3.up,floor.e);

					//floor.wnWall.gameObject.SetActive (false);
					Destroy(floor.wnWall.gameObject);
					floor.wnWall = Instantiate (floor.WallRight, floor.transform).transform;
					floor.wnWall.RotateAround(floor.transform.position,Vector3.up,floor.w);

				}

				return floor;
			}
			return blocks [iX, iY, iZ].GetComponent<Floor>();
		}

		return null;
	}
}
