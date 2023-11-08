using System;
using Unity.VisualScripting;
using UnityEngine;
public class PlanetManager : MonoBehaviour
{
   public static PlanetManager current;
   public GameObject Earth; 
   public GameObject Venus; 
   public GameObject Mercury; 
   public GameObject Neptune; 
   public GameObject Mars; 
   public GameObject Jupiter; 
   public GameObject Saturn; 
   public GameObject Uranus; 
   public PlanetObject[] planets;
   public Trajectory trajectory;
   private float EarthSize = 6371f;
 
  [SerializeField]
 public float pace;
 public float Pace
        {
        get => pace;
        set
        {
        pace = value;
        }
        }


 [SerializeField]
 private UDateTime date;
 public UDateTime Date
        {
        get => date;
        set
        {
        date = value;
        TimeChanged(value.dateTime); //Fire the event
        }
        }

 public event Action<DateTime> OnTimeChange;

 public void TimeChanged(DateTime newTime)
    {
    OnTimeChange?.Invoke(newTime);
    }
 private void Awake()
   {
   if (current == null)
   {
   current = this;
   }
   else
   {
   Destroy(obj: this);
   }
   date = DateTime.Now;
   }
 
void Start(){
   planets = new PlanetObject[] {
        new PlanetObject(Earth, PlanetData.Planet.Earth,366,1f,"Planète Terre"),
        new PlanetObject(Venus, PlanetData.Planet.Venus,225,6051/EarthSize,"venus"),
        new PlanetObject(Mercury, PlanetData.Planet.Mercury,88,2439/EarthSize,"Planète Mercure"),
        new PlanetObject(Saturn, PlanetData.Planet.Saturn,10760,58232/EarthSize,"Planète Saturn"),
        new PlanetObject(Jupiter, PlanetData.Planet.Jupiter,4333,69911/EarthSize,"Planète Jupiter"),
        new PlanetObject(Neptune, PlanetData.Planet.Neptune,60217,24622/EarthSize,"Planète Neptune"),
        new PlanetObject(Uranus, PlanetData.Planet.Uranus,30686,25362/EarthSize,"Planète Uranus"),
        new PlanetObject(Mars, PlanetData.Planet.Mars,687,3389/EarthSize,"Planète Mars"),
    };
    trajectory.CreateTrajectoryLines();
}
void Update (){
   Date= date.dateTime.AddDays(pace);

}

}

