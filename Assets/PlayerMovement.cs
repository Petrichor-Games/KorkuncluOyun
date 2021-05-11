using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    //Movement
    public float speed;
    public float jump;
    float moveVelocity;
    private Rigidbody2D rgb;
    private Rigidbody2D _rigidbody2D;

    public GameObject HitScreen;
    
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

        rgb.velocity = new Vector2(moveVelocity, rgb.velocity.y);


        if (HitScreen !=null)
        {
            if (HitScreen.GetComponent<Image>().color.a > 0)
            {
                var color = HitScreen.GetComponent<Image>().color;
                color.a -= 0.01f;
                HitScreen.GetComponent<Image>().color = color;
            }
        }
        

    }

    public void TakeDamage(int amount)
    {
        //TODO
        var color = HitScreen.GetComponent<Image>().color;
        color.a = 0.8f;
        HitScreen.GetComponent<Image>().color = color;
    }
}