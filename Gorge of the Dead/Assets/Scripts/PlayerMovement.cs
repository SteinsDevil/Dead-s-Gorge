using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    public float walkSpeed = 0;
    public float runSpeed = 12f;
    public float speed = 0f;
    public Vector3 playerDirection;
    //player controller
    public PlayerInputActions pc;
    public Rigidbody rb;
    private InputAction move;
    private InputAction jump;
    private InputAction run;
    private bool isRunning;


    void Awake()
    {
        pc = new PlayerInputActions();
        
        
    }

    void OnEnable()
    {
        move = pc.Player.Move;
        run = pc.Player.Run;
        move.Enable();
        run.Enable();
    }

    void OnDisable()
    {
        move.Disable();
    }


    // Start is called before the first frame update
    void Start()
    {
        walkSpeed = 7f;
        rb = GetComponent<Rigidbody>();
        

    }

    // Update is called once per frame
    void Update()
    {
        playerDirection = transform.right * move.ReadValue<Vector2>().x + transform.forward * move.ReadValue<Vector2>().y;
        playerDirection.Normalize();
        isRunning = run.ReadValue<float>() > 0.1f;
        // transform.position += playerDirection * walkSpeed * Time.deltaTime;

    }


    void FixedUpdate()
    {
        if (isRunning)
        {
            speed = runSpeed;
        }
        else speed = walkSpeed;

        rb.velocity = playerDirection * speed;
    }





}
