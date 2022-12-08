using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    life,
}

public class ItemData : MonoBehaviour
{
    public ItemType type;
    public int count = 1;

    public int arrangeId = 0;   //배치 식별자

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //접촉
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(type == ItemType.life)
            {
                if(PlayerController.hp<3)
                {
                    PlayerController.hp++;
                    //HP 갱신하기
                    PlayerPrefs.SetInt("PlayerHP", PlayerController.hp);
                }
            }

            //아이템 획득 연출
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            Rigidbody2D itemBody = GetComponent<Rigidbody2D>();
            itemBody.gravityScale = 2.5f;    //튀어오르는 연출
            itemBody.AddForce(new Vector2(0, 6), ForceMode2D.Impulse);
            Destroy(gameObject, 0.5f);

            // 배치 ID 저장
            SaveDataManager.SetArrangeId(arrangeId, gameObject.tag);
        }
    }
}
