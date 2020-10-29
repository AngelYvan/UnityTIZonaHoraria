using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrpDownClima : MonoBehaviour
{
    public Dropdown Dropdown;
    // Start is called before the first frame update
    void Start()
    {
        Lista();
    }
    private void Lista()
    {
        List<String> clima = new List<string> { "Seleccione" };
        clima.Add("Soleado");
        clima.Add("Lluvia");
        clima.Add("Granizado");
        clima.Add("Nublado");
        /*string[] lines = System.IO.File.ReadAllLines(@"DatosZonas.txt");
        foreach (string line in lines)
        {
            nombres.Add(line.Trim());
        }*/

        Dropdown.AddOptions(clima);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
