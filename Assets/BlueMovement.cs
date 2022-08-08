using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueMovement : MonoBehaviour
{
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float moveSpeed;

    [SerializeField] private float gravityMultiplier;

    Rigidbody rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();

    }

    public void FixedUpdate()
    {
        rigidBody.AddForce(Physics.gravity * gravityMultiplier, ForceMode.Acceleration);
    }

    public void UpdateMovement()
    {
        // Jumping
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, jumpSpeed, rigidBody.velocity.z);
        }

        // Moving in Cardinal Direcitons
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y, -moveSpeed);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y, moveSpeed);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidBody.velocity = new Vector3(moveSpeed, rigidBody.velocity.y, rigidBody.velocity.z);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rigidBody.velocity = new Vector3(-moveSpeed, rigidBody.velocity.y, rigidBody.velocity.z);
        }
    }
}
