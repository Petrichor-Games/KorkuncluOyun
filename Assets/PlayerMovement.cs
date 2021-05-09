using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    //Movement
    public float speed;
    public float jump;
    float moveVelocity;
    private Rigidbody2D rgb;

    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();


    }



    void Update()
    {
      
        moveVelocity = 0;

        //Left Right Movement
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            moveVelocity = -speed;
            transform.localScale = new Vector3(-2, 2, 2);
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            moveVelocity = speed;
            transform.localScale = new Vector3(2, 2, 2);
        }

        if (Input.GetButtonDown("Jump") && Mathf.Approximately(rgb.velocity.y,0))
        {
            rgb.AddForce(Vector3.up * jump, ForceMode2D.Impulse);

        }

        rgb.velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);

    }
    
}