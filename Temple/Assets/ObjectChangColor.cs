using UnityEngine;
using System.Collections;

public class ObjectChangColor : MonoBehaviour {
	public MouseEvent mouseevent;
	public bool isselect = false;
	float speed = 10000.0f;
	float x;
	float y;
	float z;







	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseOver (){
		GetComponent<Renderer> ().material.color = Color.red;
		if (Input.GetMouseButton(0)){
			y = Input.GetAxis("Mouse X") * Time.deltaTime * speed;
			x = Input.GetAxis("Mouse Y") * Time.deltaTime * speed;


			transform.Translate(y / 10, x / 10, 0);

		}





	}
	void OnMouseExit(){
		GetComponent<Renderer> ().material.color = Color.white;
	}

}
