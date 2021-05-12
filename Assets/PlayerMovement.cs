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
    public int karaktercan;
    public GameObject HitScreen;
    public Slider Canbar;
    public AudioSource audioSource;
    public AudioClip clip;
    public AudioClip clip2;
    public GameObject yazi;
    public GameObject btnExit;
    
    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
        karaktercan = 100;
        yazi.SetActive(false);
        btnExit.SetActive(false);
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

        Canbar.value = karaktercan;

        if (HitScreen !=null)
        {
            if (HitScreen.GetComponent<Image>().color.a > 0)
            {
                var color = HitScreen.GetComponent<Image>().color;
                color.a -= 0.01f;
                HitScreen.GetComponent<Image>().color = color;
            }
        }

        if (transform.position.y <= -12)
        {
            OldumMequ(true);
        }

    }

    public void OldumMequ(bool nassi)
    {
        var anakarakter = GameObject.FindGameObjectWithTag("anakarakter");
        if (nassi)
        {
            audioSource.PlayOneShot(clip, 1f);
            yazi.GetComponent<Text>().text = "Yırmaktasın";
        }
        else
        {
            audioSource.PlayOneShot(clip2, 1f);
            yazi.GetComponent<Text>().text = "Zabadak";
        }
        
        Destroy(anakarakter);
        yazi.SetActive(true);
        
        btnExit.SetActive(true);
    }
    
    
    public void TakeDamage(int damageAmount)
    {
        //TODO
        var color = HitScreen.GetComponent<Image>().color;
        color.a = 0.8f;
        HitScreen.GetComponent<Image>().color = color;
            if (karaktercan > damageAmount)
            {
                karaktercan -= damageAmount;
            }
            else
            {
                karaktercan -= damageAmount;
                OldumMequ(false);
            }
        
    }
}