 using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 20f;
    public float range = 100f;
    public Camera fpsCam;
    public ParticleSystem muzzle;
    public GameObject impact;
    public float force = 50f;
    GunInvoker gunShoot;
    void Start()
    {
        Command shootcommand = new ShootCommand(damage, range, fpsCam, muzzle, impact, force);
        gunShoot = new GunInvoker(shootcommand);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            gunShoot.shoot();
        }
    }
}

