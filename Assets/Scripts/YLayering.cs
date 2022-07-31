using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class YLayering : MonoBehaviour
{
    SpriteRenderer sprite;
	public float yOffset = 0;

	private void Start()
	{
		sprite = GetComponent<SpriteRenderer>();
	}

	void Update()
    {
        sprite.sortingOrder = Mathf.RoundToInt(-(transform.position.y + yOffset));        
    }

	public void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(new Vector3(transform.position.x, transform.position.y + yOffset, 0), 0.3f);
	}
}
