using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// [System.Serializable] // Unity Inspector에서 표시되도록 직렬화
// public class skillView
// {
//     public Button skillBtn;
//     public RawImage skillIcon;
//     public TextMeshProUGUI skillName;
//     public TextMeshProUGUI skillExplane;

// }
public class timerManager : MonoBehaviour
{
    public int seconds = 30;
    public TextMeshProUGUI timerText; // 변경할 TMP 텍스트를 할당할 변수
    public TextMeshProUGUI waveText; // 변경할 TMP 텍스트를 할당할 변수
    private int level = 1;

    private void Start()
    {
        // 카운트다운 코루틴 시작
        StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        while (seconds > 0)
        {
            // 분과 초 계산
            int minutes = seconds / 60;
            int remainingSeconds = seconds % 60;

            // "분:초" 형식으로 표시 (두 자릿수 맞추기)
            timerText.text = string.Format("{0:00}:{1:00}", minutes, remainingSeconds);

            yield return new WaitForSeconds(1f);
            seconds--;
        }

        // 카운트다운이 끝나면 텍스트 변경
        timerText.text = "00:00";

        // 카운트다운이 끝나면 텍스트 변경
        ChangeText();
    }

    private void ChangeText()
    {
        if (waveText != null)
        {
            level++;
            waveText.text = "WAVE " + level; // 텍스트 변경
            seconds = 30;
            StartCoroutine(Countdown());

        }
    }
    public void CreateMonster()
    {

    }
}
