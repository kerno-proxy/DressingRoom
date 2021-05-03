using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Item Database", menuName = "Items/AddItemDatabase")]

public class ItemDatabaseScriptableObject : ScriptableObject
{

    
    public List<SpawnScriptableObjectItem> databaseList;
  
    
    

}