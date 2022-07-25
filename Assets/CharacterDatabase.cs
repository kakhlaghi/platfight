using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterDatabase : ScriptableObject
{
   public CharacterChoiceObj[] character;
   public int CharCounter
   {
    get { return character.Length; }
   }

   public CharacterChoiceObj GetCharacter(int index){
    return character[index];
   }
}
