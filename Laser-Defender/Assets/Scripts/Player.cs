using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header ("Speed:")]
    [SerializeField] float moveSpeed = 5f;
    Vector2 rawInput;
    Vector2 minBounds;
    Vector2 maxBounds;
    [Header ("Pending Amounts:")]
    [SerializeField] float pendingRight;
    [SerializeField] float pendingLeft;
    [SerializeField] float pendingTop;
    [SerializeField] float pendingBottom;

    void Start() 
    {
        InItBoundaries();
    }
    void Update()
    {
        Move();
    }

    void InItBoundaries()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0,0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1,1));
    }

    void Move()
    {
        Vector2 delta = rawInput * moveSpeed * Time.deltaTime;
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + pendingLeft, maxBounds.x - pendingRight);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + pendingBottom, maxBounds.y - pendingTop);
        transform.position = newPos;
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }


}
