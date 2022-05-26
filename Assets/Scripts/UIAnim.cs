using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnim : MonoBehaviour
{
    float speedx = 1f;
    float speed = 0.1f;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vector3 = new Vector3(speedx, 0f, 0f);
        transform.position += vector3 * speed;
    }
}
