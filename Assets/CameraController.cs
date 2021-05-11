using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]

    private Transform targetToFollow;

    private void Update()
    {
        transform.position = new Vector3(

            Mathf.Clamp(targetToFollow.position.x, -17f, 17f),
            Mathf.Clamp(targetToFollow.position.y, -1.45f, 8.5f),
            transform.position.z);
            
           
    }

}
