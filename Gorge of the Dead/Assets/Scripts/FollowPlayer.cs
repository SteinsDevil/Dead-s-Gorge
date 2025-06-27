using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // assign the head or player body
    public Vector3 offset = new Vector3(0, 0.7f, 0); // offset from the target
    public float smoothSpeed = 50f;
    public Transform head;


    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        
    }
    void Update()
    {
        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.rotation = target.rotation;
    }
}