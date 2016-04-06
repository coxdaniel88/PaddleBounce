using UnityEngine;
using System.Collections;

public class BallMove : MonoBehaviour {
    public float speed = 15;

	void Start () {
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        //Left Paddle
        if (col.gameObject.name == "PaddleA")
        {
            float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);

            Vector2 dir = new Vector2(1, y).normalized;

            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
        //Right Paddle
        if (col.gameObject.name == "PaddleB")
        {
            float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);

            Vector2 dir = new Vector2(-1, y).normalized;

            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

        if(col.gameObject.name == "WallLeft")
        {
            //yield return new WaitForSeconds(1);
            transform.position = new Vector3(0, 0, 0);
            Vector2 dir = new Vector2(-1, 0).normalized;

            GetComponent<Rigidbody2D>().velocity = dir * (speed/2);
        }
        if (col.gameObject.name == "WallRight")
        {
            //yield return new WaitForSeconds(1);
            transform.position = new Vector3(0, 0, 0);
            Vector2 dir = new Vector2(1, 0).normalized;

            GetComponent<Rigidbody2D>().velocity = dir * (speed/2);
        }
    }

    float hitFactor(Vector2 ballPos, Vector2 paddlePos, float paddleHeight)
    {
        return (ballPos.y - paddlePos.y) / paddleHeight;
    }
}
