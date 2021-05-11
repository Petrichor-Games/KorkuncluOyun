using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
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
            if(hitInfo.collider.CompareTag("Enemy"))
            {
                GameObject.FindGameObjectWithTag("Enemy").GetComponent<enemybehaviour>().TakeDamage(20);
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
