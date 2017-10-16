using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

	protected Transform block;

	protected Dictionary<string,GameObject> walls;
	protected Dictionary<string,GameObject> northWalls;
	protected Dictionary<string,GameObject> eastWalls;
	protected Dictionary<string,GameObject> southWalls;
	protected Dictionary<string,GameObject> westWalls;

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

	}
	
	void Update () {
		
	}
}
