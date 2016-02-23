using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ButtonEvent : MonoBehaviour {


	public Button Button_add;
	public Button Button_move;
	public Button Button_del;
	public Button Button_roofridge;
	public Button Button_Beam;
	public bool isadd = false;
	public bool ismove = false;
	public bool isdel = false;
	public bool isring = false;
	public bool isBeam = false;
	public CatMullRomManage cmrmanage;
	public Roof roof;
	public BeamControl beamcontrol;
	public int RRnumber;
	// Use this for initialization

	public void mode_AddCP(){
		isadd = true;
		ismove = false;
		isdel = false;
		isring = false;
		print ("cliked add");
	}
	public void mode_MoveCP(){
		isadd = false;
		ismove = true;
		isdel = false;
		isring = false;

		print ("cliked move");
	}
	public void mode_DelCP(){
		isadd = false;
		ismove = false;
		isdel = true;
		isring = false;
		print ("cliked del");
	}
	public void RingButton(){
		isadd = false;
		ismove = false;
		isdel = false;
		isring = true;
		//print ("cliked ring");
		cmrmanage.Ring (4);
		//roof.RoofTrinangle ();

	}
	public void RRaddBotton(){
		if (isring) {
			cmrmanage.RRP ();

		}



		
	}
	public void RRsubBotton(){
		if (isring) {
			cmrmanage.RRS ();

		}



	}
	public void BeamBotton(){
		isBeam = true;
		isring = false;
		beamcontrol.SetBeam ();
		cmrmanage.RingBeams ();


	}

}
