using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    public GameObject[] bombList;
    private GameObject bomb;
    public int bombIndex;


    // Start is called before the first frame update
    void Start()
    {
        SpawnBomb();
    }

    private int DelayTime(int index)
    {  
        return index * 5 + 5;
    }

    private async void SpawnBomb()
    {
        int index = Random.Range(0, 3); //назначаем случайный индекс в пределах длины массива
        bombIndex = index;
        await Task.Delay(DelayTime(index) * 1000); // ждем определенное время
        bomb = Instantiate(bombList[index], transform.position, Quaternion.identity, transform);//создаем бомбочку
        bomb.GetComponent<Rigidbody>().isKinematic = true;
        await Task.Delay(Random.Range(5,15) * 1000);
        DestroyBomb();
    }

    private void DestroyBomb()
    {
        if (bomb)
        {
            Destroy(bomb);
            SpawnBomb();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player"&& bomb) //добавление префаба по тегу
        {
            var character = other.GetComponent<CharacterControler>();
            character.countBomb[bombIndex]++ ;
            character.uIManager.RefreshBombCount(bombIndex, character.countBomb[bombIndex]);
            DestroyBomb();
            Debug.Log("добавление префаба по тегу");
        }
    }
}
