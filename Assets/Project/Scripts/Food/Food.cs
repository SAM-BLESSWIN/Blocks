using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Food : MonoBehaviour
{
    public TMP_Text countText;
    private int count;

    private void OnEnable()
    {
        count = (int)Random.Range(GameManager.Instance.foodValueRange.x,GameManager.Instance.foodValueRange.y);
        countText.text = count.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.TryGetComponent<SpawnPlayerBody>(out SpawnPlayerBody spawnPlayerBody);
            spawnPlayerBody?.Spawn(count);

            collision.TryGetComponent<PlayerHealth>(out PlayerHealth playerHealth);
            playerHealth?.SetCount();

            GameManager.Instance.UpdateScore(count);
        }
        gameObject.SetActive(false);
    }
}
