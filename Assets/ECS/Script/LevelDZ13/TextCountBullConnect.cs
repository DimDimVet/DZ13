using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextCountBullConnect : MonoBehaviour
{
    void Start()
    {
        GlobalConnectObjectPhoton.TextCountBull= this.gameObject.GetComponent<Text>();
    }

}
