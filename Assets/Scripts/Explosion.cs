using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public int damage;
    public GameObject vfx;
 
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.GetComponent<Enemy>().Damage(damage);
            SetActiveExplosionBomb();
        } 
    }

    public void SetActiveExplosionBomb()
    {
        vfx.gameObject.SetActive(true);
    }
}
