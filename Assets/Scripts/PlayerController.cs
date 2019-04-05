using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	public Animator playerAnimator;
	public GameObject weapon;
	private bool slash = false;

	public float walkingSpeed = 3f;
	public float runningSpeed = 6f;
	public static float speed = 0f;
	public float jumpHeight = 2f;
	public float groundDistance = 0.2f;
	public float dashDistance = 5f;
	public LayerMask ground;

	private Rigidbody body;
	private Vector3 inputs = Vector3.zero;
	private bool isGrounded = true;
	private Transform groundChecker;

	// Start is called before the first frame update
	void Start()
	{
		body = GetComponent<Rigidbody>();
		groundChecker = transform.GetChild(0);
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Fight();
		}

		// Code that makes the player sprint
		if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && Input.GetKey(KeyCode.LeftShift))
		{
			Debug.Log("Im Sprinting");
			speed = Mathf.Lerp(speed, runningSpeed, 0.5f);
		}
		else
		{
			speed = Mathf.Lerp(speed, walkingSpeed, 0.5f);
		}

		// Checks if player is grounded
		isGrounded = Physics.CheckSphere(groundChecker.position, groundDistance, ground, QueryTriggerInteraction.Ignore);
		inputs = Vector3.zero; 
		inputs.x = Input.GetAxis("Horizontal");

		// Rotates player model to the way it goes
		if (inputs != Vector3.zero)
		{
			transform.right = inputs;
		}
		else
		{
			speed = 0;
		}

		// Jump
		if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
		{
			body.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
		}

		// Animation for running / walking
		float animationSpeed = Mathf.Abs(speed * Input.GetAxis("Horizontal")); ;
		playerAnimator.SetFloat("Speed", animationSpeed);
	}

	void FixedUpdate()
	{
		if (!slash)
		{
			body.MovePosition(body.position + inputs * speed * Time.fixedDeltaTime);
		}
	}

	private void Fight()
	{
		if (!slash)
		{
			slash = true;
			StartCoroutine("SetWeaponCollider");
		}
	}

	IEnumerator SetWeaponCollider()
	{
		weapon.GetComponent<MeshCollider>().enabled = true;
		playerAnimator.SetTrigger("Slash");
		yield return new WaitForSeconds(0.5f);
		weapon.GetComponent<MeshCollider>().enabled = false;
		yield return new WaitForSeconds(0.5f);
		slash = false;
	}
}
