using UnityEngine;
using System.Collections;

public class MouseEvent : MonoBehaviour {
	public GameObject CPpoint;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void MouseCreatCP(){
		if (Input.GetMouseButtonDown(0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray))
				Instantiate (CPpoint, transform.position, transform.position);
		}
	}

}
