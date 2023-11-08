using System;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using static PlanetData;

public class Trajectory : MonoBehaviour
{
    public int numberOfPlanets; // Nombre de planètes
    public DateTime currentTime; // Temps de départ
    public Boolean showAllTrajectories;
    public PlanetManager planetManager;

    private List<LineRenderer> lineRenderers = new List<LineRenderer>();

    void Start()
    {
        showAllTrajectories = true;
        
        ToggleTrajectories();
    }

    public void CreateTrajectoryLines()
    {
        numberOfPlanets = planetManager.planets.Length;

        for (int i = 0; i < numberOfPlanets; i++)
        {
            GameObject lineObject = new GameObject("TrajectoryLine_" + i);
            LineRenderer lineRenderer = lineObject.AddComponent<LineRenderer>();
            lineRenderers.Add(lineRenderer);
            DrawTrajectory(planetManager.planets[i], lineRenderer);
        }
    }

    public void DrawTrajectory(PlanetObject planet, LineRenderer lineRenderer)
    {
        List<Vector3> trajectoryPoints = CalculateTrajectory(planet);
        lineRenderer.positionCount = trajectoryPoints.Count;
        lineRenderer.SetPositions(trajectoryPoints.ToArray());
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
    }

    public List<Vector3> CalculateTrajectory(PlanetObject planet)
    {
        List<Vector3> points = new List<Vector3>();
        float totalDays = planet.period;
        int numberPoints = 100;
        float timeInterval = totalDays/numberPoints;
        DateTime targetTime = PlanetManager.current.Date;

        for (int i = 0; i <= numberPoints; i++)
        {
            Vector3 planetPosition = GetPlanetPosition(planet.PlanetType, targetTime);
            points.Add(planetPosition);
            targetTime = targetTime.AddDays(timeInterval);
        }

        return points;
    }

    public void ToggleTrajectories()
    {
        foreach (LineRenderer lineRenderer in lineRenderers)
        {
            lineRenderer.enabled = showAllTrajectories;
        }
        showAllTrajectories =!showAllTrajectories;

    }
}
