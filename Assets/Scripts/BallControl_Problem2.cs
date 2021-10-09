using UnityEngine;

public class BallControl_Problem2 : MonoBehaviour
{
    private Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        ResetBall();
        Invoke("PushBall", 1); //Remove this to rollback to Problem 1
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