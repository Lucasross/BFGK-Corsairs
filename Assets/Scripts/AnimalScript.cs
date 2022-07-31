using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalScript : MonoBehaviour
{
    public bool poulet;

    void Update()
    {
        if (poulet)
        {
            transform.position = new Vector2(Mathf.PingPong(Time.time * 3, 10), transform.position.y);
        }
        else
            transform.position = new Vector2(Mathf.PingPong(Time.time, 6), transform.position.y);
    }
}
