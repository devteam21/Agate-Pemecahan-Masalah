using System.Collections;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public ScoreController scoreController;
    public BoxSpawner boxSpawner;
    public GameObject gameoverScreen;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        ResetBall();

        //Problem 2 & 3
        //Invoke("PushBall", 1); 
    }

    private void Update()
    {
        //Problem 4 Start
        /*if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Vector3 position = transform.position;
            position.y += 0.5f;
            transform.position = position;
        } 
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Vector3 position = transform.position;
            position.x -= 0.5f;
            transform.position = position;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Vector3 position = transform.position;
            position.x += 0.5f;
            transform.position = position;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Vector3 position = transform.position;
            position.y -= 0.5f;
            transform.position = position;
        }*/
        //Problem 4 End

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
            StartCoroutine(delaySpawn());
        }
        else if (collision.gameObject.tag == "Obstacle")
        {
            scoreController.EndScore();
            gameoverScreen.SetActive(true);
            enabled = false;
        }
    }

   private IEnumerator delaySpawn()
    {
        yield return new WaitForSeconds(3);
        while (true)
        {
            float posX = Random.Range(-boxSpawner.boxTemplateWidth / 2, boxSpawner.boxTemplateWidth / 2);
            float posY = Random.Range(-boxSpawner.boxTemplateHeight / 2, boxSpawner.boxTemplateHeight / 2);
            if (posX != transform.position.x && posY != transform.position.y)
            {
                boxSpawner.SpawnBox(posX, posY);
                break;
            }
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
