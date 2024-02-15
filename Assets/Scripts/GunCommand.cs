using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ShootCommand : Command
{
    public float damage = 10f;
    public float range = 100f;
    public Camera fpsCam;
    public ParticleSystem muzzle;
    public GameObject impact;
    public float force = 500f;

    public ShootCommand(float damage, float range, Camera fpsCam, ParticleSystem muzzle, GameObject impact, float force)
    {
        this.damage = damage;
        this.range = range;
        this.fpsCam = fpsCam;
        this.muzzle = muzzle;
        this.impact = impact;
        this.force = force;
    }
    public override void Execute()
    {
        RaycastHit hit;
        muzzle.Play();
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.takeDamage(damage);
                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * force);
                }   
            }
            GameObject impactObject = Object.Instantiate(impact, hit.point, Quaternion.LookRotation(hit.normal * force));
            Object.Destroy(impactObject, 0.6f);
        }
    }
}
public class GunInvoker
{
    Command onCommand;
    public GunInvoker(Command onCommand)
    {
        this.onCommand = onCommand;
    }
    public void shoot()
    {
        onCommand.Execute();
    }
}
