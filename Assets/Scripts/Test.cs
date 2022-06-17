using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField]float speed, verticalVel;
    CharacterController cc;
    [SerializeField]bool isGrounded;
    public bool blockRotationPlayer;
    public float desiredRotationSpeed = 0.1f;

    Vector3 moveVector;
    Vector3 desiredMoveDirection;
    float inputX,inputZ=1;

    // Start is called before the first frame update
    void Start()
    {        
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {        
        cc.Move(new Vector3(0, 0, 1 * speed * Time.deltaTime));
        isGrounded = cc.isGrounded;
        if (isGrounded)
        {
            verticalVel -= 0;
        }
        else
        {
            verticalVel -= 1;
        }
        moveVector = new Vector3(0, verticalVel * .2f * Time.deltaTime, 0);
        cc.Move(moveVector);
        Rotation();
    }
    void Rotation()
    {
        inputX = Input.GetAxis("Horizontal");
        var cam = Camera.main;
        var forward = cam.transform.forward;
        var right = cam.transform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        desiredMoveDirection = forward * inputZ + right * inputX;
        if (blockRotationPlayer == false)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection), desiredRotationSpeed);
            cc.Move(desiredMoveDirection * Time.deltaTime * speed);
        }
    }
  
}
