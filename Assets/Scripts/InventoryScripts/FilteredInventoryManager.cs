using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class FilteredInventoryManager : MonoBehaviour
{
    [SerializeField]
    List<SpawnScriptableObjectItem> filteredItemsList = new List<SpawnScriptableObjectItem>();
    [SerializeField]
    static GameObject[] filteredInventoryButtons;
    CategoriesFiltering categoriesFilteringScript;

    //Scrolling buttons
    [SerializeField]
    Button leftScrollingButton;
    [SerializeField]
    Button rightScrollingButton;
    [SerializeField]
    private int indexMod = 0;
    private void Awake()
    {
        //caching our filtered item list which we gonna use to assign items to buttons
        categoriesFilteringScript = FindObjectOfType<CategoriesFiltering>();
        //caching our filtered inventory slots to address them when we want to change their sprites
        filteredInventoryButtons = GameObject.FindGameObjectsWithTag("FilteredInventory");


    }
    private void Start()
    {
        
        
        
        //Initial filters population
        PopulateFilterInventoryButtons();
    }
    public void PopulateFilterInventoryButtons()
    {
        //Checking that we have all the required components in scene and getting the reference.
        if (categoriesFilteringScript)
        {
            filteredItemsList = categoriesFilteringScript.GetFilteredItemsList();

        }
        else { Debug.LogError("Missing categoriesFiltering script in the scene"); }
        //populates filteredInventoryButtons with content without separate GameObject[] parameter.

        FillingFilterArray(filteredInventoryButtons,0);

    }
    private void FillingFilterArray(GameObject[] inventorySlotButtons, int indexModifier)
    {
        Image img;
        for (int i = 0; i <inventorySlotButtons.Length; i++)
        {
            img = inventorySlotButtons[i].GetComponent<Image>();
            img.enabled = false;
            inventorySlotButtons[i].GetComponent<ItemAssignToGearSet>().ClearItemCacheForThisButton();
        }
       for (int i = 0; i < filteredItemsList.Count; i++)
        {
            if (i < inventorySlotButtons.Length)
            {
                img = inventorySlotButtons[i].GetComponent<Image>();
                img.enabled = true;
                img.sprite = filteredItemsList[i+indexModifier].item.itemPic;
                inventorySlotButtons[i].GetComponent<ItemAssignToGearSet>().CacheItemIntoButton(filteredItemsList[i + indexModifier]);
                
            }
        }
    }
    
    /* public void PopulateFilterInventoryButtons(GameObject[] goArray)
     {

         //Checking that we have all the required components in scene and getting the reference.
         if (categoriesFilteringScript)
         {
             filteredItemsList = categoriesFilteringScript.GetFilteredItemsList();

         }
         else { Debug.LogError("Missing categoriesFiltering script in the scene"); }
         //populates filteredInventoryButtons with content

         for (int i = 0; i < goArray.Length; i++)
         {
             if (i < filteredItemsList.Count)
             {
                 goArray[i].GetComponent<Image>().enabled = true;
                 goArray[i].GetComponent<Image>().sprite = filteredItemsList[i].item.itemPic;
             }  else
             {
                 Debug.Log("Disabling sprite");
                 goArray[i].GetComponent<Image>().enabled = false;
             }
         }

     }*/
    public void ScrollFilteredInventory(string indexModifierString)
    {
       
        if (indexModifierString == "Left")
        {
            if (indexMod > 0)
            {
                indexMod--;
                ScrollingButtonsGreyOut();
                FillingFilterArray(filteredInventoryButtons, indexMod);
            }
        } else if (indexModifierString == "Right")
        {
            if (indexMod < filteredItemsList.Count && filteredItemsList.Count - indexMod > filteredInventoryButtons.Length)
            {
                indexMod++;
                ScrollingButtonsGreyOut();
                FillingFilterArray(filteredInventoryButtons, indexMod);
            }
        }
    }
    public void ClearIndexMod()
    {
        indexMod = 0;
    }
    /// <summary>
    /// This method manages the way scrolling buttons are being greyed out every time we scroll our inventory or change filtering.
    /// </summary>
    public void ScrollingButtonsGreyOut()
    {
        if (filteredItemsList.Count <= filteredInventoryButtons.Length)
        {
            // < >
            leftScrollingButton.gameObject.GetComponent<Image>().color = Color.grey;
            rightScrollingButton.gameObject.GetComponent<Image>().color = Color.grey;
        }
        else
        {
            if (indexMod == 0)
            {
                // < >>
                leftScrollingButton.gameObject.GetComponent<Image>().color = Color.grey;
                rightScrollingButton.gameObject.GetComponent<Image>().color = Color.white;
            } else
            {
                if (filteredItemsList.Count - indexMod > filteredInventoryButtons.Length)
                {
                    // << >> 
                    leftScrollingButton.gameObject.GetComponent<Image>().color = Color.white;
                    rightScrollingButton.gameObject.GetComponent<Image>().color = Color.white;
                } else
                {
                    // << >
                    leftScrollingButton.gameObject.GetComponent<Image>().color = Color.white;
                    rightScrollingButton.gameObject.GetComponent<Image>().color = Color.grey;
                }
            }
        }
    }
}
