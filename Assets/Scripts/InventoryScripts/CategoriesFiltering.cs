using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CategoriesFiltering : MonoBehaviour
{
    [SerializeField]
    ItemDatabaseScriptableObject itemDatabase;
    [SerializeField]
    static List<SpawnScriptableObjectItem> filteredItems = new List<SpawnScriptableObjectItem>();
    FilterButton[] filteredButtonsCollection;


    public void Awake()
    {
        itemDatabase = FindObjectOfType<GameManager>().mainItemDatabase;
        if (itemDatabase)
        {
            //Initial filtering index generating
            filteredButtonsCollection = GetComponentsInChildren<FilterButton>();
            foreach (FilterButton filterButton in filteredButtonsCollection) 
            {
                GenerateFilterContent(filterButton.slotType, filterButton.gameObject.GetComponentInChildren<Text>());
            }
            
        }
        else
        {
            Debug.LogError("CategoriesFiltering Script is missing mainItemDatabase reference");
        }
    }
 
    /// <summary>
    /// This method generates filter contents for the chosen slottype. It's always executed in the awake function, but also supposed to be executed each time
    /// something changes in the avaiable item list (for instance we checked isObtained for one of the items
    /// This method needs some functionality about only updating for a particular slotType when new item is found instead of updating it for all slottypes.
    /// </summary>
    /// <param name="slotType"></param>
    /// <param name="itemDatabase"></param>
    public void GenerateFilterContent(Item.slotType slotType, Text textComponentToEdit)
    {
        filteredItems.Clear();
        foreach (SpawnScriptableObjectItem item in itemDatabase.databaseList)
        {
            if ( slotType == item.item.slot && item.item.isObtained)
            {
                filteredItems.Add(item);


            }
        }

        textComponentToEdit.text = filteredItems.Count.ToString();
        
        
    }
    public List<SpawnScriptableObjectItem> GetFilteredItemsList()
    {
       
        if (filteredItems.Count > 0)
        {
            return filteredItems;
        }
        else { return null; }
    }
}
