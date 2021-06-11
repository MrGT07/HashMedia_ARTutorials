using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonScripts : MonoBehaviour
{
    private string _btnName;
    public GameObject cata;
    private void Update()
    {
        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                _btnName = hit.transform.name;
                switch (_btnName)
                {
                    case "backButton":
                        goBack();
                        break;
                    case "CloseButton":
                        goClose();
                        break;
                }
            }
        }
    }

    //BACK
    public void goBack()
    {
        SceneManager.LoadScene("main");
    }

    public void goClose()
    {
        transform.parent.parent.gameObject.SetActive(false);
    }

    public void test()
    {
        this.gameObject.SetActive(false);
        cata.SetActive(true);
    }
}
