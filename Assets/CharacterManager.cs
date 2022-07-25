using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    public CharacterDatabase characterDB;
    public Text nameText;

    public SpriteRenderer artSprite;

    private int selectedOption = 0;

    void Start(){
        UpdateCharacter(selectedOption);

    }

    public void NextOpt(){
        selectedOption++;

        if(selectedOption >= characterDB.CharCounter)
        {
            selectedOption = 0;
        }
        UpdateCharacter(selectedOption);

    }

    public void BackOpt(){
        selectedOption--;

        if(selectedOption <= 0)
        {
            selectedOption = characterDB.CharCounter-1;
        }

        UpdateCharacter(selectedOption);
    }

    private void UpdateCharacter (int selectedOption){
        Debug.Log(selectedOption);
        CharacterChoiceObj character = characterDB.GetCharacter(selectedOption);
        artSprite.sprite = character.characterSprite;
        nameText.text = character.characterName;
    }
}
