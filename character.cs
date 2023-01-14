using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class character : MonoBehaviour
{
    public Slider myslider1;
    public Slider myslider2;
    public Text sliderAtk;
    public Text sliderHp;


    public Text sliderAtk1;
    public Text sliderHp1;

    int a, b;


    void Update()
    {

        if(myslider1.value * a>200)
        {
            b = 400-a;
        }
        else
        {
            b = 300;
        }
        if(myslider2.value * b > 200)
        {
            a = 400 - b;
        }
        else
        {
            a = 300;
        }


        sliderAtk.text = "" + myslider1.value*a;
        sliderHp.text = "" + myslider2.value*b;

        sliderAtk1.text = sliderAtk.text;
        sliderHp1.text = sliderHp.text;
    }
}
