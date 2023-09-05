using System.Collections.Generic;
using UnityEngine;

public class HeartItemAbility : MonoBehaviour, ICollisionsComponent,ICraft
{
    public string _Name="";
    public string Name
    {
        get
        {
            return _Name;
        }
    }

    private List<Collider> _colliders = new List<Collider>();

    public void Work()
    {
        for (int i = 0; i < _colliders.Count; i++)
        {
            HealtComponent healt = _colliders[i].GetComponent<HealtComponent>();
            if (healt != null)
            {
                healt.LvlUpData(50);//запишем и обновим
                Destroy(gameObject);//убъем объект
            }
            else
            {
                return;
            }
        }
    }

    public void Execute(List<Collider> colliders)
    {
        _colliders = colliders;
    }
}
