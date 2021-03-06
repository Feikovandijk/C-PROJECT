﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playermovement : MonoBehaviour
{

    public float moveSpeed;
    public float moveSpeedWind;
    public float moveSpeedStandard;
    public GameObject deathParticles;
    public float maxSpeed;
    public float maxSpeedWind;
    public float maxSpeedStandard;

    private Rigidbody rigidbody;
    private bool inTrigger;
    private Vector3 input;

    private Vector3 spawn;


    // Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        spawn = transform.position;
        moveSpeedStandard = moveSpeed;
    }

    // Update is called once per frame
    void Die()
    {
        Instantiate(deathParticles, transform.position, Quaternion.identity);
        transform.position = spawn;
    }
    void Update()
    {
        input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        if (rigidbody.velocity.magnitude < maxSpeed)
        {
            rigidbody.AddForce(input * moveSpeed);
        }
        if (transform.position.y < -2)
        {
            Die();
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Enemy")
        {
            Die();
        }
        if (other.transform.tag == "Trap")
        {
            Die();
        }
        if (other.transform.tag == "Goal")
        {
            GameManager.instance.CompleteLevel();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Wind")
        {
            //maxSpeed = maxSpeedWind;
            //moveSpeed = moveSpeedWind;
            rigidbody.drag = 20;
        }
    }
    void OnTriggerExit(Collider player)
    { 
        //maxSpeed = maxSpeedStandard;
        //moveSpeed = moveSpeedStandard;
        rigidbody.drag = 0;

    }
}

