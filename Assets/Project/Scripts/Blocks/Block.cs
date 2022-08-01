using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Block : MonoBehaviour
{
    public TMP_Text countText;
    private int count;
    private float nextDamageTime;
    private PlayerHealth playerHealth;


    public void SetBlockValue()
    {
        gameObject.SetActive(true);
        count = Random.Range(0, GameManager.Instance.blockValue);

        if (count == 0)
        {
            gameObject.SetActive(false);
            return;
        }

        countText.text = count.ToString();
    }

    private void Update()
    {
        if(playerHealth!=null && nextDamageTime < Time.time)
        {
            PlayerDamage();
        }
    }

    void PlayerDamage()
    {
        nextDamageTime = Time.time + GameManager.Instance.damageTime;
        count--;
        countText.text = count.ToString();
        playerHealth?.TakeDamage();
        if (count <=0)
        {
            gameObject.SetActive(false);
            playerHealth = null;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerHealth = null;
        }
    }

}
