using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Alphabet Database", menuName = "Minigames/Alphabet/Add Database")]

public class AlphabetLettersDatabase : ScriptableObject
{
    
    public List<AlphabetBaseClass> Alphabet = new List<AlphabetBaseClass>();

}
