using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed;
    private Rigidbody theRB;
    // Start is called before the first frame update
    void Start()
    {
        theRB = GetComponent<Rigidbody>();

        theRB.velocity = transform.forward * speed;
    }
}
