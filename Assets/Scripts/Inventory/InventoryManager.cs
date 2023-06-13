using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject slotPrefab;
    public List<InventorySlot> inventorySlots = new List<InventorySlot>(27);
    public bool draggingItem;
    public GameObject hotbar;

    void Awake(){
        ResetInventory();
        draggingItem = false;
        Fruit.OnFruitCollected += UpdateInventory;
        Weapon.OnWeaponCollected += UpdateInventory;
        transform.parent.gameObject.SetActive(false);
    }

    void ResetInventory(){
        foreach (Transform inventorySlotTransform in transform){
            Destroy(inventorySlotTransform.gameObject);
        }
        inventorySlots = new List<InventorySlot>(27);

        for (int i = 0; i < inventorySlots.Capacity; i++){
            CreateInventorySlot(i);
        }
    }

    void CreateInventorySlot(int inventorySlotIndex){
        GameObject newSlot = Instantiate(slotPrefab);
        newSlot.transform.SetParent(transform, false);

        InventorySlot newSlotComponent = newSlot.GetComponent<InventorySlot>();
        newSlotComponent.inventorySlotIndex = inventorySlotIndex;
        newSlotComponent.ClearSlot();
        inventorySlots.Add(newSlotComponent);
    }

    // Searches if item already exists in inventory, and if so, add to that item's stackSize.
    //   If item doesn't exist, then add item to first empty InventorySlot.
    void UpdateInventory(GameObject inventoryItemPrefab){
        hotbar.GetComponent<HotbarManagerScript>().LinkSlotTransforms();
        HotbarManagerScript hotbarManager = hotbar.GetComponent<HotbarManagerScript>();
        for (int i = 0; i < inventorySlots.Count; i++){
            InventorySlot inventorySlot = inventorySlots[i];
            Transform slotTransform = inventorySlot.transform.GetChild(0); 
            if (slotTransform.childCount > 0){
                InventoryItem inventoryItem = inventorySlot.transform.GetComponentInChildren<InventoryItem>();
                hotbarManager.UpdateHotbar();
                if (inventoryItem.displayName == inventoryItemPrefab.GetComponent<InventoryItem>().displayName){
                    inventoryItem.AddToStack();
                    return;
                }
            }
        }

        for (int i = 0; i < inventorySlots.Count; i++){
            InventorySlot inventorySlot = inventorySlots[i];
            Transform slotTransform = inventorySlot.transform.GetChild(0); 
            if (slotTransform.childCount == 0){
                inventorySlot.DrawSlot(inventoryItemPrefab);
                hotbarManager.UpdateHotbar();
                return;
            }
        }
    }
}
