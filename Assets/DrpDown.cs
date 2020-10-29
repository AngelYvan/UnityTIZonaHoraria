using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrpDown : MonoBehaviour
{
    public Dropdown Dropdown;
    // Start is called before the first frame update
    void Start()
    {
        Lista();
    }

    private void Lista()
    {
        List<String> horas = new List<string> { "Seleccione" };
        horas.Add("0");
        horas.Add("1");
        horas.Add("2");
        horas.Add("3");
        horas.Add("4");
        horas.Add("5");
        horas.Add("6");
        horas.Add("7");
        horas.Add("8");
        horas.Add("9");
        horas.Add("10");
        horas.Add("11");
        horas.Add("12");
        horas.Add("13");
        horas.Add("14");
        horas.Add("15");
        horas.Add("16");
        horas.Add("17");
        horas.Add("18");
        horas.Add("19");
        horas.Add("20");
        horas.Add("21");
        horas.Add("22");
        horas.Add("23");
        /*string[] lines = System.IO.File.ReadAllLines(@"DatosZonas.txt");
        foreach (string line in lines)
        {
            nombres.Add(line.Trim());
        }*/

        Dropdown.AddOptions(horas);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
