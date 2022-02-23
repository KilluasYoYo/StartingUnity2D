using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody2D enemyRigidBody;
    [SerializeField] float enemyMoveSpeed = 5f;
    BoxCollider2D enemyHeadCollider;
    CapsuleCollider2D enemyBodyCollider;
    Transform enemyTransform;



    void Start()
    {
        enemyRigidBody = GetComponent<Rigidbody2D>();
        enemyHeadCollider = GetComponent<BoxCollider2D>();
        enemyTransform = GetComponent<Transform>();
    }

    void Update()
    {
        enemyRigidBody.velocity = new Vector2 (enemyMoveSpeed, 0f);
    }
    void OnTriggerExit2D(Collider2D other) 
    {
        enemyMoveSpeed = -enemyMoveSpeed;
        FlipEnemyFace();
    }

    void FlipEnemyFace()
    {
        transform.localScale = new Vector2 (-(Mathf.Sign(enemyRigidBody.velocity.x)), 1f);
    }


}
