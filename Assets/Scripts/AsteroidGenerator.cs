using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidGenerator : MonoBehaviour
{
    [SerializeField] private float spawnRange;
    [SerializeField] private float amountSpawn;

    private Vector3 spawnPoint;

    [SerializeField] private GameObject asteriod;
    [SerializeField] private float startRange;
    private List<GameObject> objectsPlace = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i =0; i < amountSpawn; i++)
        {
            PickSpawn();

            while(Vector3.Distance(spawnPoint, Vector3.zero) < startRange)
            {
                PickSpawn();
            }
            objectsPlace.Add(Instantiate(asteriod, spawnPoint, Quaternion.Euler(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f))));
            objectsPlace[i].transform.parent = this.transform;
        }
        asteriod.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PickSpawn()
    {
        spawnPoint = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));

        if(spawnPoint.magnitude > 1)
        {
            spawnPoint.Normalize();
        }
        spawnPoint *= spawnRange;
    }
}
