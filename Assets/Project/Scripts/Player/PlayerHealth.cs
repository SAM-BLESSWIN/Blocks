using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public Transform playerBody;
    public TMP_Text bodyCountText;
    private int bodyCount;

    private void Start()
    {
        bodyCount = playerBody.childCount;
        bodyCountText.text = bodyCount.ToString();
    }

    public void SetCount()
    {
        bodyCount = playerBody.childCount;
        bodyCountText.text = bodyCount.ToString();
    }

    public void TakeDamage()
    {
        bodyCount = playerBody.childCount;
        if (bodyCount <= 0)
        {
            GameManager.Instance.GameOver();
        }
        else
        {
            Destroy(playerBody.GetChild(bodyCount-1).gameObject);
        }
        
        bodyCountText.text = (bodyCount - 1).ToString();
    }
}
