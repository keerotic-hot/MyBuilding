using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Index3{
	public int x{set; get;}
	public int y{set; get;}
	public int z{set; get;}

	public override string ToString(){
		return "Index3("+x + "," + y + "," + z+")";
	}
}

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

	public Index3 PositionToIndex(Vector3 pos) {
		Index3 index = new Index3();
		index.x = (int)(pos.x - minX);
		index.y = (int)(pos.y - minY);
		index.z = (int)(pos.z - minZ);
		return index;
	}

	public Vector3 IndexToPosition(Index3 i){
		return new Vector3 (i.x + minX, i.y + minY, i.z + minZ);
	}

	public Block GetBlock(Index3 i){
		if(i.x >= 0 && i.x < sizeX
		&& i.y >= 0 && i.y < sizeY
		&& i.z >= 0 && i.z < sizeZ) {
			GameObject block = blocks [i.x, i.y, i.z];
			if(block) return block.GetComponent<Block>();
		}
		return null;
	}


	Block CreateBlock(Index3 i){

		if (i.x >= 0 && i.x < sizeX
		   && i.y >= 0 && i.y < sizeY
		   && i.z >= 0 && i.z < sizeZ) {

			if (blocks [i.x, i.y, i.z] == null) {
				GameObject Obj = Block;
				if (i.y == 0)
					Obj = FirstFloorBlock;
				
				Block block = Instantiate (Obj, transform).GetComponent<Block> ();
				blocks [i.x, i.y, i.z] = block.gameObject;

				block.transform.localPosition = IndexToPosition (i);
				block.gameController = this;

				return block;
			}
		}
		return null;
	}

	Block CreateBlock(Vector3 pos){
		return CreateBlock (PositionToIndex (pos));
	}
}
