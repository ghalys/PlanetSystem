using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleToggleScript : MonoBehaviour
{
    public PlanetManager planetManager;  
    public Boolean RealScale;

    // Start is called before the first frame update
    void Start()
    {
        RealScale =true;
        
    }
    public void UpdateSizePlanets(){
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
        RealScale = !RealScale;

      
    }


}
