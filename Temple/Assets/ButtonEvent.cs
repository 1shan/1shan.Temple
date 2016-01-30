using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ButtonEvent : MonoBehaviour {


	public Button Button_add;
	public Button Button_move;
	public Button Button_del;
	public bool isadd = false;
	public bool ismove = false;
	public bool isdel = false;
	// Use this for initialization

	public void mode_AddCP(){
		isadd = true;
		ismove = false;
		isdel = false;
		print ("cliked");
	}
	public void mode_MoveCP(){
		isadd = false;
		ismove = true;
		isdel = false;
		print ("cliked");
	}
	public void mode_DelCP(){
		isadd = false;
		ismove = false;
		isdel = true;
		print ("cliked");
	}
}
