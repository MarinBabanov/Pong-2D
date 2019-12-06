﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Ball ball;
    public Paddle paddle;

    public static Vector2 bottomLeft; //Screen Boundaries
    public static Vector2 topRight; //Screen Boundaries
    // Start is called before the first frame update
    void Start()
    {
        //Converting the game boundaries
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        topRight = Camera.main.ScreenToWorldPoint(new Vector2 (Screen.width, Screen.height));

        Instantiate(ball);

        Paddle paddle1 = Instantiate (paddle) as Paddle;
        Paddle paddle2 = Instantiate (paddle) as Paddle;

        paddle1.Init (true);
        paddle2.Init (false);
    }
}
