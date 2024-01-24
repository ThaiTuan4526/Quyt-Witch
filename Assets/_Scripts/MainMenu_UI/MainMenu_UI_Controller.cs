using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu_UI_Controller : MonoBehaviour
{
    [Header("Main Menu UI Panel")]
    public GameObject loading_panel;

    public GameObject main_panel;

    [Header("Main Menu Panel Properties")]

    public GameObject main_menu_continue;

    public TextMeshPro[] main_menu_text;

    public GameObject[] main_menu_texts_back;

    #region Main Menu Panel Properties
    private int menu_state = 1;

    private Vector3 main_pointer_pos;

    private string state = "main";
    #endregion

    private bool the_game_is_on;

    private Color light_color;

    private Color dark_color;

    public string lvl_phrase;

    private int current_resolution_cell = 10;

    private int[] width = new int[15]
    {
        1024, 1280, 1280, 1280, 1360, 1366, 1440, 1600, 1680, 1920,
        1920, 2560, 2560, 3440, 3840
    };

    private int[] height = new int[15]
    {
        768, 800, 1024, 720, 768, 768, 900, 900, 1050, 1080,
        1200, 1440, 1080, 1440, 2160
    };

    private void Start()
    {
        MainMenuInit();
    }

    private void Update()
    {
        MainMenuControl();
    }

    #region Controll Main Menu
    private void MainMenuControl()
    {
        if (state == "main")
        {
            HandleControlMainState();
        }
    }

    private void HandleControlMainState()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S) && menu_state != 3)
        {
            main_menu_texts_back[menu_state].SetActive(false);
            
        }
    }
    #endregion

    #region Init và SetUp Game
    private void MainMenuInit()
    {
        Cursor.visible = false;

        light_color = new Color(0.8359f, 0.7187f, 0.4375f);
        dark_color = new Color(0.414f, 0.2187f, 0.25f);

        //Xác định dữ liệu tiến trình chương
        SetUpGameProgressData();

        //Xác định dữ liệu thiết lập resolution cho game
        SetUpGameResolutionData();

        //Thiết lập đường dẫn game và hiển thị
        SetUpSavePath();
    }

    private void SetUpGameProgressData()
    {
        if (!PlayerPrefs.HasKey("book_0_read"))
        {
            PlayerPrefs.SetInt("book_0_read", 0);
        }
        if (!PlayerPrefs.HasKey("book_1_read"))
        {
            PlayerPrefs.SetInt("book_1_read", 0);
        }
        if (!PlayerPrefs.HasKey("book_2_read"))
        {
            PlayerPrefs.SetInt("book_2_read", 0);
        }
        if (!PlayerPrefs.HasKey("book_3_read"))
        {
            PlayerPrefs.SetInt("book_3_read", 0);
        }
    }

    private void SetUpGameResolutionData()
    {
        if (PlayerPrefs.HasKey("resolution_width") && PlayerPrefs.HasKey("resolution_height"))
        {
            if (PlayerPrefs.HasKey("full_screen"))
            {
                Screen.SetResolution(PlayerPrefs.GetInt("resolution_width"), PlayerPrefs.GetInt("resolution_height"), PlayerPrefs.GetInt("full_screen") == 1);
            }
            else
            {
                Screen.SetResolution(PlayerPrefs.GetInt("resolution_width"), PlayerPrefs.GetInt("resolution_height"), Screen.fullScreen);
            }

            for (int i = 0; i < width.Length; i++)
            {
                if (Screen.width == width[i])
                {
                    current_resolution_cell = i;
                    break;
                }
            }
        }
        else
        {
            for (int j = 0; j < width.Length; j++)
            {
                if (width[j] == Screen.currentResolution.width && height[j] == Screen.currentResolution.height)
                {
                    PlayerPrefs.SetInt("resolution_width", Screen.currentResolution.width);
                    PlayerPrefs.SetInt("resolution_height", Screen.currentResolution.height);
                    current_resolution_cell = j;
                    break;
                }
            }
        }
    }

    private void SetUpSavePath()
    {
        if(!Directory.Exists(Application.dataPath + "/Saves"))
        {
            Directory.CreateDirectory(Application.dataPath + "/Saves");
        }

        string path = Application.dataPath + "/Saves/save.pidg";

        if(File.Exists(path))
        {
            the_game_is_on = true;
            main_menu_continue.SetActive(true);
            menu_state = 0;
            main_menu_text[0].GetComponent<Shadow>().enabled = true;
            main_menu_texts_back[0].SetActive(true);
        }
        else
        {
            main_menu_text[1].GetComponent<Shadow>().enabled = true;
            main_menu_texts_back[0].SetActive(true);
        }
    }
    #endregion
}
