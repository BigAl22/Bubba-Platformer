using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinsihBox : MonoBehaviour
{
    #region Inspector
    public string loadLevel;
    #endregion

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(loadLevel);
            Debug.Log("The level [" + loadLevel + "] is now loaded!");
        }
    }

}
