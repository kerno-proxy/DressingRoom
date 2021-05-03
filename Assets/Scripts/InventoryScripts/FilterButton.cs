using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FilterButton : MonoBehaviour
{
    [SerializeField]
    public Item.slotType slotType = Item.slotType.Empty;
    private CategoriesFiltering _categoriesFilteringCache;

    private void Start()
    {
        _categoriesFilteringCache = FindObjectOfType<CategoriesFiltering>();
        FilteredInventoryManager filteredInventoryManager = FindObjectOfType<FilteredInventoryManager>();
        if (!_categoriesFilteringCache)
        {
            Debug.LogError("Can't detect categories filtering script in the scene.");
        }
        else
        {
            //по ходу надо разбираться с onclick().addlistener - это и только это.
            
            Button btn = GetComponentInChildren<Button>();
            btn.onClick.AddListener(delegate { _categoriesFilteringCache.GenerateFilterContent(slotType, GetComponentInChildren<Text>());});
            btn.onClick.AddListener(delegate { filteredInventoryManager.ClearIndexMod(); filteredInventoryManager.ScrollingButtonsGreyOut(); filteredInventoryManager.PopulateFilterInventoryButtons(); });
            

        }
    }
    
}
