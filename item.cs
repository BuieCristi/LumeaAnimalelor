using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]

public class item 
{
    public int id;
    public string name;
    public string description;

    public Sprite icons;


    //  parte de putere/ hp
    public int HP;
    public int Atac;
    public int Felina;
    public int Pasari;
    public int Giganti;
    public int A;
    public int B;
    public int C;
    public int inferior;


    public item()
    {

    }

    public item(int ID, string Name, string Description, Sprite Iconcharacter, int hp, int atac, int felina,int pasari,int giganti, int a,int b,int c,int Inferior)
    {
        id = ID;
        name = Name;
        description = Description;
        icons = Iconcharacter;
        HP = hp;
        Atac = atac;
        Felina = felina;
        Pasari = pasari;
        Giganti = giganti;
        A = a;
        B = b;
        C = c;
        inferior = Inferior;
    }
}
