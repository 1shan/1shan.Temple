using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BeamControl : MonoBehaviour {
	public GameObject Beam_ControlPoint;
	public GameObject BeamSet;
	public CatMullRomManage cmrmanage;
	private LineRenderer lineRenderer;
	public List<Transform> BeamCPList = new List<Transform> ();

	// Use this for initialization
	void Start () {
		lineRenderer = GetComponent<LineRenderer> ();

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void SetBeam () {
		BeamCPList.Insert (0,cmrmanage.controlPointsList [cmrmanage.controlPointsList.Count - 2]);







//		lineRenderer.SetVertexCount (BeamCPList.Count);
//		for (int i = 0; i < BeamCPList.Count; i++) {
//			lineRenderer.SetPosition (i, BeamCPList[i].transform.position);

	
	}
}
