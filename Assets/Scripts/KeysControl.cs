using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class KeysControl : MonoBehaviour
{
    #region variable
    [SerializeField] GameObject[] spawnPoints; //spawnpoint pos
    [SerializeField] GameObject[] keysPrefab; //key prefabs
    [SerializeField] float secondSpawn = 10f; //key spawn every 10s
    [SerializeField] float minX;
    [SerializeField] float maxX;
    [SerializeField] float minY;
    [SerializeField] float maxY;
    private Scoree cat;
    #endregion

    #region code
    public void Start()
    {
        StartCoroutine(KeysSpawn()); //start keyspawn command with coroutine
    }

    IEnumerator KeysSpawn()
    {
        while (true)
        {
            //float xPosition = Random.Range(minX, maxX); // สุ่มตำแหน่ง x
            //float yPosition = Random.Range(minY, maxY); // สุ่มตำแหน่ง y
            //Vector2 position = new Vector2(xPosition, yPosition);

            int spawnpointspos = Random.Range(0, spawnPoints.Length); //random from 0 to length in array
            Vector2 position = spawnPoints[spawnpointspos].transform.position;

            GameObject keyInstance = Instantiate(keysPrefab[Random.Range(0, keysPrefab.Length)], position, Quaternion.identity);
                yield return new WaitForSeconds(secondSpawn);
                Destroy(keyInstance, 20f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // if Player trigger with collider gameobject add score 1
        {
            Destroy(gameObject); //then destroy key
            Scoree.Score += 1; // and add score
        }
    }
    #endregion
}
