using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerController : MonoBehaviour
{
    #region Inspector
    public Transform player;
    public Vector3 offset;
    public float speed;
    #endregion

    void Update()
    {
        Vector3 desirePos = player.position + offset;
        transform.position = Vector3.Lerp(transform.position, desirePos, speed * Time.deltaTime);
    }
}
