//using System;
//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Game Configuration
    const string menuHint = "Escriba 'menu' para volver al comienzo";
    string[] level1Passwords = { "paco", "yuta", "tombo", "rati", "tira" };
    string[] level2Passwords = { "huanaco", "mentholatum", "zorrillo", "abusador", "asesino", "lagrimogena"};
    string[] level3Passwords = { "inepto", "ridiculo", "tiriton", "payaso", "desaprobacion", "inconstitucional", "ladron" };

    // Game State
    int level;
    const int initialTries = 6;
    int triesLeft = initialTries;
    string password;
    enum Screen { MainMenu, Password, Win, Lose };
    Screen currentScreen;

    //TODO Set tries for each level, then do a "you lose screen"

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
        Terminal.WriteLine("3. A Piraña");
        Terminal.WriteLine("");
        Terminal.WriteLine("Escribe tu opcion:");
    }
    
    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu();
        }
        else if (input == "exit" || input == "quit" || input == "close" || input == "salir")
        {
            Terminal.WriteLine("Gracias por jugar!");
            Application.Quit();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");

        if (isValidLevelNumber)
        {
            level = int.Parse(input);   // int.Parse convierte el formato del parametro a int
            triesLeft = initialTries - level;
            AskForPassword();
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

    void AskForPassword()
    {
        currentScreen = Screen.Password;

        SetRandomPassword();
        Terminal.ClearScreen();
        Terminal.WriteLine("Seguridad nivel " + level);
        Terminal.WriteLine("Ingresa el password (pista: " + password.Anagram() + "):");
    }

    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;

            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;

            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;

            default:
                Debug.LogError("Invalid level number");
                break;
        }
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else if (triesLeft > 1)
        {
            triesLeft = triesLeft - 1;
            Terminal.WriteLine("Password incorrecto!");
            Terminal.WriteLine("Intente otra vez. Quedan " + triesLeft + " intentos.");
        }
        else
        {
            DisplayLoseScreen();
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;

        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine(menuHint);
    }

    void DisplayLoseScreen()
    {
        currentScreen = Screen.Lose;

        Terminal.ClearScreen();
        Terminal.WriteLine(@"

 (       (   (    (   (              
 )\ )    )\ ))\ ) )\ ))\ ) *   )     
(()/((  (()/(()/((()/(()/` )  /((    
 /(_))\  /(_)/(_))/(_)/(_)( )(_))\   
(_))((_)(_))(_))_(_))(_))(_(_()((_)  
| _ | __| _ \|   |_ _/ __|_   _| __| 
|  _| _||   /| |) | |\__ \ | | | _|  
|_| |___|_|_\|___|___|___/ |_| |___|

");
        Terminal.WriteLine(menuHint);
    }

    void ShowLevelReward()
    {
        Terminal.WriteLine("Bienvenido al nivel de seguridad " + level);
        switch (level)
        {
            case 1:
                Terminal.WriteLine(@" 
   (       (      (       (   
   )\      )\     )\    ( )\  
((((_)(  (((_) ((((_)(  )((_) 
 )\ _ )\ )\___  )\ _ )\((_)_  
 (_)_\(_((/ __| (_)_\(_)| _ ) 
  / _ \ _| (__ _ / _ \ _| _ \ 
 /_/ \_(_)\___(_/_/ \_(_|___/
                ");   // @"" en Terminal.Writeline saca texto ascii tal como esta escrito, de ahi la indentacion fea
                break;

            case 2:
                Terminal.WriteLine(@"    
    )     )   )    )  
 ( /(  ( /(( /( ( /(  
 )\()) )\())\()))(_)) 
((_)\ ((_)((_)\((_)   
 / (_|__ (_/ (_|_  )  
 | |  |_ \ | |  / /   
 |_| |___/ |_| /___|
                ");
                break;

            case 3:
                Terminal.WriteLine(@"
    ________  ____________  ___    __
   / ____/ / / / ____/ __ \/   |  / /
  / /_  / / / / __/ / /_/ / /| | / / 
 / __/ / /_/ / /___/ _, _/ ___ |/_/  
/_/    \____/_____/_/ |_/_/  |_(_)   
                ");
                break;

            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
