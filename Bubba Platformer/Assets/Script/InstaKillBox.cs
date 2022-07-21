using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstaKillBox : MonoBehaviour
{
    #region Inspector
    public GameObject startPoint;
    //public GameObject Player;
    #endregion

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.transform.position = startPoint.transform.position;
            collision.relativeVelocity.Set(0f, 0f, 0f);
            collision.rigidbody.rotation = Quaternion.identity;
            //Player.transform.position = startPoint.transform.position;
            Debug.Log("Player has died!");
        }
    }
}
