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
		northWalls.Add ("Top", walls ["NTWall"]);
		northWalls.Add ("Bottom", walls ["NBWall"]);
		northWalls.Add ("JLeft", walls ["NLJoin"]);
		northWalls.Add ("JRight", walls ["NRJoin"]);
		northWalls.Add ("JTop", walls ["NTJoin"]);
		northWalls.Add ("JBottom", walls ["NBJoin"]);
		northWalls.Add ("TL", walls ["NTLWall"]);
		northWalls.Add ("TR", walls ["NTRWall"]);
		northWalls.Add ("BL", walls ["NBLWall"]);
		northWalls.Add ("BR", walls ["NBRWall"]);

		eastWalls = new Dictionary<string,GameObject> ();
		eastWalls.Add ("Wall", walls ["EastWall"]);
		eastWalls.Add ("Left", walls ["ELWall"]);
		eastWalls.Add ("Right", walls ["ERWall"]);
		eastWalls.Add ("Top", walls ["ETWall"]);
		eastWalls.Add ("Bottom", walls ["EBWall"]);
		eastWalls.Add ("JLeft", walls ["ELJoin"]);
		eastWalls.Add ("JRight", walls ["ERJoin"]);
		eastWalls.Add ("JTop", walls ["ETJoin"]);
		eastWalls.Add ("JBottom", walls ["EBJoin"]);
		eastWalls.Add ("TL", walls ["ETLWall"]);
		eastWalls.Add ("TR", walls ["ETRWall"]);
		eastWalls.Add ("BL", walls ["EBLWall"]);
		eastWalls.Add ("BR", walls ["EBRWall"]);

		southWalls = new Dictionary<string,GameObject> ();
		southWalls.Add ("Wall", walls ["SouthWall"]);
		southWalls.Add ("Left", walls ["SLWall"]);
		southWalls.Add ("Right", walls ["SRWall"]);
		southWalls.Add ("Top", walls ["STWall"]);
		southWalls.Add ("Bottom", walls ["SBWall"]);
		southWalls.Add ("JLeft", walls ["SLJoin"]);
		southWalls.Add ("JRight", walls ["SRJoin"]);
		southWalls.Add ("JTop", walls ["STJoin"]);
		southWalls.Add ("JBottom", walls ["SBJoin"]);
		southWalls.Add ("TL", walls ["STLWall"]);
		southWalls.Add ("TR", walls ["STRWall"]);
		southWalls.Add ("BL", walls ["SBLWall"]);
		southWalls.Add ("BR", walls ["SBRWall"]);

		westWalls = new Dictionary<string,GameObject> ();
		westWalls.Add ("Wall", walls ["WestWall"]);
		westWalls.Add ("Left", walls ["WLWall"]);
		westWalls.Add ("Right", walls ["WRWall"]);
		westWalls.Add ("Top", walls ["WTWall"]);
		westWalls.Add ("Bottom", walls ["WBWall"]);
		westWalls.Add ("JLeft", walls ["WLJoin"]);
		westWalls.Add ("JRight", walls ["WRJoin"]);
		westWalls.Add ("JTop", walls ["WTJoin"]);
		westWalls.Add ("JBottom", walls ["WBJoin"]);
		westWalls.Add ("TL", walls ["WTLWall"]);
		westWalls.Add ("TR", walls ["WTRWall"]);
		westWalls.Add ("BL", walls ["WBLWall"]);
		westWalls.Add ("BR", walls ["WBRWall"]);

		upWalls = new Dictionary<string,GameObject> ();
		upWalls.Add ("Wall", walls ["Top"]);
		upWalls.Add ("North", walls ["TNWall"]);
		upWalls.Add ("East", walls ["TEWall"]);
		upWalls.Add ("South", walls ["TSWall"]);
		upWalls.Add ("West", walls ["TWWall"]);
		upWalls.Add ("JNorth", walls ["TNJoin"]);
		upWalls.Add ("JEast", walls ["TEJoin"]);
		upWalls.Add ("JSouth", walls ["TSJoin"]);
		upWalls.Add ("JWest", walls ["TWJoin"]);
		upWalls.Add ("NE", walls ["NETWall"]);
		upWalls.Add ("NW", walls ["NWTWall"]);
		upWalls.Add ("SE", walls ["SETWall"]);
		upWalls.Add ("SW", walls ["SWTWall"]);

		downWalls = new Dictionary<string,GameObject> ();
		downWalls.Add ("Wall", walls ["Bottom"]);
		downWalls.Add ("North", walls ["BNWall"]);
		downWalls.Add ("East", walls ["BEWall"]);
		downWalls.Add ("South", walls ["BSWall"]);
		downWalls.Add ("West", walls ["BWWall"]);
		downWalls.Add ("JNorth", walls ["BNJoin"]);
		downWalls.Add ("JEast", walls ["BEJoin"]);
		downWalls.Add ("JSouth", walls ["BSJoin"]);
		downWalls.Add ("JWest", walls ["BWJoin"]);
		downWalls.Add ("NE", walls ["NEBWall"]);
		downWalls.Add ("NW", walls ["NWBWall"]);
		downWalls.Add ("SE", walls ["SEBWall"]);
		downWalls.Add ("SW", walls ["SWBWall"]);

		northWalls["Left"].SetActive (false);
		northWalls["Right"].SetActive (false);
		northWalls["Top"].SetActive (false);
		northWalls["Bottom"].SetActive (false);
		northWalls["JLeft"].SetActive (false);
		northWalls["JRight"].SetActive (false);
		northWalls["JTop"].SetActive (false);
		northWalls["JBottom"].SetActive (false);
		northWalls["TL"].SetActive (false);
		northWalls["TR"].SetActive (false);
		northWalls["BL"].SetActive (false);
		northWalls["BR"].SetActive (false);

		eastWalls["Left"].SetActive (false);
		eastWalls["Right"].SetActive (false);
		eastWalls["Top"].SetActive (false);
		eastWalls["Bottom"].SetActive (false);
		eastWalls["JLeft"].SetActive (false);
		eastWalls["JRight"].SetActive (false);
		eastWalls["JTop"].SetActive (false);
		eastWalls["JBottom"].SetActive (false);
		eastWalls["TL"].SetActive (false);
		eastWalls["TR"].SetActive (false);
		eastWalls["BL"].SetActive (false);
		eastWalls["BR"].SetActive (false);

		southWalls["Left"].SetActive (false);
		southWalls["Right"].SetActive (false);
		southWalls["Top"].SetActive (false);
		southWalls["Bottom"].SetActive (false);
		southWalls["JLeft"].SetActive (false);
		southWalls["JRight"].SetActive (false);
		southWalls["JTop"].SetActive (false);
		southWalls["JBottom"].SetActive (false);
		southWalls["TL"].SetActive (false);
		southWalls["TR"].SetActive (false);
		southWalls["BL"].SetActive (false);
		southWalls["BR"].SetActive (false);

		westWalls["Left"].SetActive (false);
		westWalls["Right"].SetActive (false);
		westWalls["Top"].SetActive (false);
		westWalls["Bottom"].SetActive (false);
		westWalls["JLeft"].SetActive (false);
		westWalls["JRight"].SetActive (false);
		westWalls["JTop"].SetActive (false);
		westWalls["JBottom"].SetActive (false);
		westWalls["TL"].SetActive (false);
		westWalls["TR"].SetActive (false);
		westWalls["BL"].SetActive (false);
		westWalls["BR"].SetActive (false);

		upWalls["North"].SetActive (false);
		upWalls["East"].SetActive (false);
		upWalls["South"].SetActive (false);
		upWalls["West"].SetActive (false);
		upWalls["JNorth"].SetActive (false);
		upWalls["JEast"].SetActive (false);
		upWalls["JSouth"].SetActive (false);
		upWalls["JWest"].SetActive (false);
		upWalls["NE"].SetActive (false);
		upWalls["NW"].SetActive (false);
		upWalls["SE"].SetActive (false);
		upWalls["SW"].SetActive (false);

		downWalls["North"].SetActive (false);
		downWalls["East"].SetActive (false);
		downWalls["South"].SetActive (false);
		downWalls["West"].SetActive (false);
		downWalls["JNorth"].SetActive (false);
		downWalls["JEast"].SetActive (false);
		downWalls["JSouth"].SetActive (false);
		downWalls["JWest"].SetActive (false);
		downWalls["NE"].SetActive (false);
		downWalls["NW"].SetActive (false);
		downWalls["SE"].SetActive (false);
		downWalls["SW"].SetActive (false);

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
		Index3 ntIndex = gc.PositionToIndex (transform.localPosition + Vector3.forward + Vector3.up);
		Index3 nbIndex = gc.PositionToIndex (transform.localPosition + Vector3.forward + Vector3.down);

		Index3 seIndex = gc.PositionToIndex (transform.localPosition + Vector3.back + Vector3.right);
		Index3 swIndex = gc.PositionToIndex (transform.localPosition + Vector3.back + Vector3.left);
		Index3 stIndex = gc.PositionToIndex (transform.localPosition + Vector3.back + Vector3.up);
		Index3 sbIndex = gc.PositionToIndex (transform.localPosition + Vector3.back + Vector3.down);

		Index3 etIndex = gc.PositionToIndex (transform.localPosition + Vector3.right + Vector3.up);
		Index3 ebIndex = gc.PositionToIndex (transform.localPosition + Vector3.right + Vector3.down);
		Index3 wtIndex = gc.PositionToIndex (transform.localPosition + Vector3.left + Vector3.up);
		Index3 wbIndex = gc.PositionToIndex (transform.localPosition + Vector3.left + Vector3.down);

		Index3 netIndex = gc.PositionToIndex (transform.localPosition + Vector3.forward + Vector3.right + Vector3.up);
		Index3 nebIndex = gc.PositionToIndex (transform.localPosition + Vector3.forward + Vector3.right + Vector3.down);
		Index3 nwtIndex = gc.PositionToIndex (transform.localPosition + Vector3.forward + Vector3.left + Vector3.up);
		Index3 nwbIndex = gc.PositionToIndex (transform.localPosition + Vector3.forward + Vector3.left + Vector3.down);
		Index3 setIndex = gc.PositionToIndex (transform.localPosition + Vector3.back + Vector3.right + Vector3.up);
		Index3 sebIndex = gc.PositionToIndex (transform.localPosition + Vector3.back + Vector3.right + Vector3.down);
		Index3 swtIndex = gc.PositionToIndex (transform.localPosition + Vector3.back + Vector3.left + Vector3.up);
		Index3 swbIndex = gc.PositionToIndex (transform.localPosition + Vector3.back + Vector3.left + Vector3.down);

		Block north = gc.GetBlock (northIndex);
		Block east = gc.GetBlock (eastIndex);
		Block south = gc.GetBlock (southIndex);
		Block west = gc.GetBlock (westIndex);
		Block up = gc.GetBlock (upIndex);
		Block down = gc.GetBlock (downIndex);

		Block ne = gc.GetBlock (neIndex);
		Block nw = gc.GetBlock (nwIndex);
		Block nt = gc.GetBlock (ntIndex);
		Block nb = gc.GetBlock (nbIndex);

		Block se = gc.GetBlock (seIndex);
		Block sw = gc.GetBlock (swIndex);
		Block st = gc.GetBlock (stIndex);
		Block sb = gc.GetBlock (sbIndex);

		Block et = gc.GetBlock (etIndex);
		Block eb = gc.GetBlock (ebIndex);
		Block wt = gc.GetBlock (wtIndex);
		Block wb = gc.GetBlock (wbIndex);

		Block net = gc.GetBlock (netIndex);
		Block neb = gc.GetBlock (nebIndex);
		Block nwt = gc.GetBlock (nwtIndex);
		Block nwb = gc.GetBlock (nwbIndex);
		Block set = gc.GetBlock (setIndex);
		Block seb = gc.GetBlock (sebIndex);
		Block swt = gc.GetBlock (swtIndex);
		Block swb = gc.GetBlock (swbIndex);

		northWalls ["Wall"].SetActive (north == null);
		northWalls ["Left"].SetActive (north != null && nw == null && west == null);
		northWalls ["Right"].SetActive (north != null && ne == null && east == null);
		northWalls ["Top"].SetActive (north != null && nt == null && up == null);
		northWalls ["Bottom"].SetActive (north != null && nb == null && down == null);
		northWalls ["JLeft"].SetActive (north != null && nw != null && west == null);
		northWalls ["JRight"].SetActive (north != null && ne != null && east == null);
		northWalls ["JTop"].SetActive (north != null && nt != null && up == null);
		northWalls ["JBottom"].SetActive (north != null && nb != null && down == null);
		northWalls ["TL"].SetActive (north != null && nw == null && west == null && nt == null && up == null);
		northWalls ["TR"].SetActive (north != null && ne == null && east == null && nt == null && up == null);
		northWalls ["BL"].SetActive (north != null && nw == null && west == null && nb == null && down == null);
		northWalls ["BR"].SetActive (north != null && ne == null && east == null && nb == null && down == null);


		southWalls ["Wall"].SetActive (south == null);
		southWalls ["Left"].SetActive (south != null && se == null && east == null);
		southWalls ["Right"].SetActive (south != null && sw == null && west == null);
		southWalls ["Top"].SetActive (south != null && st == null && up == null);
		southWalls ["Bottom"].SetActive (south != null && sb == null && down == null);
		southWalls ["JLeft"].SetActive (south != null && se != null && east == null);
		southWalls ["JRight"].SetActive (south != null && sw != null && west == null);
		southWalls ["JTop"].SetActive (south != null && st != null && up == null);
		southWalls ["JBottom"].SetActive (south != null && sb != null && down == null);
		southWalls ["TL"].SetActive (south != null && se == null && east == null && st == null && up == null);
		southWalls ["TR"].SetActive (south != null && sw == null && west == null && st == null && up == null);
		southWalls ["BL"].SetActive (south != null && se == null && east == null && sb == null && down == null);
		southWalls ["BR"].SetActive (south != null && sw == null && west == null && sb == null && down == null);

		eastWalls ["Wall"].SetActive (east == null);
		eastWalls ["Left"].SetActive (east != null && ne == null && north == null);
		eastWalls ["Right"].SetActive (east != null && se == null && south == null);
		eastWalls ["Top"].SetActive (east != null && et == null && up == null);
		eastWalls ["Bottom"].SetActive (east != null && eb == null && down == null);
		eastWalls ["JLeft"].SetActive (east != null && ne != null && north == null);
		eastWalls ["JRight"].SetActive (east != null && se != null && south == null);
		eastWalls ["JTop"].SetActive (east != null && et != null && up == null);
		eastWalls ["JBottom"].SetActive (east != null && eb != null && down == null);
		eastWalls ["TL"].SetActive (east != null && ne == null && north == null && et == null && up == null);
		eastWalls ["TR"].SetActive (east != null && se == null && south == null && et == null && up == null);
		eastWalls ["BL"].SetActive (east != null && ne == null && north == null && eb == null && down == null);
		eastWalls ["BR"].SetActive (east != null && se == null && south == null && eb == null && down == null);

		westWalls ["Wall"].SetActive (west == null);
		westWalls ["Left"].SetActive (west != null && sw == null && south == null);
		westWalls ["Right"].SetActive (west != null && nw == null && north == null);
		westWalls ["Top"].SetActive (west != null && wt == null && up == null);
		westWalls ["Bottom"].SetActive (west != null && wb == null && down == null);
		westWalls ["JLeft"].SetActive (west != null && sw != null && south == null);
		westWalls ["JRight"].SetActive (west != null && nw != null && north == null);
		westWalls ["JTop"].SetActive (west != null && wt != null && up == null);
		westWalls ["JBottom"].SetActive (west != null && wb != null && down == null);
		westWalls ["TL"].SetActive (west != null && sw == null && south == null && wt == null && up == null);
		westWalls ["TR"].SetActive (west != null && nw == null && north == null && wt == null && up == null);
		westWalls ["BL"].SetActive (west != null && sw == null && south == null && wb == null && down == null);
		westWalls ["BR"].SetActive (west != null && nw == null && north == null && wb == null && down == null);

		upWalls ["Wall"].SetActive (up == null);
		upWalls ["North"].SetActive (up != null && nt == null && north == null);
		upWalls ["South"].SetActive (up != null && st == null && south == null);
		upWalls ["East"].SetActive (up != null && et == null && east == null);
		upWalls ["West"].SetActive (up != null && wt == null && west == null);
		upWalls ["JNorth"].SetActive (up != null && nt != null && north == null);
		upWalls ["JSouth"].SetActive (up != null && st != null && south == null);
		upWalls ["JEast"].SetActive (up != null && et != null && east == null);
		upWalls ["JWest"].SetActive (up != null && wt != null && west == null);
		upWalls ["NE"].SetActive (up != null && north == null && east == null && nt == null && et == null);
		upWalls ["NW"].SetActive (up != null && north == null && west == null && nt == null && wt == null);
		upWalls ["SE"].SetActive (up != null && south == null && east == null && st == null && et == null);
		upWalls ["SW"].SetActive (up != null && south == null && west == null && st == null && wt == null);

		downWalls ["Wall"].SetActive (down == null);
		downWalls ["North"].SetActive (down != null && nb == null && north == null);
		downWalls ["South"].SetActive (down != null && sb == null && south == null);
		downWalls ["East"].SetActive (down != null && eb == null && east == null);
		downWalls ["West"].SetActive (down != null && wb == null && west == null);
		downWalls ["JNorth"].SetActive (down != null && nb != null && north == null);
		downWalls ["JSouth"].SetActive (down != null && sb != null && south == null);
		downWalls ["JEast"].SetActive (down != null && eb != null && east == null);
		downWalls ["JWest"].SetActive (down != null && wb != null && west == null);
		downWalls ["NE"].SetActive (down != null && north == null && east == null && nb == null && eb == null);
		downWalls ["NW"].SetActive (down != null && north == null && west == null && nb == null && wb == null);
		downWalls ["SE"].SetActive (down != null && south == null && east == null && sb == null && eb == null);
		downWalls ["SW"].SetActive (down != null && south == null && west == null && sb == null && wb == null);

		walls ["NE"].SetActive (north == null && east == null);
		walls ["NW"].SetActive (north == null && west == null);
		walls ["SE"].SetActive (south == null && east == null);
		walls ["SW"].SetActive (south == null && west == null);
		walls ["NT"].SetActive (north == null && up == null);
		walls ["NB"].SetActive (north == null && down == null);
		walls ["ST"].SetActive (south == null && up == null);
		walls ["SB"].SetActive (south == null && down == null);
		walls ["ET"].SetActive (east == null && up == null);
		walls ["EB"].SetActive (east == null && down == null);
		walls ["WT"].SetActive (west == null && up == null);
		walls ["WB"].SetActive (west == null && down == null);

		walls ["NET"].SetActive (north == null && east == null && up == null);
		walls ["NEB"].SetActive (north == null && east == null && down == null);
		walls ["NWT"].SetActive (north == null && west == null && up == null);
		walls ["NWB"].SetActive (north == null && west == null && down == null);
		walls ["SET"].SetActive (south == null && east == null && up == null);
		walls ["SEB"].SetActive (south == null && east == null && down == null);
		walls ["SWT"].SetActive (south == null && west == null && up == null);
		walls ["SWB"].SetActive (south == null && west == null && down == null);

		if (chain) {
			if(north != null) north.UpdateWalls ();
			if(south != null) south.UpdateWalls ();
			if(east != null) east.UpdateWalls ();
			if(west != null) west.UpdateWalls ();
			if(up != null) up.UpdateWalls ();
			if(down != null) down.UpdateWalls ();

			if(ne != null) ne.UpdateWalls ();
			if(nw != null) nw.UpdateWalls ();
			if(nt != null) nt.UpdateWalls ();
			if(nb != null) nb.UpdateWalls ();

			if(se != null) se.UpdateWalls ();
			if(sw != null) sw.UpdateWalls ();
			if(st != null) st.UpdateWalls ();
			if(sb != null) sb.UpdateWalls ();

			if(et != null) et.UpdateWalls ();
			if(eb != null) eb.UpdateWalls ();
			if(wt != null) wt.UpdateWalls ();
			if(wb != null) wb.UpdateWalls ();
		}
	}
	
	void Update () {
		
	}
}
