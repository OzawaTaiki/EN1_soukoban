using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    // �������ꂽ�I�u�W�F�N�g�̃��X�g
    private List<GameObject> generatedObjects = new List<GameObject>();

    // �I�u�W�F�N�g�𐶐����郁�\�b�h
    public GameObject GenerateObject(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        GameObject newObject = Instantiate(prefab, position, rotation);
        generatedObjects.Add(newObject);
        return newObject;
    }

    // ���ׂĂ̐������ꂽ�I�u�W�F�N�g���폜���郁�\�b�h
    public void ClearGeneratedObjects()
    {
        foreach (GameObject obj in generatedObjects)
        {
            Destroy(obj);
        }
        generatedObjects.Clear();
    }
}
