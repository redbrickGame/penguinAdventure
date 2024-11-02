using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayerInfoManager;
using TMPro;
public class LobbyManager : MonoBehaviour
{   public static LobbyManager Instance { get; private set; }

    [SerializeField] private PassiveBtnGroup passiveBtn;
    [SerializeField] private GameObject health;
    [SerializeField] private GameObject defense;
    [SerializeField] private GameObject damage;
    [SerializeField] private GameObject speed;
    // Start is called before the first frame update

    private RectTransform healthBar;
    private TextMeshProUGUI healthNum;
    private RectTransform defenseBar;
    private TextMeshProUGUI defenseNum;
    private RectTransform damageBar;
    private TextMeshProUGUI damageNum;
    private RectTransform speedBar;
    private TextMeshProUGUI speedNum;
    private void Awake()
    {
        //if(Instance == null)
        //{
        //    Instance = this;
        //    DontDestroyOnLoad(gameObject);
        //}
        //else
        //{
        //    if (Instance != this)
        //        Destroy(this.gameObject);
        //}
        setPassiveBtn();
    }
    void Start()
    {
        healthBar = health.transform.Find("HealthBarBack/HealthBar").GetComponent<RectTransform>();
        healthNum = health.transform.Find("HealthNum").GetComponent<TextMeshProUGUI>();
        defenseBar = defense.transform.Find("DefenseBarBack/DefenseBar").GetComponent<RectTransform>();
        defenseNum = defense.transform.Find("DefenseNum").GetComponent<TextMeshProUGUI>();
        damageBar = damage.transform.Find("DamageBarBack/DamageBar").GetComponent<RectTransform>();
        damageNum = damage.transform.Find("DamageNum").GetComponent<TextMeshProUGUI>();
        speedBar = speed.transform.Find("SpeedBarBack/SpeedBar").GetComponent<RectTransform>();
        speedNum = speed.transform.Find("SpeedNum").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void LateUpdate()
    {
        healthNum.text = PlayerManager.Instance.myPlayer._hp.ToString();
        defenseNum.text = PlayerManager.Instance.myPlayer._defense.ToString();
        damageNum.text = PlayerManager.Instance.myPlayer._damage.ToString();
        speedNum.text = PlayerManager.Instance.myPlayer._moveSpeed.ToString();
        if (PlayerManager.Instance != null)
        {
            if ((float)PlayerManager.Instance.myPlayer._hp / 100 >= 0)
                healthBar.localScale = new Vector3((float)PlayerManager.Instance.myPlayer._hp / 100, 1, 1);
            if ((float)PlayerManager.Instance.myPlayer._hp / 100 >= 0)
                defenseBar.localScale = new Vector3((float)PlayerManager.Instance.myPlayer._defense / 100, 1, 1);
            if ((float)PlayerManager.Instance.myPlayer._hp / 100 >= 0)
                damageBar.localScale = new Vector3((float)PlayerManager.Instance.myPlayer._damage / 100, 1, 1);
            if ((float)PlayerManager.Instance.myPlayer._hp / 100 >= 0)
                speedBar.localScale = new Vector3((float)PlayerManager.Instance.myPlayer._moveSpeed / 100, 1, 1);
        }
        //health..text = PlayerManager.Instance.myCharacter._hp + " / " + "100";
        //playerLevelText.text = CharacterManager.Instance.myCharacter._level.ToString();
        //playerNameText.text = CharacterManager.Instance._username;
        //playerCoinText.text = string.Format("{0:n0}", CharacterManager.Instance.myCharacter._money);
        //if (player != null)
        //{
        //    if ((float)CharacterManager.Instance.myCharacter._hp / 100 >= 0)
        //        playerHealthBar.localScale = new Vector3((float)CharacterManager.Instance.myCharacter._hp / 100, 1, 1);
        //}

    }
    void setPassiveBtn()
    {
        passiveBtn.GenerateButtons();
    }

}
