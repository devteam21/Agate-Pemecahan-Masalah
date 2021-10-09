using UnityEngine;

public class BallControl_Problem5 : MonoBehaviour
{
    private Rigidbody2D rb2d;

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
