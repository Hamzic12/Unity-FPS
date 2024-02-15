using Unity.VisualScripting;
using UnityEngine;

public class ForwardCommand : Command
{
    public Rigidbody rb;
    public ForwardCommand(Rigidbody rb)
    {
        this.rb = rb;
    }


    public override void Execute()
    {
        rb.transform.position += rb.transform.forward * playerMovement.speed * Time.deltaTime;
    }


}
public class BackwardCommand : Command
{
    public Rigidbody rb;
    public BackwardCommand(Rigidbody rb)
    {
        this.rb = rb;
    }
    public override void Execute()
    {
        rb.transform.position -= rb.transform.forward * playerMovement.speed * Time.deltaTime;
    }
}

public class RightCommand : Command
{
    public Rigidbody rb;
    public RightCommand(Rigidbody rb)
    {
        this.rb = rb;
    }
    public override void Execute()
    {
        rb.transform.position += rb.transform.right * playerMovement.speed * Time.deltaTime;
    }
}
public class LeftCommand : Command
{
    public Rigidbody rb;
    public LeftCommand(Rigidbody rb)
    {
        this.rb = rb;
    }
    public override void Execute()
    {
        rb.transform.position -= rb.transform.right * playerMovement.speed * Time.deltaTime;
    }
}
public class JumpCommand: Command
{
    public Rigidbody rb;
    public LayerMask groundMask;
    public Transform groundCheck;


    public JumpCommand(Rigidbody rb, Transform groundCheck, LayerMask groundMask)
    {
        this.rb = rb;
        this.groundCheck = groundCheck;
        this.groundMask = groundMask;

    }
         
    public override void Execute()
    {
         if(Physics.CheckSphere(groundCheck.position, 0.3f, groundMask))
            {
                rb.AddForce(Vector3.up * playerMovement.jumpForce, ForceMode.Impulse);
            }
    }
}

public class MovementInvoker
{
    Command onCommand;
    public MovementInvoker(Command onCommand)
    {
        this.onCommand = onCommand;
    }
    public void move()
    {
        onCommand.Execute();
    }
}
