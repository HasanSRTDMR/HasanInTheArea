using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    [SerializeField] PlayerControler playerControler;
    [SerializeField] bool left, right;
    [SerializeField] float rotateValue;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (right)
        {
            transform.Rotate(Vector3.forward * rotateValue * Time.deltaTime);
            left = false;
        }
        else if (left)
        {
            transform.Rotate(Vector3.back * rotateValue * Time.deltaTime);
            right = false;
        }
    }
    float CalculateRotateForce()
    {
        if (right)
        {
            return -rotateValue;
        }
        else
        {
            return rotateValue;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            playerControler.rotateForce = CalculateRotateForce();
            playerControler.speed = 5;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerControler.rotateForce = 0;
            playerControler.speed = 10;
        }
    }
}
