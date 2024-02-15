using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMCommand : Command
{
    public GameObject enemyM;
    public SpawnMCommand(GameObject enemyM)
    {
        this.enemyM = enemyM;
    }

    public override void Execute()
    {
        int xPos = Random.Range(13, 23);
        GameObject.Instantiate(enemyM, new Vector3(xPos, 8, 7), Quaternion.identity);
    }

}
public class SpawnLCommand : Command
{
    public GameObject enemyL;
    public SpawnLCommand(GameObject enemyL)
    {
        this.enemyL = enemyL;
    }

    public override void Execute()
    {
        int xPos = Random.Range(55, 69);
        GameObject.Instantiate(enemyL, new Vector3(xPos, 8, 7), Quaternion.identity);
    }

}

public class SpawnInvoker
{
    Command onCommand;
    public SpawnInvoker(Command onCommand)
    {
        this.onCommand = onCommand;
    }
    public void spawn()
    {
        onCommand.Execute();
    }
}
