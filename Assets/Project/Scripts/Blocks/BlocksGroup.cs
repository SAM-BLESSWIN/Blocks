using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksGroup : MonoBehaviour
{
    public Block[] blocks;
    public Transform player;
    
    public Vector2 yLimit;
    public GameObject blocksGroupGameobject;
    static int groupCount;

    void Start()
    {
        groupCount = FindObjectsOfType<BlocksGroup>().Length;
        SetBlocks();
    }

    void SetBlocks()
    {
        for(int i=0;i<blocks.Length;i++)
        {
            blocks[i].SetBlockValue();
        }
    }

    void RepositionBlocks()
    {
        transform.position = new Vector2(0,player.position.y + GameManager.Instance.blocksDistance * groupCount);
        blocksGroupGameobject.transform.localPosition = new Vector2(0, Random.Range(yLimit.x,yLimit.y));    
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            RepositionBlocks();
            SetBlocks();
        }
    }
}
