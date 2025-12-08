using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoJump : MonoBehaviour
{
    public float jumpForce = 7f;
    public float groundRayLength = 0.1f;
    public LayerMask groundMask;
    public float jumpDelay = 1f;

    private Rigidbody rb;
    private float sphereRadius;
    private bool readyToJump = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        SphereCollider col = GetComponent<SphereCollider>();
        sphereRadius = col.radius * transform.localScale.y;

        Debug.Log("[DEBUG] Start OK! SphereRadius = " + sphereRadius);
    }

    void Update()
    {
        bool grounded = CheckGrounded();
        Debug.Log("[DEBUG] Grounded = " + grounded);

        if (grounded && readyToJump)
        {
            Debug.Log("[DEBUG] Grounded & ready → scheduling jump in " + jumpDelay + " seconds");
            readyToJump = false;
            Invoke(nameof(Jump), jumpDelay);
        }
    }

    void Jump()
    {
        Debug.Log("[DEBUG] Jump() called!");

        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);

        Debug.Log("[DEBUG] Force applied: " + jumpForce);
        readyToJump = true;
    }

    bool CheckGrounded()
    {
        Vector3 origin = transform.position + Vector3.down * (sphereRadius - 0.01f);
        Vector3 direction = Vector3.down;

        Debug.DrawRay(origin, direction * groundRayLength, Color.red);

        bool hit = Physics.Raycast(origin, direction, groundRayLength, groundMask);

        if (hit == false)
        {
            Debug.Log("[DEBUG] Raycast miss! is Jumping");
        }

        return hit;
    }
}
