using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ObjectDestroyer : MonoBehaviour
{
	private void OnCollisionEnter2D(Collision2D collision)
	{
		Destroy(collision.gameObject);
	}
}