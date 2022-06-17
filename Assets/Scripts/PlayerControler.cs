using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float speed = 10, horizontalSpeed = 10;
    [SerializeField] float smootheValue = 2.0f;
    [SerializeField] float smootheValue2 = 0.125f;
    [SerializeField] float crashForce = 2f;
    float newXPos,movementValue;
    [HideInInspector] public float rotateForce = 0;
    Rigidbody rb;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        anim.SetBool("isRunning", true);
    }

    // Update is called once per frame
    void Update()
    {
#if PLATFORM_ANDROID

       
        if (Input.touchCount > 0)
        {
            movementValue = Input.touches[0].deltaPosition.x * 0.1f;
        }

#else
		
		 movementValue = Input.GetAxisRaw("Horizontal");
#endif


        newXPos = Mathf.Lerp(transform.position.x, transform.position.x +movementValue  * Time.deltaTime * horizontalSpeed + rotateForce * Time.deltaTime, smootheValue);

    }
    private void FixedUpdate()
    {
        rb.MovePosition(new Vector3(Mathf.Lerp(transform.position.x, newXPos, smootheValue2), transform.position.y, transform.position.z + speed * Time.fixedDeltaTime));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Rival")
        {
            Vector3 distance = transform.position - collision.gameObject.transform.position;

            distance.Normalize();

            collision.transform.position = Vector3.Lerp(collision.transform.position, collision.transform.position - distance * crashForce, 2.0f);
        }

    }
}
