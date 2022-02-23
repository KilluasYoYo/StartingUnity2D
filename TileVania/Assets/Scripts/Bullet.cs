using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 10f;
    Rigidbody2D bulletRigidBody;

    void Start()
    {
        bulletRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        bulletRigidBody.velocity = new Vector2 (-bulletSpeed * Mathf.Sign(transform.rotation.z), 0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
        Destroy(gameObject);    
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject, 2f);    
    }
}
