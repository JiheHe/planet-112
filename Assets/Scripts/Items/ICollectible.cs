using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollectible
{
    public void Collect();
    public void Use();
    public void LinkInventoryItem(InventoryItem inventoryItem);
}
