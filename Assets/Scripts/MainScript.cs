using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CubicBoard;
using UnityEngine.UI;
using System.IO;


public class MainScript : MonoBehaviour
{
    public Text TextMoves;
    public Text TextWords;
    const int size = 4;
    GameLogic game;
    Sound sound;
    public GameObject empty;

    // Sprite[] IMAGES = new Sprite[16];




    // Start is called before the first frame update
    void Start()
    {
        
        game = new GameLogic(size);
        sound = GetComponent<Sound>();
        HideButtons();
    }

    public void OnStart() {
        StreamWriter WriteFile = new StreamWriter("Save.txt", false, System.Text.Encoding.Default);
        game.Start(1000 + System.DateTime.Now.Second);
        ShowButtons();
        sound.PlayStart();
    }
    
    public void OnClick() {
        if (game.Solved()) return;
        string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

        int x = int.Parse(name.Substring(0, 1));
        int y = int.Parse(name.Substring(1, 1));
        if (game.PressAt(x, y) > 0) sound.PlayMove();
        ShowButtons();
        if (game.Solved())
        {
            empty.SetActive(true);
            TextWords.text = "Победа!!!";
            sound.PlaySolved();
            Time.timeScale = 0f;
            empty = new GameObject();
            
        }
    }

    void ShowDigitAt(int digit, int x, int y) {
        string name = x + "" + y;
        var button = GameObject.Find(name);
        var text = button.GetComponentInChildren<Text>();
        button.GetComponentInChildren<Image>().color = (digit > 0) ? Color.white : Color.clear;
        if (digit == 0) text.text = "";
        else text.text = digit.ToString();
        //button.GetComponentInChildren<Image>().sprite = IMAGES[digit];
    }

    void HideButtons()
    {
        for (int x = 0; x < size; ++x)
        {
            for (int y = 0; y < size; ++y)
            {
                ShowDigitAt(0, x, y);
            }
        }
    }

    void ShowButtons()
    {
        for (int x = 0; x < size; ++x)
        {
            for (int y = 0; y < size; ++y)
            {
                ShowDigitAt(game.GetDigitAt(x, y), x, y);
            }
        }
        TextMoves.text = game.moves.ToString();
    }
    /*
    [System.Obsolete]
    public void SavePictures()
    {
        WWW www;
        for (int i = 1; i < 16; ++i)
        {
        
            string name = "C:/FiftyImages/" + i + ".png";
            www = new WWW(name);
            IMAGES[i - 1] = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), Vector2.zero, 0);

        }
    }
    */
}
