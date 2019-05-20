using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.ThirdPerson;

public class NPCtalk : MonoBehaviour
{
    public AICharacterControl NPCstanding;
    //定义NPC对话数据
    private string[] mData =
    {
        "Oh, hello.", 
        "Are you come to look for JadeFox's treasure?",
        "A seeker who can hear the sound of treasure will come today, that must be you!", 
        "JadeFox is known as a great monster.", 
        "She left a treasure chest here that requires three special items to unlock.", 
        "All of the three items are in the town, but no one have seen them before.",
        "If you can hear the sounds made by those items, that would be very helpful."
    };

//当前对话索引
    private int index = 0;

//用于显示对话的GUI Text
    public Text NPCText;
    public GameObject player;
    public GameObject dialog;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        NPCstanding = GameObject.FindWithTag("NPC").GetComponent<AICharacterControl>();
        dialog = GameObject.Find("DialogPanel");
        
        //设定初始对话框状态
        dialog.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //从角色位置向NPC发射一条经过鼠标位置的射线
        // mRay = new Ray(player.transform.position, player.transform.forward);
        //Debug.DrawRay(player.transform.position+Vector3.up, player.transform.forward,Color.cyan);
        //RaycastHit mHi;
        //判断是否击中了NPC
       // if (Physics.Raycast(mRay, out mHi, 10))
        //{
           // if (mHi.collider.gameObject.CompareTag("NPC"))
           
           //用射线太难碰到了还是用trigger吧~
           if (NPCstanding.playertouch == true)
            {
                
                //Debug.Log("Yes");

                // 点击鼠标， 就会进行对话
                if (Input.GetKeyDown(KeyCode.F) || Input.GetMouseButtonDown(0))
                {
                    //绘制指定索引的对话文本
                    if (index < mData.Length)
                    {
                        dialog.SetActive(true);
                        NPCText.text = "<color=#EFD92A><b>" + "The Guard:"+"</b></color>\n\n" + mData[index];
                        index = index + 1;
                    }
                    else
                    {
                        NPCText.enabled = false; //不显示
                        dialog.SetActive(false);
                        //index=0;
                    }
                }
            }
       // }
        else
        {
            dialog.SetActive(false);
            //NPCstanding.playertouch = false;//没触碰时会继续闲逛
        }
    }
}