﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JoystickInput : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler {

	private Image backgroundImage;
	private Image joystickImage;

	private Vector2 backgroundSize;
	private Vector2 pivot;

	private float horizontal;

	void Start()
	{
		backgroundImage = GetComponent<Image>();
		joystickImage = transform.GetChild(0).GetComponent<Image>();

		backgroundSize = backgroundImage.rectTransform.sizeDelta;

		pivot = backgroundImage.rectTransform.pivot;
		pivot.x -= 0.5f;
		pivot.y -= 0.5f;
		pivot *= 2;
	}

	public void OnDrag(PointerEventData data) {
		Vector2 pos;
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle (
			backgroundImage.rectTransform,
			data.position,
			data.pressEventCamera,
			out pos
		))
		{
			pos.x = pos.x / backgroundSize.x * 2 + pivot.x;
			pos.y = pos.y / backgroundSize.y * 2 + pivot.y;

			if (pos.magnitude > 1)
			{
				pos.Normalize();
			}

			horizontal = pos.x;
			if (Mathf.Abs(horizontal) < 0.15f) {
				horizontal = 0;
			}

			MoveJoystick(pos);
		}
	}

	public void OnPointerDown(PointerEventData data) {
		OnDrag(data);
	}

	public void OnPointerUp(PointerEventData data)
	{
		MoveJoystick(Vector2.zero);
		horizontal = 0;
	}

	private void MoveJoystick(Vector2 inputVector)
	{
		inputVector.x *= backgroundSize.x / 2f;
		inputVector.y = 0;
		joystickImage.rectTransform.anchoredPosition = inputVector;
	}

	public float GetHorizontal()
	{
		return horizontal;
	}
	
}
