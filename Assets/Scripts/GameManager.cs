using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }
    #endregion
    
    public ItemDatabaseScriptableObject mainItemDatabase;
    public GearSetScriptableObject defaultGearSet;
    public GearSetScriptableObject currentGearSet;
    public CharacterPartType[] characterParts;

    private void Awake()
    {
       
        #region Singleton Check
        if (_instance != null && _instance != this)
        {
            Debug.LogError("Singleton breach!");
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
        DontDestroyOnLoad(gameObject);
        #endregion

        InitGearSetOnCharacter();
    }

    public void InitGearSetOnCharacter()
    {
        if (!mainItemDatabase)
        {
            Debug.LogError("Main Item Database is not assigned! Choose an appropriate item database scriptable object through item manager window and make it main item database!");
        }
        if (!defaultGearSet || !currentGearSet)
        {
            Debug.LogError("Either default or current gearsets are not assigned. Assign them gearset scriptable object through inspector window");
        }
        CacheCharacterParts();
        UpdateEquippedItems();
    }

    public void AssignMainDatabaseSO (ItemDatabaseScriptableObject itemDatabase)
    {
        mainItemDatabase = itemDatabase;
    }
   public void CacheCharacterParts()
    {
        characterParts = FindObjectsOfType<CharacterPartType>();
    }
    public void UpdateEquippedItems()
    {
        if (characterParts != null)
        {
            var gearSetArray = currentGearSet.GetGearSet;
            foreach (CharacterPartType characterPart in characterParts)
            {

                for (int i = 0; i < gearSetArray.Length; i++)
                {
                    if (gearSetArray[i].item.slot == characterPart.PartType)
                    {
                        
                        characterPart.gameObject.GetComponent<SpriteRenderer>().sprite = gearSetArray[i].item.itemPic;
                    }
                }
            }
        }
    }
}
