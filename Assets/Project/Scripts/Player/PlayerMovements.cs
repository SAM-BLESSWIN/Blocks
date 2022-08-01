using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    public float speed = 1;
    private float mouseDistance;
    private Rigidbody2D rb;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseDistance = worldPoint.x - transform.position.x;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(mouseDistance * speed, GameManager.Instance.gameSpeed);
    }
}
