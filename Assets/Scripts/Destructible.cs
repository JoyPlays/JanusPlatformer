using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
	public GameObject destroyedVersion;

	// Destroy the object
	public void DestructObject()
	{
		Instantiate(destroyedVersion, transform.position, transform.rotation);
		Destroy(gameObject);
	}

}
