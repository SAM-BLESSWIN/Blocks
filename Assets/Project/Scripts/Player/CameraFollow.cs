using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    private Vector2 followOffset;

    void Start()
    {
        followOffset = transform.position - player.position;
    }

    void Update()
    {
        transform.position = new Vector3(0, player.position.y + followOffset.y, -10f);
    }
}
