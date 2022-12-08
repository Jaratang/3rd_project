using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public GameObject startButton;
    public GameObject continueButton;
    public string firstSceneName;

    // Start is called before the first frame update
    void Start()
    {
        string sceneName = PlayerPrefs.GetString("LastScene");  //저장된 씬
        if(sceneName == "")
        {
            continueButton.GetComponent<Button>().interactable = false; 
        }
        else
        {
            continueButton.GetComponent<Button>().interactable = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButtonClicked()
    {
        //저장 데이터 초기화
        PlayerPrefs.DeleteAll();
        //HP초기화
        PlayerPrefs.SetInt("PlayerHP", 3);
        //스테이지 초기화
        PlayerPrefs.SetString("LastScene", firstSceneName);
        RoomManager.doorNumber = 0;

        SceneManager.LoadScene(firstSceneName);
    }

    public void ContinueButtonClicked()
    {
        string sceneName = PlayerPrefs.GetString("LastScene");
        RoomManager.doorNumber = PlayerPrefs.GetInt("LastDoor");
        SceneManager.LoadScene(sceneName);
    }
}
