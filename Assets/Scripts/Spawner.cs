using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject cubePrefab;

    [SerializeField] private float spawnStart;
    [SerializeField] private float spawnSpeed;
    [SerializeField] private float spawnDistance;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("InstantiateRandomCubes", spawnStart, spawnSpeed);
     }

    // Update is called once per frame
    void Update()
    {
        
    }

    float RandomPositionX()
    {
        float randomPositionX = Random.Range(0, Screen.width);
        return randomPositionX;
    }

    float RandomPositionY()
    {
        float randomPositionY = Random.Range(0, Screen.height);
        return randomPositionY;
    }

    void InstantiateRandomCubes()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(new Vector3(RandomPositionX(), RandomPositionY(), spawnDistance));
        Instantiate(cubePrefab, newPosition, transform.rotation);
    }
}
