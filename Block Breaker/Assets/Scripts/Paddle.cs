using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    //Config Parameters
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float x_min = 1f;
    [SerializeField] float x_max = 15f;

    //cached references
    GameSession thegameSession;
    Ball theball;
    // Start is called before the first frame update
    void Start()
    {
        thegameSession = FindObjectOfType<GameSession>();
        theball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        //float Clamp(float mousePos, float min, float max);
        
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), x_min, x_max);
        transform.position = paddlePos;
         
    }

    private float GetXPos()
    {
        if (thegameSession.IsAutoPlayEnabled())
        {
            return theball.transform.position.x;
        }
        else
        {
            return (Input.mousePosition.x / Screen.width * screenWidthInUnits);
        }
    }
}
