using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public Transform player;
    public ObjectPooling foodPool;
    public Vector2 foodSpawnXLimit;

    private void Start()
    {
        SpawnFood();
    }

    void SpawnFood()
    {
        foodPool.GetObject().transform.position = new Vector2(Random.Range(foodSpawnXLimit.x, foodSpawnXLimit.y),
            player.position.y + GameManager.Instance.foodDistance);

        Invoke(nameof(SpawnFood), Random.Range(GameManager.Instance.foodSpawnTimeRange.x, 
            GameManager.Instance.foodSpawnTimeRange.y));
    }
}
