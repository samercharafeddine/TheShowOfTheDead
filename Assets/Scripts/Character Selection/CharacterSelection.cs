using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    [SerializeField] private GameObject[] characters;
    [SerializeField] private int selectedCharacter;

    public void NextCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter = (selectedCharacter+ 1) % characters.Length;
        characters[selectedCharacter].gameObject.SetActive(true);
    }

    public void PreviousCharacter()
    {
        characters[selectedCharacter].gameObject.SetActive(false);
        selectedCharacter--;
        if(selectedCharacter < 0 )
        {
            selectedCharacter += characters.Length;
        }
        characters[selectedCharacter].SetActive(true);
    }

    public void StartGame()
    {
        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}
