using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Destructible")
		{
			Debug.Log("I hit a target");
			other.gameObject.GetComponent<Destructible>().DestructObject();
		}
	}
	private void OnCollisionEnter(Collision collision)
	{
		
		
	}
}
