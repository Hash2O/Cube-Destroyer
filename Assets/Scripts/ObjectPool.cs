using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;
    public int counter;
    public int index;

    [SerializeField] private float spawnDistance;

    void Awake()
    {
        SharedInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }
        counter = 0;
        index = 0;


        InvokeRepeating("InstantiateCubesFromPool", 1, 2.0f);

    }

    // Update is called once per frame
    void Update()
    {
      
    }

    void InstantiateCubesFromPool()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(RandomPositionX(), RandomPositionY(), spawnDistance));

        GameObject newObject = SharedInstance.GetPooledObject();

        if (newObject != null)
        {
            newObject.transform.position = worldPosition;
            newObject.SetActive(true);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
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

}
