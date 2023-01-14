using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class database : MonoBehaviour
{
    public static List<item> itemList = new List<item>();

    void Awake()
    {
        itemList.Add(new item(0, "none", "none", Resources.Load <Sprite>("0"),0,0,0,0,0,0,0,0,0));
        itemList.Add(new item(1, "Leu", "Tip: Felina:  \ndaca ai 2 feline +25 atac \ndaca ai 3 feline +40 atac  \nleu +hipopotan primesti +25 viata  ", Resources.Load <Sprite>("1"),200,150,1,0,0,1,0,0,0));
        itemList.Add(new item(2, "Tigru", "Tip: Felina   \ndaca ai 2 feline +25 atac \ndaca ai 3 feline +40 atac  \n tigru + vultur primesti +25 atac   ", Resources.Load <Sprite>("2"),200,150,1,0,0,0,1,0,0));
        itemList.Add(new item(3, "Pisica", "Tip: Felina si inferior   \ndaca ai 2 feline +25 atac \ndaca ai 3 feline +40 atac\ndaca ai 3 inferiori: +200 atac +200 viata", Resources.Load <Sprite>("3"),125,125,1,0,0,0,0,0,1));
        itemList.Add(new item(4, "Cioara", "Tip: Pasare si inferior   \ndaca ai 2 pasari primesti +25 viata \ndaca ai 3 pasari primesti +40 viata \ndaca ai 3 inferiori: +200 atac +200 viata ", Resources.Load <Sprite>("4"),100,150,0,1,0,0,0,0,1));
        itemList.Add(new item(5, "Pinugin", "Tip: Pasare   \ndaca ai 2 pasari primesti +25 viata \ndaca ai 3 pasari primesti +40 viata \npinguin + crocodil primesti +25 atac", Resources.Load <Sprite>("5"),225,125,0,1,0,0,0,1,0));
        itemList.Add(new item(6, "Vultur", "Tip: Pasare  \ndaca ai 2 pasari primesti +25 viata \ndaca ai 3 pasari primesti +40 viata\nvultur + tigru primesti +25 atac", Resources.Load <Sprite>("6"),200,150,0,1,0,0,1,0,0));
        itemList.Add(new item(7, "Hipopotan", "Tip: Gigant   \ndaca ai 2 giganti primesti +25 atac \ndaca ai 3 giganti primesti +40 atac \n hipopotan + leu primesti +25 viata", Resources.Load <Sprite>("7"),300,50,0,0,1,1,0,0,0));
        itemList.Add(new item(8, "Crocodil", "Tip: Gigant   \ndaca ai 2 giganti primesti +25 atac \ndaca ai 3 giganti primesti +40 atac \ncrocodil + pinguin primesti + 25 atac", Resources.Load <Sprite>("8"),250,100,0,0,1,0,0,1,0));
        itemList.Add(new item(9, "Elefant", "Tip: Gigant si inferior   \ndaca ai 2 giganti primesti +25 atac \ndaca ai 3 giganti primesti +40 atac \ndaca ai 3 inferiori: +200 atac +200 viata ", Resources.Load <Sprite>("9"),200,50,0,0,1,0,0,0,1));
        itemList.Add(new item(10,"Nenea","",Resources.Load<Sprite>("10"), 0, 0, 0, 0, 0, 0, 0, 0, 0));
    }
}
