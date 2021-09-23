using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControler : MonoBehaviour
{
    private GameObject player;
    public static int speed = 6;
    public static int _speed;
    public int rotation = 250;
    public static float x = 0.0f;
    public Transform headCamera;
    public Transform body;
    public float sensitivity = 3f; // чувствительность мыши
    // ограничение угла для головы
    public float headMinY = -50f;
    public float headMaxY = 50f;
    private float rotationY;
    public UIManager uIManager;
    public int[] countBomb;
    public int selectedBombIndex;

    void Start()
    {
        _speed = speed;
        player = (GameObject)this.gameObject;
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            player.transform.localPosition += player.transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            speed = _speed / 2;
            player.transform.localPosition -= player.transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            speed = _speed * 2;
        }
        if (Input.GetKey(KeyCode.A))
        {
            player.transform.localPosition -= player.transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            player.transform.localPosition += player.transform.right * speed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (selectedBombIndex > 0)
            {
                selectedBombIndex -= 1;
            }
            else selectedBombIndex = 2;
            uIManager.ChangeImage(selectedBombIndex);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (selectedBombIndex < 2)
            {
                selectedBombIndex += 1;
            }
            else selectedBombIndex = 0;
            uIManager.ChangeImage(selectedBombIndex);
        }

        body.eulerAngles += new Vector3(0, Input.GetAxis("Mouse X") * sensitivity, 0);
        rotationY += Input.GetAxis("Mouse Y") * sensitivity;
        rotationY = Mathf.Clamp(rotationY, headMinY, headMaxY);
        headCamera.eulerAngles = new Vector3(-rotationY, headCamera.eulerAngles.y, headCamera.eulerAngles.z);
    }
}