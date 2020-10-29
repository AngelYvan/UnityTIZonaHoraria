using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrpDownNubes : MonoBehaviour
{
    public Dropdown Dropdown;
    // Start is called before the first frame update
    void Start()
    {
        Lista();
    }
    private void Lista()
    {
        List<String> nubes = new List<string> { "Seleccione" };
        nubes.Add("Despejado");
        nubes.Add("Nublado");
        /*string[] lines = System.IO.File.ReadAllLines(@"DatosZonas.txt");
        foreach (string line in lines)
        {
            nombres.Add(line.Trim());
        }*/

        Dropdown.AddOptions(nubes);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
