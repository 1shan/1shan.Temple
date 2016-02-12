using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class roof : MonoBehaviour {

	// Use this for initialization

	public CatMullRomManage catmullromanage;
	public List<Transform> ridgeList = new List<Transform> ();

	void Start () {
		 

	}

	public void RoofTrinangle(){
		MeshFilter mf = GetComponent<MeshFilter> ();
		Mesh mesh = mf.mesh;
		ridgeList = catmullromanage.ridgeList;
		if (ridgeList.Count < 2) return;
		int number = ridgeList.Count*catmullromanage.totalPointList.Count;
		Vector3[] vertices = new Vector3[number];
		vertices [0] = ridgeList [0].GetComponent<CatMullRomManage> ().totalPointList [0];
		vertices [1] = ridgeList [1].GetComponent<CatMullRomManage> ().totalPointList [5];
		vertices [2] = ridgeList [0].GetComponent<CatMullRomManage> ().totalPointList [5];



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
	
	

