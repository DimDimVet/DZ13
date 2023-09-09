using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class GiveItemPickUp : MonoBehaviour, ICollisionsComponent, IConvertGameObjectToEntity//IConvertGameObjectToEntity - ��� ��������� ���� �� ������
{

    public GameObject _ItemUI;//�������� ������� ��������� ������ ���������
    public GameObject ItemUI => _ItemUI;

    private Entity _entity;
    private EntityManager _dstManager;

    public void Execute(List<Collider> colliders)
    {
        for (int i = 0; i < colliders.Count; i++)
        {
            CharacterData characterData = colliders[i].GetComponent<CharacterData>();

            if (characterData != null && characterData.InventoryUIRoot!=null)
            {
                GameObject item = GameObject.Instantiate(ItemUI,characterData.InventoryUIRoot.transform);
                ICollisionsComponent newAbility = item.GetComponent<ICollisionsComponent>();//����� ������ ��������  � ����
                if (newAbility!=null)
                {
                    newAbility.Execute(colliders);
                }
                Destroy(gameObject);//����� ������
                _dstManager.DestroyEntity(_entity);//����� ������
            }
            else
            {
                return;
            }
        }
    }

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        _entity = entity;//������� � ������ �������� ������
        _dstManager = dstManager;
    }
}
