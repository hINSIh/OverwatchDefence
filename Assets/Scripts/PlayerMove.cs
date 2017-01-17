using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public NewBehaviourScript joystick;
 
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        joystick.GetHorizontal();

        if(joystick.GetHorizontal() > 0)
        {
            transform.Translate(-Vector3.left * Time.deltaTime);
        }

        if (joystick.GetHorizontal() < 0)
        {
            transform.Translate(Vector3.left * Time.deltaTime);
        }
    }
}
