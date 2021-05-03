using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssignToGearSet : MonoBehaviour
{
    [SerializeField]
    SpawnScriptableObjectItem itemCurrentlyAssignedToThisButton;
    [SerializeField]
    GearSetScriptableObject currentGearSet;

    private void Start()
    {
        currentGearSet = FindObjectOfType<GameManager>().currentGearSet;
    }
    
    public void AssignItemToCurrentGearSet ()
    {
        
        currentGearSet.AssignAnItemToGearSlot(itemCurrentlyAssignedToThisButton);
        FindObjectOfType<GameManager>().UpdateEquippedItems();
    }
    public void CacheItemIntoButton(SpawnScriptableObjectItem item)
    {
        
        itemCurrentlyAssignedToThisButton = item;
    }
    public void ClearItemCacheForThisButton()
    {
        itemCurrentlyAssignedToThisButton = null;
    }
}
