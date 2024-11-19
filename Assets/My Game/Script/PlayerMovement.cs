using System;
using UnityEngine;

[AddComponentMenu("ScaryGame/PlayerMovement")]

public class PlayerMovement : MonoBehaviour
{
    [Header("Speed Move")]
    public float speedMove = 8f;
    public float gravity = -9.81f * 2;
    public Transform groundCheck;
    public LayerMask groundMash;
    public float groundDistance = 0.4f;

    private CharacterController controller;
    private Vector3 velocity;


    private Animator anim;
    private int isRunID;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
        isRunID = Animator.StringToHash("IsRun");

    }

    // Update is called once per frame
    void Update()
    {
        if (IsGroundCheck() && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = (transform.right * x + transform.forward * z);
        controller.Move(move * speedMove * Time.deltaTime);
/*        if (x != 0 || z != 0)
        {
            anim.SetBool(isRunID, true);
        }
        else
        {
            anim.SetBool(isRunID, false);
        }*/
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private bool IsGroundCheck()
    {
        bool isGroundCheck = Physics.CheckSphere(groundCheck.position, groundDistance, groundMash);
        return isGroundCheck;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundCheck.position, groundDistance);
    }
}
