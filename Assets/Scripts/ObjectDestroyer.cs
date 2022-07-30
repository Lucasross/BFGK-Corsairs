using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ObjectDestroyer : MonoBehaviour
{
	public MapGeneration map;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		map.GenerateNextRoom();
		Destroy(collision.gameObject);
	}
}
