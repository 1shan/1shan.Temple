using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class MouseEvent : MonoBehaviour
{
	public GameObject ControlPoint;
	public GameObject ColliderPlane;
	public CatMullRomManage cmrmanage;

	// Use this for initialization
	void Start ()
	{
	
	}

	// Update is called once per frame
	void Update ()
	{
		
		if (Input.GetMouseButtonDown (0)) {
			Vector3 mouse_pos = Input.mousePosition;
			mouse_pos.z = 0.0f;
			Ray ray = Camera.main.ScreenPointToRay (mouse_pos);
			RaycastHit hit;
			//Debug.Log ("mousePosition" + Input.mousePosition);
			if (Physics.Raycast (ray, out hit)) {
				cmrmanage.CreateCP (hit.point);
				//Debug.Log (copy.transform.position);
			}

		}


		
			
	

	}

	void MouseCreatCP ()
	{
		
	}


}
