using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;
    [SerializeField]
    PlayerOnMapBehaviour playerOnMapBehavourScript;
    public GameObject buildingEntrance;

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
        if (Input.GetAxis("Horizontal") != 0 | Input.GetAxis("Vertical") != 0)
        {
            Moving(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }
        else { Idle(); }
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

    private void Moving(float moveX, float moveY)
    {
        transform.Translate(moveX * Time.deltaTime * moveSpeed, moveY * Time.deltaTime * moveSpeed, 0);
        playerOnMapBehavourScript.SetAnimatorToMoving();
    }
    private void Idle()
    {
        playerOnMapBehavourScript.SetAnimatorToIdle();
    }
}
