using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CharacterManager : MonoBehaviour
{
    public SpriteRenderer sr;
    public List<Sprite> sprites = new List<Sprite>();
   // public Character[] character;
    private int selectedChar = 0;
    public GameObject playerChar;

    public void NextOpt(){
        selectedChar += 1;
        if(selectedChar == sprites.Count){

        }
    }
}
