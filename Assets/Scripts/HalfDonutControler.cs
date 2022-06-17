using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfDonutControler : MonoBehaviour
{
    [SerializeField] Transform movingStick;
    [SerializeField] Rigidbody movingStickRigidbody;
    [SerializeField] Vector2 moveLimit;
    [SerializeField] float lerpSpeed=1.0f;
    bool trig = true;
   
    
    void Start()
    {
        movingStick.transform.position = new Vector3(moveLimit.x,movingStick.position.y,movingStick.position.z);
        
    }
  
    private void OnTriggerExit(Collider other)
    {
        if (trig)
        {
        movingStickRigidbody.AddForce(new Vector3(moveLimit.y, 0, 0), ForceMode.Impulse);
            trig = false;

        }
       movingStick.position = new Vector3(Mathf.Lerp(moveLimit.x, moveLimit.y, lerpSpeed), movingStick.position.y, movingStick.position.z);
    }
}
