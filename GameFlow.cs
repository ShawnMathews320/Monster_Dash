using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour
{
    public Transform tileObj;
    private Vector3 nextTileSpawn;
    public Transform barrierCubeObj;
    private Vector3 nextBarrierCubeSpawn;
    private int randX;
    private int randObj;
    public static int totalCoins = 0;

    public Transform barrierCylinderObj;
    private Vector3 nextBarrierCylinderSpawn;

    public Transform barrierHedraObj;
    private Vector3 nextBarrierHedraSpawn;

    public Transform barrierTetraObj;
    private Vector3 nextBarrierTetraSpawn;

    public Transform rockSpawnObj;
    private Vector3 nextRockSpawn;

    public Transform coinObj;
    private Vector3 nextCoinSpawn;

    void Start()
    {
        nextTileSpawn.z = 21;
        StartCoroutine(spawnTile());
    }

    
    void Update()
    {
        
    }

    IEnumerator spawnTile()
    {
        yield return new WaitForSeconds(1);

        randX = Random.Range(-2, 3);
        nextBarrierCubeSpawn = nextTileSpawn;
        nextBarrierCubeSpawn.x = randX;
        nextBarrierCubeSpawn.y = 0.506f;
        Instantiate(tileObj, nextTileSpawn, tileObj.rotation);
        Instantiate(barrierCubeObj, nextBarrierCubeSpawn, barrierCubeObj.rotation);


        if (randX == -2)
        {
            randX = 2;
        }
        else if (randX == -1)
        {
            randX = -2;
        }
        else if (randX == 0)
        {
            randX = 1;
        }
        else if (randX == 1)
        {
            randX = -1;
        }
        else if (randX == 2)
        {
            randX = 0;
        }

        randObj = Random.Range(0,8);

        if (randObj == 0)
        {
            nextBarrierHedraSpawn.z = nextTileSpawn.z;
            nextBarrierHedraSpawn.y = 0.52171f;
            nextBarrierHedraSpawn.x = randX;
            Instantiate(barrierHedraObj, nextBarrierHedraSpawn, barrierHedraObj.rotation);
        }
        else if (randObj == 1)
        {
            nextBarrierCubeSpawn.z = nextTileSpawn.z;
            nextBarrierCubeSpawn.y = 0.506f;
            nextBarrierCubeSpawn.x = randX;
            Instantiate(barrierCubeObj, nextBarrierCubeSpawn, barrierCubeObj.rotation);
        }
        else if (randObj == 2)
        {
            nextBarrierCylinderSpawn.z = nextTileSpawn.z;
            nextBarrierCylinderSpawn.y = 0.52664f;
            nextBarrierCylinderSpawn.x = randX;
            Instantiate(barrierCylinderObj, nextBarrierCylinderSpawn, barrierCylinderObj.rotation);
        }
        else if (randObj == 3 )
        {
            nextBarrierTetraSpawn.z = nextTileSpawn.z;
            nextBarrierTetraSpawn.y = 0.5f;
            nextBarrierTetraSpawn.x = randX;
            Instantiate(barrierTetraObj, nextBarrierTetraSpawn, barrierTetraObj.rotation);
        }
        else if (randObj == 4)
        {
            nextRockSpawn.z = nextTileSpawn.z;
            nextRockSpawn.y = 0.795f;
            nextRockSpawn.x = randX;
            Instantiate(rockSpawnObj, nextRockSpawn, rockSpawnObj.rotation);
        }
        else if (randObj == 5 || randObj == 6 || randObj == 7)
        {
            nextCoinSpawn.z = nextTileSpawn.z;
            nextCoinSpawn.y = 1.1f;
            nextCoinSpawn.x = randX;
            Instantiate(coinObj, nextCoinSpawn, coinObj.rotation);
        }

        nextTileSpawn.z += 3;
        StartCoroutine(spawnTile());
    }
}