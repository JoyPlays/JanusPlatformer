using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

	// This script is designated to move platforms up and down.
	// Lift service for player to get from point A to point B.

	public GameObject player;
	public Vector3 destination;
	public float timeToTarget = 1;

	private float t = 0;
	private bool startElevator = false;
	private Vector3 startingPosition;
	private Quaternion startingRotation;
	
	public void Start()
	{
		// Set initial position of the elevator
		startingPosition = transform.position;
		startingRotation = transform.rotation;

		destination = new Vector3(transform.position.x, destination.y, transform.position.z);
	}

	public void Update()
	{
		if (Input.GetKeyDown(KeyCode.E))
		{
			startElevator = true;
		}
		if (startElevator)
		{
			t += Time.deltaTime / timeToTarget;
			MoveLift(t);
		}
	}

	public void MoveLift(float time)
	{
		if (destination == transform.position)
		{
			destination = startingPosition;
			startingPosition = transform.position;
			startElevator = false;
			t = 0;
		}
		else
		{
			transform.position = Vector3.Lerp(startingPosition, destination, time);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == player)
		{
			player.transform.parent = transform;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject == player)
		{
			player.transform.parent = null;
		}
	}
}
