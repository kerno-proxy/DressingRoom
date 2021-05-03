using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabaseListing : MonoBehaviour
{
    private void OnGUI()
    {
        Rect boxParams = new Rect(new Vector2(1, 1), new Vector2(1, 1));
        GUI.Box(boxParams, new GUIContent("Hi"));
    }
}
