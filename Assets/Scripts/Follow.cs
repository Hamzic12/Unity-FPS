using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform target;
    public float speed;
    Rigidbody rb;
    AiInvoker AiFollow;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Command follow = new FollowCommand(target, speed, rb);
        AiFollow = new AiInvoker(follow);
    }

    void Update()
    {
        AiFollow.walk();
    }
}
