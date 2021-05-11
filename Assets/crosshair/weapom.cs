using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapom : MonoBehaviour
{

    public float offset;

    public GameObject projectile;
    public Transform shotPoint;

    private float timeBtwShots;
    public float startTimeBtwShots;
    

    // Update is called once per frame
    void Update()
    {
        // Silah Takip Sistemi
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ);

        //Ateþleme Sistemi
        if(timeBtwShots <= 0)
        {
            if (Input.GetMouseButtonDown(0) && itemLoot.soulAmount > 0)
            {
                var toplam = Quaternion.Euler(0f, 0f, rotZ + offset);
                Instantiate(projectile, shotPoint.position, toplam);
                timeBtwShots = startTimeBtwShots;
                itemLoot.soulAmount -= 1;
            }
        }

        else
        {
            timeBtwShots -= Time.deltaTime;
        }

        
    }
}
