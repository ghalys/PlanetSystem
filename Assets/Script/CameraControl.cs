using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UIElements;
using UnityEngine.PlayerLoop;

public class CameraControl : MonoBehaviour

{
    public UnityEngine.UI.Slider zoomSlider;     // Pour le contrôle du zoom
    public Camera mainCamera;
    public float rotationSpeed = 5;
    public float zoomDistance = 1000.0f; // Distance de zoom depuis la planète
    private bool zoomed = false; // Suivi de l'état du zoom
    private Vector3 InitialPosition; 
    private PlanetObject SelectedPlanet;
    public TMP_Text textElement; 
    public PlanetManager planetManager;  


    void Start(){
        textElement.enabled = false;
        InitialPosition = mainCamera.transform.position;
    }
    
    void Update()
    {
        rotateView();

        if (Input.GetMouseButtonDown(0)) // Vérifie si le bouton gauche de la souris est cliqué
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Vérifie si le rayon lancé depuis la caméra touche un objet
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                // Si l'objet touché est la planète (vérifie par tag par exemple)
                if (hit.collider.tag == "Planet")
                {
                    foreach (PlanetObject planet in planetManager.planets){
                        if (hit.collider.gameObject==planet.planetObject){
                            SelectedPlanet = planet;
                        }
                    }
                    if (!zoomed) // Si nous ne sommes pas déjà zoomés
                    {
                        // Zoomer sur la planète
                        zoomed = true; // Mettre à jour l'état du zoom
                        textElement.enabled = true; 
                        textElement.text = SelectedPlanet.info;
                        InitialPosition = mainCamera.transform.position;
                    }
                    else
                    {
                        SelectedPlanet =null;
                        textElement.enabled = false; 

                        // Revenir à la vue initiale
                        ResetZoom();
                        zoomed = false; // Mettre à jour l'état du zoom
                    }
                }
            }
        }
    }

    public void rotateView(){
        if (Input.GetMouseButton(1)) // Vérifie si le clic droit est enfoncé
        {
            mainCamera.transform.eulerAngles += rotationSpeed * new Vector3( -Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"),0) ; 
        }
    }
    void LateUpdate()
    {
        if (SelectedPlanet != null)
        {   
            Transform target = SelectedPlanet.planetObject.transform; 
            mainCamera.transform.position = target.position - (target.forward * zoomDistance);
            mainCamera.transform.LookAt(target);
        }
    }

    void ResetZoom()
    {
        mainCamera.transform.position = InitialPosition;
    }


    public void OnSliderValueChanged()
    {
        float zoomValue = zoomSlider.value;
        Vector3 cameraPosition = mainCamera.transform.position;
        cameraPosition.z = +zoomValue; 
        mainCamera.transform.position = cameraPosition;
    }
    }
