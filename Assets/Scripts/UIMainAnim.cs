using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMainAnim : MonoBehaviour
{
    
    Rigidbody rb;
    Animator anim;
    public float speed;

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
            
            Debug.Log("çarpýþtý");
            rb.AddForce(transform.forward*speed);
            anim.SetBool("UIMove",true);
        }    
    }
    

}
