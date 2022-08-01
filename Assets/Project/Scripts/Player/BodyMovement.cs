using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyMovement : MonoBehaviour
{
    public float speed = 15;

    private Transform followTarget;
    private float height;

    private void Start()
    {
        height = transform.localPosition.y;
    }

    public void SetFollowTarget(Transform target)
    {
        followTarget = target;
    }

    void Update()
    {
        float distance = Mathf.Abs(followTarget.position.x - transform.position.x);

        float distanceDelta = speed * distance * Time.deltaTime;

        Vector2 newPosition = new Vector2(followTarget.position.x, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, newPosition, distanceDelta );

        transform.localPosition = new Vector2(transform.localPosition.x,height);
    }
}
