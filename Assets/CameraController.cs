using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]

    private Transform targetToFollow;

    private void Update()
    {
        if (targetToFollow != null)
        {
            
        
        
        transform.position = new Vector3(

            Mathf.Clamp(targetToFollow.position.x, -1.51f, 37f),
            Mathf.Clamp(targetToFollow.position.y, -1.87f, 14.63f),
            transform.position.z);
        
            }
           
    }

}
