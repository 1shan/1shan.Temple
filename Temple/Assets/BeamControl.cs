using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BeamControl : MonoBehaviour {
	public GameObject Beam_ControlPoint;
	public CatMullRomManage cmrmanage;
	public Eave_manage eavemanage;
	public GameObject Beam_clone;
	public BeamControl beamcontrol;

	private LineRenderer lineRenderer;
	public List<GameObject> BeamCPList = new List<GameObject> ();
	public List<GameObject> RingBeamlist = new List<GameObject> ();

	public int number=3;


	public int lenthOfBeam=2;

	// Use this for initialization
	void Awake(){
		lineRenderer = GetComponent<LineRenderer>();
		if (!lineRenderer)
		{
			gameObject.AddComponent<LineRenderer>();
			lineRenderer = GetComponent<LineRenderer>();
		}
	}

	
	// Update is called once per frame
	void Update () {

	}
	public void SetBeam () {


		Vector3 ori = eavemanage.EaveobjList [0].position;
//		Vector3 pos = ori;
//	
//		for(int i =0;i<lenthOfBeam;i++){
//			pos.y = ori.y - 3.0f*i;
//		}
//		BeamCPList.Add (ori);
//		BeamCPList.Add (pos);
//		BeamRender ();
//
//		for (int i = 1; i < cmrmanage.RRnumber; i++) {
//			float angle = (float)i * 360 / (float)cmrmanage.RRnumber;
//			GameObject clone = Instantiate (this.gameObject, this.transform.position, Quaternion.identity) as GameObject;
//			clone.transform.parent = BeamSet.transform;
//			clone.transform.RotateAround (centerPos, Vector3.up, angle);
//		}
		Debug.Log("ori"+ori);
	
//		

		for (int i = 0; i < number; i++){
			AddBeamsControlPoint(new Vector3(ori.x,ori.y-( i * 2), ori.z));

		}
		RenderBeams ();

	
	}
	public void AddBeamsControlPoint(Vector3 point){
		
		Debug.Log ("BCP" + point);
		GameObject clone;
		clone = Instantiate (Beam_ControlPoint, point, Quaternion.identity) as GameObject;
		clone.transform.parent = this.gameObject.transform;
		BeamCPList.Add (clone);

	}

	public void RenderBeams(){
		lineRenderer.SetVertexCount (BeamCPList.Count);
		for (int i = 0; i < BeamCPList.Count; i++) {
			lineRenderer.SetPosition (i, BeamCPList [i].transform.position);
		}
	}

}


