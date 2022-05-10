using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    public float runSpeed = 40f;
    public float horizontalSpeed = 40f;
    public float forwardSpeed = 100f;
    public float verticalSpeed = 45f;

    public Joystick joystick;
    public Rigidbody rb;
    bool jump = false;
    bool crouch = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 direction = Vector3.forward * forwardSpeed + Vector3.right * joystick.Horizontal * horizontalSpeed;
        direction.y = joystick.Vertical * verticalSpeed;
        rb.velocity = direction * runSpeed * Time.fixedDeltaTime;
        
    }
}
