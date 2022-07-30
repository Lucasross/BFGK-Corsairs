using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class MasterCharacter : MonoBehaviour
{
	public int speed;

	private Rigidbody2D rb;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		rb.velocity = new Vector2(0, -speed);
	}
}
