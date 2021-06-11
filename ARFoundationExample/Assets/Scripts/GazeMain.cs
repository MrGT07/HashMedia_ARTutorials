using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GazeMain : MonoBehaviour
{
    private List<InfoBehaviour> _infos = new List<InfoBehaviour>(); //List of catalogue items

    private void Start()
    {
        _infos = FindObjectsOfType<InfoBehaviour>().ToList();
    }

    //If the AR camera hits a object which has "hasInfo" tag -> calls the _openInfo()
    private void Update()
    {
        if(Physics.Raycast(transform.position, transform.forward, out RaycastHit hit))
        {
            GameObject to = hit.collider.gameObject;
            if (to.CompareTag("hasInfo"))
            {
                _openInfo(to.GetComponent<InfoBehaviour>());
            }
        }
        else
        {
            _closeAll(); //Close the catalogue info, if AR Camera is not facing the object/catalogue item
        }
    }

    //Opens the information of catalogue item
    private void _openInfo(InfoBehaviour desiredInfo)
    {
        foreach(InfoBehaviour info in _infos)
        {
            if(info == desiredInfo)
            {
                info.openInfo();
            }
            else
            {
                info.closeInfo();
            }
        }
    }

    //Close the information of catalogue item
    private void _closeAll()
    {
        foreach (InfoBehaviour info in _infos)
        {
            info.closeInfo();
        }

    }
}
