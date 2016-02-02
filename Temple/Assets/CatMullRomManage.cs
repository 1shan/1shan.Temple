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
	public GameObject Eave;
	public GameObject ridge;


	public Color c1 = Color.white;
	public List<Transform> controlPointsList = new List<Transform> ();
	public List<Vector3> totalPointList = new List<Vector3> ();
	public List<Transform> ridgeList = new List<Transform> ();
	public List<Vector3> EaveobjList = new List<Vector3> ();
	private LineRenderer lineRenderer;
	public int RRnumber;


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
		//CalCatmullRomSpline ();

		//GameObject CP_Clone = Instantiate (CPoint, Input.mousePosition, Quaternion.identity) as GameObject;
	}


	void CalCatmullRomSpline ()
	{	
		if (controlPointsList.Count < 2)
			return;
		else if (controlPointsList.Count == 2) {
			Vector3 cp0pos = controlPointsList [0].position;
			Vector3 cp1pos = controlPointsList [0].position;
			Vector3 cp2pos = controlPointsList [1].position;
			Vector3 cp3pos = controlPointsList [1].position;
			Vector3 lastpos = Vector3.zero;
			for (float t = 0; t < 1; t += 0.1f) {
				Vector3 newpos = ReturnCatmullRom (t, cp0pos, cp1pos, cp2pos, cp3pos);
				if (t == 0) {
					lastpos = cp0pos;
					totalPointList.Add (lastpos);
					continue;
				}

				totalPointList.Add (newpos);
				lastpos = newpos;

			}

		} else if (controlPointsList.Count == 3) {
			totalPointList.Clear ();
			//int i = controlPointsList.Count;
			Vector3 cp0pos = controlPointsList [0].position;
			Vector3 cp1pos = controlPointsList [1].position;
			Vector3 cp2pos = controlPointsList [2].position;
			Vector3 lastpos = Vector3.zero;

			Vector3 auxcp_s = endpoint (cp0pos, cp1pos);//輔助點
			Vector3 auxcp_e = endpoint (cp2pos, cp1pos);
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
			////
			for (float t = 0; t < 1; t += 0.1f) {
				Vector3 newpos = ReturnCatmullRom (t, cp0pos, cp1pos, cp2pos, auxcp_e);
				if (t == 0) {
					lastpos = cp1pos;
					totalPointList.Add (lastpos);
					continue;
				}

				totalPointList.Add (newpos);
				lastpos = newpos;
			}
		} else if (controlPointsList.Count > 3) {
			totalPointList.Clear ();
			Vector3 cp0pos, cp1pos, cp2pos, cp4pos, cp5pos, cp6pos;
			Vector3 p0, p1, p2, p3;
			cp0pos = controlPointsList [0].transform.position;
			cp1pos = controlPointsList [1].transform.position;
			cp2pos = controlPointsList [2].transform.position;

			Vector3 auxcp_s = endpoint (cp0pos, cp1pos);//輔助點
			Vector3 auxcp_e = endpoint (cp2pos, cp1pos);
			Vector3 lastpos = Vector3.zero;
			// first time
			for (float t = 0; t < 1; t += 0.05f) {
				Vector3 newpos = ReturnCatmullRom (t, auxcp_s, cp0pos, cp1pos, cp2pos);
				if (t == 0) {
					lastpos = cp0pos;
					totalPointList.Add (lastpos);
					continue;
				}

				totalPointList.Add (newpos);
				lastpos = newpos;

			}

			for (int i = 0; i < controlPointsList.Count - 3; i++) {
				p0 = controlPointsList [i].transform.position;
				p1 = controlPointsList [i + 1].transform.position;
				p2 = controlPointsList [i + 2].transform.position;
				p3 = controlPointsList [i + 3].transform.position;
				for (float t = 0; t < 1; t += 0.05f) {
					Vector3 newpos = ReturnCatmullRom (t, p0, p1, p2, p3);
					if (t == 0) {
						lastpos = p1;
						totalPointList.Add (lastpos);
						continue;
					}
					totalPointList.Add (newpos);
					lastpos = newpos;
				}
			}
			//lasttime
			for (float t = 0; t < 1; t += 0.05f) {
				int lastnode;
				lastnode = controlPointsList.Count;
				cp4pos = controlPointsList [lastnode - 3].transform.position;
				cp5pos = controlPointsList [lastnode - 2].transform.position;
				cp6pos = controlPointsList [lastnode - 1].transform.position;
				Vector3 newpos = ReturnCatmullRom (t, cp4pos, cp5pos, cp6pos, auxcp_e);
				if (t == 0) {
					lastpos = cp5pos;
					totalPointList.Add (lastpos);
					continue;
				}

				totalPointList.Add (newpos);
				lastpos = newpos;

			}


		}
		Renderspline ();
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

	Vector3 CatmullRom_tangent (float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
	{
		Vector3 c = 0.5f * (p2 - p0);
		Vector3 b = 0.5f * (2f * p0 - 5f * p1 + 4f * p2 - p3);
		Vector3 a = 0.5f * (-p0 + 3f * p1 - 3f * p2 + p3);
		Vector3 tv = c + 2 * (b * t * t) + 3 * (a * t * t * t);
		return tv;
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
		copy.transform.parent = gameObject.transform;//這樣才能夠用this旋轉屋頂
		controlPointsList.Add (copy.transform);
		//Debug.Log ("add.");
		CalCatmullRomSpline ();

	}

	Vector3 endpoint (Vector3 cmid, Vector3 c2)
	{

		Vector3 auxcp = Vector3.zero;
		auxcp.x = (2 * cmid.x) - (c2.x);
		auxcp.y = (2 * cmid.y) - (c2.y);
		auxcp.z = cmid.z;

		//Debug.Log ("cmid" + cmid);
		//Debug.Log ("c2" + c2);

		return auxcp;

	}

	public void DeleteCP (GameObject obj)
	{
		
		Destroy (obj);
		totalPointList.Clear ();





	}

	public void Ring (int num)
	{
		//Debug.Log ("Start ring");
		Vector3 centerPos = controlPointsList [0].position;
		//Debug.Log (controlPointsList [0].position);
		//Debug.Log (centerPos);
		RRnumber = num;

		ridgeList.Add (this.gameObject.transform);//自己也要加入
		for (int i = 1; i < RRnumber; i++) {
			float angle = (float)i * 360 / (float)RRnumber;
			GameObject clone = Instantiate (this.gameObject, this.transform.position, Quaternion.identity) as GameObject;
			clone.transform.parent = ridge.transform;
			clone.transform.RotateAround (centerPos, Vector3.up, angle);
			ridgeList.Add (clone.transform);

		}
		Debug.Log ("ridgeListcount:" + ridgeList.Count);
		EaveCPconnect ();
	}

	public void RRP ()
	{
		RRnumber = RRnumber + 1;


		for (int i = 0; i < ridgeList.Count; i++) {
			Destroy (ridgeList [i].gameObject);
		}
		ridgeList.Clear ();
		Ring (RRnumber);

	}

	public void RRS ()
	{
		if (RRnumber > 4) {
			RRnumber = RRnumber - 1;
			for (int i = 0; i < ridgeList.Count; i++) {
				Destroy (ridgeList [i].gameObject);
			}
			ridgeList.Clear ();
			Ring (RRnumber);
		}
	}

	public void EaveCPconnect ()
	{
		
		int i = controlPointsList.Count;//cp last node
		Vector2 eavepoint;
		Vector3 pos = controlPointsList [i - 1].transform.position;
		Vector3 centerPos = controlPointsList [0].position;
		centerPos.y = pos.y;
		EaveobjList.Add (pos);//他自己

		Debug.Log ("centerPos" + centerPos);
		Debug.Log ("Eavepoint1" + pos);

		for (int x = 0; x < RRnumber-1; x++) {//旋轉點的位置
			float angle = (float)x * 360 / (float)RRnumber;
			Vector3 dir = pos - centerPos;
			eavepoint = angle * dir  ;



			EaveobjList.Add (eavepoint);
			Debug.Log ("eavepoint" + eavepoint);
		}


//		for (int eave = 1; eave < RRnumber; eave++) {
//			float angle = (float)eave * 360 / (float)RRnumber;
//			GameObject clone = Instantiate (obj.gameObject, obj.transform.position, Quaternion.identity) as GameObject;
//			clone.transform.parent = Eave.transform;
//			clone.transform.RotateAround (centerPos, Vector3.up, angle);
//			EaveobjList.Add (clone.transform.position);
//			}
//		Debug.Log ("eaveobjListcount:" + EaveobjList.Count);
//		lineRenderer.SetVertexCount (EaveobjList.Count);
//		for (int j = 0; j < EaveobjList.Count; j++) {
//			lineRenderer.SetPosition (j, EaveobjList [j]);
//		}

	}



}