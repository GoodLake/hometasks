using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {
    public int window;

    void Start()
    {
        window = 1;
    }
    private void OnGUI()
    {
        GUI.BeginGroup(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 200));
        if (window == 1)
        {
            if (GUI.Button(new Rect(10, 30, 180, 30), "Играть"))
            {
                window = 2;
            }
            if (GUI.Button(new Rect(10, 60, 180, 30), "Выход"))
            {
                window = 3;
            }
        }

        if (window == 2)
        {
            Application.LoadLevel(1);
        }
        if (window == 3)
        {
            GUI.Label(new Rect(50, 10, 180, 30), "Вы уже выходите?");
            if (GUI.Button(new Rect(10, 40, 180, 30), "Да"))
            {
                Application.Quit();
            }
            if (GUI.Button(new Rect(10, 80, 180, 30), "Нет"))
            {
                window = 1;
            }
        }
        GUI.EndGroup();
    }
}
