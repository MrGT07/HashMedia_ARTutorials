using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonScripts : MonoBehaviour
{
    [SerializeField]
    private GameObject _cata;
    [SerializeField]
    private GameObject _menu;

    private void Start()
    {
        _cata.SetActive(false);
    }

    //BACK
    public void goBack()
    {
        SceneManager.LoadScene("main");
    }
    //CLOSE
    public void goClose()
    {
        this.transform.parent.parent.gameObject.SetActive(false);
        InteractionWithCatalogue.isActive = true;
        _cata.SetActive(true);
    }
    //START
    public void goStart()
    {
        this.gameObject.SetActive(false);
        InteractionWithCatalogue.isActive = true;
        _cata.SetActive(true);
       
    }
}
