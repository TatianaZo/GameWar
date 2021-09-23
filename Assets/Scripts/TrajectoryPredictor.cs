using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryPredictor : MonoBehaviour
{
    // ������ ����� ����������
    public GameObject pointPref;
    // ������ ����� ����������
    private GameObject[] pointsArray;
    // ���������� ����� ����������
    public int numberOfPoints;
    // ����������� ������
    private Vector3 Direction;
    // ���� ������ (������ ���� ����� ���� ������ �������)
    public float force;
    // ��������� ����� ������� (��� ������ ��������� ��� ������ ����� ����� ��� ��������� ���� ����������)
    public float pointDistance = 0.1f;


    
    void Start()
    {
        // ������ �� ����� ����� ����������
        pointsArray = new GameObject[numberOfPoints];
        for (int i = 0; i < numberOfPoints; i++)
        {
            pointsArray[i] = Instantiate(pointPref, transform.position, Quaternion.identity, transform.parent = transform);
            
        }
    }
    
    void Update()
    {
        // ����� �����������
        Direction = transform.forward;

        // ����� ������� ������ ����� ���������� � ������ �����
        for(int i = 0; i < pointsArray.Length; i++)
        {
            pointsArray[i].transform.position = Predict(i*pointDistance);
        }
    }

    // ������� ������� ����� ����������
    private Vector3 Predict(float t)
    {    
        
        Vector3 CurrentPosition = (Vector3)transform.position + (Direction.normalized * force * t) + (0.5f * Physics.gravity * (t * t));
        return CurrentPosition;
    }
}
