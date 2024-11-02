using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PassiceInfoScript;
using UnityEngine.UI;
public class Passive : MonoBehaviour
{
    // Start is called before the first frame update
    public string title = "";
    public string discription = "";
    public int nowLevel = 0;
    public int limitLevel = 5;
    public string imgSource = "";
    public void SetData(PassiveInfo passiveData)
    {
        title = passiveData.title;
        discription = passiveData.discription;
        nowLevel = passiveData.nowLevel;
        limitLevel = passiveData.limitLevel;
        imgSource = passiveData.imgSource;

        Image imageComponent = this.GetComponent<Image>();

        // Resources 폴더에서 경로에 해당하는 이미지를 불러옴
        if (imageComponent != null && !string.IsNullOrEmpty(imgSource))
        {
            // imgSource에서 확장자 제외하고 불러옴 (예: "Images/myImage")
            Sprite newSprite = Resources.Load<Sprite>(imgSource);

            if (newSprite != null)
            {
                imageComponent.sprite = newSprite;
            }
        }
    }
}
