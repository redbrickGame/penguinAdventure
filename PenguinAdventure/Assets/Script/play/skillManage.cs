using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using System; // LINQ 기능 사용을 위한 네임스페이스

[System.Serializable] // Unity Inspector에서 표시되도록 직렬화
public class inputSkill
{
    private int skillLevel = 0;
    public Sprite skillIcon;
    public string skillName;
    public string skillExplane;

    //func
    public int SkillLevel
    {
        get { return skillLevel; }
        set { skillLevel = value; }
    }
}


[System.Serializable] // Unity Inspector에서 표시되도록 직렬화
public class skillView
{
    public Button skillBtn;
    public RawImage skillIcon;
    public TextMeshProUGUI skillName;
    public TextMeshProUGUI skillExplane;

}


[System.Serializable] // Unity Inspector에서 표시되도록 직렬화
public class presentSkill
{
    public List<inputSkill> list = new List<inputSkill> { null, null, null, null, null };
}

public class skillManage : MonoBehaviour
{
    public GameObject skillList;
    public List<skillView> skillViews;
    public List<inputSkill> skillItems;
    public Sprite sprite;
    List<string> selectMySkill = new List<string>();
    List<inputSkill> skillList_select = new List<inputSkill>();
    bool Once = false;

    private void Start()
    {
        skillList_select = skillItems;
    }
    public void setSkill()
    {
        // Debug.Log(Once);

        List<inputSkill> randomNumbers = RandomSample.GetRandomElements(skillList_select, Math.Min(3, skillList_select.Count));
        int i = 0;
        foreach (inputSkill number in randomNumbers)
        {

            skillViews[i].skillIcon.texture = number.skillIcon.texture;
            skillViews[i].skillName.text = number.skillName + "  " + (number.SkillLevel + 1) + " / 5";
            skillViews[i].skillExplane.text = number.skillExplane;
            skillViews[i].skillBtn.GetComponent<skillInfo>().SkillName = number.skillName;
            i++;

        }
        if (i <= 2)
        {
            //자식객체 다 setActive하고 

            int childCount = skillViews[i].skillBtn.transform.childCount;

            for (int j = 0; j < childCount; j++)
            {
                GameObject Btnchild = skillViews[i].skillBtn.transform.GetChild(j).gameObject;
                Btnchild.gameObject.SetActive(false);
                skillViews[i].skillBtn.interactable = false;
                skillViews[i].skillBtn.GetComponent<Image>().sprite = sprite;
            }

            i++;
            if (i > 2)
                return;
        }
    }

    public void SelectSkill(string name)
    {
        inputSkill foundSkill = skillItems.Find(skill => skill.skillName == name);
        // foundSkill.SkillLevel = foundSkill.SkillLevel + 1;
        // mySkillList(foundSkill);
        if (foundSkill != null)
        {
            // Debug.Log($"찾은 스킬: {foundSkill.skillName}");
            foundSkill.SkillLevel = foundSkill.SkillLevel + 1;
            mySkillList(foundSkill);
        }
        else
        {
            Debug.Log($"스킬 '{name}'을(를) 찾을 수 없습니다.");
        }
    }

    public void mySkillList(inputSkill skill)
    {
        List<GameObject> childObjects = new List<GameObject>();

        int childCount = skillList.transform.childCount; // 자식의 개수 가져오기

        for (int i = 0; i < childCount; i++)
        {
            GameObject child = skillList.transform.GetChild(i).gameObject;
            childObjects.Add(child);
        }

        // 결과 출력
        foreach (var child in childObjects)
        {
            skillInfo info = child.GetComponent<skillInfo>();
            if (info.SkillName == skill.skillName)
            {
                info.level = skill.SkillLevel;
                child.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "" + skill.SkillLevel + " / 5";

                if (skill.SkillLevel == 5)
                {
                    //삭제하는거 다시 만들기
                    inputSkill skillToRemove = skillList_select.Find(ski => ski.skillName == skill.skillName);

                    if (skillToRemove != null)
                    {
                        // 해당 스킬 삭제
                        skillList_select.Remove(skillToRemove);
                        Debug.Log($"스킬 '{name}'이(가) 삭제되었습니다." + skillList_select.Count);
                    }
                    else
                    {
                        Debug.Log($"스킬 '{name}'을(를) 찾을 수 없어 삭제하지 못했습니다.");
                    }
                }

                break;
            }
            else if (info.SkillName == "")
            {

                selectMySkill.Add(skill.skillName);
                info.SkillName = skill.skillName;
                info.level = skill.SkillLevel;
                child.GetComponent<RawImage>().texture = skill.skillIcon.texture;
                child.transform.GetChild(0).gameObject.SetActive(true);
                if (selectMySkill.Count == 5 && !Once)
                {
                    Once = true;
                    List<inputSkill> foundSkills = skillList_select
            .Where(skill => selectMySkill.Contains(skill.skillName))
            .ToList();

                    // 결과 확인
                    if (foundSkills.Count > 0)
                    {
                        // Debug.Log(foundSkills.Count);
                        skillList_select.Clear(); // 기존 리스트의 내용을 지움
                        skillList_select.AddRange(foundSkills); // foundSkills의 내용을 skillList_select에 추가

                    }
                    else
                    {
                        Debug.Log("조건에 맞는 스킬을 찾을 수 없습니다.");
                    }
                    // inputSkill foundSkill = skillItems.Find(skill => selectMySkill.Contains(skill.skillName));
                }

                break;
            }
            else
            {

            }

        }
    }

}
