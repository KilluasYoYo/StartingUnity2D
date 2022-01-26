using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 115.8f;
    [SerializeField] float moveSpeed = 18.3f;
    [SerializeField] float slowSpeed = 11.8f;
    [SerializeField] float fastSpeed = 32.3f;

   void OnTriggerEnter2D(Collider2D other)
   {
       if(other.tag == "Boosts")
       {
           moveSpeed = fastSpeed;
       }
   }
   void OnCollisionEnter2D(Collision2D other)
   {
       moveSpeed = slowSpeed;
   }


    void Start()
    {

    }

    void Update()
    {
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }
}
