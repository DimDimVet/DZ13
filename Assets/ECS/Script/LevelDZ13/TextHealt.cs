using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextHealt : MonoBehaviour
{
    [HideInInspector] public Text text; 
    void Start()
    {
        text = this.gameObject.GetComponent<Text>();
    }

}
