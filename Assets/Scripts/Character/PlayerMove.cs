using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

	public JoystickInput joystick;
	public float speed;

	private Vector3 moveVector;
	private Animator animator;
 
    // Use this for initialization
    void Start () {
		moveVector = Vector3.zero;
		animator = GetComponent<Character>().GetAnimator();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		moveVector.x = joystick.GetHorizontal();
		bool isRun = Mathf.Abs(moveVector.x)> 0.1f;

		animator.SetBool("Run", isRun);
		animator.SetBool("Idle", !isRun);

		if (Mathf.Abs(moveVector.x) < 0.1f) {
			return;
		}

		moveVector.Normalize();

		Rotate(moveVector.x);
		transform.transform.position += moveVector * Time.fixedDeltaTime * speed;
    }

	private void Rotate(float moveX) {
		float angle = moveX < 0 ? 0 : 180;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
	}
}
