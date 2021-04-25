using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    
    [SerializeField] AudioClip blockSound;

    Level level;

    private void Start()
    {
        level = FindObjectOfType<Level>();   
        level.CountBreakableBlocks(); 
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
       DestroyBlock();
    }

    private void DestroyBlock()
    {
         AudioSource.PlayClipAtPoint(blockSound, Camera.main.transform.position);
        Destroy(gameObject);    
        level.BlockDestroyed();
    }
}
