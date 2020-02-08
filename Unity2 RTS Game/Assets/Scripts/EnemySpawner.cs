using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private int health = 200;
    public float maxCoolDown = 30f;
    private float timerCoolDown;
    public List<GameObject> enemiesToSpawn;
    public float minRange = 5.1f;
    public float maxRange = 5.4f;
    // Start is called before the first frame update
    void Start()
    {
        timerCoolDown = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerCoolDown <= 0f)
        {
            timerCoolDown = maxCoolDown;
            SpawnEnemies();
        }
        else
        {
            timerCoolDown -= Time.deltaTime;
        }
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    Vector2 RandomPostion()
    {
        Vector3 randPos = Random.onUnitSphere * Random.Range(minRange, maxRange);
        return this.transform.position + randPos;
    }

    void SpawnEnemies()
    {
        foreach(GameObject enemy in enemiesToSpawn)
        {
            GameObject temp = Instantiate(enemy, this.transform.parent.parent);
            temp.transform.position = RandomPostion();
        }
    }
}
