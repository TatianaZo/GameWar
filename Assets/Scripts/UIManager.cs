using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text[] textNumberBomb;
    public Image selectedBombImage;
    public Sprite[] bombImages;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RefreshBombCount(int index, int count)
    {
        textNumberBomb[index].text = ("X"+ count);
    }

    public void ChangeImage(int index)
    {
        selectedBombImage.sprite = bombImages[index];
    }
}
