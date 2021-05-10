using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class AlphabetRandomizer : MonoBehaviour
{
    [SerializeField]
    GameObject _guess_example;
    [SerializeField]
    AlphabetBaseClass _guess;
    [SerializeField]
    List<GameObject> _guess_buttons_array = new List<GameObject>();
    [SerializeField]
    AlphabetLettersDatabase _alphabetDatabase;
    

    private void Awake()
    {
        
        if (_guess_example == null)
        {
            Debug.LogError("Missing example reference");
        }
        if (_alphabetDatabase == null)
        {
            Debug.LogError("Missing alphabet letters database reference");
        }
        

        GameObject[] _guess_buttons = GameObject.FindGameObjectsWithTag("GuessButton");
        
        for (int i = 0; i<_guess_buttons.Length; i++)
        {
            _guess_buttons_array.Add(_guess_buttons[i]);
        }
        if (_guess_buttons.Length > _alphabetDatabase.Alphabet.Count)
        {
            Debug.LogError("Ammount of buttons is bigger than the ammount of avaiable letters");
        }

        Randomize();
    }

    void Randomize()
    {
        
        List<int> list_of_letters_indexes = new List<int>();
        while (list_of_letters_indexes.Count < _guess_buttons_array.Count)
        {
            
            int generatedInt = UnityEngine.Random.Range(0, _alphabetDatabase.Alphabet.Count);
            if (list_of_letters_indexes.Contains(generatedInt) == false) 
            {
                list_of_letters_indexes.Add(generatedInt);
            }
        }

        for (int i = 0; i<=list_of_letters_indexes.Count-1; i++)
        {
            _guess_buttons_array[i].GetComponent<Image>().sprite = _alphabetDatabase.Alphabet[list_of_letters_indexes[i]].LetterImage;
            _guess_buttons_array[i].GetComponent<ReferenceHolder>().SetGetReference = _alphabetDatabase.Alphabet[list_of_letters_indexes[i]];
        }
        int _correct_guess_index = UnityEngine.Random.Range(0, _guess_buttons_array.Count);
       _guess_example.GetComponent<Image>().sprite = _guess_buttons_array[_correct_guess_index].GetComponent<Image>().sprite;
        _guess = _alphabetDatabase.Alphabet[list_of_letters_indexes[_correct_guess_index]];
        
    }

   
   public void Compare(GameObject referenceHolderItem)
    {
        if (_guess != null)
        {
            if (_guess == referenceHolderItem.GetComponent<ReferenceHolder>().SetGetReference)
            {
                Randomize();
                Debug.Log("Correct!");
            } else { Debug.Log("Incorrect!!");
                Randomize();
            }
            Debug.Log("Compare!");
        } else { Debug.LogError("Didn't pick up guess example"); }
    }
}
