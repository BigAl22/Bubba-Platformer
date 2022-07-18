using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static PlayerMovement;

public class PlayerInventory : MonoBehaviour
{
    [Header("Health Settings")]
    public float health;
    public float maxHealth;

    [Header("Movement")]
    public float speed;
    private float Move;

    public float jump;

    public bool isJumping;

    private Rigidbody2D rb;

    

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
