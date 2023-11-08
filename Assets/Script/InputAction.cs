using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputAction : MonoBehaviour
{
  
    public PlanetManager planetManager;  
    public Boolean RealScale; 
 
    // Start is called before the first frame update
    void Start()
    {
        RealScale = false;
    }
    
 
    public void UpdateSizePlanets(){
        RealScale = ! RealScale;
        if(RealScale)
        {
            foreach (PlanetObject planet in planetManager.planets)
            {  
                planet.planetObject.transform.localScale *= planet.size;
            }
        }
        else {
            foreach (PlanetObject planet in planetManager.planets)
            {  

                planet.planetObject.transform.localScale /= planet.size;
            }
        }
    }

    public void UpdateDateFromInput(string input)
    {
        if (DateTime.TryParse(input, out DateTime newDate))
        {
             planetManager.Date =  newDate;
        }
        else
        {
            Debug.LogWarning("Date non valide : " + input);
        }
    }

}
