using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceHolder : MonoBehaviour
{
    [SerializeField]
    AlphabetBaseClass _referenceHolder;

    public AlphabetBaseClass SetGetReference
    {
        get { return _referenceHolder; }
        set { _referenceHolder = value; }
    }
}
