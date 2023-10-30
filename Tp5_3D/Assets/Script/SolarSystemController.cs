using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class SolarSystemController : MonoBehaviour
{

    public PlanetObject[] planets;
    public PlanetManager planetManager;  


    void Start()
    {
    planets = planetManager.planets;
    PlanetManager.current.OnTimeChange += UpdatePosition;
    }

    /// <summary>
    /// Update the position of a Planet at a given time (in AU)
    /// </summary>
    /// <param name="t"></param>
    /// <returns></returns>
    public  void UpdatePosition(DateTime t){
        foreach (PlanetObject planet in planets)
            {
                Vector3 position = PlanetData.GetPlanetPosition(planet.PlanetType,t);
                planet.planetObject.transform.position =position ;
            }
    }



}
