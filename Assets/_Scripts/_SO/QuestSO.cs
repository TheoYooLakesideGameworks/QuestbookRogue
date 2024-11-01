using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestSO", menuName = "Scriptable Objects/Quests/QuestSO")]
public class QuestSO : ScriptableObject
{
    [SerializeField] public int questID;
    [SerializeField] public string questName;

    [SerializeField] public Sprite questThumbnail;
    [SerializeField] public Sprite questSeal;
    [SerializeField] public string questType;

    [SerializeField] public List<SelectionData> selectionDatas;
}

[System.Serializable]
public class SelectionData
{
    [SerializeField] public string selectionName;
    [SerializeField] public int selectionStamina;

    [SerializeField] public List<ContentSO> questContents;
}