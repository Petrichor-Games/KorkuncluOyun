using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_AI : MonoBehaviour
{
    Transform anakarakter;
    
    public float BossHealth;
    private GameObject yazi;


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
        
        Debug.Log(BossHealth);
    }
    
}
