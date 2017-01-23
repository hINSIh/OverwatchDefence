using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Camera))]
public class CameraFollow : MonoBehaviour {
	private struct LimitArea {
		public Vector3 min, max;
		public float fixedZAxis;

		public LimitArea(Vector3 min, Vector3 max, float fixedZAxis) {
			this.min = min;
			this.max = max;
			this.fixedZAxis = fixedZAxis;
		}

		public void SetZAxis() {
			min.z = fixedZAxis;
			max.z = fixedZAxis;
		}
	}

	public SpriteRenderer background;
	[Header("Character padding")]
	public float paddingLeft;

	new private Camera camera;
	private Character character;

	private Vector3 backgroundHalfSize;
	private LimitArea limitArea;

	private float screenWidth;
	private float screenHeight;

	private float moveYAxis;

	// Use this for initialization
	void Awake () {
		camera = GetComponent<Camera>();
		character = GameObject.FindWithTag("Player").GetComponent<Character>();
		backgroundHalfSize = background.bounds.extents;
		limitArea = new LimitArea(Vector3.zero, Vector3.zero, transform.position.z);

		UpdateLimitSize();
	}
	
	// Update is called once per frame
	void LateUpdate () {
		Vector3 targetPos = character.transform.position;
		targetPos.x += screenWidth - paddingLeft;
		targetPos.y = moveYAxis;

		transform.position = ClampVector(targetPos, limitArea.min, limitArea.max);
	}

	public float GetMaxOrthographicSize() {
		return backgroundHalfSize.y;
	}

	public void UpdateLimitSize() {
		screenHeight = camera.orthographicSize;
		screenWidth = screenHeight * camera.aspect;
		Vector3 cameraSize = new Vector3(screenWidth, screenHeight);

		Vector3 mapPosition = background.transform.position;
		Vector3 limitMagnitude = backgroundHalfSize - cameraSize;

		limitArea.min = mapPosition - limitMagnitude;
		limitArea.max = mapPosition + limitMagnitude;
		limitArea.SetZAxis();

		moveYAxis = mapPosition.y - backgroundHalfSize.y + screenHeight;
	}

	private Vector3 ClampVector(Vector3 value, Vector3 min, Vector3 max) {
		return Vector3.Max(Vector3.Min(value, max), min);
	}
}
