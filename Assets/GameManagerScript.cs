using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public GameObject playerPrefab;

    int[,] map;
    string debugText = "";

    // Start is called before the first frame update
    void Start()
    {
        //GameObject instance = Instantiate(
        //    playerPrefab,
        //    new Vector3(0, 0, 0),
        //    Quaternion.identity);

        map = new int[,]
        {
            {1,0,2,0,0,2,0,0},
            {0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0}
        };
        Print();

    }


    //// Update is called once per frame
    //void Update()
    //{
    //    int index = GetIndex();

    //    if (Input.GetKeyDown(KeyCode.LeftArrow))
    //    {
    //        if (MoveNum(1, index, index - 1))
    //            Print();

    //    }
    //    if (Input.GetKeyDown(KeyCode.RightArrow))
    //    {
    //        if (MoveNum(1, index, index + 1))
    //            Print();
    //    }
    //}

    void Print()
    {
        debugText = "";
        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                debugText += map[y, x].ToString() + ",";
            }
            debugText += "\n";
        }
        Debug.Log(debugText);
    }

    //int GetIndex()
    //{
    //    for (int i = 0; i < map.Length; i++)
    //    {
    //        if (map[i] == 1)
    //        {
    //            return i;
    //        }
    //    }
    //    return -1;
    //}

    //bool MoveNum(int _num, int _moveFrom, int _moveTo)
    //{
    //    if (_moveTo < 0 || _moveTo >= map.Length)
    //        return false;

    //    if (map[_moveTo]!=0)
    //    {
    //        int velocity = _moveTo - _moveFrom;
    //        if (!MoveNum(map[_moveTo], _moveTo, _moveTo+velocity))
    //            return false;
    //    }

    //    map[_moveTo] = _num;
    //    map[_moveFrom] = 0;
    //    return true;
    //}
}
