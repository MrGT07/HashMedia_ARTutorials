﻿using UnityEngine;

public class InteractionWithCatalogue : MonoBehaviour
{
    private string _btnName;
    [SerializeField]
    private GameObject _MenuController;
    [SerializeField]
    private GameObject _closeBtn;
    public static bool isActive;

    private void Start()
    {
        for(int i = 0; i < _MenuController.transform.childCount; i++)
        {
            _MenuController.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (!isActive)
        {
            this.gameObject.SetActive(true);
            isActive = false;
        }
        //Get the touch input and based on the button name -> Load the scene with that particular tutorial
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position); //Generate rays from camera
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) //Cast the ray and get the hit information
            {
                _btnName = hit.transform.name;
                if (_btnName != null)
                    _openMenu(_btnName);
                _closeBtn.transform.gameObject.SetActive(true);
            }
            if(isActive)
            { 
                this.gameObject.SetActive(false);
                isActive = false;
            }
        }
    }
    private void _openMenu(string categoryName)
    {
        switch (categoryName) //Switch using button names
        {
            case "sensors":
                _MenuController.transform.GetChild(0).gameObject.SetActive(true);
                break;
            case "boards":
                _MenuController.transform.GetChild(1).gameObject.SetActive(true);
                break;
            case "wires":
                _MenuController.transform.GetChild(2).gameObject.SetActive(true);
                break;
            case "miscellaneous":
                _MenuController.transform.GetChild(3).gameObject.SetActive(true);
                break;
            case "projects":
                _MenuController.transform.GetChild(4).gameObject.SetActive(true);
                break;
            default:
                Debug.Log("Button not found!");
                break;
        }
    }
}
