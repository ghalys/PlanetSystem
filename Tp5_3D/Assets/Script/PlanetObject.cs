using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetObject
{
    public GameObject planetObject ;
    public PlanetData.Planet PlanetType;
    public float period;
    public float size;
    public string info;

    public PlanetObject(GameObject gameObject, PlanetData.Planet planetType, float Period, float Size, string text)
    {
        planetObject = gameObject;
        PlanetType = planetType;
        period=Period;
        size = Size;
        info = text;
    }
}

