using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCtalk : MonoBehaviour
{
    //定义NPC对话数据
    private string[] mData =
    {
        "你好,我是NPC", "欢迎来到幻想世界",
        "可以请你帮我去打怪物吗？", "我会给你一定的奖励", "请打死守在怪物洞口前的侍卫兵", "我旁边的南瓜可以增加你的生命值"
    };

//当前对话索引
    private int index = 0;

//用于显示对话的GUI Text
    public Text NPCText;
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //从角色位置向NPC发射一条经过鼠标位置的射线
        Ray mRay = new Ray(player.transform.position, player.transform.forward);
        RaycastHit mHi;
        //判断是否击中了NPC
        if (Physics.Raycast(mRay, out mHi, 10))
        {
            if (mHi.collider.gameObject.CompareTag("NPC"))
            {
                Debug.Log("Yes");

                // 点击鼠标， 就会进行对话
                if (Input.GetKeyDown(KeyCode.F) || Input.GetMouseButtonDown(0))
                {
                    //绘制指定索引的对话文本
                    if (index < mData.Length)
                    {
                        NPCText.text = "NPC:" + mData[index];
                        index = index + 1;
                    }
                    else
                    {
                        NPCText.enabled = false; //不显示
//index=0;
                    }
                }
            }
        }
    }
}