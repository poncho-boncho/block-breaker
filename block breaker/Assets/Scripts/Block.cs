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
        level = FindObjectOfType<Level>();   
        level.CountBreakableBlocks();
        gameStatus = FindObjectOfType<GameStatus>(); 
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
       DestroyBlock();
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
}
