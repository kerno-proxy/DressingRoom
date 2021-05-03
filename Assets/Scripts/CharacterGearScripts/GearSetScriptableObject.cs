using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Gear Set", menuName = "Items/AddGearSet")]
public class GearSetScriptableObject : ScriptableObject
{
    [SerializeField]
    SpawnScriptableObjectItem[] gearSet = new SpawnScriptableObjectItem[7];   

    private void OnEnable()
    {

        //Checking for a dummy asset in the assets/scriptableObjects folder. This dummy is used when we are creating new gearset.
        //In a nutshell it's just an empty item slot without any sprites or anchors.
        SpawnScriptableObjectItem dummySearch = Resources.Load<SpawnScriptableObjectItem>("ScriptableObjects/Dummy");
        
        if (dummySearch != null) 
        {
        
           
            for (int i = 0; i < gearSet.Length; i++)
            {
                
                if (gearSet[i] == null)
                {
                    Debug.LogWarning("Parampam");
                    gearSet[i] = dummySearch; 
                }
            }
        } else { Debug.LogError("Missing a dummy spawnScriptableObject asset in the Assets/Resources/ScriptableObjects"); }
              
        
    }
    /// <summary>
    /// Этот метод должен назначать предмет в массив предметов набора. 
    /// </summary>
    /// <param name="itemToAssign"></param>
    public void AssignAnItemToGearSlot(SpawnScriptableObjectItem itemToAssign)
    {
        bool foundAnItemToReplace = false; // нашли или не нашли предмет в соответствующем слоте?
        int lastDummyItemIndex = 0; //индекс последней заглушки. По этому индексу мы запишем предмет, если не найдем его тип в массиве
        
        //Начинаем обход массива, чтобы найти слот, в котором уже есть предмет такого типа, или запомнить индекс последней найденной заглушки.
        for (int i = 0; i < gearSet.Length; i++)
        {
            //Debug.Log(i + " cycling " + lastDummyItemIndex);
            //условный оператор, которым мы будем сохранять индекс последней заглушки
            if (gearSet[i].item.slot == Item.slotType.Empty)
            {
                
                lastDummyItemIndex = i;
            }
            //этим условным оператором мы будем проверять совпадение типов. Если типы совпали, то мы записываем наш предмет поверх старого и выходим из цикла
            if (itemToAssign.item.slot == gearSet[i].item.slot)
            {
                
                gearSet[i] = itemToAssign;
                foundAnItemToReplace = true;
                break;
            }

        }
        //Если не нашли ни одного совпавшего типа в массиве, то записываем наш предмет вместо последней найденной заглушки.
        if (!foundAnItemToReplace)
        {
            
            gearSet[lastDummyItemIndex] = itemToAssign;
        }
    }
    public SpawnScriptableObjectItem[] GetGearSet
    {
        get { return gearSet; }
    }
}
