using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutIDHolder : MonoBehaviour
{
    public static int id;
    private void Awake()
    {
        id = InteractionWithMenu.id;
        DontDestroyOnLoad(this.gameObject);
    }
}
