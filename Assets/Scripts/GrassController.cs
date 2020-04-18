using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassController : MonoBehaviour
{
    // -- DM --
    public int notSpawnChacne = 0;
    public GameObject[] ArrayGrassPrefab;
    public float respawnTime = 1.0f;
    private int randomInt;
    private Vector2 _screenBounds;

    // Use this for initialization
    void Start()
    {
        _screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(grassWave());
    }

    // Spawn grass as floor platform.
    private void spawnGrass()
    {
        // Select random number 0-100.
        randomInt = Random.Range(0, 100);

        // Chance for not creating prefab, only instantiate if bigger than bypass.
        if (randomInt > notSpawnChacne)
        {
            // Select random grass.
            randomInt = Random.Range(0, ArrayGrassPrefab.Length);

            // Create GameObject of cur grass.
            GameObject a = Instantiate(ArrayGrassPrefab[randomInt]) as GameObject;

            // Set position.
            a.transform.position = new Vector2(_screenBounds.x * 2, -_screenBounds.y + 0.3f);
        } 
    }
    IEnumerator grassWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnGrass();
        }
    }
}
