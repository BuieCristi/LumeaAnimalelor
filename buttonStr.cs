using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonStr : MonoBehaviour
{

    public GameObject panel1;
    public GameObject panel2;


   public void starting()
    {
        panel1.SetActive(false);
        panel2.SetActive(true); 
    }
}
