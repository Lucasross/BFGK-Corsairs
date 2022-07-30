using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour
{
	public Transform areaForGeneration;
	public Transform areaForGenerationSecond;

	public List<GameObject> grounds;

	public void Start()
	{
		Instantiate(grounds[Random.Range(0, grounds.Count)], areaForGeneration.transform.position, Quaternion.identity);
		GenerateNextRoom();
	}

	public void GenerateNextRoom()
	{
		var x = Instantiate(grounds[Random.Range(0, grounds.Count)], areaForGenerationSecond.transform.position, Quaternion.identity);
		x.transform.position = new Vector3(0, Mathf.CeilToInt(x.transform.position.y), 0);
	}
}
