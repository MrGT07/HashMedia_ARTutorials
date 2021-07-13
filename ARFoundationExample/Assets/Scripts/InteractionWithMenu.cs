using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class InteractionWithMenu : MonoBehaviour
{
    private int id = -1;
    private string category;
    private void Update()
    {
        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            if(Physics.Raycast(raycast, out hit))
            {
                if(hit.collider.tag == "MenuItem")
                {
                    id = Int16.Parse(hit.collider.name);
                    category = hit.collider.gameObject.transform.parent.name;
                    Debug.Log("ID = " + id);
                    TutIDHolder.id = id;
                    TutIDHolder.category = category;
                    SceneManager.LoadScene("tutorials");
                }
            }
        }
    }
}
