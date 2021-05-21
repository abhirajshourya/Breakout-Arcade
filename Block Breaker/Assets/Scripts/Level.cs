using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    //Counters-Trackers
    [SerializeField] int breakableBlocks; //Serialized for debugging purposes
    
    //cached reference
    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void CountBlocks()
    {
        breakableBlocks++;
    }

    public void BlockDestoryed()
    {
        breakableBlocks--;
        if(breakableBlocks<=0)
        {
            sceneLoader.LoadNextScreen();
        }
    }
}
