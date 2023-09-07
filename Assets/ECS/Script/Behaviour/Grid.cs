using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [HideInInspector] public GameObject gObject;
    void Start()
    {
        gObject = this.gameObject;
    }
}
