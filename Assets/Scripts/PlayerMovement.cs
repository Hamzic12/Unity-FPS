using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;


public class playerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public const float jumpForce = 7f;
    public const float speed = 10f;
    public LayerMask groundMask;
    public Transform groundCheck;
    MovementInvoker walkForward;
    MovementInvoker walkBackwards;
    MovementInvoker walkRight;
    MovementInvoker walkLeft;
    MovementInvoker jump;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Command forwardcommand = new ForwardCommand(rb);
        walkForward = new MovementInvoker(forwardcommand);

        Command backwardcommand = new BackwardCommand(rb);
        walkBackwards = new MovementInvoker(backwardcommand);
        
        Command rightcommand = new RightCommand(rb);
        walkRight = new MovementInvoker(rightcommand);

        Command leftcommand = new LeftCommand(rb);
        walkLeft = new MovementInvoker(leftcommand);
        
        Command jumpcommand = new JumpCommand(rb, groundCheck, groundMask);
        jump = new MovementInvoker(jumpcommand);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            
            walkForward.move();
        }
        if (Input.GetKey(KeyCode.S))
        {
            
            walkBackwards.move();
        }
        if (Input.GetKey(KeyCode.D))
        {
            
            walkRight.move();
        }
        if (Input.GetKey(KeyCode.A))
        {  
            walkLeft.move();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump.move();
        }
    }
}