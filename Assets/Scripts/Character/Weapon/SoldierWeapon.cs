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

	public override void Fire(Vector3 mousePosition) {
		Debug.Log("soldier fire! " + GetCurrentMagazine() + "/" + magazine);

		Vector3 targetPosition = Camera.main.ScreenToWorldPoint(mousePosition);
		Vector3 direction = targetPosition - transform.position;


	}
}
