using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hitPoints;
    public EnemySpawner enemySpawner;
    public TextMeshPro textMesh;
    
    public async void Damage(int damage)
    {
        hitPoints -= damage;
       // Debug.Log("получено " + damage + " урона, осталось" + hitPoints);
        if (hitPoints<=0)
        {
            Destroy(gameObject);
            enemySpawner.SpawnEnemy();
        }
        textMesh.text = (damage + " /10");
        await Task.Delay(3000);
        textMesh.text = " ";
    }
}