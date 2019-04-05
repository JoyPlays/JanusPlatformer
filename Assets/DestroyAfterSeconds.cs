using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSeconds : MonoBehaviour
{

	public float destroyAfter = 0f;

    // Update is called once per frame
    void Start()
    {
		StartCoroutine("RemoveObject", destroyAfter); 
    }

	IEnumerator RemoveObject(float destroyAfter)
	{
		yield return new WaitForSeconds(destroyAfter);
		Destroy(gameObject);
	}
}
