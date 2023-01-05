using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    private BoardManager boardScript;
    private List<Sprite> sprite1;
    private List<Sprite> sprite2;
    private int level;
    private bool end;

    public Sprite[] sprites;

    void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        boardScript = GetComponent<BoardManager>();
        InitGame();
    }

    void InitGame()
    {
        end = false;
        level = 1;
        NextLevel();
    }

    public void SelectCrate(Vector3 mousePos)
    {
        if (!end)
        {
            int x = Convert.ToInt32(mousePos[0]);
            int y = Convert.ToInt32(mousePos[1]);
            int index = (x - 6) * 4 + y;
            UpdateCrate(index);
            boardScript.BoardUpdate(sprite1, sprite2);
            Check();
        }
        else
        {
            print("End");
        }
    }

    void Check()
    {
        int j = 0;
        for (int i = 0; i < sprite1.Count; i++)
        {
            if (sprite1[i] == sprite2[i])
            {
                j++;
            }
        }
        if (sprite1.Count == j)
        {
            print("OK");
            level++;
            NextLevel();
        }
    }

    void UpdateCrate(int index)
    {
        int[] num = new int[0];
        if (index == 0)
            num = new int[] { 0, 1, 4, 5 };
        else if (index == 1 || index == 2)
            num = new int[] { -1, 0, 1, 3, 4, 5 };
        else if (index == 3)
            num = new int[] { -1, 0, 3, 4 };
        else if (index == 4 || index == 8)
            num = new int[] { -4, -3, 0, 1, 4, 5 };
        else if (index == 5 || index == 6 || index == 9 || index == 10)
            num = new int[] { -5, -4, -3, -1, 0, 1, 3, 4, 5 };
        else if (index == 7 || index == 11)
            num = new int[] { -5, -4, -1, 0, 3, 4 };
        else if (index == 12)
            num = new int[] { -4, -3, 0, 1 };
        else if (index == 13 || index == 14)
            num = new int[] { -5, -4, -3, -1, 0, 1 };
        else if (index == 15)
            num = new int[] { -5, -4, 0, -1 };
        foreach (int n in num)
        {
            if (sprite2[index + n] == sprites[0])
            {
                sprite2[index + n] = sprites[1];
            }
            else if (sprite2[index + n] == sprites[1])
            {
                sprite2[index + n] = sprites[0];
            }
        }
    }

    void NextLevel()
    {
        sprite1 = new List<Sprite>();
        sprite2 = new List<Sprite>();
        int rand = Random.Range(0, 15);
        if (level == 1)
        {
            for (int i = 0; i < 16; i++)
            {
                Sprite sprite = sprites[Random.Range(0, sprites.Length)];
                sprite1.Add(sprite);
                sprite2.Add(sprite);
            }
            UpdateCrate(rand);
        }
        else if (level == 2)
        {
            for (int i = 0; i < 16; i++)
            {
                Sprite sprite = sprites[Random.Range(0, sprites.Length)];
                sprite1.Add(sprite);
                sprite2.Add(sprite);
            }
            UpdateCrate(rand);
            int rand2 = Random.Range(0, 15);
            while (rand2 == rand)
            {
                rand2 = Random.Range(0, 15);
            }
            UpdateCrate(rand2);
        }
        else if (level == 3)
        {
            for (int i = 0; i < 16; i++)
            {
                Sprite sprite = sprites[Random.Range(0, sprites.Length)];
                sprite1.Add(sprite);
                sprite2.Add(sprite);
            }
            UpdateCrate(rand);
            int rand2 = Random.Range(0, 15);
            while (rand2 == rand)
            {
                rand2 = Random.Range(0, 15);
            }
            UpdateCrate(rand2);
            int rand3 = Random.Range(0, 15);
            while (rand3 == rand2 && rand3 == rand)
            {
                rand3 = Random.Range(0, 15);
            }
            UpdateCrate(rand3);
        }
        else
        {
            end = true;
        }
        if (!end)
        {
            boardScript.BoardUpdate(sprite1, sprite2);
        }
    }
}