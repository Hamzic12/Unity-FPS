using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemyM;
    public GameObject enemyL;
    SpawnInvoker spawnmedium;
    SpawnInvoker spawnbig;

    void Start()
    {
        Command spawnmcommand = new SpawnMCommand(enemyM);
        Command spawnlcommand = new SpawnLCommand(enemyL);
        spawnmedium = new SpawnInvoker(spawnmcommand);
        spawnbig = new SpawnInvoker(spawnlcommand);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            
            spawnmedium.spawn(); 
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            
            spawnbig.spawn(); 
        }
    }

}
