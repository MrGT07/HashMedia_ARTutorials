using UnityEngine;

//Information banner's behaviour. Basically, minimizing-maximizing! 
public class InfoBehaviour : MonoBehaviour
{
    private const float _speed = 6f;
    [SerializeField]
    private Transform SectionInfo = null;

    Vector3 desiredScale = Vector3.zero;

    private void Update()
    {
        SectionInfo.localScale = Vector3.Lerp(SectionInfo.localScale, desiredScale, Time.deltaTime * _speed);
    }

    public void openInfo()
    {
        desiredScale = Vector3.one;
    }

    public void closeInfo()
    {
        desiredScale = Vector3.zero;
    }
}
