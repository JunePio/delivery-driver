using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 0.6f;
    [SerializeField] float moveSpeed = 0.06f;
    [SerializeField] float slowSpeed = 0.03f;
    [SerializeField] float boostSpeed = 0.1f;


    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "BoostSpeed")
        {
            moveSpeed = boostSpeed;
            Debug.Log("You are boosting, man!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal")* steerSpeed;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed;
        transform.Rotate(0,0, -steerAmount);
        transform.Translate(0, moveAmount, 0);        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        moveSpeed = slowSpeed;
    }

}
