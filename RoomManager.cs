using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomManager : MonoBehaviour
{
    public static int doorNumber = 0;

    // Start is called before the first frame update
    void Start()
    {
        //플레이어 위치, 출입구를 배열로 얻기
        GameObject[] enters = GameObject.FindGameObjectsWithTag("Exit");
        for(int i = 0; i < enters.Length; i++)
        {
            GameObject doorObj = enters[i];
            Exit exit = doorObj.GetComponent<Exit>();
            if(doorNumber == exit.doorNumber)
            {
                //플레이어를 해당 출입구로 이동
                float x = doorObj.transform.position.x;
                float y = doorObj.transform.position.y;

                if(exit.direction == ExitDirection.up)
                {
                    y += 1;
                }
                else if (exit.direction == ExitDirection.down)
                {
                    y -= 1;
                }
                else if(exit.direction == ExitDirection.right)
                {
                    x += 1;
                }
                else if (exit.direction == ExitDirection.left)
                {
                    x -= 1;
                }
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                player.transform.position = new Vector3(x, y);
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //씬 이동
    public static void ChangeScene(string scnename, int doornum)
    {
        doorNumber = doornum;   //문 번호를 static 변수에 저장
        string nowScene = PlayerPrefs.GetString("LastScene");
        if(nowScene != "")
        {
            SaveDataManager.SaveArrangeData(nowScene);  //배치 정보 저장
        }
        PlayerPrefs.SetString("LastScene", scnename);   //씬 이름 저장
        PlayerPrefs.SetInt("LastDoor", doornum);    //문  번호 저장
        SceneManager.LoadScene(scnename);   //씬 이동
    }
}
