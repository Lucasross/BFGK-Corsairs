using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalScript : MonoBehaviour
{
    void Update()
    {
        transform.position = new Vector2(Mathf.PingPong(Time.time, 6), transform.position.y);
    }
}
