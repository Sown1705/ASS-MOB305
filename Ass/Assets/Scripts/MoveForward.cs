using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
	public float speed = .5f;

	public float maxDistance = 20;
	private Rigidbody2D rb2d;
	private float distance = 0;
	 private bool canMove = false;
	 void Start()
	{
		rb2d = GetComponent<Rigidbody2D>();
		distance = 0;
	}
	void Update()
	 {
		/*if (canMove)
		{
			GetComponent<Rigidbody2D>().velocity =
				new Vector2(transform.localScale.x, 0) * speed;
		}*/
		distance += Time.deltaTime * 2;
		if (distance > maxDistance)
		{
			transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z); ;
			distance = 0;
		}
		rb2d.velocity = new Vector2(-transform.localScale.x, 0) * speed;
	}

	 private void OnCollisionEnter2D(Collision2D collision)
	 {

			 canMove = collision.gameObject.tag == "Ground";
	 }

}
