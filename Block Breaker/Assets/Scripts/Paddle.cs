using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    //Config Parameters
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float x_min = 1f;
    [SerializeField] float x_max = 15f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //float Clamp(float mousePos, float min, float max);
        float mousePos = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(mousePos, x_min, x_max);
        transform.position = paddlePos;
         
    }
}
