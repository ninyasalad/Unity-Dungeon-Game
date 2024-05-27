using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        // Not the best option of solving mutiple GameManager appeared at the same time, but this still works.
        if (GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
    }
    // Resources
    public List<Sprite> playerSprites;
    public List<int> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    // References
    public Player player;
    // public weapon weapon...
    public FloatingTextManager floatingTextManager;


    // logic
    public int pesos;
    public int experience;

    // Floating Text
    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }

    // Save State
    /*
     * INT preferedSkin
     * INT pesos
     * INT experience
     * INT weaponLevel
     */

    public void SaveState()
    {
        string saving = "";

        saving += "0" + "|";
        saving += pesos.ToString() + "|";
        saving += experience.ToString() + "|";
        saving += "0";

        PlayerPrefs.SetString("SaveState", saving);
    }

    public void LoadState(Scene s, LoadSceneMode mode)
    {
        if (!PlayerPrefs.HasKey("SaveSate"))
        {
            return;
        }
        //  "0|10|15|2" => "0", "10", "15", "2"
        string[] data = PlayerPrefs.GetString("SaveState").Split('|');

        //Change Player skin
        pesos = int.Parse(data[1]);
        experience = int.Parse(data[2]);
        //Change the Weapon level

        Debug.Log("LoadState");
    }
}
