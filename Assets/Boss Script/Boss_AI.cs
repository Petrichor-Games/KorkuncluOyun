using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_AI : MonoBehaviour
{
    Transform anakarakter;
    
    public float BossHealth;
    private GameObject yazi;
    public float offset;

    
    public GameObject projectile;
    public Transform shotPoint;

    // Start is called before the first frame update
    void Start()
    {
        yazi = GameObject.FindGameObjectWithTag("oyunbitti");
        yazi.SetActive(false);
        BossHealth = 100f;
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

    public void ShootToPlayer()
    {
        var player = GameObject.FindWithTag("anakarakter");
        Vector3 difference = player.transform.position - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        
        
        var toplam = Quaternion.Euler(0f, 0f, rotZ + offset);
        Instantiate(projectile, shotPoint.position, toplam);
    }
    
    
}
