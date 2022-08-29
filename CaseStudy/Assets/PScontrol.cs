using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PScontrol : MonoBehaviour
{
    public GameObject Slider;
    void Start()
    {
        DOTween.Init();
    }

    // Update is called once per frame
    void Update()
    {
        if (Slider.transform.GetComponent<Slider>().value < 1)
        {
            Slider.transform.GetComponent<Slider>().value += 0.2f * Time.deltaTime;
        }
        else
        {
            Application.LoadLevel(1);
        }
    }
}