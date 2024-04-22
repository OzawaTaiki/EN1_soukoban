using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject boxPrefab;
    public GameObject goalPrefab;
    public GameObject particlePrefab;


    public GameObject clearText;

    int[,] map;
    GameObject[,] field;

    Vector2Int[] move = new Vector2Int[]
    {
        new Vector2Int (0, -1),
        new Vector2Int( -1, 0 ),
        new Vector2Int(0, 1 ),
        new Vector2Int( 1, 0)
    };



    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1920, 1080, false);

        map = new int[,]
        {
            {1,0,0,2,0,0,0,0},
            {0,0,0,0,0,0,2,0},
            {0,0,0,0,0,0,2,0},
            {0,0,0,0,0,0,2,0},
            {0,3,0,2,0,0,0,0}
        };
        field = new GameObject[map.GetLength(0), map.GetLength(1)];

        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                if (map[y, x] == 1)
                {
                    field[y, x] = Instantiate(
                        playerPrefab,
                        new Vector3(x, map.GetLength(0) - y, 0),
                        Quaternion.identity);
                }
                if (map[y, x] == 2)
                {
                    field[y, x] = Instantiate(
                        boxPrefab,
                        new Vector3(x, map.GetLength(0) - y, 0),
                        Quaternion.identity);
                }
                if (map[y, x] == 3)
                {
                    Instantiate(
                        goalPrefab,
                        new Vector3(x, map.GetLength(0) - y, 0.01f),
                        Quaternion.identity);
                }
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        Vector2Int index = GetIndex();

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveNum("Player", index, index + move[1]);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveNum("Player", index, index + move[3]);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MoveNum("Player", index, index + move[0]);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MoveNum("Player", index, index + move[2]);
        }


        if (isCleared())
        {
            clearText.SetActive(true);
        }

    }


    Vector2Int GetIndex()
    {
        for (int y = 0; y < field.GetLength(0); y++)
        {
            for (int x = 0; x < field.GetLength(1); x++)
            {
                if (field[y, x] == null) { continue; }
                if (field[y, x].tag == "Player") { return new Vector2Int(x, y); }
            }
        }
        return new Vector2Int(-1, 1);
    }

    bool MoveNum(string _tag, Vector2Int _moveFrom, Vector2Int _moveTo)
    {
        if (_moveTo.y < 0 || _moveTo.y >= field.GetLength(0) ||
            _moveTo.x < 0 || _moveTo.x >= field.GetLength(1))
            return false;

        if (field[_moveTo.y, _moveTo.x] != null && field[_moveTo.y, _moveTo.x].tag == "Box")
        {
            Vector2Int velocity = _moveTo - _moveFrom;
            bool success = MoveNum(_tag, _moveTo, _moveTo + velocity);
            if (!success) { return false; }
        }

        field[_moveFrom.y, _moveFrom.x].transform.position = new Vector3(_moveTo.x, field.GetLength(0) - _moveTo.y, 0);
        field[_moveTo.y, _moveTo.x] = field[_moveFrom.y, _moveFrom.x];
        field[_moveFrom.y, _moveFrom.x] = null;



        for (int i = 0; i < 7; i++)
        {
            Instantiate(
               particlePrefab,
              new Vector3(GetIndex().x, map.GetLength(0) - GetIndex().y, 0),
               Quaternion.identity);
        }

        return true;
    }

    bool isCleared()
    {
        List<Vector2Int> goals = new List<Vector2Int>();

        for (int y = 0; y < field.GetLength(0); y++)
        {
            for (int x = 0; x < field.GetLength(1); x++)
            {
                if (map[y, x] == 3)
                {
                    goals.Add(new Vector2Int(x, y));
                }
            }
        }

        for (int i = 0; i < goals.Count; i++)
        {
            GameObject f = field[goals[i].y, goals[i].x];
            if (f == null || f.tag != "Box")
                return false;
        }

        return true;
    }

}

