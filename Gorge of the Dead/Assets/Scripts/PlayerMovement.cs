using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Timeline;

public class PlayerMovement : MonoBehaviour
{

    public float walkSpeed = 0;
    public Vector3 playerDirection;
    //player controller
    public PlayerInputActions pc;
    public Rigidbody rb;
    private InputAction move;
    private InputAction jump;


    void Awake()
    {
        pc = new PlayerInputActions();
    }

    void OnEnable()
    {
        move = pc.Player.Move;
        move.Enable();
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
        // transform.position += playerDirection * walkSpeed * Time.deltaTime;

    }


    void FixedUpdate()
    {
        rb.velocity = playerDirection * walkSpeed;
    }





}
