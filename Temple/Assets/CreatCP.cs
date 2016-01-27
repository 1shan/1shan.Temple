using UnityEngine;
using System.Collections;

public class CreatCP : MonoBehaviour {
	public GameObject CPoint;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GameObject CP_Clone = Instantiate (CPoint, Input.mousePosition, Quaternion.identity) as GameObject;
	}

}
