using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutIDHolder : MonoBehaviour
{
    public static int id;
    public static string category;
    private void Awake() 
    { 
        DontDestroyOnLoad(this.gameObject);
    }
}
