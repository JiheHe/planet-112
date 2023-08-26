using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Weapon : MonoBehaviour, ICollectible
{
    public delegate void HandleWeaponCollected(GameObject weaponInventoryPrefab);
    public static event HandleWeaponCollected OnWeaponCollected;
    public GameObject weaponInventoryPrefab;

    // Is triggered whenever player picks up stick off ground.
    public void Collect(){
        AudioManager.GetSFX("collectGenericSFX").Play();
        Destroy(gameObject);
        OnWeaponCollected?.Invoke(weaponInventoryPrefab);
    }

    // Is triggered whenever player uses stick to attack.
    public void Use(){
        print("using stick");
    }
}
