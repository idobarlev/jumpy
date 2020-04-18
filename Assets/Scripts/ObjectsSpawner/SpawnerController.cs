using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    // -- DM --
    public int notSpawnChacne = 0;
    public GameObject[] ArrayPrefab;
    public float minYAdd, maxYSub;
    public float respawnTime = 1.0f;

    private Vector2 screenBounds;
    private int randomInt;

    // Use this for initialization
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(prefabWave());
    }
    private void spawnPrefab()
    {
        // Select random number 0-100.
        randomInt = Random.Range(0, 100);

        // Chance for not creating prefab, only instantiate if bigger than bypass.
        if (randomInt > notSpawnChacne)
        {
            // Select random prefab.
            randomInt = Random.Range(0, ArrayPrefab.Length);

            // Create GameObject of cur prefab.
            GameObject a = Instantiate(ArrayPrefab[randomInt]) as GameObject;

            // Set position.
            a.transform.position = new Vector2(screenBounds.x * 2, Random.Range(-screenBounds.y + minYAdd, screenBounds.y - maxYSub));
        }
    }
    IEnumerator prefabWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnPrefab();
        }
    }
}
