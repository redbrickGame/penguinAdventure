using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using PassiceInfoScript;
using PlayerInfoManager;
public class PassiveManager : MonoBehaviour
{
    public static PassiveManager Instance { get; private set; }

    
    public TextMeshProUGUI passiveText;
    public TextMeshProUGUI passiveTextLevel;
    public TextMeshProUGUI passiveDiscription;
    public RawImage passiveImg;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        SetSelectedPassive(PlayerManager.Instance.SelectedPassive);
    }

    public void SetSelectedPassive(PassiveInfo passiveInfo)
    {
        PlayerManager.Instance.SelectedPassive = passiveInfo;
        passiveText.text = PlayerManager.Instance.SelectedPassive.title;
        passiveDiscription.text = PlayerManager.Instance.SelectedPassive.discription;
        passiveTextLevel.text = "LV"+ PlayerManager.Instance.SelectedPassive.nowLevel;
        Texture2D texture = Resources.Load<Texture2D>(PlayerManager.Instance.SelectedPassive.imgSource);
        if (texture != null)
        {
            passiveImg.texture = texture;
        }
    }

}

