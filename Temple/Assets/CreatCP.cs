using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreatCP : MonoBehaviour {
	public GameObject CP0;
	public GameObject CP1;
	public GameObject CP2;
	public GameObject CP3;
	public Color c1 = Color.white;
	public List<Transform> controlPointsList = new List<Transform>();
	public List<Vector3> totalPointList = new List<Vector3>();
	private LineRenderer lineRenderer;

	// Use this for initialization
	void Start () {
		
		lineRenderer = GetComponent<LineRenderer>();
		CalCatmullRomSpline();
		Renderspline();

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//GameObject CP_Clone = Instantiate (CPoint, Input.mousePosition, Quaternion.identity) as GameObject;
	}


	void CalCatmullRomSpline(){
	

		Vector3 cp0pos = CP0.transform.position;
		Vector3 cp1pos = CP1.transform.position;
		Vector3 cp2pos = CP2.transform.position;
		Vector3 cp3pos = CP3.transform.position;
		Vector3 lastpos = Vector3.zero;


		for (float t = 0; t < 1; t += 0.1f) {
			Vector3 newpos = ReturnCatmullRom (t, (cp0pos*2)-(cp1pos), cp0pos, cp1pos, cp2pos);
			if (t == 0) {
				lastpos = cp0pos;
				totalPointList.Add (lastpos);
				continue;
			}

			totalPointList.Add (newpos);
			lastpos = newpos;

		}
//
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

		for (float t = 0; t < 1; t += 0.1f) {
			Vector3 newpos = ReturnCatmullRom (t, cp1pos, cp2pos, cp3pos, (cp3pos*2)-cp2pos);
			if (t == 0) {
				lastpos = cp2pos;
				totalPointList.Add (lastpos);
				continue;
			}

			totalPointList.Add (newpos);
			lastpos = newpos;

		}


	}

	Vector3 ReturnCatmullRom(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3) {
		Vector3 d = 0.5f * (2f * p1);
		Vector3 c = 0.5f * (p2 - p0);
		Vector3 b = 0.5f * (2f * p0 - 5f * p1 + 4f * p2 - p3);
		Vector3 a = 0.5f * (-p0 + 3f * p1 - 3f * p2 + p3);

		Vector3 pos = d + (c * t) + (b * t * t) + (a * t * t * t);

		return pos;
	}

	void Renderspline(){
		Debug.Log (totalPointList);
		lineRenderer.SetVertexCount (totalPointList.Count);
		for (int i = 0; i < totalPointList.Count; i++) {
			lineRenderer.SetPosition (i, totalPointList [i]);
			
		}


	}
}


