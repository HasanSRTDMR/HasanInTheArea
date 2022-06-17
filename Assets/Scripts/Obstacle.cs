using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] Vector2 horizontalMinMax,verticleMinMax;
    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.tag=="Player"|| collision.gameObject.tag == "Rival")
        {
            collision.gameObject.transform.position = new Vector3(Random.Range(horizontalMinMax.x, horizontalMinMax.y), 0.2f, Random.Range(verticleMinMax.x, verticleMinMax.y));
           
        }
    }

}
