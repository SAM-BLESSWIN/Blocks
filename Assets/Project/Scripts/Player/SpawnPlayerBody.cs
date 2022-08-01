using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayerBody : MonoBehaviour
{
    public Transform playerBodyparent;
    public GameObject playerBodyPrefab;
    private float headHeight;
    private float bodyHeight;

    private void Start()
    {
        headHeight = GetComponent<SpriteRenderer>().bounds.size.y;
        bodyHeight = playerBodyPrefab.GetComponent<SpriteRenderer>().bounds.size.y;
    }

    public void Spawn(int count)
    {
        for(int i=0;i<count;i++)
        {
            int bodyCount = playerBodyparent.childCount;
            GameObject newBody = Instantiate(playerBodyPrefab, playerBodyparent);
            float spawnheight = headHeight + (bodyCount * bodyHeight);
            newBody.transform.localPosition = Vector3.down * spawnheight;

            newBody.TryGetComponent<BodyMovement>(out BodyMovement bodyMovement);
            
            if (bodyCount == 0)
            {
                bodyMovement?.SetFollowTarget(transform);
            }
            else
            {
                bodyMovement?.SetFollowTarget(playerBodyparent.GetChild(bodyCount - 1));
            }
        }
    }
}
