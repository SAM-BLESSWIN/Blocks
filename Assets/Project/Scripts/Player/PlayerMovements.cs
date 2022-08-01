using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    public float speed = 1;
    private float mouseDistance;
    private Rigidbody2D rb;
    
    public Vector2 screenXLimit;
    private float playerWidth;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerWidth = GetComponent<SpriteRenderer>().bounds.size.x / 2;
    }

    void Update()
    {
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseDistance = worldPoint.x - transform.position.x;
        ClampPlayer();
    }

    private void ClampPlayer()
    {
        Vector3 viewPosition = transform.position;
        viewPosition.x = Mathf.Clamp(viewPosition.x, screenXLimit.x + playerWidth, screenXLimit.y - playerWidth);
        transform.position = viewPosition;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(mouseDistance * speed, GameManager.Instance.gameSpeed);
    }
}
