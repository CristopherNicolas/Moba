using System;
using UnityEngine;
using System.Linq;
public class Iluminacion : MonoBehaviour
{
    Light directionalLight;
    private void Start()
    {
        directionalLight = transform.GetChild(0).GetComponent<Light>();
        string time = DateTime.Now.ToString("h:mm:ss tt");
        var arr = time.Split(' ');
        if(arr.Last().ToLower().Contains("am") && int.Parse(arr.First())<6)
        {
            // luz de noche
            directionalLight.transform.rotation = Quaternion.Euler(274,0,0);
        }
        else if(arr.Last().ToLower().Contains("am") && int.Parse(arr.First()) >= 6)
        {
            // luz de mañana
            directionalLight.transform.rotation = Quaternion.Euler(22,0,0);
        }
        else if (arr.Last().ToLower().Contains("pm") && int.Parse(arr.First()) < 8)
        {
            // luz dia 
            directionalLight.transform.rotation = Quaternion.Euler(90,0,0);
        }
        else if (arr.Last().ToLower().Contains("pm") && int.Parse(arr.First()) < 8)
        {
            // luz noche
            directionalLight.transform.rotation = Quaternion.Euler(274,0,0);
        }
    }
}
