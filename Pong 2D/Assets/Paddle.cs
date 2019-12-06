﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    float speed;
    float height;

    string input;
    public bool isRight;

    // Start is called before the first frame update
    void Start()
    {
        height = transform.localScale.y;
        speed = 5f;
    }

    public void Init (bool isRightPaddle)
    {
        isRight = isRightPaddle;

        Vector2 pos = Vector2.zero;

        if (isRightPaddle)
        {
            //Paddle placement on the right of the screen
            pos = new Vector2(GameManager.topRight.x, 0);
            pos -= Vector2.right * transform.localScale.x; //Left Padding

            input = "PaddleRight";
        }
        else
        {
            //Paddle placement on the left of the screen
            pos = new Vector2(GameManager.bottomLeft.x, 0); 
            pos += Vector2.right * transform.localScale.x; //Right Padding

            input = "PaddleLeft";
        }
        transform.position = pos;

        transform.name = input;
    }
    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis(input) * Time.deltaTime * speed; //Detecting the user inpput multiplied by framerate mutiplied by the speed of the paddle

        //Paddle movement edge of screen restriction
        if(transform.position.y < GameManager.bottomLeft.y + height / 2 && move < 0) //If paddle is too low and user is continuing to move down - stop
        {
            move = 0;
        }
        if (transform.position.y > GameManager.topRight.y - height / 2 && move > 0) //If paddle is too low and user is continuing to move up - stop
        {
            move = 0;
        }



        transform.Translate(move * Vector2.up);
    }
}
