using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Globalization;
using System.Security.Permissions;
using System;

public class movcar : MonoBehaviour
{
    /*public Text Result;

    void Start()
    {
        // A correct website page.
        StartCoroutine(GetRequest("http://api.timezonedb.com/v2.1/get-time-zone?key=SQU3IIYRYDLP&format=json&by=zone&zone=America/Lima"));

        // A non-existing page.
        //StartCoroutine(GetRequest("https://error.html"));
        
    }
    IEnumerator GetRequest(string uri)
    {

        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();
            string[] datos = webRequest.downloadHandler.text.Split(',');
            string[] datos1 = datos[12].Split(' ');
            string[] datos2 = datos1[1].Split(':');
            Result.text = "" + datos2[0];

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            if (webRequest.isNetworkError)
            {
                Debug.Log(pages[page] + ": Error: " + webRequest.error);
            }
            else
            {
                Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
    public Text Result;
    public Text TiempoDia;
    public Dropdown dropdown;
    public string resultado;
    public string pais;
    public GameObject inputField;
    public GameObject textDisplay;
    public GameObject gTimeOfDay;
    private ToD_Base clToDBase;
    public float horaPais;
    /*public void storeName() {
        Result = inputField.GetComponent<Text>().text;
        textDisplay.GetComponent<Text>().text = "Bienvenido " + Result + " al juego";
    }*/
    public void storeName()
    {
        pais = inputField.GetComponent<Text>().text.Trim() == "" ? dropdown.options[dropdown.value].text.ToString(): inputField.GetComponent<Text>().text.Trim();
        inputField.GetComponent<Text>().text = dropdown.options[dropdown.value].text.ToString();
        TiempoDia.text = pais;
        StartCoroutine(GetRequest("http://api.timezonedb.com/v2.1/get-time-zone?key=SQU3IIYRYDLP&format=json&by=zone&zone="+pais));
        //StartCoroutine(GetRequest("http://api.timezonedb.com/v2.1/get-time-zone?key=SQU3IIYRYDLP&format=json&by=zone&zone=America/Argentina/Buenos_Aires"));
    }
    IEnumerator GetRequest(string uri)
    {

        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {

            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();
            string temp = webRequest.downloadHandler.text;
            resultado = "" + temp.Substring(temp.LastIndexOf(" ") + 1, 2); 
            Result.text = "" + temp.Substring(temp.LastIndexOf(" ") + 1, 8);
            try
            {
                int hora = Int32.Parse("" + temp.Substring(temp.LastIndexOf(" ") + 1, 2)); 
                if(hora >= 6 && hora < 12) {
                    TiempoDia.text = "Mañana";
                }else if(hora>=12 && hora < 19)
                {
                    TiempoDia.text = "Tarde";
                }
                else if (hora >= 0 && hora < 6)
                {
                    TiempoDia.text = "Madrugada";
                }
                else
                {
                    TiempoDia.text = "Noche";
                }
            }
            catch (Exception)
            {
                TiempoDia.text = "Indefinido";
            }

            /*string[] datos = webRequest.downloadHandler.text.Split(',');
            string[] datos1 = datos[12].Split(' ');
            string[] datos2 = datos1[1].Split(':');
            resultado = "" + datos[12].Substring(datos[12].IndexOf(" ")+1, 2);
            Result.text = "" + datos[12].Substring(datos[12].IndexOf(" ")+1,8);*/
            horaPais = float.Parse(resultado);
            horaPais = horaPais / 24.0f;
            
            clToDBase = gTimeOfDay.GetComponent<ToD_Base>();
            clToDBase.FCurrentTimeOfDay(horaPais);
            clToDBase.UpdateTimeset();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            if (webRequest.isNetworkError)
            {
                Debug.Log(pages[page] + ": Error: " + webRequest.error);
            }
            else
            {
                Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
            }

        }
    }
}
