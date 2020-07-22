using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using UnityEngine.UI;

// UnityWebRequest.Get example

// Access a website and use UnityWebRequest.Get to download a page.
// Also try to download a non-existing page. Display the error.

public class movcar : MonoBehaviour
{
    public Text Result;

    void Start()
    {
        // A correct website page.
        StartCoroutine(GetRequest("http://api.timezonedb.com/v2.1/get-time-zone?key=3YY8K2D2GPTU&format=json&by=zone&zone=Antarctica/Palmer"));

        // A non-existing page.
        //StartCoroutine(GetRequest("https://error.html"));
    }

    IEnumerator GetRequest(string uri)
    {

        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
        
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] datos =webRequest.downloadHandler.text.Split(',');
            string []datos1= datos[12].Split(' ');
            string []datos2= datos1[1].Split(':');
            Result.text=""+datos2[0];
               
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