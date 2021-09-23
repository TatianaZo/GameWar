using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryPredictor : MonoBehaviour
{
    // префаб точки предиктора
    public GameObject pointPref;
    // массив точек предиктора
    private GameObject[] pointsArray;
    // количество точек предиктора
    public int numberOfPoints;
    // Ќаправление броска
    private Vector3 Direction;
    // сила броска (должна быть равна силе броска гранаты)
    public float force;
    // дистанци€ между точками (чем меньше дистанци€ тем больше нужно точек дл€ отрисовки всей траектории)
    public float pointDistance = 0.1f;


    
    void Start()
    {
        // создаЄм на сцене точки предиктора
        pointsArray = new GameObject[numberOfPoints];
        for (int i = 0; i < numberOfPoints; i++)
        {
            pointsArray[i] = Instantiate(pointPref, transform.position, Quaternion.identity, transform.parent = transform);
            
        }
    }
    
    void Update()
    {
        // «адаЄм направление
        Direction = transform.forward;

        // «адаЄм позицию каждой точке предиктора в каждом кадре
        for(int i = 0; i < pointsArray.Length; i++)
        {
            pointsArray[i].transform.position = Predict(i*pointDistance);
        }
    }

    // –ассчЄт позиции точек предиктора
    private Vector3 Predict(float t)
    {    
        
        Vector3 CurrentPosition = (Vector3)transform.position + (Direction.normalized * force * t) + (0.5f * Physics.gravity * (t * t));
        return CurrentPosition;
    }
}
