using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{

    private float sensitivity = 5f;
    private float x_rotation = 0;
    private float upperClamp = -90f;
    private float bottomClamp = 90f;
    private GameObject player;
    public Transform camera;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        

        float mouse_x = Input.GetAxis("Mouse X") * sensitivity*150f * Time.deltaTime;
        float mouse_y = Input.GetAxis("Mouse Y") * sensitivity*150f * Time.deltaTime;

        // CALCULATE PLAYER ROTATION
        // AND CONSTRAIN X ROTATION (UP AND DOWN) TO -90 AND 90 DEGREES 
        x_rotation -= mouse_y;
        x_rotation = Mathf.Clamp(x_rotation, upperClamp, bottomClamp);

        // ROTATE CAMERA UP AND DOWN
        transform.localRotation = Quaternion.Euler(x_rotation, 0f, 0f);

        // ROTATE PLAYER (AND CAMERA) LEFT AND RIGHT
        player.transform.Rotate(Vector3.up * mouse_x);
        }
        
    }

