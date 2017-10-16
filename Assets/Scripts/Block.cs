using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

	public GameController gameController;

	protected Transform block;

	protected Dictionary<string,GameObject> walls;
	protected Dictionary<string,GameObject> northWalls;
	protected Dictionary<string,GameObject> eastWalls;
	protected Dictionary<string,GameObject> southWalls;
	protected Dictionary<string,GameObject> westWalls;
	protected Dictionary<string,GameObject> upWalls;
	protected Dictionary<string,GameObject> downWalls;

	protected void Start () {
		block = transform.GetChild(0);
		walls = new Dictionary<string,GameObject> ();
		int cnt = block.GetChildCount ();
		for (int i = 0; i < cnt; i++) {
			walls.Add (block.GetChild (i).name, block.GetChild (i).gameObject);
		}

		northWalls = new Dictionary<string,GameObject> ();
		northWalls.Add ("Wall", walls ["NorthWall"]);
		northWalls.Add ("Left", walls ["NLWall"]);
		northWalls.Add ("Right", walls ["NRWall"]);
		northWalls.Add ("JLeft", walls ["NLJoin"]);
		northWalls.Add ("JRight", walls ["NRJoin"]);

		eastWalls = new Dictionary<string,GameObject> ();
		eastWalls.Add ("Wall", walls ["EastWall"]);
		eastWalls.Add ("Left", walls ["ELWall"]);
		eastWalls.Add ("Right", walls ["ERWall"]);
		eastWalls.Add ("JLeft", walls ["ELJoin"]);
		eastWalls.Add ("JRight", walls ["ERJoin"]);

		southWalls = new Dictionary<string,GameObject> ();
		southWalls.Add ("Wall", walls ["SouthWall"]);
		southWalls.Add ("Left", walls ["SLWall"]);
		southWalls.Add ("Right", walls ["SRWall"]);
		southWalls.Add ("JLeft", walls ["SLJoin"]);
		southWalls.Add ("JRight", walls ["SRJoin"]);

		westWalls = new Dictionary<string,GameObject> ();
		westWalls.Add ("Wall", walls ["WestWall"]);
		westWalls.Add ("Left", walls ["WLWall"]);
		westWalls.Add ("Right", walls ["WRWall"]);
		westWalls.Add ("JLeft", walls ["WLJoin"]);
		westWalls.Add ("JRight", walls ["WRJoin"]);

		/*upWalls = new Dictionary<string,GameObject> ();
		upWalls.Add ("Wall", walls ["Top"]);
		upWalls.Add ("North", walls ["NTWall"]);
		upWalls.Add ("East", walls ["ETWall"]);
		upWalls.Add ("South", walls ["STWall"]);
		upWalls.Add ("West", walls ["WTWall"]);
		upWalls.Add ("JNorth", walls ["TNJoin"]);
		upWalls.Add ("JEast", walls ["TEJoin"]);
		upWalls.Add ("JSouth", walls ["TSJoin"]);
		upWalls.Add ("JWest", walls ["TWJoin"]);

		downWalls = new Dictionary<string,GameObject> ();
		downWalls.Add ("Wall", walls ["Bottom"]);
		downWalls.Add ("North", walls ["NBWall"]);
		downWalls.Add ("East", walls ["EBWall"]);
		downWalls.Add ("South", walls ["SBWall"]);
		downWalls.Add ("West", walls ["WBWall"]);
		downWalls.Add ("JNorth", walls ["BNJoin"]);
		downWalls.Add ("JEast", walls ["BEJoin"]);
		downWalls.Add ("JSouth", walls ["BSJoin"]);
		downWalls.Add ("JWest", walls ["BWJoin"]);*/

		northWalls["Left"].SetActive (false);
		northWalls["Right"].SetActive (false);
		northWalls["JLeft"].SetActive (false);
		northWalls["JRight"].SetActive (false);

		eastWalls["Left"].SetActive (false);
		eastWalls["Right"].SetActive (false);
		eastWalls["JLeft"].SetActive (false);
		eastWalls["JRight"].SetActive (false);

		southWalls["Left"].SetActive (false);
		southWalls["Right"].SetActive (false);
		southWalls["JLeft"].SetActive (false);
		southWalls["JRight"].SetActive (false);

		westWalls["Left"].SetActive (false);
		westWalls["Right"].SetActive (false);
		westWalls["JLeft"].SetActive (false);
		westWalls["JRight"].SetActive (false);

		UpdateWalls (true);
	}

	public void UpdateWalls(bool chain = false){
		
		GameController gc = gameController;
		
		Index3 index = gc.PositionToIndex(transform.localPosition);

		Index3 northIndex = gc.PositionToIndex (transform.localPosition + Vector3.forward);
		Index3 eastIndex = gc.PositionToIndex (transform.localPosition + Vector3.right);
		Index3 southIndex = gc.PositionToIndex (transform.localPosition + Vector3.back);
		Index3 westIndex = gc.PositionToIndex (transform.localPosition + Vector3.left);
		Index3 upIndex = gc.PositionToIndex (transform.localPosition + Vector3.up);
		Index3 downIndex = gc.PositionToIndex (transform.localPosition + Vector3.down);

		Index3 neIndex = gc.PositionToIndex (transform.localPosition + Vector3.forward + Vector3.right);
		Index3 nwIndex = gc.PositionToIndex (transform.localPosition + Vector3.forward + Vector3.left);
		Index3 seIndex = gc.PositionToIndex (transform.localPosition + Vector3.back + Vector3.right);
		Index3 swIndex = gc.PositionToIndex (transform.localPosition + Vector3.back + Vector3.left);

		Index3 nuIndex = gc.PositionToIndex (transform.localPosition + Vector3.forward + Vector3.up);
		Index3 ndIndex = gc.PositionToIndex (transform.localPosition + Vector3.forward + Vector3.down);
		Index3 suIndex = gc.PositionToIndex (transform.localPosition + Vector3.back + Vector3.up);
		Index3 sdIndex = gc.PositionToIndex (transform.localPosition + Vector3.back + Vector3.down);

		Index3 euIndex = gc.PositionToIndex (transform.localPosition + Vector3.right + Vector3.up);
		Index3 edIndex = gc.PositionToIndex (transform.localPosition + Vector3.right + Vector3.down);
		Index3 wuIndex = gc.PositionToIndex (transform.localPosition + Vector3.left + Vector3.up);
		Index3 wdIndex = gc.PositionToIndex (transform.localPosition + Vector3.left + Vector3.down);

		Block north = gc.GetBlock (northIndex);
		Block east = gc.GetBlock (eastIndex);
		Block south = gc.GetBlock (southIndex);
		Block west = gc.GetBlock (westIndex);
		Block up = gc.GetBlock (upIndex);
		Block down = gc.GetBlock (downIndex);

		Block ne = gc.GetBlock (neIndex);
		Block nw = gc.GetBlock (nwIndex);
		Block se = gc.GetBlock (seIndex);
		Block sw = gc.GetBlock (swIndex);
		Block nu = gc.GetBlock (nuIndex);
		Block nd = gc.GetBlock (ndIndex);
		Block su = gc.GetBlock (suIndex);
		Block sd = gc.GetBlock (sdIndex);

		northWalls ["Wall"].SetActive (north == null);
		northWalls ["Left"].SetActive (north != null && nw == null && west == null);
		northWalls ["Right"].SetActive (north != null && ne == null && east == null);
		northWalls ["JLeft"].SetActive (north != null && nw != null && west == null);
		northWalls ["JRight"].SetActive (north != null && ne != null && east == null);

		southWalls ["Wall"].SetActive (south == null);
		southWalls ["Left"].SetActive (south != null && se == null && east == null);
		southWalls ["Right"].SetActive (south != null && sw == null && west == null);
		southWalls ["JLeft"].SetActive (south != null && se != null && east == null);
		southWalls ["JRight"].SetActive (south != null && sw != null && west == null);

		eastWalls ["Wall"].SetActive (east == null);
		eastWalls ["Left"].SetActive (east != null && ne == null && north == null);
		eastWalls ["Right"].SetActive (east != null && se == null && south == null);
		eastWalls ["JLeft"].SetActive (east != null && ne != null && north == null);
		eastWalls ["JRight"].SetActive (east != null && se != null && south == null);

		westWalls ["Wall"].SetActive (west == null);
		westWalls ["Left"].SetActive (west != null && sw == null && south == null);
		westWalls ["Right"].SetActive (west != null && nw == null && north == null);
		westWalls ["JLeft"].SetActive (west != null && sw != null && south == null);
		westWalls ["JRight"].SetActive (west != null && nw != null && north == null);

		walls ["NEWall"].SetActive (north == null && east == null);
		walls ["NWWall"].SetActive (north == null && west == null);
		walls ["SEWall"].SetActive (south == null && east == null);
		walls ["SWWall"].SetActive (south == null && west == null);

		if (chain) {
			if(north != null) north.UpdateWalls ();
			if(south != null) south.UpdateWalls ();
			if(east != null) east.UpdateWalls ();
			if(west != null) west.UpdateWalls ();

			if(ne != null) ne.UpdateWalls ();
			if(nw != null) nw.UpdateWalls ();
			if(se != null) se.UpdateWalls ();
			if(sw != null) sw.UpdateWalls ();
		}
	}
	
	void Update () {
		
	}
}
