using UnityEngine;
using System.Collections;

public class StreetViewImageLoader : MonoBehaviour
{

    public double heading = 0.0;
    public double pitch = 0.0;

    //渋谷スクランブル交差点
    private double longitude = 139.7003779;
    private double latitude = 35.6596065;

    private int width = 640;
    private int height = 640;

    private string api_key = "YOUR_API_KEY";

    // Use this for initialization
    void Start()
    {
        StartCoroutine(GetStreetViewImage(latitude, longitude, heading, pitch));
    }

    private IEnumerator GetStreetViewImage(double latitude, double longitude, double heading, double pitch)
    {
        string url = "http://maps.googleapis.com/maps/api/streetview?" + "size=" + width + "x" + height + "&location=" + latitude + "," + longitude + "&heading=" + heading + "&pitch=" + pitch + "&fov=90&sensor=false" + "&key=" + api_key;

        WWW www = new WWW(url);
        yield return www;

        GetComponent<Renderer>().material.mainTexture = www.texture;
    }
}
