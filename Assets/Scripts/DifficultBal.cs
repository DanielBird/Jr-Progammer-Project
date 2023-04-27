using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultBal : Ball
{
    public override Vector3 SetAcceleration(Vector3 velocity)
    {
        velocity += velocity.normalized * 0.03f;
        return velocity;
    }

    public override Vector3 SetMaxVelocity(Vector3 velocity)
    {
        if (velocity.magnitude > 6.0f)
        {
            velocity = velocity.normalized * 6.0f;
        }

        return velocity;
    }
}
