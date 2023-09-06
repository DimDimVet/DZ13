using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridConnect : MonoBehaviour
{
    void Start()
    {
        GlobalConnectObjectPhoton.InventoryUIRoot= this.gameObject.GetComponent<GameObject>();
    }

}
