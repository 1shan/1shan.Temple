using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Roof : MonoBehaviour {

	// Use this for initialization

	public CatMullRomManage catmullrommanage;




	public void RoofTrinangle(){
		MeshFilter mf = GetComponent<MeshFilter> ();
		Mesh mesh = mf.mesh;
		Debug.Log ("ridgelistcount "+catmullrommanage.ridgeList.Count);


//		Vector3[] vertices = new Vector3[3];
//		vertices [0] = catmullrommanage.ridgeList [0].GetComponent<CatMullRomManage> ().controlPointsList [0].position;
//		vertices [1] = catmullrommanage.ridgeList [1].GetComponent<CatMullRomManage> ().controlPointsList [1].position;
//		vertices [2] = catmullrommanage.ridgeList [0].GetComponent<CatMullRomManage> ().controlPointsList [1].position;
		int number = (catmullrommanage.ridgeList.Count+1)*catmullrommanage.controlPointsList.Count;
		Vector3[] vertices = new Vector3[number];
		
		for (int ori = 0; ori < catmullrommanage.controlPointsList.Count; ori++) {
			vertices [ori] = catmullrommanage.controlPointsList [ori].position;
		}
		
		for (int i = 0; i < catmullrommanage.ridgeList.Count; i++) {
			for (int j = 0;j<catmullrommanage.controlPointsList.Count;j++)
		
				vertices [(i+1) * catmullrommanage.controlPointsList.Count + j] = catmullrommanage.ridgeList [i].GetComponent<CatMullRomManage> ().controlPointsList [j].position;
		}







//		int number = (catmullrommanage.ridgeList.Count+1)*catmullrommanage.totalPointList.Count;
//		Vector3[] vertices = new Vector3[number];

//		for (int ori = 0; ori < catmullrommanage.totalPointList.Count; ori++) {
//			vertices [ori] = catmullrommanage.totalPointList [ori];
//		}
//
//		for (int i = 0; i < catmullrommanage.ridgeList.Count; i++) {
//			for (int j = 0;j<catmullrommanage.totalPointList.Count;j++)
//
//				vertices [(i+1) * catmullrommanage.totalPointList.Count + j] = catmullrommanage.ridgeList [i].GetComponent<CatMullRomManage> ().totalPointList [j];
//		}
//		Debug.Log ("ALL:"+number);


//
//		for (int i = 0; i < number; i++) {
//			Debug.Log(vertices [i]);
//		}
		int[] triangles = new int[(catmullrommanage.ridgeList.Count+1) * (catmullrommanage.controlPointsList.Count - 1) * 6];
		int index = 0;
		for (int i = 0; i < catmullrommanage.ridgeList.Count+1; i++) {
			for (int j = 0; j < catmullrommanage.controlPointsList.Count - 1; j++) {
			
				triangles [index] = (((i + catmullrommanage.ridgeList.Count) % catmullrommanage.ridgeList.Count)*catmullrommanage.controlPointsList.Count)+j;
				triangles [index+1] = (((i + catmullrommanage.ridgeList.Count) % catmullrommanage.ridgeList.Count)*catmullrommanage.controlPointsList.Count)+j+1;
				triangles [index+2] = (((i -1+ catmullrommanage.ridgeList.Count) % catmullrommanage.ridgeList.Count)*catmullrommanage.controlPointsList.Count)+j+1;
				triangles [index+3] = (((i + catmullrommanage.ridgeList.Count) % catmullrommanage.ridgeList.Count)*catmullrommanage.controlPointsList.Count)+j;
				triangles [index+4] = (((i -1+ catmullrommanage.ridgeList.Count) % catmullrommanage.ridgeList.Count)*catmullrommanage.controlPointsList.Count)+j+1;
				triangles [index+5] = (((i -1+ catmullrommanage.ridgeList.Count) % catmullrommanage.ridgeList.Count)*catmullrommanage.controlPointsList.Count)+j;
				index += 6;
		
			}
		}



//		int[] triangles = new int[catmullrommanage.ridgeList.Count * (catmullrommanage.totalPointList.Count - 1) * 6];
//		int index = 0;
//		for (int i = 0; i < catmullrommanage.ridgeList.Count; i++) {
//			for (int j = 0; j < catmullrommanage.totalPointList.Count - 1; j++) {
//			
//				triangles [index] = (((i + catmullrommanage.ridgeList.Count) % catmullrommanage.ridgeList.Count)*catmullrommanage.totalPointList.Count)+j;
//				triangles [index+1] = (((i + catmullrommanage.ridgeList.Count) % catmullrommanage.ridgeList.Count)*catmullrommanage.totalPointList.Count)+j+1;
//				triangles [index+2] = (((i -1+ catmullrommanage.ridgeList.Count) % catmullrommanage.ridgeList.Count)*catmullrommanage.totalPointList.Count)+j+1;
//				triangles [index+3] = (((i + catmullrommanage.ridgeList.Count) % catmullrommanage.ridgeList.Count)*catmullrommanage.totalPointList.Count)+j;
//				triangles [index+4] = (((i -1+ catmullrommanage.ridgeList.Count) % catmullrommanage.ridgeList.Count)*catmullrommanage.totalPointList.Count)+j+1;
//				triangles [index+5] = (((i -1+ catmullrommanage.ridgeList.Count) % catmullrommanage.ridgeList.Count)*catmullrommanage.totalPointList.Count)+j;
//				index += 6;
//
//			}
//		}

		//

//		
//
//		Vector3[] normals = new Vector3[number];
//		Vector3 up = Vector3.up;
//		for (int i = 0; i < number; i++) {
//			Vector3 binnormal = Vector3.Cross (up, vertices [i]).normalized;
//			normals [i] = Vector3.Cross (vertices [i], binnormal);
//		}
////
		mesh.vertices = vertices;
		mesh.triangles = triangles;
		//mesh.normals = normals;
		//mesh.uv = uvs;
	}
}
	
	

