using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayerInfoManager;
public class useUltimate : MonoBehaviour
{
    public int selectUltimate = 0;
    public Sprite[] Ultimate;
    public GameObject ultimateDelayObject;
    private void Start()
    {
        GameObject ultimateObject = GameObject.Find("ultimateBTN");
        Image buttonImage = ultimateObject.GetComponent<Image>();
        if (buttonImage != null && Ultimate.Length > selectUltimate)
        {
            Debug.Log(PlayerManager.Instance.SelectedPassive.imgSource);
            if (PlayerManager.Instance.SelectedPassive.imgSource == null|| PlayerManager.Instance.SelectedPassive.imgSource == "")
            {
                Sprite newSprite = Resources.Load<Sprite>("Images/NotOpen");
                buttonImage.sprite = newSprite;
            }
            else
            {
                Texture2D texture = Resources.Load<Texture2D>(PlayerManager.Instance.SelectedPassive.imgSource);

                Sprite newSprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
                // 텍스처 할당
                //buttonImage.sprite = Ultimate[selectUltimate];
                buttonImage.sprite = newSprite;
            }
            
        }
        else
        {
            Debug.LogWarning("buttonImage 컴포넌트가 없거나 인덱스 범위를 벗어났습니다.");
        }
    }
    // Start is called before the first frame update
    public void clickUltimate()
    {
        if (ultimateDelayObject != null)
        {
            // 오브젝트가 존재할 때 수행할 작업
            ultimateDelayObject.SetActive(true);
            Debug.Log("Found the ultimateDelay GameObject!");
        }
        else
        {
            // 오브젝트가 존재하지 않을 때
            Debug.LogWarning("GameObject with the name 'ultimateDelay' was not found.");
        }
    }
}
