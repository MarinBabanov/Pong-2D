using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    float speed;

    float radius;
    Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        direction = Vector2.one.normalized; //direction is (1,1) normalized
        radius = transform.localScale.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        //Bounce off Top and Bottom
        if (transform.position.y < GameManager.bottomLeft.y + radius && direction.y < 0)
        {
            direction.y = -direction.y;
        }
        if (transform.position.y > GameManager.topRight.y - radius && direction.y > 0)
        {
            direction.y = -direction.y;
        }

        //Game Over
        if (transform.position.x < GameManager.bottomLeft.x + radius && direction.x < 0)
        {
            Debug.Log("Player 2 Winds!");
            Time.timeScale = 0; //Stops game
        }
        if (transform.position.x > GameManager.topRight.x - radius && direction.x > 0)
        {
            Debug.Log("Player 1 Wins!");
            Time.timeScale = 0; //Stops game
        }

        void OnTriggerEnter2D(Collider2D other) //Dunno why it does not work
        {
            if (other.tag == "Paddle") // Linked to the tag of the paddle, still not recognized
            {
                bool isRight = other.GetComponent<Paddle>().isRight;

                if (isRight == true && direction.x > 0)
                {
                    direction.x = -direction.x;
                }
                if (isRight == false && direction.x < 0)
                {
                    direction.x = -direction.x;
                }
            }
        }
    }
}
