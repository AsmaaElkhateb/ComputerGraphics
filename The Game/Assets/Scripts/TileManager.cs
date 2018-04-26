using System.Collections;
using System.Collections.Generic; // 3shan nsta5dm el list type
using UnityEngine;

public class TileManager : MonoBehaviour
{

    public GameObject[] tilesPrefabs ; /*da array bn7add mno 7agm el tiles aw 3dadhom elly hnzawdo fel runtime*/
    private Transform playerTransform;/*da 3shan nshof el player fen */
    private float spawnZ = -7.5f; /*de el msafa elly 3ndaha hnzawd tiles w (z) 3shan bnzawd fe etgah el z we7na mashyen w m5alyen el value kda 3shan elly abl el tile myzharsh fel scene*/
    private float tileLength = 7.5f;
    private int amountOfTilesOnScreen = 7;

    private List<GameObject> activeTiles;//hnsta5dmha 3shan n kep tracking lel tiles elly hn3mlha (3shan nmskha ya3ni w n3raf nmsa7ha)
    private float safeZone = 30.0f;// 3shan ybd2 y delete el tiles lma ykon el player b3ed 30 meter odam
    private int lastPrefabIndex = 0;

    // Use this for initialization
    void Start()
    {

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        activeTiles = new List<GameObject>();

        for (int i = 0; i < amountOfTilesOnScreen; i++)
        {
            if (i < 4) // awl 4 tile hykono g1
            {
                SpawnTile(0);
            }
            else
            {
                SpawnTile();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (playerTransform.position.z - safeZone > spawnZ - amountOfTilesOnScreen * tileLength
 )
        {
            SpawnTile();
            DeleteTile();
        }
    }

    private void SpawnTile(int prefapIndex = -1)
    {
        GameObject tile;
        if (prefapIndex == -1)
        {
            //pick a racndom tile
            tile = Instantiate(tilesPrefabs[RandomPrefabIndex()]) as GameObject;
        }
        else
        {
            //choose the tile with index tileIndex
            //that is sent to this function as an argumemt
            tile = Instantiate(tilesPrefabs[prefapIndex]) as GameObject;
        }
        tile.transform.SetParent(transform);
        tile.transform.position = Vector3.forward * (spawnZ + tileLength);
        spawnZ += tileLength;
        activeTiles.Add(tile);
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }


    private int RandomPrefabIndex()
    {
        if (tilesPrefabs.Length <= 0) //lw fe tile wa7da msh hy3ml 7aga 
        {
            return 0;
        }
        int randomIndex = lastPrefabIndex;
        while (randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(0, tilesPrefabs.Length);
        }
        lastPrefabIndex = randomIndex;
        return randomIndex;
    }
}