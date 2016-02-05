using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class MouseEvent : MonoBehaviour
{
	public GameObject ControlPoint;
	public GameObject ColliderPlane;
	public CatMullRomManage cmrmanage;
	public BeamControl beamcontrol;
	public ButtonEvent buttonevent;
	public GameObject chooseOBJ = null;
	float x, y;
	public LayerMask uilayer;
	//float speed = 100.0f;
	// Use this for initialization
	void Start ()
	{
	
	}

	// Update is called once per frame
	void Update ()
	{
		
		if (Input.GetMouseButtonDown (0) && buttonevent.isadd ) {
			MouseCreatCP ();
		}

		if (Input.GetMouseButtonDown (0) && buttonevent.ismove ) {
			if (chooseOBJ) {
				
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit;
				if (Physics.Raycast (ray, out hit)) {
					if (chooseOBJ.tag == "CP") {

						
					}
				}


			} else {
				 
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit;
				if (Physics.Raycast (ray, out hit)) {
					if (hit.collider.gameObject.tag == "CP") {
						chooseOBJ = hit.collider.gameObject;
					
					}
				}
			}
		}


		if (Input.GetMouseButtonDown (0) && buttonevent.isdel ) {
			MouseDeleteCP ();

		}



	}

	public void MouseCreatCP (){
		Vector3 mouse_pos = Input.mousePosition;
		mouse_pos.z = 0.0f;
		Ray ray = Camera.main.ScreenPointToRay (mouse_pos);
		RaycastHit hit;
		//Debug.Log ("mousePosition" + Input.mousePosition);
		if (Physics.Raycast (ray, out hit,1000f)) {
			cmrmanage.CreateCP (hit.point);
			//Debug.Log (copy.transform.position);
		}
			
	}
	public void MouseMoveCP(){
		Vector3 mouse_pos = Input.mousePosition;
		mouse_pos.z = 0.0f;
		Ray ray = Camera.main.ScreenPointToRay (mouse_pos);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit)) {
			cmrmanage.MoveCP (hit.collider.gameObject,hit.point);

		}

		
	}
	public void MouseDeleteCP(){
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit,1000f)) {
			cmrmanage.DeleteCP (hit.collider.gameObject);

			//Debug.Log (copy.transform.position);
		}


	}
	void OnMouseDown (){

		chooseOBJ.GetComponent<Renderer> ().material.color = Color.red;

	}



}
