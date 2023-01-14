using System;
using System.Collections.Generic;
//using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class charactere : MonoBehaviour
{

    //slider
    public GameObject panel1;// creeare caracter
    public GameObject panel2;// utilizare
    public float atacMan;
    public float hpMan;
    public Text atacManT;
    public Text hpManT;
    //

    public int a1;
    public int b1;
    public int asta;

    public Sprite[] AlegeleSprite;
    public GameObject Alege;
    public Image[] alegele;


    public List<item> yourCharacter = new List<item>();
    public List<item> drag = new List<item>();

    public int slotNum;

    public Image[] slot;
    public Sprite[] slotSprite;

    public int[] al;
    public int[] bl;
    public int a;
    public int b;

    public GameObject[] leu;
    public GameObject[] tigru;
    public GameObject[] pisica;
    public GameObject[] cioara;
    public GameObject[] pinguin;
    public GameObject[] vultur;
    public GameObject[] hpopotam;
    public GameObject[] crocodil;
    public GameObject[] elefant;
    public GameObject[] man;

    public int viata;
    public int atac;

    public int viataenemy;
    public int atacenemy;

    public Text hptext;
    public Text puteretext;

    public Text hptextenemy;
    public Text puteretextenemy;

    public GameObject gameObject1;


    public GameObject win;
    public GameObject lose;

    public int restart;//1
    public int n;
    public int l;
    public int s;
    public int count;

    public float time;
    public float timeDelay;

    public GameObject gameObject2;
    public GameObject gameObject3;
    public GameObject gameObject4;
    public GameObject gameObject5;
    public GameObject gameObject6;
    public GameObject gameObject7;

    public GameObject Boom1;
    public GameObject Boom2;
    public GameObject Boom3;

    public Text[] detali;
    public GameObject[] imaginiDetali;

    public Text nextlvl;
    public GameObject StartButton;

    public GameObject Next;
    public GameObject rest;

    public int felina;
    public int calcul;


    public int caracter1, caracter2, caracter3;

    public int[] pos1, pos2, pos3, pos4, pos5, pos6, pos7, pos8;//salvarea rundelor anterioare
    int poscounter;

    public int[] verf;
    


    void Start()
    {
        panel1.SetActive(true);
        panel2.SetActive(false);


        caracter1 = 0;
        caracter2 = 0;
        caracter3 = 0;
        rest.SetActive(false);
        Next.SetActive(false);
        count = 1;
        restart = 1;
        for (int i = 0; i < 6; i++)
        {
            imaginiDetali[i].SetActive(false);
        }

        Boom1.SetActive(false);
        Boom2.SetActive(false);
        Boom3.SetActive(false);


        l = 1;
        time = 0f;
        timeDelay = 0.01f;

        Alege.SetActive(false);

    }
    [System.Obsolete]
  
    void Update()
    {
        
        transferDate();

        yourCharacter[16] = database.itemList[10];
       
        if (restart == 1)
        {
            for (int i = 0; i < slotNum; i++)
            {
                al[i] = Random.Range(1,10);

            }
            for (int i = 0; i < slotNum; i++)
            {
                for (int j = 0; j < al.Length; j++)
                {
                    if (j == i)
                    {

                    }
                    else if (al[i] == al[j])
                    {
                        j = -1;
                        al[i] = Random.Range(1, 10);
                    }
                    else
                    {

                    }
                }
            }
            for (int i = 0; i < slotNum; i++)
            {
                
                if (i == 5)
                {
                    yourCharacter[i] = database.itemList[10];
                }
                else
                {
                    if (i >= 6)
                    {
                        yourCharacter[i] = database.itemList[0];
                    }
                    else
                    {
                        yourCharacter[i] = database.itemList[al[i]];
                    }
                }
                
            }
             
                
               
            verificare();
            istoric();
           
            for (int i = 0; i < 5; i++)
            {
                bl[i] = Random.Range(1, 10);
            }
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < bl.Length; j++)
                {
                    if (j == i)
                    {

                    }
                    else if (bl[i] == bl[j])
                    {
                        j = -1;
                        bl[i] = Random.Range(1, 10);
                    }
                    else
                    {

                    }
                }
            }



            for (int i = 12; i <= 16; i++)

           
            {
                yourCharacter[i] = database.itemList[bl[i - 12]];
            }




        }
        Alegere();
        istoric2();


     
        yourCharacter[9] = yourCharacter[12 + caracter1];
        yourCharacter[10] = yourCharacter[12 + caracter2];
        yourCharacter[11] = yourCharacter[12 + caracter3];

        restart = 0;

        for (int i = 0; i < 6; i++)
        {
            afisareCaractere(i);
        }


        
        for (int i = 0; i < slotNum; i++)
        {
            slot[i].sprite = slotSprite[i];
        }
        for (int i = 0; i < slotNum; i++)
        {

                slotSprite[i] = yourCharacter[i].icons;
            
        }


        if (gameObject1.active == false)
        {
            win.SetActive(false);
            lose.SetActive(false);
            if (yourCharacter[6].id == 10 || yourCharacter[7].id == 10 || yourCharacter[8].id == 10)
            {
                viata = yourCharacter[6].HP + yourCharacter[7].HP + yourCharacter[8].HP+(int)hpMan;
                atac = yourCharacter[6].Atac + yourCharacter[7].Atac + yourCharacter[8].Atac + (int)atacMan;
            }
            else
            {
                viata = yourCharacter[6].HP + yourCharacter[7].HP + yourCharacter[8].HP;
                atac = yourCharacter[6].Atac + yourCharacter[7].Atac + yourCharacter[8].Atac;
            }
            
            if (yourCharacter[6].Felina == 1 && yourCharacter[7].Felina == 1 || yourCharacter[6].Felina == 1 && yourCharacter[8].Felina == 1 || yourCharacter[7].Felina == 1 && yourCharacter[6].Felina == 1)
            {
                viata += 25;
            }
            if (yourCharacter[6].Felina == 1 && yourCharacter[7].Felina == 1 && yourCharacter[8].Felina == 1)
            {
                viata += 15;
            }
            if (yourCharacter[6].A == 1 && yourCharacter[7].A == 1 || yourCharacter[6].A == 1 && yourCharacter[8].A == 1 || yourCharacter[8].A == 1 && yourCharacter[7].A == 1) {
                atac += 25;
            }
            if (yourCharacter[6].Giganti == 1 && yourCharacter[7].Giganti == 1 || yourCharacter[6].Giganti == 1 && yourCharacter[8].Giganti == 1 || yourCharacter[7].Giganti == 1 && yourCharacter[8].Giganti == 1)
            {
                viata += 25;
            }
            if (yourCharacter[6].Giganti == 1 && yourCharacter[7].Giganti == 1 && yourCharacter[8].Giganti == 1)
            {
                viata += 15;
            }
            if (yourCharacter[6].B == 1 && yourCharacter[7].B == 1 || yourCharacter[6].B == 1 && yourCharacter[8].B == 1 || yourCharacter[8].B == 1 && yourCharacter[7].B == 1) {
                atac += 25;
            }
            if (yourCharacter[6].Pasari == 1 && yourCharacter[7].Pasari == 1 || yourCharacter[6].Pasari == 1 && yourCharacter[8].Pasari == 1 || yourCharacter[8].Pasari == 1 && yourCharacter[7].Pasari == 1)
            {
                atac += 25;
            }
            if (yourCharacter[6].Pasari == 1 && yourCharacter[7].Pasari == 1 && yourCharacter[8].Pasari == 1)
            {
                atac += 15;
            }
            if (yourCharacter[6].C == 1 && yourCharacter[7].C == 1 || yourCharacter[6].C == 1 && yourCharacter[8].C == 1 || yourCharacter[8].C == 1 && yourCharacter[7].C == 1)
            {
                atac += 25;
            }
            if (yourCharacter[6].inferior == 1 && yourCharacter[7].inferior == 1 && yourCharacter[8].inferior == 1)
            {
                atac += 200;
                viata += 200;
            }
            //enemy:(schim tot cu caracter1 , 2 ,3
            viataenemy = yourCharacter[9].HP + yourCharacter[10].HP + yourCharacter[11].HP;
            atacenemy = yourCharacter[9].Atac + yourCharacter[10].Atac + yourCharacter[11].Atac;

            if (yourCharacter[9].Felina == 1 && yourCharacter[10].Felina == 1 || yourCharacter[11].Felina == 1 && yourCharacter[10].Felina == 1 || yourCharacter[9].Felina == 1 && yourCharacter[11].Felina == 1)
            {
                viataenemy += 25;
            }
            if (yourCharacter[9].Felina == 1 && yourCharacter[10].Felina == 1 && yourCharacter[11].Felina == 1)
            {
                viataenemy += 15;
            }
            if (yourCharacter[9].A == 1 && yourCharacter[10].A == 1 || yourCharacter[10].A == 1 && yourCharacter[11].A == 1 || yourCharacter[9].A == 1 && yourCharacter[11].A == 1)
            {
                atacenemy += 25;
            }
            if (yourCharacter[9].Giganti == 1 && yourCharacter[10].Giganti == 1 || yourCharacter[8].Giganti == 1 && yourCharacter[10].Giganti == 1 || yourCharacter[9].Giganti == 1 && yourCharacter[11].Giganti == 1)
            {
                viataenemy += 25;
            }
            if (yourCharacter[9].Giganti == 1 && yourCharacter[10].Giganti == 1 && yourCharacter[11].Giganti == 1)
            {
                viataenemy += 15;
            }
            if (yourCharacter[9].B == 1 && yourCharacter[10].B == 1 || yourCharacter[10].B == 1 && yourCharacter[11].B == 1 || yourCharacter[11].B == 1 && yourCharacter[9].B == 1)
            {
                atacenemy += 25;
            }
            if (yourCharacter[9].Pasari == 1 && yourCharacter[10].Pasari == 1 || yourCharacter[8].Pasari == 1 && yourCharacter[10].Pasari == 1 || yourCharacter[9].Pasari == 1 && yourCharacter[11].Pasari == 1)
            {
                atacenemy += 25;
            }
            if (yourCharacter[9].Pasari == 1 && yourCharacter[10].Pasari == 1 && yourCharacter[11].Pasari == 1)
            {
                atacenemy += 15;
            }
            if (yourCharacter[9].C == 1 && yourCharacter[10].C == 1 || yourCharacter[10].C == 1 && yourCharacter[11].C == 1 || yourCharacter[9].C == 1 && yourCharacter[11].C == 1)
            {
                atacenemy += 25;
            }
            if (yourCharacter[9].inferior == 1 && yourCharacter[10].inferior == 1 && yourCharacter[11].inferior == 1)
            {
                atacenemy += 200;
                viataenemy += 200;
            }
            hptext.text = viata + " ";
            puteretext.text = atac + " ";




            hptextenemy.text = viataenemy + " ";
            puteretextenemy.text = atacenemy + " ";
            nextlvl.text = "level " + count;


        }
        else// deplasarea campionilor cand dam start
        {
            win.SetActive(false);
            lose.SetActive(false);

            if (viata > 0 && viataenemy > 0) {
                time = time + 1f * Time.deltaTime;

                if (n == 30 && l == 1)
                {
                    Boom1.SetActive(true);
                }
                if (n == 40 && l == 1)
                {
                    Boom2.SetActive(true);
                }
                if (n == 45 && l == 1)
                {
                    Boom3.SetActive(true);
                }
                if (n == 5 && l == -1)
                {
                    Boom3.SetActive(false);
                }
                if (n == 10 && l == -1)
                {
                    Boom2.SetActive(false);
                }
                if (n == 20 && l == -1)
                {
                    Boom1.SetActive(false);
                }
                //movement
                if (n == 50)
                {
                    l = l * (-1);
                    s = 2 * l;
                    n = 0;
                    if (time >= timeDelay)
                    {
                        time = 0f;
                        gameObject2.transform.position = gameObject2.transform.position + new Vector3(0f, 0f, -s);
                        gameObject3.transform.position = gameObject3.transform.position + new Vector3(0f, 0f, -l);
                        gameObject4.transform.position = gameObject4.transform.position + new Vector3(0f, 0f, -s);
                        gameObject5.transform.position = gameObject5.transform.position + new Vector3(0f, 0f, s);
                        gameObject6.transform.position = gameObject6.transform.position + new Vector3(0f, 0f, l);
                        gameObject7.transform.position = gameObject7.transform.position + new Vector3(0f, 0f, s);

                    }
                    if (l == 1)
                    {
                        viata = viata - atacenemy;
                        hptext.text = viata + " ";
                        viataenemy = viataenemy - atac;
                        hptextenemy.text = viataenemy + " ";
                    }
                }
                else
                {
                    s = 2 * l;
                    if (time >= timeDelay)
                    {
                        time = 0f;
                        gameObject2.transform.position = gameObject2.transform.position + new Vector3(0f, 0f, -s);
                        gameObject3.transform.position = gameObject3.transform.position + new Vector3(0f, 0f, -l);
                        gameObject4.transform.position = gameObject4.transform.position + new Vector3(0f, 0f, -s);
                        gameObject5.transform.position = gameObject5.transform.position + new Vector3(0f, 0f, s);
                        gameObject6.transform.position = gameObject6.transform.position + new Vector3(0f, 0f, l);
                        gameObject7.transform.position = gameObject7.transform.position + new Vector3(0f, 0f, s);

                        n++;
                    }
                }
            }
            else
            {
                Boom1.SetActive(false);
                Boom2.SetActive(false);
                Boom3.SetActive(false);
                if (viata <= 0 && viata < viataenemy)
                {
                    rest.SetActive(true);
                    lose.SetActive(true);
                }
                else
                {
                    istoric();
                    Next.SetActive(true);
                    win.SetActive(true);

                }

            }
        }
    }
    [System.Obsolete]
    public void StartDrag(Image slotX)
    {

        //print("asta");
        if (gameObject1.active == false)
        {
            for (int i = 0; i < slotNum; i++)
            {
                if (slot[i] == slotX)
                {

                    a = i;
                }
            }
        }
    }
    [System.Obsolete]
    public void Click(Image slotX)
    {
        for (int i = 0; i < 6; i++)
        {
            if (slot[i] == slotX)
            {
                if (imaginiDetali[i].active == false)
                {

                    imaginiDetali[i].SetActive(true);
                    print(i);
                    if (yourCharacter[i].id == 10)
                    {
                        detali[i].text = " " + yourCharacter[i].name + "\n" + " Viata: " + (int)hpMan + "\n" + " Atac: " + (int)atacMan;
                    }
                    else
                    {
                        detali[i].text = " " + yourCharacter[i].name + "\n" + " Viata: " + yourCharacter[i].HP + "\n" + " Atac: " + yourCharacter[i].Atac + "\n" + yourCharacter[i].description;
                    }
                }
                    
                else
                {
                    imaginiDetali[i].SetActive(false);
                }
            }
            else
            {
                imaginiDetali[i].SetActive(false);
            }
        }
    }
    [System.Obsolete]
    public void Drop(Image slotX)
    {
        if (gameObject1.active == false) {
            if (a != b)
            {

                drag[0] = yourCharacter[a];
                yourCharacter[a] = yourCharacter[b];
                yourCharacter[b] = drag[0];
                a = 0;
                b = 0;
            }
        }
    }
    [System.Obsolete]
    public void Enter(Image slotX)
    {
        if (gameObject1.active == false)
        {
            for (int i = 0; i < slotNum; i++)
            {
                if (slot[i] == slotX)
                {
                    b = i;
                }
            }
        }
    }
    [System.Obsolete]
    public void OnButtonPress()
    {

        StartButton.SetActive(false);
        if (gameObject1.active == false)
        {
            gameObject1.SetActive(true);
        }
        else
        {
            gameObject1.SetActive(false);
        }

    }
    [System.Obsolete]
    public void OnButtonPress2()
    {

        StartButton.SetActive(true);
        if (win.active == true)
        {
            restart = 1;
            count += 1;

        }
        Next.SetActive(false);
        rest.SetActive(false);

        if (gameObject1.active == false)
        {
            gameObject1.SetActive(true);
        }
        else
        {
            gameObject1.SetActive(false);
        }
        poscounter++;

    }
    [System.Obsolete]
    public void onbuttonpress3()
    {
        // OnButtonPress();
        gameObject1.SetActive(false);
        StartButton.SetActive(true);
        restart = 1;
        Next.SetActive(false);
        rest.SetActive(false);
        win.SetActive(false);
        lose.SetActive(false);
        count = 1;
        // verificare();
        // Alegere();
    }

    [System.Obsolete]
    public void onbuttonpress4()
    {
        doresti();
    }
    public void LoadSceneByIndex(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void afisareCaractere(int i)
    {
        if (yourCharacter[i + 6] != database.itemList[0])
        {
            leu[i].SetActive(false);
            tigru[i].SetActive(false);
            pisica[i].SetActive(false);
            cioara[i].SetActive(false);
            pinguin[i].SetActive(false);
            vultur[i].SetActive(false);
            hpopotam[i].SetActive(false);
            crocodil[i].SetActive(false);
            elefant[i].SetActive(false);
            man[i].SetActive(false);
            if (yourCharacter[i + 6].id == 1)
            {
                leu[i].SetActive(true);
            }
            if (yourCharacter[i + 6].id == 2)
            {
                tigru[i].SetActive(true);

            }
            if (yourCharacter[i + 6].id == 3)
            {
                pisica[i].SetActive(true);

            }
            if (yourCharacter[i + 6].id == 4)
            {
                cioara[i].SetActive(true);
            }
            if (yourCharacter[i + 6].id == 5)
            {
                pinguin[i].SetActive(true);
            }
            if (yourCharacter[i + 6].id == 6)
            {
                vultur[i].SetActive(true);
            }
            if (yourCharacter[i + 6].id == 7)
            {
                hpopotam[i].SetActive(true);
            }
            if (yourCharacter[i + 6].id == 8)
            {
                crocodil[i].SetActive(true);
            }
            if (yourCharacter[i + 6].id == 9)
            {
                elefant[i].SetActive(true);
            }
            if (yourCharacter[i + 6].id == 10)
            {
                man[i].SetActive(true);
            }

        }
        else
        {
            leu[i].SetActive(false);
            tigru[i].SetActive(false);
            pisica[i].SetActive(false);
            cioara[i].SetActive(false);
            pinguin[i].SetActive(false);
            vultur[i].SetActive(false);
            hpopotam[i].SetActive(false);
            crocodil[i].SetActive(false);
            elefant[i].SetActive(false);
            man[i].SetActive(false);
        }
    }
    public void Alegere()//alegerea calculatorului in fuctie de putere si combinatii
    {

        calcul = 0;// a = atac , b= putere , calcul = a+b
        
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                for (int k = 0; k < 5; k++)

                {
                    if (i != j && i != k && j != k)
                    {
                        a1 = yourCharacter[12 + i].Atac + yourCharacter[12 + j].Atac + yourCharacter[12 + k].Atac;
                        b1 = yourCharacter[12 + i].HP + yourCharacter[12 + j].HP + yourCharacter[12 + k].HP;
                        if (yourCharacter[12 + i].Felina == 1 && yourCharacter[12 + j].Felina == 1 || yourCharacter[12 + i].Felina == 1 && yourCharacter[12 + k].Felina == 1 || yourCharacter[12 + j].Felina == 1 && yourCharacter[12 + k].Felina == 1)
                        {
                            b1 += 25;
                        }
                        if (yourCharacter[12 + i].Felina == 1 && yourCharacter[12 + j].Felina == 1 && yourCharacter[12 + k].Felina == 1)
                        {
                            b1 += 15;
                        }
                        if (yourCharacter[12 + i].A == 1 && yourCharacter[12 + j].A == 1 || yourCharacter[12 + i].A == 1 && yourCharacter[12 + k].A == 1 || yourCharacter[12 + j].A == 1 && yourCharacter[12 + k].A == 1)
                        {
                            a1 += 25;
                        }
                        if (yourCharacter[12 + i].Giganti == 1 && yourCharacter[12 + j].Giganti == 1 || yourCharacter[12 + i].Giganti == 1 && yourCharacter[12 + k].Giganti == 1 || yourCharacter[12 + j].Giganti == 1 && yourCharacter[12 + k].Giganti == 1)
                        {
                            b1 += 25;
                        }
                        if (yourCharacter[12 + i].Giganti == 1 && yourCharacter[12 + j].Giganti == 1 && yourCharacter[12 + k].Giganti == 1)
                        {
                            b1 += 15;
                        }
                        if (yourCharacter[12 + i].B == 1 && yourCharacter[12 + j].B == 1 || yourCharacter[12 + i].B == 1 && yourCharacter[12 + k].B == 1 || yourCharacter[12 + k].B == 1 && yourCharacter[12 + j].B == 1)
                        {
                            a1 += 25;
                        }
                        if (yourCharacter[12 + i].Pasari == 1 && yourCharacter[12 + j].Pasari == 1 || yourCharacter[12 + i].Pasari == 1 && yourCharacter[12 + k].Pasari == 1 || yourCharacter[12 + j].Pasari == 1 && yourCharacter[12 + k].Pasari == 1)
                        {
                            a1 += 25;
                        }
                        if (yourCharacter[12 + i].Pasari == 1 && yourCharacter[12 + j].Pasari == 1 && yourCharacter[12 + k].Pasari == 1)
                        {
                            a1 += 15;
                        }
                        if (yourCharacter[12 + i].C == 1 && yourCharacter[12 + j].C == 1 || yourCharacter[12 + i].C == 1 && yourCharacter[12 + k].C == 1 || yourCharacter[12 + j].C == 1 && yourCharacter[12 + k].C == 1)
                        {
                            a1 += 25;
                        }
                        if (yourCharacter[12 + i].inferior == 1 && yourCharacter[12 + j].inferior == 1 && yourCharacter[12 + k].inferior == 1)
                        {
                            a1 += 200;
                            b1 += 200;
                        }

                        if (a1 + b1 >= calcul)//se salveaza doar daca calculul curent este mai mare decat cel salvat anterior
                        {
                            calcul = a1 + b1;

                        }
                        if (a1 + b1 == calcul)// se salveaza pozitiile unde au fost gasite a1 si b1 curente salvate
                        {
                            caracter1 = i;
                            caracter2 = j;
                            caracter3 = k;
                        }
                    }
                }
            }
        }
    }
    [System.Obsolete]
    public void istoric()// dupa apasarea butonului start acesta salveaza campionii care au fost pe primele pozitii(cele dintre care am ales)
    {
        if (StartButton.active == true)
        {
            pos1[poscounter] = yourCharacter[0].id;
            pos2[poscounter] = yourCharacter[1].id;
            pos3[poscounter] = yourCharacter[2].id;
            pos4[poscounter] = yourCharacter[3].id;
            pos5[poscounter] = yourCharacter[4].id;
        }
    }
    [System.Obsolete]
    public void istoric2() // acesta dup? apasarea butonului next ne salveaza campionii cu care am castigat
    {
        if (Next.active == true)
        {
            pos6[poscounter] = yourCharacter[8].id;
            pos7[poscounter] = yourCharacter[6].id;
            pos8[poscounter] = yourCharacter[7].id;

        }
    }
    [System.Obsolete]
    public void verificare()// verificam daca cele 5 caractere au mai fost afisate
    {
        for (int j = 0; j < 100; j++)
        {
            if (pos6[j] != 0 && pos7[j] != 0 && pos8[j] != 0)
            {

                if (yourCharacter[0].id == pos1[j] || yourCharacter[0].id == pos2[j] || yourCharacter[0].id == pos3[j] || yourCharacter[0].id == pos4[j] || yourCharacter[0].id == pos5[j])
                {
                    if (yourCharacter[1].id == pos1[j] || yourCharacter[1].id == pos2[j] || yourCharacter[1].id == pos3[j] || yourCharacter[1].id == pos4[j] || yourCharacter[1].id == pos5[j])
                    {
                        if (yourCharacter[2].id == pos1[j] || yourCharacter[2].id == pos2[j] || yourCharacter[2].id == pos3[j] || yourCharacter[2].id == pos4[j] || yourCharacter[2].id == pos5[j])
                        {
                            if (yourCharacter[3].id == pos1[j] || yourCharacter[3].id == pos2[j] || yourCharacter[3].id == pos3[j] || yourCharacter[3].id == pos4[j] || yourCharacter[3].id == pos5[j])
                            {
                                if (yourCharacter[4].id == pos1[j] || yourCharacter[4].id == pos2[j] || yourCharacter[4].id == pos3[j] || yourCharacter[4].id == pos4[j] || yourCharacter[4].id == pos5[j])
                                {
                                    verf[j] = 1;
                                    doresti();
                                    
                                }
                            }
                        }
                    }
                }
            }
            else
            {
            }
        }
    }

    [System.Obsolete]
    public void doresti()//in caz ca s-a castigat cu campionii respectivi ne va intreba daca dorim sa le reutilizam
    {
        asta = 0;

        for (int i = 0; i < verf.Length; i++)
        {
            if (verf[i] == 1)
            {
                asta = i;
            }
        }
        for (int j = 0; j < 6; j++)// preschimbarea campionilor de pe linia de jos pe pozitiile de lupta
        {
            if (yourCharacter[j].id == pos6[asta])
            {
                yourCharacter[j] = database.itemList[0];
            }
            if (yourCharacter[j].id == pos7[asta])
            {
                yourCharacter[j] = database.itemList[0];
            }
            if (yourCharacter[j].id == pos8[asta])
            {
                yourCharacter[j] = database.itemList[0];
            }

        }


        yourCharacter[6] = database.itemList[pos6[asta]];
        yourCharacter[7] = database.itemList[pos7[asta]];
        yourCharacter[8] = database.itemList[pos8[asta]];// inlocuirea in casutele de lupta

        AlegeleSprite[0] = yourCharacter[6].icons;
        AlegeleSprite[1] = yourCharacter[7].icons;
        AlegeleSprite[2] = yourCharacter[8].icons;// afisarea imaginii pe casuta

        alegele[0].sprite = AlegeleSprite[0];
        alegele[1].sprite = AlegeleSprite[1];
        alegele[2].sprite = AlegeleSprite[2];

        afisareimagine();

    }
    public void buttondoresc()
    {
        Alege.SetActive(false);
    }
    public void nudoresc()// ne lasa sa refacem alegerea de joc
    {
        for (int i = 0; i < 5; i++)
        {
            if (yourCharacter[i].id == 0)
            {
                if (yourCharacter[6].id != 0)
                {
                    yourCharacter[i] = yourCharacter[6];
                    yourCharacter[6] = database.itemList[0];
                }
                else
                {
                    if (yourCharacter[7].id != 0)
                    {
                        yourCharacter[i] = yourCharacter[7];
                        yourCharacter[7] = database.itemList[0];
                    }
                    else
                    {
                        yourCharacter[i] = yourCharacter[8];
                        yourCharacter[8] = database.itemList[0];
                    }
                }

            }
        }
        Alege.SetActive(false);
    }
    [System.Obsolete]
    public void afisareimagine()
    {
        if (win.active == true || lose.active == true)
        {
            Alege.SetActive(false);
        }
        else
        {
            Alege.SetActive(true);
        }
    }
    public void transferDate()// transfer de date pentru campionul customizat
    {
        atacMan = float.Parse(atacManT.text);
        hpMan = float.Parse(hpManT.text);
    }


}
