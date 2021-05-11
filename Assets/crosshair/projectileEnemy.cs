using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileEnemy : MonoBehaviour
{

    public float speed;
    public float lifeTime;
    public float distance;
    public LayerMask whatIsSolid;
    private Transform Player;
    public GameObject destroyEffect;
    private Vector2 target;


    void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
        Player = GameObject.FindGameObjectWithTag("anakarakter").transform;
        target = new Vector2(Player.position.x, Player.position.y);
    }

    
    // Update is called once per frame
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }
       // RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
       // if (hitInfo.collider != null)
      //  {
        //    if(hitInfo.collider.CompareTag("anakarakter"))
          //  {
                
           // }
            //DestroyProjectile();
        //}

    
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("anakarakter"))
        {
            GameObject.FindGameObjectWithTag("anakarakter").GetComponent<PlayerMovement>().TakeDamage(20);
            DestroyProjectile();
        }
    }
    void DestroyProjectile()
    {
        var parcalanma = Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(parcalanma, 1);
        
    }
    
    
    
    
    
}
