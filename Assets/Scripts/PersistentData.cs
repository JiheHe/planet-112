using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PersistentData : MonoBehaviour
{
    // Both of these are private. Modified through getters. This is a local, global class that can be acessed through classname. 
    static SaveData currSaveData;
    static Dictionary<int, LevelData> currLevelDatas; // Need this because indices don't always reflect level's id correctly.

    // Save 0 is always auto save; Save 1-MAX is manual save. 
    public static void LoadSave(int saveIndex)
    {
        currSaveData = null;
        if(currLevelDatas != null) currLevelDatas.Clear();

        DataManager.readFile(ref currSaveData, saveIndex);

        // Load in level datas for easier reference, since level id != elem index.
        if(currSaveData != null)
        {
            currLevelDatas = currSaveData.levelDatas.ToDictionary(keySelector: ld => ld.levelID, elementSelector: ld => ld);
        }
        else
        {
            Debug.LogError("ERROR: failed to load save " + saveIndex + ".");
        }
    }

    // Hopefully LevelData in currLevelDatas refers to the same levelDatas' LevelData in currSaveData.
    // Test result: it does! Dictionary is a class so it was passed by reference. Perfect. 
    public static void WriteToSave(int saveIndex)
    {
        DataManager.writeFile(ref currSaveData, saveIndex);
    }

    // Same here! LevelData class is passed by reference, so modifying the returned one will modify the one in SaveData as well.
    public static LevelData GetLevelData(int levelID)
    {
        return currLevelDatas[levelID];
    }

    // This method is only called when a new level is unlocked. Once a level is unlocked, it stays unlocked. 
    public static void AddLevelData(LevelData newLevelData) // Are they connected through same pass by value object? Test result: yes.
    {
        currSaveData.levelDatas.Add(newLevelData);
        currLevelDatas.Add(newLevelData.levelID, newLevelData);
    }

    // Thus this is why every data is categorized into a class; passed by reference: more intuitive and directly-reflected modification.
    public static PlayerData GetPlayerData()
    {
        return currSaveData.playerData;
    }

    public static GameStateData GetGameStateData()
    {
        return currSaveData.gameStateData;
    }
    
    public static EventsData GetEventsData()
    {
        return currSaveData.eventsData;
    }

    /* // This whole segment was used to test save/load system's functionality with PD. Worked!
    private void Awake()
    {
        PlantData plant = new PlantData
        {
            location = new Vector2(4, 5),
            currStageOfLife = 2,
            plantType = 5,
            stageTimeLeft = 0.5f
        };
        LevelData levelData = new LevelData
        {
            levelID = 9,
            plantDatas = new List<PlantData>() { plant }
        };
        SaveData saveData = new SaveData
        {
            levelDatas = new List<LevelData>() { levelData }
        };
        currSaveData = saveData;
        WriteToSave(0);
        LoadSave(0);
        Debug.Log(currLevelDatas[9].plantDatas[0].currStageOfLife);
        Debug.Log(currSaveData.levelDatas[0].plantDatas[0].currStageOfLife);
        GetLevelData(9).plantDatas[0].currStageOfLife = 69;
        Debug.Log(currLevelDatas[9].plantDatas[0].currStageOfLife);
        Debug.Log(currSaveData.levelDatas[0].plantDatas[0].currStageOfLife);
        WriteToSave(0);
        LoadSave(0);
        Debug.Log(GetLevelData(9).plantDatas[0].currStageOfLife);
        LoadSave(0);
        PlantData plant = new PlantData
        {
            location = new Vector2(4, 5),
            currStageOfLife = 2,
            plantType = 5,
            stageTimeLeft = 0.5f
        };
        LevelData levelData = new LevelData
        {
            levelID = 5,
            plantDatas = new List<PlantData>() { plant }
        };
        AddLevelData(levelData);
        GetLevelData(5).plantDatas[0].currStageOfLife = 99;
        Debug.Log(currSaveData.levelDatas[1].plantDatas[0].currStageOfLife);
    } */
}
