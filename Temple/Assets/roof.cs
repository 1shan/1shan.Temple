using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Roof : MonoBehaviour {

	// Use this for initialization

	int number;

	public CatMullRomManage catmullrommanage;

	public Vector3[] vertices; 
	public List<GameObject> ringMirrorSplineList = new List<GameObject>();

	public void RoofTrinangle(){
		MeshFilter mf = GetComponent<MeshFilter> ();
		Mesh mesh = mf.mesh;





		number = (catmullrommanage.ridgeList.Count)*catmullrommanage.totalPointList.Count; 
		vertices = new Vector3[number];
//		vertices [0] = catmullrommanage.ridgeList [0].GetComponent<CatMullRomManage> ().controlPointsList [0].position;
//		vertices [1] = catmullrommanage.ridgeList [1].GetComponent<CatMullRomManage> ().controlPointsList [1].position;
//		vertices [2] = catmullrommanage.ridgeList [0].GetComponent<CatMullRomManage> ().controlPointsList [1].position;


//		Vector3[] vertices = new Vector3[number];
//		
//		for (int ori = 0; ori < catmullrommanage.controlPointsList.Count; ori++) {
//			vertices [ori] = catmullrommanage.controlPointsList [ori].position;
//		}


		ringMirrorSplineList = catmullrommanage.ridgeList;




		for (int i = 0; i < ringMirrorSplineList.Count; i++) {
			for (int j = 0; j < catmullrommanage.totalPointList.Count; j++) {
				catmullrommanage.GetComponent<CatMullRomManage> ().ridgeList [i].GetComponent<CatMullRomManage> ().CalCatmullRomSpline ();
				vertices [i  * catmullrommanage.totalPointList.Count + j] = catmullrommanage.GetComponent<CatMullRomManage>().ridgeList[i].GetComponent<CatMullRomManage>().totalPointList[j];
			}

		}




//		for (int i = 0; i < ringMirrorSplineList.Count; i++) {
////			for (int j = 0; j < catmullrommanage.totalPointList.Count; j++) {
//			roof_meshlist.Add (ringMirrorSplineList [i].GetComponent<CatMullRomManage>().totalPointList[j]);
//			}
//		//}


//
//		int number = (catmullrommanage.ridgeList.Count+1)*catmullrommanage.totalPointList.Count;  
//		Vector3[] vertices = new Vector3[number];
//
//		for (int ori = 0; ori < catmullrommanage.totalPointList.Count; ori++) {
//			vertices [ori] = catmullrommanage.totalPointList [ori];
//		}
//
//		for (int i = 0; i < catmullrommanage.ridgeList.Count; i++) {
//			for (int j = 0; j < catmullrommanage.totalPointList.Count; j++) {
//				//vertices [(i + 1) * catmullrommanage.totalPointList.Count + j] = catmullrommanage.ridgeList [i].GetComponent<>;
//			}
//		}
//	
//		Debug.Log ("ALL:"+number);
//
//
//
////		for (int i = 0; i < number; i++) {
////			Debug.Log(vertices [i]);
////		}
//
//
//
//
//		int[] triangles = new int[(catmullrommanage.ridgeList.Count+1) * (catmullrommanage.controlPointsList.Count - 1) * 6];
//		int index = 0;
//		for (int i = 0; i < catmullrommanage.ridgeList.Count+1; i++) {
//			for (int j = 0; j < catmullrommanage.controlPointsList.Count - 1; j++) {
//			
//				triangles [index] = (((i + catmullrommanage.ridgeList.Count) % catmullrommanage.ridgeList.Count)*catmullrommanage.controlPointsList.Count)+j;
//				triangles [index+1] = (((i + catmullrommanage.ridgeList.Count) % catmullrommanage.ridgeList.Count)*catmullrommanage.controlPointsList.Count)+j+1;
//				triangles [index+2] = (((i -1+ catmullrommanage.ridgeList.Count) % catmullrommanage.ridgeList.Count)*catmullrommanage.controlPointsList.Count)+j+1;
//				triangles [index+3] = (((i + catmullrommanage.ridgeList.Count) % catmullrommanage.ridgeList.Count)*catmullrommanage.controlPointsList.Count)+j;
//				triangles [index+4] = (((i -1+ catmullrommanage.ridgeList.Count) % catmullrommanage.ridgeList.Count)*catmullrommanage.controlPointsList.Count)+j+1;
//				triangles [index+5] = (((i -1+ catmullrommanage.ridgeList.Count) % catmullrommanage.ridgeList.Count)*catmullrommanage.controlPointsList.Count)+j;
//				index += 6;
//		
//			}
//		}
////


		int[] triangles = new int[catmullrommanage.ridgeList.Count * (catmullrommanage.totalPointList.Count - 1) * 6];
		int index = 0;
		for (int i = 0; i < catmullrommanage.ridgeList.Count; i++) {
			for (int j = 0; j < catmullrommanage.totalPointList.Count - 1; j++) {
			
				triangles [index] = (((i + catmullrommanage.ridgeList.Count) % catmullrommanage.ridgeList.Count)*catmullrommanage.totalPointList.Count)+j;
				triangles [index+1] = (((i + catmullrommanage.ridgeList.Count) % catmullrommanage.ridgeList.Count)*catmullrommanage.totalPointList.Count)+j+1;
				triangles [index+2] = (((i -1+ catmullrommanage.ridgeList.Count) % catmullrommanage.ridgeList.Count)*catmullrommanage.totalPointList.Count)+j+1;
				triangles [index+3] = (((i + catmullrommanage.ridgeList.Count) % catmullrommanage.ridgeList.Count)*catmullrommanage.totalPointList.Count)+j;
				triangles [index+4] = (((i -1+ catmullrommanage.ridgeList.Count) % catmullrommanage.ridgeList.Count)*catmullrommanage.totalPointList.Count)+j+1;
				triangles [index+5] = (((i -1+ catmullrommanage.ridgeList.Count) % catmullrommanage.ridgeList.Count)*catmullrommanage.totalPointList.Count)+j;
				index += 6;

			}
		}

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
	


