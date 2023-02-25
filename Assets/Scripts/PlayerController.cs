using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Boundary bound;
    public float tilt;

    private Rigidbody theRB;
    public GameObject bullet;
    public Transform bulletSp;

    public float fireRate;
    private float timeRate;

    [SerializeField]
    private AudioSource audio;

    private void Start()
    {
        theRB = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > timeRate)
        {
            timeRate = Time.time + fireRate;
            Instantiate(bullet, bulletSp.position, bulletSp.rotation);

            audio.Play();
        }
    }

    private void FixedUpdate()
    {
        var hoz = Input.GetAxisRaw("Horizontal");
        var ver = Input.GetAxisRaw("Vertical");

        GetComponent<Rigidbody>().velocity = new Vector3(hoz, 0, ver) * speed;

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bound.xMin, bound.xMax),
            0,
            Mathf.Clamp(transform.position.z, bound.zMin, bound.zMax));

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, theRB.velocity.x * -tilt));
    }
}
