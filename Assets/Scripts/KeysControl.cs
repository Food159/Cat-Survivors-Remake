using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class KeysControl : MonoBehaviour
{
    [SerializeField] GameObject[] spawnPoints;
    [SerializeField] GameObject[] keysPrefab;
    [SerializeField] float secondSpawn = 10f;
    [SerializeField] float minX;
    [SerializeField] float maxX;
    [SerializeField] float minY;
    [SerializeField] float maxY;
    private Scoree cat;

    public void Start()
    {
        StartCoroutine(KeysSpawn());
    }

    IEnumerator KeysSpawn()
    {
        while (true)
        {
            float xPosition = Random.Range(minX, maxX); // สุ่มตำแหน่ง x
            float yPosition = Random.Range(minY, maxY); // สุ่มตำแหน่ง y
            Vector2 position = new Vector2(xPosition, yPosition);

                GameObject keyInstance = Instantiate(keysPrefab[Random.Range(0, keysPrefab.Length)], position, Quaternion.identity);
                yield return new WaitForSeconds(secondSpawn);
                Destroy(keyInstance, 50f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // ถ้า Player ชน gameobject จะเพิ่ม score 1
        {
            Destroy(gameObject);
            Scoree.Score += 1;
        }
    }
}
