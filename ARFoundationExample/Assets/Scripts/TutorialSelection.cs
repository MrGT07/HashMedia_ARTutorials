using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class TutorialSelection : MonoBehaviour
{
    private string _btnName;
    //private string _tutorialName;

    public void loadTutorial(string _tutorialName)
    {
        _btnName = EventSystem.current.currentSelectedGameObject.name; //Get the Button Name
        //_tutorialName = _btnName + "Tutorial"; //ButtonName + Tutorial would be our scene name

        switch (_btnName)
        {
            case "Sensor1":
                Debug.Log("This will start the sensor1 tutorial");
                break;
        }
    }
}
