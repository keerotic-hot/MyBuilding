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
			GameObject elm = block.GetChild(i).gameObject;
			walls.Add (elm.name,elm);
			elm.SetActive(false);
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
		northWalls.Add ("ET", walls ["JoinNET"]);
		northWalls.Add ("EB", walls ["JoinNEB"]);
		northWalls.Add ("WT", walls ["JoinNWT"]);
		northWalls.Add ("WB", walls ["JoinNWB"]);
		northWalls.Add ("TE", walls ["JoinNTE"]);
		northWalls.Add ("TW", walls ["JoinNTW"]);
		northWalls.Add ("BE", walls ["JoinNBE"]);
		northWalls.Add ("BW", walls ["JoinNBW"]);
		northWalls.Add ("CET", walls ["ETNCorner"]);
		northWalls.Add ("CWT", walls ["WTNCorner"]);
		northWalls.Add ("CEB", walls ["EBNCorner"]);
		northWalls.Add ("CWB", walls ["WBNCorner"]);

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
		eastWalls.Add ("NT", walls ["JoinENT"]);
		eastWalls.Add ("NB", walls ["JoinENB"]);
		eastWalls.Add ("ST", walls ["JoinEST"]);
		eastWalls.Add ("SB", walls ["JoinESB"]);
		eastWalls.Add ("TN", walls ["JoinETN"]);
		eastWalls.Add ("TS", walls ["JoinETS"]);
		eastWalls.Add ("BN", walls ["JoinEBN"]);
		eastWalls.Add ("BS", walls ["JoinEBS"]);
		eastWalls.Add ("CNT", walls ["NTECorner"]);
		eastWalls.Add ("CNB", walls ["NBECorner"]);
		eastWalls.Add ("CST", walls ["STECorner"]);
		eastWalls.Add ("CSB", walls ["SBECorner"]);

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
		southWalls.Add ("ET", walls ["JoinSET"]);
		southWalls.Add ("EB", walls ["JoinSEB"]);
		southWalls.Add ("WT", walls ["JoinSWT"]);
		southWalls.Add ("WB", walls ["JoinSWB"]);
		southWalls.Add ("TE", walls ["JoinSTE"]);
		southWalls.Add ("TW", walls ["JoinSTW"]);
		southWalls.Add ("BE", walls ["JoinSBE"]);
		southWalls.Add ("BW", walls ["JoinSBW"]);
		southWalls.Add ("CET", walls ["ETSCorner"]);
		southWalls.Add ("CWT", walls ["WTSCorner"]);
		southWalls.Add ("CEB", walls ["EBSCorner"]);
		southWalls.Add ("CWB", walls ["WBSCorner"]);

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
		westWalls.Add ("NT", walls ["JoinWNT"]);
		westWalls.Add ("NB", walls ["JoinWNB"]);
		westWalls.Add ("ST", walls ["JoinWST"]);
		westWalls.Add ("SB", walls ["JoinWSB"]);
		westWalls.Add ("TN", walls ["JoinWTN"]);
		westWalls.Add ("TS", walls ["JoinWTS"]);
		westWalls.Add ("BN", walls ["JoinWBN"]);
		westWalls.Add ("BS", walls ["JoinWBS"]);
		westWalls.Add ("CNT", walls ["NTWCorner"]);
		westWalls.Add ("CNB", walls ["NBWCorner"]);
		westWalls.Add ("CST", walls ["STWCorner"]);
		westWalls.Add ("CSB", walls ["SBWCorner"]);

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
		upWalls.Add ("TNE", walls ["JoinTNE"]);
		upWalls.Add ("TNW", walls ["JoinTNW"]);
		upWalls.Add ("TSE", walls ["JoinTSE"]);
		upWalls.Add ("TSW", walls ["JoinTSW"]);
		upWalls.Add ("TEN", walls ["JoinTEN"]);
		upWalls.Add ("TES", walls ["JoinTES"]);
		upWalls.Add ("TWN", walls ["JoinTWN"]);
		upWalls.Add ("TWS", walls ["JoinTWS"]);
		upWalls.Add ("CNE", walls ["NETCorner"]);
		upWalls.Add ("CNW", walls ["NWTCorner"]);
		upWalls.Add ("CSE", walls ["SETCorner"]);
		upWalls.Add ("CSW", walls ["SWTCorner"]);

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
		downWalls.Add ("BNE", walls ["JoinBNE"]);
		downWalls.Add ("BNW", walls ["JoinBNW"]);
		downWalls.Add ("BSE", walls ["JoinBSE"]);
		downWalls.Add ("BSW", walls ["JoinBSW"]);
		downWalls.Add ("BEN", walls ["JoinBEN"]);
		downWalls.Add ("BES", walls ["JoinBES"]);
		downWalls.Add ("BWN", walls ["JoinBWN"]);
		downWalls.Add ("BWS", walls ["JoinBWS"]);
		downWalls.Add ("CNE", walls ["NEBCorner"]);
		downWalls.Add ("CNW", walls ["NWBCorner"]);
		downWalls.Add ("CSE", walls ["SEBCorner"]);
		downWalls.Add ("CSW", walls ["SWBCorner"]);


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
		northWalls ["CET"].SetActive (north == null && east != null && up != null);
		northWalls ["CEB"].SetActive (north == null && east != null && down != null);
		northWalls ["CWT"].SetActive (north == null && west != null && up != null);
		northWalls ["CWB"].SetActive (north == null && west != null && down != null);
		northWalls ["ET"].SetActive (north != null && ne != null);
		northWalls ["EB"].SetActive (north != null && ne != null);
		northWalls ["WT"].SetActive (north != null && nw != null);
		northWalls ["WB"].SetActive (north != null && nw != null);
		northWalls ["TE"].SetActive (north != null && nt != null);
		northWalls ["TW"].SetActive (north != null && nt != null);
		northWalls ["BE"].SetActive (north != null && nb != null);
		northWalls ["BW"].SetActive (north != null && nb != null);


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
		southWalls ["CET"].SetActive (south == null && east != null && up != null);
		southWalls ["CEB"].SetActive (south == null && east != null && down != null);
		southWalls ["CWT"].SetActive (south == null && west != null && up != null);
		southWalls ["CWB"].SetActive (south == null && west != null && down != null);
		southWalls ["ET"].SetActive (south != null && se != null);
		southWalls ["EB"].SetActive (south != null && se != null);
		southWalls ["WT"].SetActive (south != null && sw != null);
		southWalls ["WB"].SetActive (south != null && sw != null);
		southWalls ["TE"].SetActive (south != null && st != null);
		southWalls ["TW"].SetActive (south != null && st != null);
		southWalls ["BE"].SetActive (south != null && sb != null);
		southWalls ["BW"].SetActive (south != null && sb != null);

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
		eastWalls ["CNT"].SetActive (east == null && north != null && up != null);
		eastWalls ["CNB"].SetActive (east == null && north != null && down != null);
		eastWalls ["CST"].SetActive (east == null && south != null && up != null);
		eastWalls ["CSB"].SetActive (east == null && south != null && down != null);
		eastWalls ["NT"].SetActive (east != null && ne != null);
		eastWalls ["NB"].SetActive (east != null && ne != null);
		eastWalls ["ST"].SetActive (east != null && se != null);
		eastWalls ["SB"].SetActive (east != null && se != null);
		eastWalls ["TN"].SetActive (east != null && et != null);
		eastWalls ["TS"].SetActive (east != null && et != null);
		eastWalls ["BN"].SetActive (east != null && eb != null);
		eastWalls ["BS"].SetActive (east != null && eb != null);

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
		westWalls ["CNT"].SetActive (west == null && north != null && up != null);
		westWalls ["CNB"].SetActive (west == null && north != null && down != null);
		westWalls ["CST"].SetActive (west == null && south != null && up != null);
		westWalls ["CSB"].SetActive (west == null && south != null && down != null);
		westWalls ["NT"].SetActive (west != null && nw != null);
		westWalls ["NB"].SetActive (west != null && nw != null);
		westWalls ["ST"].SetActive (west != null && sw != null);
		westWalls ["SB"].SetActive (west != null && sw != null);
		westWalls ["TN"].SetActive (west != null && wt != null);
		westWalls ["TS"].SetActive (west != null && wt != null);
		westWalls ["BN"].SetActive (west != null && wb != null);
		westWalls ["BS"].SetActive (west != null && wb != null);

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
		upWalls ["CNE"].SetActive (up == null && north != null && east != null);
		upWalls ["CNW"].SetActive (up == null && north != null && west != null);
		upWalls ["CSE"].SetActive (up == null && south != null && east != null);
		upWalls ["CSW"].SetActive (up == null && south != null && west != null);
		upWalls ["TNE"].SetActive (up != null && nt != null);
		upWalls ["TNW"].SetActive (up != null && nt != null);
		upWalls ["TSE"].SetActive (up != null && st != null);
		upWalls ["TSW"].SetActive (up != null && st != null);
		upWalls ["TEN"].SetActive (up != null && et != null);
		upWalls ["TES"].SetActive (up != null && et != null);
		upWalls ["TWN"].SetActive (up != null && wt != null);
		upWalls ["TWS"].SetActive (up != null && wt != null);

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
		downWalls ["CNE"].SetActive (down == null && north != null && east != null);
		downWalls ["CNW"].SetActive (down == null && north != null && west != null);
		downWalls ["CSE"].SetActive (down == null && south != null && east != null);
		downWalls ["CSW"].SetActive (down == null && south != null && west != null);
		downWalls ["BNE"].SetActive (down != null && nb != null);
		downWalls ["BNW"].SetActive (down != null && nb != null);
		downWalls ["BSE"].SetActive (down != null && sb != null);
		downWalls ["BSW"].SetActive (down != null && sb != null);
		downWalls ["BEN"].SetActive (down != null && eb != null);
		downWalls ["BES"].SetActive (down != null && eb != null);
		downWalls ["BWN"].SetActive (down != null && wb != null);
		downWalls ["BWS"].SetActive (down != null && wb != null);

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

			if (net != null) net.UpdateWalls ();
			if (neb != null) neb.UpdateWalls ();
			if (nwt != null) nwt.UpdateWalls ();
			if (nwb != null) nwb.UpdateWalls ();
			if (set != null) set.UpdateWalls ();
			if (seb != null) seb.UpdateWalls ();
			if (swt != null) swt.UpdateWalls ();
			if (swb != null) swb.UpdateWalls ();
		}
	}
	
	void Update () {
		
	}
}
