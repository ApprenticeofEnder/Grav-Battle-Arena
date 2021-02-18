using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Transform perspective;
    private Transform playerTrans;
    private Transform playerMovement;
    public Transform groundCheck;
    
    public CharacterController pController;

    public float moveSpeed = 10f;

    private static float groundDistance = 0.4f;
    private static float jumpForce = 2.0f;
    private static float gravForce = -9.81f;

    Vector3 velocity;
    Vector3 orientation;

    public LayerMask groundMask;

    bool isGrounded;

    void Start()
    {
        playerTrans = GetComponent<Transform>();
        perspective = playerTrans.GetChild(0);
        playerMovement = playerTrans.parent;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = checkGrounded();

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = playerTrans.right * x + playerTrans.forward * z;

        pController.Move(move * moveSpeed * Time.deltaTime);
        gravity();
    }

    void FixedUpdate()
    {

    }

    private bool checkGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }

    private void gravity()
    {
        orientation = playerMovement.up;

        Vector3 downVector = Vector3.Project(velocity, -orientation);

        if(isGrounded && downVector.magnitude > 0)
        {
            velocity = -orientation * 2;
        }
        else
        {
            velocity += orientation * Time.deltaTime * gravForce;
        }

        pController.Move(velocity * Time.deltaTime);
    }
}
