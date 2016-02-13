using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Roof : MonoBehaviour {

	// Use this for initialization

	public CatMullRomManage catmullrommanage;



	public void RoofTrinangle(){
		MeshFilter mf = GetComponent<MeshFilter> ();
		Mesh mesh = mf.mesh;

		int number = catmullrommanage.ridgeList.Count*catmullrommanage.totalPointList.Count;
		Vector3[] vertices = new Vector3[number];
		for (int i = 0; i < catmullrommanage.ridgeList.Count; i++) {
			for (int j = 0;j<catmullrommanage.totalPointList.Count;j++)

				vertices [i * catmullrommanage.totalPointList.Count + j] = catmullrommanage.ridgeList [i].GetComponent<CatMullRomManage> ().totalPointList [j];
		}
		//Debug.Log (number);



		int[] triangles = new int[] {
			0, 1, 2

		};






		mesh.Clear ();
		mesh.vertices = vertices;
		mesh.triangles = triangles;
		//mesh.uv = uvs;
		mesh.Optimize ();
		mesh.RecalculateNormals ();
			
	}

//		Vector3[] vertices = new Vector3[] {
//
//			new Vector3 (-1, 1, 1),
//			new Vector3 (1, 1, 1),
//			new Vector3 (-1, -1, 1),
//			new Vector3 (1, -1, 1),
//
//
//		};
//
//		int[] triangles = new int[] {
//
//			0, 2, 3,
//
//		};
//		Vector2[] uvs = new Vector2[] {
//			new Vector2 (0, 1),
//			new Vector2 (0, 0),
//			new Vector2 (1, 1),
//
//		};

		




	

}
	
	

