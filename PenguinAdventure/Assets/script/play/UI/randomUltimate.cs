using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class randomUltimate : MonoBehaviour
{
    public Texture[] Ultimate; // 사용할 텍스처 배열
    public int selectUltimate; // 선택할 텍스처 인덱스
    private void OnEnable()
    {

        int randomNumber = Random.Range(0, 4);
        selectUltimate = randomNumber;
        GameObject ultimateObject = GameObject.Find("getultimateIcon");
        // ultimateObject에서 RawImage 컴포넌트를 가져오기
        RawImage rawImage = ultimateObject.GetComponent<RawImage>();

        if (rawImage != null && Ultimate.Length > selectUltimate)
        {
            // 텍스처 할당
            rawImage.texture = Ultimate[selectUltimate];
        }
        else
        {
            Debug.LogWarning("RawImage 컴포넌트가 없거나 인덱스 범위를 벗어났습니다.");
        }
    }
}
