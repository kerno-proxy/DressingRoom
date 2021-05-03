using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterPartType : MonoBehaviour
{
    [SerializeField]
    Item.slotType _partType = Item.slotType.Empty;

    public Item.slotType PartType { get { return _partType; } set { _partType = value; } }
}
