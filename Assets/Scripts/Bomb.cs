using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public int minDamage;
    public int maxDamage;

    private SphereCollider explosion;

    private void Start()
    {
        explosion = transform.GetChild(0).GetComponent<SphereCollider>();
    }
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name != "Player")
        {
            explosion.gameObject.SetActive(true);
            explosion.gameObject.GetComponent<Explosion>().damage = Random.Range(minDamage, maxDamage);
            DestroyBomb();
        }

    }

    private async void DestroyBomb()
    {
        await Task.Delay(50);
        Destroy(gameObject);
    }
}
