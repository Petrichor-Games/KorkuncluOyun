using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soul : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("anakarakter"))
        {
            itemLoot.soulAmount += 1;
            Destroy(gameObject);
            spawner.spawnAllowed = true;
        }
    }
}
