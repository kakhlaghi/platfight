using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterManager : MonoBehaviour
{
    public CharacterDatabase characterDB;
    public Text nameText;
    public Animator animCtrl;
    public SpriteRenderer artSprite;

    private int selectedOption = 0;

    void Start(){
        if(!PlayerPrefs.HasKey("selectedOption")){
            selectedOption = 0;
        } else {
            Load();
        }
        UpdateCharacter(selectedOption);

    }

    public void NextOpt(){
        selectedOption++;

        if(selectedOption >= characterDB.CharCounter)
        {
            selectedOption = 0;
        }
        UpdateCharacter(selectedOption);
        Save();

    }

    public void BackOpt(){
        selectedOption--;

        if(selectedOption <= 0)
        {
            selectedOption = characterDB.CharCounter-1;
        }

        UpdateCharacter(selectedOption);
        Save();
    }

    private void UpdateCharacter (int selectedOption){
        Debug.Log(selectedOption);
        CharacterChoiceObj character = characterDB.GetCharacter(selectedOption);
        artSprite.sprite = character.characterSprite;
        nameText.text = character.characterName;
    }

    private void Load(){
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }

    private void Save(){
        PlayerPrefs.SetInt("selectedOption", selectedOption);
    }

    public void ChangeScene(int SceneId){
        SceneManager.LoadScene(SceneId);
    }
}
