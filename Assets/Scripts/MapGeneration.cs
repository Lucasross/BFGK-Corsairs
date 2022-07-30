using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour
{
	public Transform areaForGeneration;

	public List<GameObject> grounds;

	public void Start()
	{
		Instantiate(grounds[Random.Range(0, grounds.Count)], Vector3.zero, Quaternion.identity);
		Instantiate(grounds[Random.Range(0, grounds.Count)], areaForGeneration.transform.position, Quaternion.identity);
 	}
}
