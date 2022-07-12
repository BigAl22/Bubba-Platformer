using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Transform player;
    public Vector3 offset;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 desirePos = player.position + offset;
        transform.position = Vector3.Lerp(transform.position, desirePos, speed * Time.deltaTime);
    }
}
