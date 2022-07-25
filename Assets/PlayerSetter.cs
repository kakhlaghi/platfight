using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetter : MonoBehaviour
{
    public CharacterDatabase characterDB;
    public SpriteRenderer artSprite;

    private int selectedOption = 0;
    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("selectedOption")){
            selectedOption = 0;
        } else {
            Load();
        }
        UpdateCharacter(selectedOption);
    }

    private void UpdateCharacter (int selectedOption){
        Debug.Log(selectedOption);
        CharacterChoiceObj character = characterDB.GetCharacter(selectedOption);
        artSprite.sprite = character.characterSprite;
    }


    private void Load(){
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }


}
