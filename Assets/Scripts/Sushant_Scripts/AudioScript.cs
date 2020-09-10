using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioScript : MonoBehaviour
{
    [SerializeField]
    AudioSource src;
    [SerializeField]
    GameObject buttonImg;
    [SerializeField]
    Sprite[] imgs;
    [SerializeField]
    Button btn;
    private bool isOn = true;
    private void Start()
    {
        btn.onClick.AddListener(delegate { onValueChanged(); });
    }
    public void onValueChanged()
    {
        if (isOn)
        {
            buttonImg.GetComponent<Image>().sprite = imgs[1];
            src.volume = 0.0F;
            isOn = false;

        }
        else
        {
            buttonImg.GetComponent<Image>().sprite = imgs[0];
            src.volume = 0.5f;
            isOn = true;
        }
            
    }
}
