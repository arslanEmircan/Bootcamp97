using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMainAnim : MonoBehaviour
{
    float speedx = 1f;
    float speed = 0.1f;
    Rigidbody rb;
    Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("go"))
        {
            //Vector3 vector3 = new Vector3(1f, 1f, 1f);
            //transform.position += vector3 * speed;
            Debug.Log("çarpýþtý");
            rb.AddForce(transform.forward*1500);
            anim.SetBool("UIMove",true);
        }    
    }
    

}
