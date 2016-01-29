using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CatMullRomManage : MonoBehaviour
{
	public GameObject CP0;
	public GameObject CP1;
	public GameObject CP2;
	public GameObject CP3;
	public GameObject ControlPoint;

	public Color c1 = Color.white;
	public List<Transform> controlPointsList = new List<Transform> ();
	public List<Vector3> totalPointList = new List<Vector3> ();
	private LineRenderer lineRenderer;

	// Use this for initialization
	void Start ()
	{

		lineRenderer = GetComponent<LineRenderer> ();
		CalCatmullRomSpline ();
		Renderspline ();

	}

	// Update is called once per frame
	void Update ()
	{
		

		//GameObject CP_Clone = Instantiate (CPoint, Input.mousePosition, Quaternion.identity) as GameObject;
	}


	void CalCatmullRomSpline ()
	{	
		if (controlPointsList.Count == 4) {
			Debug.Log ("DO ME");
			//int i = controlPointsList.Count;
			Vector3 cp0pos = controlPointsList [0].position;
			Vector3 cp1pos = controlPointsList [1].position;
			Vector3 cp2pos = controlPointsList [2].position;
			Vector3 cp3pos = controlPointsList [3].position;
			Vector3 lastpos = Vector3.zero;
			
			Vector3 auxcp_s = endpoint (cp0pos,cp1pos);//輔助點
			Vector3 auxcp_e = endpoint (cp3pos,cp2pos);
			Debug.Log ("auxcp_s" + auxcp_s);
			Debug.Log ("auxcp_e" + auxcp_e);

			for (float t = 0; t < 1; t += 0.1f) {
				Vector3 newpos = ReturnCatmullRom (t, auxcp_s, cp0pos, cp1pos, cp2pos);
				if (t == 0) {
					lastpos = cp0pos;
					totalPointList.Add (lastpos);
					continue;
				}

				totalPointList.Add (newpos);
				lastpos = newpos;

			}
			for (float t = 0; t < 1; t += 0.1f) {
				Vector3 newpos = ReturnCatmullRom (t, cp0pos, cp1pos, cp2pos, cp3pos);
				if (t == 0) {
					lastpos = cp1pos;
					totalPointList.Add (lastpos);
					continue;
				}

				totalPointList.Add (newpos);
				lastpos = newpos;

			}
////
			for (float t = 0; t < 1; t += 0.1f) {
				Vector3 newpos = ReturnCatmullRom (t, cp1pos, cp2pos, cp3pos, auxcp_e);
				if (t == 0) {
					lastpos = cp2pos;
					totalPointList.Add (lastpos);
					continue;
				}

				totalPointList.Add (newpos);
				lastpos = newpos;
//
			}
		}
		Renderspline();
	}

	Vector3 ReturnCatmullRom (float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
	{
		Vector3 d = 0.5f * (2f * p1);
		Vector3 c = 0.5f * (p2 - p0);
		Vector3 b = 0.5f * (2f * p0 - 5f * p1 + 4f * p2 - p3);
		Vector3 a = 0.5f * (-p0 + 3f * p1 - 3f * p2 + p3);

		Vector3 pos = d + (c * t) + (b * t * t) + (a * t * t * t);

		return pos;
	}

	void Renderspline ()
	{
		
		lineRenderer.SetVertexCount (totalPointList.Count);
		for (int i = 0; i < totalPointList.Count; i++) {
			lineRenderer.SetPosition (i, totalPointList [i]);
		}


	}

	public void MoveCP (GameObject obj, Vector3 point)
	{//未完成移動物件
		obj.transform.position = point;
	}

	public void CreateCP (Vector3 point)
	{
		GameObject copy;
		copy = Instantiate (ControlPoint, point, Quaternion.identity)as GameObject;
		controlPointsList.Add (copy.transform);
		Debug.Log ("add.");
		CalCatmullRomSpline ();

	}
	 Vector3 endpoint(Vector3 cmid,Vector3 c2){

		Vector3 auxcp = Vector3.zero;
		auxcp.x =(2*cmid.x)-(c2.x);
		auxcp.y =(2*cmid.y)-(c2.y);
		auxcp.z = cmid.z;

		Debug.Log ("cmid" + cmid);
		Debug.Log ("c2" + c2);

		return auxcp;

	}
}