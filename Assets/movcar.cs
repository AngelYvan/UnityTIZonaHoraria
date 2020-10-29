using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Globalization;
using System.Security.Permissions;
using System;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

public class movcar : MonoBehaviour
{
    public Text Result;
    public Text TiempoDia;
    public Dropdown dropdown;
    public Dropdown dropdownNubes;
    public Dropdown dropdownClima;
    public GameObject inputField;
    public GameObject textDisplay;
    public GameObject gTimeOfDay;
    public GameObject gWeatherMaster;
    private ToD_Base clToDBase;
    private Weather_Controller weather_Controller;
    public float horaPais;
    /*public void storeName() {
        Result = inputField.GetComponent<Text>().text;
        textDisplay.GetComponent<Text>().text = "Bienvenido " + Result + " al juego";
    }*/
    public void storeName()
    {
        String hora = dropdown.options[dropdown.value].text.ToString();
        //Debug.Log(hora);
        horaPais = float.Parse(hora);
        horaPais = horaPais / 24.0f;
        clToDBase = gTimeOfDay.GetComponent<ToD_Base>();
        clToDBase.FCurrentTimeOfDay(horaPais);
        clToDBase.UpdateTimeset();

        weather_Controller = gWeatherMaster.GetComponent<Weather_Controller>();
        

        String clima = dropdownClima.options[dropdownClima.value].text.ToString();

        switch (clima) {
            case "Soleado":
                weather_Controller.ChangeWeatherToSun();
                weather_Controller.Update();
                break;
            case "Lluvia":
                weather_Controller.ChangeWeatherToRain();
                weather_Controller.Update();
                break;
            case "Granizado":
                weather_Controller.ChangeWeatherToSnow();
                weather_Controller.Update();
                break;
            case "Nublado":
                weather_Controller.ChangeWeatherToCloudy();
                weather_Controller.Update();
                break;
        }
    }
}
