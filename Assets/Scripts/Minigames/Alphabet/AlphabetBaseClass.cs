using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class AlphabetBaseClass 
{
    [SerializeField]
    private Sprite _letterImage;
    [SerializeField]
    private string _letterName;

    public AlphabetBaseClass(Sprite letterImage, string letterName)
    {
        _letterImage = letterImage;
        _letterName = letterName;
    }
    
    public Sprite LetterImage { get { return _letterImage; } set { _letterImage = value; } }
    public string LetterName { get { return _letterName; } set { _letterName = value; } }

}
