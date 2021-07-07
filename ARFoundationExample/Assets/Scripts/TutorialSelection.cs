using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSelection : MonoBehaviour
{
    private int _screenID;
    [SerializeField]
    private GameObject _screens;
    [SerializeField]
    private GameObject _btnManager;
    private void Start()
    {
        if (TutIDHolder.id != -1)
        {
            _screenID = TutIDHolder.id;           
            //Disabling screens
            foreach (Transform child in _screens.transform.GetChild(0).gameObject.transform)
            {
                Debug.Log("Disabling screens!");
                child.gameObject.SetActive(false);
            }
            _btnManager.SetActive(false);
        }

        Invoke("_startTutorial", 1f);
    }

    private void _startTutorial()
    {

        Debug.Log("Starting Screen: " + _screenID);
        if (_screens.transform.GetChild(0).gameObject.transform.childCount > _screenID)
        {
            _screens.transform.GetChild(0).gameObject.transform.GetChild(_screenID).gameObject.SetActive(true);
            _btnManager.SetActive(true);
        }
        else
        {
            Debug.Log("Invalid ID!");
        }
    }
}
