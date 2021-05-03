using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class ItemDatabaseManager : EditorWindow
{
    
    //Надо выдумать способ вывода элементов скриптового объекта itemDatabase и сохранения новых внутри этого объекта.
    string itemName = "Enter Item Name";
    Sprite itemPic;
    Item.slotType slotType = Item.slotType.Head;
    bool isObtained;

    [SerializeField]
    ItemDatabaseScriptableObject itemDatabase = null;


    [MenuItem("Window/ItemManagement")]
    public static void ShowWindow()
    {
        GetWindow(typeof(ItemDatabaseManager));
    }
    void OnGUI()
    {
        #region ItemDatabaseSelection
        SerializedProperty itemDatabaseProperty = new SerializedObject(this).FindProperty("itemDatabase");
        EditorGUILayout.ObjectField(itemDatabaseProperty);
        itemDatabaseProperty.serializedObject.ApplyModifiedProperties();
        #endregion
        //checking if we got itemdatabase selected or not
        if (itemDatabase != null)
        {
            
            if (GUILayout.Button("Make this database Main"))
            {
                AssignCurrentItemDatabaseAsMain(itemDatabase);
            }
            if (GUILayout.Button("Clear Database"))
            {
                if (itemDatabase.databaseList.Count != 0)
                {
                    ClearItemDatabase(itemDatabase.databaseList);
                }
                else
                {
                    Debug.Log("Database is already empty");
                }
            }
            
            EditorGUILayout.LabelField("Number of items in the database " + itemDatabase.databaseList.Count);

            EditorGUI.DrawRect(EditorGUILayout.GetControlRect(GUILayout.Height(2f)), Color.gray);
            
            GUILayout.Label("Add an Item to the DataBase", EditorStyles.boldLabel);

            
            itemName = EditorGUILayout.TextField("Item name", itemName);

            itemPic = EditorGUILayout.ObjectField("Choose Item Sprite", itemPic, typeof(Sprite), true) as Sprite;

            slotType = (Item.slotType)EditorGUILayout.EnumPopup("Choose Item SlotType", slotType);

            isObtained = EditorGUILayout.Toggle("Obtainable from the start", isObtained);

            if (GUILayout.Button("Create Item"))
            {
                CreateItem(itemName, itemPic, slotType, isObtained);
                Debug.Log("Number of elements in the itemdatabase list: " + itemDatabase.databaseList.Count);

            }
            
            


        }
        else
        {
            EditorGUILayout.HelpBox("Choose ItemDatabase scriptable object from your project", MessageType.Warning, true);
        }
                     
    }
    /// <summary>
    /// Creates a new item in the currently loaded item database
    /// </summary>
    /// <param name="itemName"></param> item's name
    /// <param name="itemPic"></param> item's pic
    /// <param name="slotType"></param> item's type
    private void CreateItem(string itemName, Sprite itemPic,Item.slotType slotType, bool isObtained)
    {
        var scriptableObjectItem = CreateInstance<SpawnScriptableObjectItem>();
        scriptableObjectItem.item = new Item(itemName, itemPic, slotType, isObtained);
        if (AssetDatabase.FindAssets(itemName, new[] { "Assets/Resources/ScriptableObjects" }).Length != 0)
        {
            Debug.Log("This item already exists");
        }
        else
        {
            AssetDatabase.CreateAsset(scriptableObjectItem, "Assets/Resources/ScriptableObjects/" + itemName + ".asset");
            itemDatabase.databaseList.Add(scriptableObjectItem);
            AssetDatabase.SaveAssets();
            Debug.Log("Created an item " + scriptableObjectItem.item.itemName);
        }
        
    }
    /// <summary>
    /// Clears whole database
    /// </summary>
    /// <param name="items"></param> database reference
    private void ClearItemDatabase(List<SpawnScriptableObjectItem> items)
    {
        
        for (int i = itemDatabase.databaseList.Count - 1; i >= 0; i--)
        {
           
           if (AssetDatabase.FindAssets(itemDatabase.databaseList[i].item.itemName, new[] { "Assets/Resources/ScriptableObjects" }).Length != 0)
            {
                AssetDatabase.DeleteAsset("Assets/Resources/ScriptableObjects/" + itemDatabase.databaseList[i].item.itemName + ".asset");
                AssetDatabase.SaveAssets();
            }
            itemDatabase.databaseList.RemoveAt(i);
            
        }
        if (itemDatabase.databaseList.Count == 0) { Debug.Log("Database cleared!"); }
    }

   /// <summary>
   /// This method assigns currently choosen item database as a main item database in the gamemanager gameobject through the corresponding script.
   /// </summary>
   /// <param name="itemDatabaseToAssign"></param>
    private void AssignCurrentItemDatabaseAsMain(ItemDatabaseScriptableObject itemDatabaseToAssign)
    {
        var gameManager = FindObjectOfType<GameManager>();
        gameManager.AssignMainDatabaseSO(itemDatabaseToAssign);
    }
}
