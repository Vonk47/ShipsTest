using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotSpawner : MonoBehaviour
{
    [SerializeField] BotController bot;
    [SerializeField] List<Transform> spawnPositions;
    [SerializeField] float spawnRate;
    [SerializeField] PlayerShipController player;
    void Start()
    {
        InvokeRepeating("SpawnBot", spawnRate, spawnRate);
    }

   
    private void SpawnBot()
    {
      BotController _bot=  Instantiate(bot, spawnPositions[Random.Range(0, spawnPositions.Count)].position, Quaternion.identity);
        _bot.SetPlayer(player);
    }
}
