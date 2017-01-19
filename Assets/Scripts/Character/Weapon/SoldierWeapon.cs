using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierWeapon : MagazineWeapon {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void Fire() {
		Debug.Log("soldier fire! " + GetCurrentMagazine() + "/" + magazine);
	}
}
