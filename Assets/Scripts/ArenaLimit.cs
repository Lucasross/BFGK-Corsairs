using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ArenaLimit : MonoBehaviour
{
	public Transform cameraRef;

	[Range(-15, 15)] public float limitY;
	[Range(-15, 15)] public float limitYNeg;
	[Range(-15, 15)] public float limitX;

	private Rigidbody2D rb;

	public bool master;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	void LateUpdate()
	{

		if(!master)
		{
			if (transform.position.y < limitYNeg + cameraRef.position.y && rb.velocity.y < 0)
				rb.velocity = rb.velocity * Vector2.right;

			if (transform.position.y > limitY + cameraRef.position.y && rb.velocity.y > 0)
				rb.velocity = rb.velocity * Vector2.right;
		}
		else
		{
			if (transform.position.y < limitYNeg + cameraRef.position.y)
				rb.position = new Vector2(rb.position.x, limitYNeg + cameraRef.position.y);
		}

		if (transform.position.y > limitY + cameraRef.position.y)
			rb.position = new Vector2(rb.position.x, limitY + cameraRef.position.y);

		if (transform.position.x < -limitX && rb.velocity.x < 0)
			rb.velocity = rb.velocity * Vector2.up;

		if (transform.position.x > limitX && rb.velocity.x > 0)
			rb.velocity = rb.velocity * Vector2.up;
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.DrawWireCube(new Vector3(limitX + cameraRef.position.x, 0, 0), Vector3.one);
		Gizmos.DrawWireCube(new Vector3(-limitX + cameraRef.position.x, 0, 0), Vector3.one);

		Gizmos.DrawWireCube(new Vector3(0, limitY + cameraRef.position.y, 0), Vector3.one);
		Gizmos.DrawWireCube(new Vector3(0, limitYNeg + cameraRef.position.y, 0), Vector3.one);
	}
}
