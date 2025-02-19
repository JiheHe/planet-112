using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlantName // Actual names of the plants! 
{
    Bob, //0
    MrHealer,
    Blushberry,
    SnakePlant,
    Lilypad,
    PeachTree,
    PitcherPlant,
    GoliathSunflower,
    CryingLavender,
    GinkgoTree,
}

public enum PlantTargetPriority // the priority of beginning targeted by pests.
{
    one = 1, // lowest currently
    two,
    three,
    four,
    five // highest currently
}

public enum HealMode
{
    flat, // flat amt
    max, // max hp %
    current, // curr hp %
    missing, // curr missing hp %
}

// Data is predefined and non-dynamic, but ideally this script is only spawned once at beginning and sticks to persistent managers. 
public class PlantStorage : MonoBehaviour // gonna switch to scriptable object in the future, or no need? Ask Jacob. 
{
    public PlantScript[] plantPrefabsInit; // declared in editor
    private static PlantScript[] plantPrefabs; //MAKE SURE THE PREFAB INDEX MATCHES ENUM OF NAME! // had to do this cuz Unity hides static.

    private void Awake() // test if this can return null possibly. Test sult: nope, we good. 
    {
        plantPrefabs = plantPrefabsInit; // passed by reference I think, so run time no need to worry. Static for convenience. 
    }

    public static GameObject GetPlantPrefab(PlantName plantName)
    {
        return plantPrefabs[(int)plantName].gameObject; // returns the prefab blueprint
    } 
} 
