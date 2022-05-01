using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [Header("Ramp")]
    public float slopeForceRayLength = 2f;
    public float slopeForce = 3f;
    
    [Header("Movement")] 
    public float forwardSpeed=1.0f;
    private bool isJump;
    public float LANE_DISTANCE = 2.4f;
    public float moveSpeed = 7f;
    private CharacterController controller;
    private float verticalVelocity = -0.1f;
    public float jumpForce= 7.3f;
    public float gravity=12.0f;
    private Animator anim;
    private int desiredLane = 1; //0 = LEFT 1=Middle 2= Right
    bool isRamp;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }
  
    private void Update()
    {
        if(OnSlope())
        {
            if(isRamp)
            {
                controller.Move(Vector3.up * controller.height / 2 * slopeForce * Time.deltaTime);
                Debug.Log("rampadayim");
            }         
        }
        if (MobileInput.Instance.SwipeLeft)
        {
            MoveLane(false);
        }
        if (MobileInput.Instance.SwipeLRight)
        {
            MoveLane(true);
        }
        bool isGrounded = IsGrounded();
        anim.SetBool("Grounded", isGrounded);
       
        Vector3 targetPosition = transform.position.z * Vector3.forward;

        if (desiredLane == 0)
        {
            targetPosition += Vector3.left * LANE_DISTANCE;
        }
       
        else if (desiredLane == 2)
        {
            targetPosition += Vector3.right * LANE_DISTANCE;
        }
     
        Vector3 moveVector = Vector3.zero;
        moveVector.x = (targetPosition - transform.position).normalized.x * moveSpeed;
        if (!isJump)
        {
            verticalVelocity = -5.81f;
            if (MobileInput.Instance.SwipeUp)
            {
                //JUMP
                anim.SetTrigger("Jump");
                verticalVelocity = jumpForce;
                isJump = true;
            }
        }
        else
        {
            verticalVelocity -= (gravity * Time.deltaTime);

            if (MobileInput.Instance.SwipeDown)
            {
                verticalVelocity = -jumpForce;
            }
        }

        if (MobileInput.Instance.SwipeDown)
        {
            anim.SetTrigger("Roll");
        }


        moveVector.y = verticalVelocity;
        moveVector.z = forwardSpeed;

        //Move the player
        controller.Move(moveVector * Time.deltaTime);

        Vector3 dir = controller.velocity;
        if(dir != Vector3.zero)
        {
            dir.y = 0;
            transform.forward = Vector3.Lerp(transform.forward, dir, 0.05f);
        }
       

    }

    public void MoveLane(bool goingRight)
    {
       desiredLane += (goingRight) ? 1 : -1;
       desiredLane=Mathf.Clamp(desiredLane, 0, 2);
    }

    private bool IsGrounded()
    {
        Ray groundRay = new Ray(new Vector3(controller.bounds.center.x,(controller.bounds.center.y- controller.bounds.extents.y) + 0.2f, controller.bounds.center.z), Vector3.down);
        Debug.DrawRay(groundRay.origin, groundRay.direction, Color.cyan, 1.0f);
        return Physics.Raycast(groundRay, 0.2f + 0.1f); ;
    }
    private bool OnSlope()
    {
        //JUMP control return false
        if (isJump)
            return false;
        RaycastHit hit;
        if(Physics.Raycast(transform.position,Vector3.down,out hit, controller.height / 2 * slopeForceRayLength))
            if(hit.normal != Vector3.up) 
                return true;
        return false;
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        switch (hit.gameObject.tag)
        {
            case "Ground":
                isJump = false;
            break;

            case "Ramp":
                isRamp = true;
            break;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            SceneManager.LoadSceneAsync(0);
            Debug.Log("caripti");
        }
    }

}