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
        List<String> nombres = new List<string> { "Seleccione" };
        string[] lines = System.IO.File.ReadAllLines(@"DatosZonas.txt");
        foreach (string line in lines)
        {
            nombres.Add(line.Trim());
        }

        Dropdown.AddOptions(nombres);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
