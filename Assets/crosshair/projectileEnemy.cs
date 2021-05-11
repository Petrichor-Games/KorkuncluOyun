using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileEnemy : MonoBehaviour
{

    public float speed;
    public float lifeTime;
    public float distance;
    public LayerMask whatIsSolid;

    public GameObject destroyEffect;

    void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }

    
    // Update is called once per frame
    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if(hitInfo.collider.CompareTag("anakarakter"))
            {
                GameObject.FindGameObjectWithTag("anakarakter").GetComponent<PlayerMovement>().TakeDamage(20);
            }
            DestroyProjectile();
        }

        transform.Translate(Vector2.up * (speed * Time.deltaTime));
    }

    void DestroyProjectile()
    {
        var parcalanma = Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(parcalanma, 1);
        
    }
    
    
    
    
    
}
