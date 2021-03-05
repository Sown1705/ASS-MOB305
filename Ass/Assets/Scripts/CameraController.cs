using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public Transform playerTransform;
	private void Update()
	{
		if (playerTransform.position.x > transform.position.x)
		{
			transform.position = new Vector3(playerTransform.position.x,
				transform.position.y, transform.position.z);
		}
		if (playerTransform.position.y > transform.position.y)
		{
			transform.position = new Vector3(transform.position.x,
				playerTransform.position.y, transform.position.z);
		}
		else if (playerTransform.position.y < transform.position.y)
		{
			transform.position = new Vector3(transform.position.x,
				playerTransform.position.y, transform.position.z);
		}

	}
}
