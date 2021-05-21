using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //config params
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparksVFX;
    [SerializeField] int maxHits = 2; //Serialized for Debug
    [SerializeField] Sprite[] hitSprites;

    //cached reference
    Level level;

    //state variables
    [SerializeField] int timesHit; //Serialized for Debug
    
    private void Start()
    {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if(tag == "breakable")
        {
            level.CountBlocks();
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(tag == "breakable")
        {
            HandleHits();
        }
    }

    private void HandleHits()
    {
        timesHit++;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit-1;
        GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    }

    private void DestroyBlock()
    {
        PlayBlockDestroySFX();
        FindObjectOfType<GameSession>().AddToScore();
        Destroy(gameObject);
        level.BlockDestoryed();
        TriggerSparksVFX();
    }

    private void PlayBlockDestroySFX()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    private void TriggerSparksVFX()
    {
        GameObject sparkles = Instantiate(blockSparksVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}