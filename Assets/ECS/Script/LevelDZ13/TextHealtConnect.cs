using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextHealtConnect : MonoBehaviour
{
    void Start()
    {
        GlobalConnectObjectPhoton.TextHealt = this.gameObject.GetComponent<Text>();
    }

}
