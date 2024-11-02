using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using PassiceInfoScript;
public class PassiveManager : MonoBehaviour
{
    public static PassiveManager Instance { get; private set; }

    public PassiveInfo SelectedPassive { get; private set; }
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
    }
    public void SetSelectedPassive(PassiveInfo passiveInfo)
    {
        SelectedPassive = passiveInfo;
        passiveText.text = SelectedPassive.title;
        passiveDiscription.text = SelectedPassive.discription;
        passiveTextLevel.text = "LV"+ SelectedPassive.nowLevel;
        Texture2D texture = Resources.Load<Texture2D>(SelectedPassive.imgSource);
        if (texture != null)
        {
            passiveImg.texture = texture;
        }
    }

}

