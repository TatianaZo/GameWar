using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPref;

    void Start()
    {
        SpawnEnemy();
    }

    public async void SpawnEnemy()
    {
        await Task.Delay(Random.Range(5, 15) * 1000); // ждем определенное время
        var enemy = Instantiate(enemyPref, transform.position + new Vector3(0,1,0), Quaternion.identity, transform);//создаем врага
        enemy.GetComponent<Enemy>().enemySpawner = gameObject.GetComponent<EnemySpawner>();
    }
}
