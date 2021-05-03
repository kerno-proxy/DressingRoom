using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;
    public GameObject buildingEntrance;

    // Update is called once per frame
    private void Awake()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            gameManager.InitGearSetOnCharacter();
        }
        if (buildingEntrance.activeInHierarchy == true)
        {
            buildingEntrance.SetActive(false);
        }
    }
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        transform.Translate(moveX * Time.deltaTime * moveSpeed, moveY * Time.deltaTime * moveSpeed, 0);    

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.tag == "Building")
        {
            FindObjectOfType<SceneManagementScript>().SetSceneNameToLoad(collision.gameObject.GetComponent<BuildingsInteractions>().sceneName);
            buildingEntrance.SetActive(true); 
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Building")
        {
            buildingEntrance.SetActive(false);
        }
    }

    
}
