using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl_Problem7 : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public ScoreController scoreController;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        ResetBall();
    }

    private void Update()
    {
        //Problem 5 Start
        Vector2 destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector3.MoveTowards(transform.position, destination, 5f * Time.deltaTime);
        //Problem 5 End
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Box")
        {
            scoreController.IncreaseCurrentScore(1);
            Destroy(collision.gameObject);
        }
    }

    private void ResetBall()
    {
        transform.position = Vector2.zero;
        rb2d.velocity = Vector2.zero;
    }

    private void PushBall()
    {
        rb2d.AddForce(new Vector2(10f, 8f));
    }
}
