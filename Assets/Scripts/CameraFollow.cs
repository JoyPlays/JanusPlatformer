using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform target;
	public float smoothSpeed = 10f;
	public float easeInSpeed = 5f;
	public Vector3 offsetRight;
	public Vector3 offsetLeft;

	private Vector3 offset;
	public static Vector3 initialOffset = new Vector3(0, 2.15f, -6.5f);

	public float MIN_X;
	public float MAX_X;
	public float MIN_Y;
	public float MAX_Y;
	public float MIN_Z;
	public float MAX_Z;

	private void Start()
	{
		offset = initialOffset;
	}

	// Update is called once per frame
	void Update()
    {
		// Get players direction (which direction he's pressing to);

		Vector3 inputs = Vector3.zero;
		inputs.x = Input.GetAxis("Horizontal");
		float checkSpeed = PlayerController.speed * inputs.x;
		// Set cameras position
		if (checkSpeed < -2.5)
		{
			offset = Vector3.Lerp(offset, offsetLeft, easeInSpeed * 1.5f * Time.deltaTime);
		}
		else if (checkSpeed > 2.5)
		{
			offset = Vector3.Lerp(offset, offsetRight, easeInSpeed * 1.5f * Time.deltaTime);
		}
		else
		{
			offset = Vector3.Lerp(offset, initialOffset, easeInSpeed * Time.deltaTime);
		}
		Vector3 desiredPosition = target.position + offset;
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
		transform.position = smoothedPosition;

		/*
		transform.position = new Vector3(
			Mathf.Clamp(transform.position.x, MIN_X, MAX_X),
			Mathf.Clamp(transform.position.y, MIN_Y, MAX_Y),
			Mathf.Clamp(transform.position.z, MIN_Z, MAX_Z));
		*/
	}


}
