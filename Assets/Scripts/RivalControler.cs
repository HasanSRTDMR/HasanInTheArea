using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RivalControler : MonoBehaviour
{
    public Transform endPoint;
    [SerializeField] float crashForce=1.0f;
    
    NavMeshAgent navMesh;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        anim.SetBool("isRunning", true);
    }

    // Update is called once per frame
    void Update()
    {
        navMesh.destination=endPoint.position;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Rival"|| collision.gameObject.tag =="Player")
        {
           Vector3 distance = transform.position- collision.gameObject.transform.position;

            distance.Normalize();

           collision.transform.position = Vector3.Lerp(collision.transform.position,collision.transform.position - distance * crashForce, 2.0f);
            

        }
    }
}
