using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    private Rigidbody theRB;
    public float speed;

    private void Start()
    {
        theRB = GetComponent<Rigidbody>();

        theRB.angularVelocity = Random.insideUnitSphere * speed;
    }
}
