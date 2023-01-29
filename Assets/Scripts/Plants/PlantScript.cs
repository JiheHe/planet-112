using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

// This is an abstract class: we can't create instances of it, but other (non-abstract) classes can inherit from this. In general, you can have specific variables to child classes (which inherit from this class).
public abstract class PlantScript : MonoBehaviour
{
    // The scriptable oxject that contains fixed (non-dynamic) data about this plant.
    public Plant plantSO;
    
    // Plant module Dict. They are separated by function. They are not in the scriptable object because that can't have runtime-changeable data.
    protected Dictionary<PlantModuleEnum, IPlantModule> plantModules = new Dictionary<PlantModuleEnum, IPlantModule>();

    // this needs to be here, because each instance has its own sprite renderer
    protected SpriteRenderer spriteRenderer; // our plants might use animations for idle instead of sprites, so a parameter from animator would replace.

    // no need to hideininspector for now. Use for demo.
    /*[HideInInspector]*/ public PlantData plantData; // contains all the dynamic data of a plant to be saved, a reference to PD 
    // TODO: name this something more descriptive
    IEnumerator g = null; // coroutine obj that controls plant growth.

    public int attackers = 0; // prob need to be dynamic from save data?
    public List<PestScript> pestScripts = new List<PestScript>(); // all the attackers attacking it
    public bool inMotion = false; // a boolean for whether the plant is in motion, aka being moved or moving.
    public bool pickedUp = false; // a boolean for whether this plant have been picked up by the player

    // Setter method. Make sure this is called whenever a plant's motion state is being set
    public void SetInMotion(bool inMotion)
    {
        this.inMotion = inMotion;

        if(inMotion)
        {
            foreach(PestScript pestScript in pestScripts)
            {
                pestScript.ChaseAfterPlant();
            }
        }
    }

    // Everytime the below function is called, the commanded modules will get executed once. 
    public void RunPlantModules(List<PlantModuleEnum> commands) 
    {
        foreach (var command in commands)
        {
            plantModules[command].Run();
        }
    }

    public void AddPlantModule(PlantModuleEnum module, String dataString = null)
    {
        if (!plantModules.ContainsKey(module))
        { // do we want multiple modules? rework if so.
            var moduleInstance = PlantModuleArr.GetModule(module, this);
            if (dataString != null) {
                moduleInstance.AssignDataFromString(dataString);
            } else {
                dataString = moduleInstance.EncodeDataToString();
            }
            plantModules.Add(module, moduleInstance);
            plantData.plantModuleData.Add(module, dataString);
        }
    }

    public void RemovePlantModule(PlantModuleEnum module)
    {
        if (plantModules.ContainsKey(module)) // do we want multiple modules? rework if so.
        {
            plantModules.Remove(module); // user's responsibility to pause the module? or pause it here. 
            plantData.plantModuleData.Remove(module);
        }
    }

    public IPlantModule GetPlantModule(PlantModuleEnum module)
    {
        return plantModules[module];
    }

    public virtual void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    public void InitializePlantData(Vector2 location) {
        plantData = new PlantData();
        plantData.location = location;
        plantData.currStageOfLife = 0;
        plantData.plantName = (int)plantSO.pName;
        plantData.stageTimeLeft = plantSO.stageTimeMax[plantData.currStageOfLife];
        plantData.currentHealth = plantSO.maxHealth[plantData.currStageOfLife];
        plantData.plantModuleData = new Dictionary<PlantModuleEnum, string>(); // size 0. Modules to be added in the child class
        PersistentData.GetLevelData(LevelManager.currentLevelID).plantDatas.Add(plantData); // add this plant into save. 
    }

    // If a plant is new, no modules. if it exists, then load em in!
    public void SpawnInModules()
    {
        // no modules, fresh plant
        if (plantData.plantModuleData.Count == 0)
        {
            // add in the default modules!
            foreach (PlantModuleEnum module in plantSO.defaultModules)
            {
                AddPlantModule(module);
            }
        }
        else // has modules, spawn in previous plant
        {
            foreach (PlantModuleEnum module in plantData.plantModuleData.Keys)
            {
                AddPlantModule(module, plantData.plantModuleData[module]);
            }
        }
    }

    // This step is called after plant object has been initialized. This function places the plant in the world and schedules the first growth events.
    public void VisualizePlant() // for now, assume spawn function is only used in the level where player's present
    {   
        // Set sprite
        spriteRenderer.sprite = plantSO.spriteArray[plantData.currStageOfLife];

        if (plantData.currStageOfLife != plantSO.maxStage) // if they are equal then no need to keep growing.
        {
            // TODO: call this something different to indicate that growth doesn't happen immediately
            GrowPlant(PlantStageUpdate, plantSO.stageTimeMax[plantData.currStageOfLife]);
        }
    }

    // called by the attacker upon attacking this plant. Also, notice how taking negative damage HEALS the plant!
    public void TakeDamage(int damage)
    {
        plantData.currentHealth -= damage;

        // check if plant dies.
        StartCoroutine(CheckPlantHealthInTheEndOfFrame());
    } // PLEASE DON'T DELETE THIS. I do this to make sure that in the same frame, if you heal a <0 plant as it's attacked, it doesn't die.
    IEnumerator CheckPlantHealthInTheEndOfFrame()
    {
        yield return new WaitForEndOfFrame(); // hopefully this phrase makes sense.

        CheckPlantHealth();
    }
    private void CheckPlantHealth() // only used here
    {
        // TODO: different behaviors / presentation based on different stages of health (by percentage)?
        if (plantData.currentHealth <= 0)
        {
            // sadly, plant dies.
            Debug.Log("PLANT KILLED GG");
            GameManager.KillPlant(this);
        }
    }

    // This is called upon plant destruction.
    public void OnPlantDeath()
    {
        // remove this plant from save
        PersistentData.GetLevelData(LevelManager.currentLevelID).plantDatas.Remove(plantData);
        // TODO: probably need to call module terminations. Be mindful that some modules are automatically terminated when the gameObject destructs.
        // remove the gameObject from scene. Make sure to check for null in other objects! (after destruction -> null, but might still be in other lists atm)
        Destroy(gameObject);
    }

    // TODO: rewrite this coroutine stuff when implementing the time system

    // TODO: make an UpdatePlantStats function? No need atm.
    //public abstract void UpdatePlantStats(int currStage); // or use virtual, which only marks override. 
    // Could be override in child class, but this method is not needed atm. 

    // TODO does this need a callback argument? If all it does is call PlantStageUpdate. Hmm lemme think about it... flexibility and frame order maybe?
    private void GrowPlant(Action callback, float stageTime) // if want input parameters, do Action<type, type, ...>
    {
        plantData.stageTimeLeft = stageTime;
        g = StartPlantGrowth(callback);
        StartCoroutine(g);
    }

    // Coroutine script that takes in a function and executes that function at the end of the count.
    IEnumerator StartPlantGrowth(Action callback) // assume plant data's stage time left isn't 0 at start.
    {
        yield return new WaitForSeconds(TimeManager.timeUnit * TimeManager.gameTimeScale);

        plantData.stageTimeLeft -= 1;
        if (plantData.stageTimeLeft <= 0)
        {
            callback(); // this shows how callback structure works.
        }
        else
        {
            //Debug.Log("Current time left: " + plantData.stageTimeLeft);
            g = StartPlantGrowth(callback);
            StartCoroutine(g);
        }
        // can execute a call back every iteration if want, like current % plant growth etc for growth animation if want.
        // the action can return more info to the callback, as long as parameters match!
    }

    private void PlantStageUpdate()
    {
        plantData.currStageOfLife += 1;

        // First check if there's space for all the new space needed at this next stage. 
        // we can do this knowing plantstageupdate will be called with currStage at least 1
        Vector2[] newSpaceNeeded = (plantSO.relativeGridsOccupied[plantData.currStageOfLife].vec2Array).Except(
            plantSO.relativeGridsOccupied[plantData.currStageOfLife - 1].vec2Array).ToArray();
        if (!GridScript.CheckOtherTilesAvailability(plantData.location, newSpaceNeeded)) // if the spaces are not available, pause the growth.
        {         
            // TODO: what's a way to resume the growth later on?
            Debug.Log("Plant growth is paused. Need more space.");
            plantData.currStageOfLife -= 1; // revert
            return; 
        }

        // update stats and visuals
        // trigger delegates so the subscribers will be notified. Want to reduce if statements and dependency!
        if (plantSO.plantStageUpdateDelegate != null) plantSO.plantStageUpdateDelegate();

        // update visuals
        spriteRenderer.sprite = plantSO.spriteArray[plantData.currStageOfLife];

        // current health refreshes? either leave this line or delete
        plantData.currentHealth = plantSO.maxHealth[plantData.currStageOfLife];

        // update new tiles that needed to be occupied in the grid
        GridScript.SetTileStates(plantData.location, TileState.OCCUPIED_STATE, newSpaceNeeded);
        // a1.except(a2) is anything in a1 that's not in a2. We are basically finding the spaces freed up from prev just incase it shrinks
        Vector2[] freedUpSpaceFromPrev = (plantSO.relativeGridsOccupied[plantData.currStageOfLife - 1].vec2Array).Except(
            plantSO.relativeGridsOccupied[plantData.currStageOfLife].vec2Array).ToArray();
        if (freedUpSpaceFromPrev.Length > 0) GridScript.SetTileStates(plantData.location, TileState.AVAILABLE_STATE, freedUpSpaceFromPrev);


        if (plantData.currStageOfLife == plantSO.maxStage) //if maxStage = 3, then 0-1, 1-2, 2-3, but indices are 0 1 2 3.
        {
            // plant is fully grown; do something.
            Debug.Log("Plant is fully grown!");
        }
        else
        {
            // continues growing
            GrowPlant(PlantStageUpdate, plantSO.stageTimeMax[plantData.currStageOfLife]); 
        }
    }

    public void StopPlantGrowth()
    {
        if (g != null) StopCoroutine(g);
    }

    public void LiftPlant(Transform handTransform)
    {
        pickedUp = true;
        // Free up the space
        GridScript.RemoveObjectFromGrid(plantData.location,
            plantSO.relativeGridsOccupied[plantData.currStageOfLife].vec2Array);
        // Pause the growth
        StopPlantGrowth(); // aware of potential bug? like coroutine generated after pausing? do we need a bool + if in coroutine?
        // In motion now
        SetInMotion(true);
        // Remove it from plantDatas and put it onto plantInHand
        PersistentData.GetLevelData(LevelManager.currentLevelID).plantDatas.Remove(plantData);
        PersistentData.GetLevelData(LevelManager.currentLevelID).plantInHand = plantData;
        // Set parent (aka can play an animation here)
        transform.SetParent(handTransform, false);
        transform.localPosition = Vector3.zero;

        Debug.Log("Plant has been lifted, and growth paused at " + plantData.stageTimeLeft + " seconds");
    }

    public bool PlacePlant(Vector2 location)
    {
        // Check grid and place
        if(GridScript.PlaceObjectAtGrid(location, gameObject, plantSO.relativeGridsOccupied[plantData.currStageOfLife].vec2Array)) {
            pickedUp = false;
            // No longer plantInHand, put back
            PersistentData.GetLevelData(LevelManager.currentLevelID).plantDatas.Add(plantData);
            PersistentData.GetLevelData(LevelManager.currentLevelID).plantInHand = null;
            plantData.location = location; // also update plantdata to this new loc
            // Resume the growth
            if(plantData.currStageOfLife < plantSO.maxStage) GrowPlant(PlantStageUpdate, plantData.stageTimeLeft);
            // Set the object back to the root of the scene
            transform.parent = null;
            // No longer in motion
            SetInMotion(false);

            return true;
        }

        return false;
    }

    // Returns the bottomLeft and topRight coord for the pest target loc rect. 
    public void VisualizePlantTargetBoundary()
    {
        var offset = plantSO.targetRectParameters[plantData.currStageOfLife].vec2Array[0];
        var dim = plantSO.targetRectParameters[plantData.currStageOfLife].vec2Array[1];
        var offsetBottomCenter = new Vector2(transform.position.x + offset.x, transform.position.y + offset.y);
        Vector2 bottomLeft = new Vector2(offsetBottomCenter.x - dim.x / 2, offsetBottomCenter.y),
            topRight = new Vector2(offsetBottomCenter.x + dim.x / 2, offsetBottomCenter.y + dim.y);
        Vector2 bottomRight = new Vector2(offsetBottomCenter.x + dim.x / 2, offsetBottomCenter.y),
            topLeft = new Vector2(offsetBottomCenter.x - dim.x / 2, offsetBottomCenter.y + dim.y);
        Debug.DrawLine(topLeft, topRight, Color.red, 0.5f, false);
        Debug.DrawLine(bottomLeft, bottomRight, Color.red, 0.5f, false);
        Debug.DrawLine(topLeft, bottomLeft, Color.red, 0.5f, false);
        Debug.DrawLine(topRight, bottomRight, Color.red, 0.5f, false);
        Debug.DrawLine(offsetBottomCenter, transform.position, Color.red, 0.5f, false);
    }

    // Player interaction.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerScript>().closePlants.Add(this);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerScript>().closePlants.Remove(this);
        }
    }
}
