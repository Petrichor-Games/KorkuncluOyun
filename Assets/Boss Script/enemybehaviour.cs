using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemybehaviour : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float goingdistance;
    public Transform Player;
    public int BossHealth;
    private GameObject yazi;
    private float timebtwshots;
    public float starttimebtwshots;
    public GameObject projectileEnemy;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("anakarakter").transform;
        yazi = GameObject.FindGameObjectWithTag("oyunbitti");
        yazi.SetActive(false);
        BossHealth = 100;
        timebtwshots = starttimebtwshots;


    }
    public void TakeDamage(int damageAmount)
    {
        if (BossHealth > damageAmount)
        {
            BossHealth -= damageAmount;
        }
        else
        {
            var boss = GameObject.FindGameObjectWithTag("Enemy");
            yazi.SetActive(true);
            Destroy(boss);
        }
    }
    
    void Update()
    {
        if (Player !=null)
        {
            
        
        
        if (Vector3.Distance(transform.position, Player.position) < goingdistance && Vector3.Distance(transform.position , Player.position) > stoppingDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);
        }
             if (Vector3.Distance(transform.position, Player.position) == stoppingDistance)
            {
                transform.position = this.transform.position;
              
            }if (Vector3.Distance(transform.position, Player.position) < stoppingDistance)
            {
            transform.position = Vector3.MoveTowards(transform.position, Player.position, -speed * Time.deltaTime);
        }

        if (timebtwshots <=0)
        {
            Instantiate(projectileEnemy, transform.position, Quaternion.identity);
            timebtwshots = starttimebtwshots;
        }else
        {
            timebtwshots -= Time.deltaTime;
        }
        }
    }

}
    
