using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

    private Rigidbody rb;

    private float nextFire;

    private AudioSource source;

    private float volLowRange = .5f;

    private float volHighRange = 1.0f;


    public float speed;

    public float tilt;

    public Boundary boundary;

    public GameObject shot;

    public Transform shotSpawn;

    public float fireRate;

    public AudioClip weaponShot;


    void Start () {
      rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);

            source = GetComponent<AudioSource>();

            float vol = Random.Range(volLowRange, volHighRange);
            source.PlayOneShot(weaponShot);
        }
    }

    void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");

        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;

        rb.position = new Vector3(Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
             0.0f,
             Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax));

        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);

        if (Input.GetKey("escape"))
            Application.Quit();
    }
}
