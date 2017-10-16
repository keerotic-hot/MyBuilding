using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour {
	
	public GameObject Top;
	public GameObject Bottom;
	public GameObject Wall;
	public GameObject WallLeft;
	public GameObject WallRight;
	public GameObject Corner;
	public GameObject CornerLeft;
	public GameObject CornerRight;

	public Vector3 index;

	public string blockMask = "Block";
	public float maxDistance = 100f;

	private int blockMaskHash;

	private MeshRenderer mr;

	public float n = 0f, e = 90f, w = 270f, s = 180f;

	public Transform top;
	public Transform nWall,eWall,wWall,sWall;
	public Transform enWall,esWall,wnWall,wsWall;
	public Transform nTop,eTop,wTop,sTop;
	public Transform enTop,esTop,wnTop,wsTop;
	public Transform bottom;
	public Transform nBottom,eBottom,wBottom,sBottom;
	public Transform enBottom,esBottom,wnBottom,wsBottom;

	// Use this for initialization
	void Awake () {
		mr = GetComponent<MeshRenderer> ();
		mr.enabled = false;

		blockMaskHash = LayerMask.GetMask (blockMask);

		top = Instantiate (Top, transform).transform;
		bottom = Instantiate (Bottom, transform).transform;

		nWall = Instantiate (Wall, transform).transform;
		nWall.RotateAround (transform.position, Vector3.up, n);

		eWall = Instantiate (Wall, transform).transform;
		eWall.RotateAround (transform.position, Vector3.up, e);

		wWall = Instantiate (Wall, transform).transform;
		wWall.RotateAround (transform.position, Vector3.up, w);

		sWall = Instantiate (Wall, transform).transform;
		sWall.RotateAround (transform.position, Vector3.up, s);

		enWall = Instantiate (Corner, transform).transform;
		enWall.RotateAround (transform.position, Vector3.up, e);

		esWall = Instantiate (Corner, transform).transform;
		esWall.RotateAround (transform.position, Vector3.up, s);

		wnWall = Instantiate (Corner, transform).transform;
		wnWall.RotateAround (transform.position, Vector3.up, n);

		wsWall = Instantiate (Corner, transform).transform;
		wsWall.RotateAround (transform.position, Vector3.up, w);
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;

		Physics.Raycast (ray, out hit, maxDistance, blockMaskHash);
		mr.enabled = (hit.collider && hit.collider.gameObject == gameObject);

	}

	public void UpdateBlock(Vector3 position){
	}
}
