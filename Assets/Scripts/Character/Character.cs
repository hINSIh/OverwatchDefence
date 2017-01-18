using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour{

    private ISkillHandler skillHandler;

	// Use this for initialization
	void Start () {
        skillHandler = GetComponent<ISkillHandler>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
