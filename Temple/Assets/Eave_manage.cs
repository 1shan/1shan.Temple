using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Eave_manage : MonoBehaviour {
	public CatMullRomManage cmrmanage;
	private LineRenderer lineRenderer;
	public List<Transform> EaveobjList = new List<Transform> ();


	// Use this for initialization
	void Start () {	
		lineRenderer = GetComponent<LineRenderer> ();

		

	}
	// Update is called once per frame

	public void eavepointconnect(){
		
		EaveobjList.Insert (0,cmrmanage.controlPointsList [cmrmanage.controlPointsList.Count - 2]);
		for(int i = 0;i<cmrmanage.ridgeList.Count;i++){
			EaveobjList.Add(cmrmanage.ridgeList[i].GetComponent<CatMullRomManage>().controlPointsList[cmrmanage.ridgeList[i].GetComponent<CatMullRomManage>().controlPointsList.Count - 2].transform);
		}
		EaveobjList.Insert (EaveobjList.Count,cmrmanage.controlPointsList [cmrmanage.controlPointsList.Count - 2]);
		lineRenderer.SetVertexCount (EaveobjList.Count);
		for (int i = 0; i < EaveobjList.Count; i++) {
			lineRenderer.SetPosition (i, EaveobjList[i].transform.position);
		}
	}
}
