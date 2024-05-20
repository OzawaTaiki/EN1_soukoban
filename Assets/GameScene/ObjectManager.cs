using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    // 生成されたオブジェクトのリスト
    private List<GameObject> generatedObjects = new List<GameObject>();

    // オブジェクトを生成するメソッド
    public GameObject GenerateObject(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        GameObject newObject = Instantiate(prefab, position, rotation);
        generatedObjects.Add(newObject);
        return newObject;
    }

    // すべての生成されたオブジェクトを削除するメソッド
    public void ClearGeneratedObjects()
    {
        foreach (GameObject obj in generatedObjects)
        {
            Destroy(obj);
        }
        generatedObjects.Clear();
    }
}
