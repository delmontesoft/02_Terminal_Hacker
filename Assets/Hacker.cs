using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Member Variables:
    int level;

    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();

        Terminal.WriteLine("Que te gustaria hackear hoy?");
        Terminal.WriteLine("");
        Terminal.WriteLine("1. A los pacos");
        Terminal.WriteLine("2. A la agencia de des-'inteligencia'");
        Terminal.WriteLine("");
        Terminal.WriteLine("Escribe tu opcion:");
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu();

        } else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
    }

    void RunMainMenu(string input)
    {
        if (input == "1")
        {
            // ir a dificultad 1
            level = 1;
            StartGame();
        }
        else if (input == "2")
        {
            // ir a dificultad 2
            level = 2;
            StartGame();
        }
        else if (input == "007")
        {
            Terminal.WriteLine("Seleccione una opcion valida Sr. Bond!");
        }
        else
        {
            Terminal.WriteLine("La opcion ingresada no es valida");
        }
    }

    void StartGame()
    {
        currentScreen = Screen.Password;

        Terminal.WriteLine("Seguridad nivel " + level);
        Terminal.WriteLine("Ingresa el password:");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
