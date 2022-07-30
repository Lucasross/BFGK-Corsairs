using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Pushable : MonoBehaviour
{
	private void Awake()
	{
		var rb = GetComponent<Rigidbody2D>();

		rb.freezeRotation = true;
		rb.drag = 100;
	}
}
