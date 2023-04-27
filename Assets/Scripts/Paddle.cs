using System;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    
    // ENCAPSULATION
    public float Speed { get; private set; }
    public float MaxMovement { get; private set; }

    private void Start()
    {
        Speed = 2.0f; 
        MaxMovement = 2.0f; 
    }

    void Update()
    {
        float input = Input.GetAxis("Horizontal");

        Vector3 pos = transform.position;
        pos.x += input * Speed * Time.deltaTime;

        if (pos.x > MaxMovement)
            pos.x = MaxMovement;
        else if (pos.x < -MaxMovement)
            pos.x = -MaxMovement;
                            
        transform.position = pos;
    }

}
