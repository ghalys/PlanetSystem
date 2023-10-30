using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderPace : MonoBehaviour
{
    public PlanetManager planetManager;  

    public Slider Slider;     // Pour le contrôle du zoom
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        public void UpdatePacePlanets()
    {
        float Value = Slider.value;
        planetManager.Pace = Value;
    }
}
