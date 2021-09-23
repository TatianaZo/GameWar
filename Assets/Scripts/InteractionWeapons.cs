using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractionWeapons : MonoBehaviour
{
    public bool checkPresence;
    public GameObject[] bombPrefabs;
    public GameObject predictor;
    public CharacterControler character;

    private void Start()
    {
        predictor.SetActive(false);
    }

    void Update()
    {
        if (checkPresence)
        {
            if (Input.GetMouseButtonDown(0)) //прицеливание
            {
               predictor.SetActive(true);
            }

            if (Input.GetMouseButtonUp(0)) //кинуть гранату
            {
                predictor.SetActive(false);

                ThrowBomb();
            }
        }

        else // нет гранат
        {
            if (checkPresence)
            {
                checkPresence = true;
            }
        } 
    }

    public void ThrowBomb()
    {
        if (character.countBomb[character.selectedBombIndex] > 0) //проверка гранат
        {
            GameObject bomb = Instantiate(bombPrefabs[character.selectedBombIndex], predictor.transform.position, transform.rotation);
            bomb.GetComponent<Rigidbody>().velocity = predictor.transform.forward * predictor.GetComponent<TrajectoryPredictor>().force;
            bomb.GetComponent<Rigidbody>().angularVelocity = bomb.transform.right * Random.Range(1, 25);
            character.countBomb[character.selectedBombIndex] -= 1; // вычитаем 1 бомбочку из массива 
            character.uIManager.RefreshBombCount(character.selectedBombIndex, character.countBomb[character.selectedBombIndex]); //обновляем UI
        }
    } 
}
