using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMainAnim : MonoBehaviour
{
    
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
            
            Debug.Log("çarpýþtý");
            rb.AddForce(transform.forward*1500);
            anim.SetBool("UIMove",true);
        }    
    }
    

}
