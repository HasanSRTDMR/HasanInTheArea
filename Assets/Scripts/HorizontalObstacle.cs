using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalObstacle : MonoBehaviour
{
    [SerializeField] float speed, max, min;
    bool isMax;
   // Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        isMax = transform.position.x >= max;
        //rb = GetComponent<Rigidbody>();
    }   

    // Update is called once per frame
    void Update()
    {
        //rb.MovePosition(new Vector3(Mathf.Lerp(min, max, speed), transform.position.y, transform.position.z));
        if (isMax)
        {
            transform.position = new Vector3(transform.position.x-speed*Time.deltaTime, transform.position.y, transform.position.z);
            if (transform.position.x <= min)
                isMax = false;
        }
        else 
        {
            transform.position = new Vector3(transform.position.x +speed * Time.deltaTime, transform.position.y, transform.position.z);
            if (transform.position.x >= max)
                isMax = true;
        }

    }
}
