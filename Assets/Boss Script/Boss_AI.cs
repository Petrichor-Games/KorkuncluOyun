using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_AI : MonoBehaviour
{
    Transform anakarakter;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        anakarakter = GameObject.FindGameObjectWithTag("anakarakter").transform;



    }
}