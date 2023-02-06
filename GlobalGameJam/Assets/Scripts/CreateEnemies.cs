using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemies : MonoBehaviour
{
    // Private Variables
    private float nextTime;

    // Public Variables
    public GameObject bear;
    public GameObject worm;
    public GameObject net;
    public GameObject eagle;
    public GameObject log;
    public float updateTimeInSeconds = 1f;

    // Start is called before the first frame update
    void Start()
    {
        nextTime = Time.time + updateTimeInSeconds;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextTime)
        {
            nextTime += Random.Range(1f, 4f);
            CreateEnemy();
        }
    }

    private void CreateEnemy()
    {
        int i = Random.Range(0, 5);

        switch (i)
        {
            case 0: // bear
                Instantiate(bear, new Vector3(Random.Range(12f,25f), -3.72f, 0f), bear.transform.rotation);
                break;
            case 1: // worm
                Instantiate(worm, new Vector3(Random.Range(12f,25f), Random.Range(-2.5f, 2.5f), 0f), worm.transform.rotation);
                break;
            case 2: // net
                Instantiate(net, new Vector3(Random.Range(12f,25f), 0f, 0f), net.transform.rotation);
                break;
            case 3: // eagle
                Instantiate(eagle, new Vector3(Random.Range(12f,25f), Random.Range(-2.7f, 2.7f), 0f), eagle.transform.rotation);
                break;
            default: // log
                Instantiate(log, new Vector3(Random.Range(12f,25f), Random.Range(-1.7f, 1.7f), 0f), log.transform.rotation);
                break;
        }
    }
}
