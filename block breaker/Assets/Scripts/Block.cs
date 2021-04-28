using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    
    [SerializeField] AudioClip blockSound;
    [SerializeField] GameObject blockSparklesVFX;

    Level level;
    GameStatus gameStatus;

    private void Start()
    {

        CountBreakableBlocks();
        gameStatus = FindObjectOfType<GameStatus>(); 
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            DestroyBlock();
        }
       
    }

    private void DestroyBlock()
    { 
        PlayBlockDestroySFX();
        level.BlockDestroyed();
        gameStatus.AddToScore();
        TriggerSparklesVFX();
    }

    private void PlayBlockDestroySFX()
    {
        AudioSource.PlayClipAtPoint(blockSound, Camera.main.transform.position);
        Destroy(gameObject);   
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 2f);
    }
    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();   
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }
}
