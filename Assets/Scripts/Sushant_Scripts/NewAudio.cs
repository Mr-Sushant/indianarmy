using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewAudio : MonoBehaviour
{

    [SerializeField]
    AudioSource src;

    [SerializeField]
    GameObject VolumeButton;

    [SerializeField]
    Button btn;

    [SerializeField]
    Sprite[] images;

    [SerializeField]
    bool isOn = true;
    // Start is called before the first frame update
    void Update()
    {
        btn.onClick.AddListener(delegate { onValueChanged();});
    }

    public void onValueChanged()
    {
        if(!isOn)
        {
            VolumeButton.GetComponent<Image>().sprite = images[0];
            src.volume = 0.5F;
            isOn = true;
        }

        else
        {
            VolumeButton.GetComponent<Image>().sprite = images[1];
            src.volume = 0.0f;
            isOn = false;
        }
    }
}
