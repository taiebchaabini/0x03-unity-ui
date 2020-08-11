using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    private float sideWayForce = 100f;
    private int score = 0;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // FixedUpdate has the frequency of the physics system; it is called every fixed frame-rate frame
    void FixedUpdate()
    {
        if ( Input.GetKey("w")){
            rb.AddForce(0, 0, sideWayForce * speed * Time.deltaTime);
        }
        if ( Input.GetKey("s")){
            rb.AddForce(0, 0, -sideWayForce * speed * Time.deltaTime);
        }
        if ( Input.GetKey("d")){
            rb.AddForce(sideWayForce * speed * Time.deltaTime, 0, 0);
        }
        if ( Input.GetKey("a")){
            rb.AddForce(-sideWayForce * speed * Time.deltaTime, 0, 0);
        }
    }

    // Increments the value of score when the Player touches an object tagged Pickup
    void OnTriggerEnter(Collider other){
        if (other.tag == "Pickup"){
            score += 1;
            Destroy(other.gameObject);
        }
        Debug.Log($"Score: {score}");
    }

}
