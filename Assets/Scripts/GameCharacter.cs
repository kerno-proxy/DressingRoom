using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCharacter : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
