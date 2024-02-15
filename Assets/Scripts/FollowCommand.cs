using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCommand : Command
{
    public Transform target;
    public float speed;
    Rigidbody rb;
    public FollowCommand(Transform target, float speed, Rigidbody rb)
    {
        this.target = target;
        this.speed = speed;
        this.rb = rb;
    }
    public override void Execute()
    {
        Vector3 position = Vector3.MoveTowards(rb.transform.position, target.position, speed*Time.deltaTime);
        rb.MovePosition(position);
        rb.transform.LookAt(target);
    }
}

public class AiInvoker
{
    Command onCommand;
    public AiInvoker(Command onCommand)
    {
        this.onCommand = onCommand;
    }
    public void walk()
    {
        onCommand.Execute();
    }
}
