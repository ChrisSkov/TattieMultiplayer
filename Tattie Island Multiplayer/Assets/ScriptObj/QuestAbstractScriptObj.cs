using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class QuestAbstractScriptObj : ScriptableObject
{
    [SerializeField] public Dictionary<GameObject, int> enemiesAndAmounts;

    public string questTitle;
    public string questSummarry;
    public string questStory;
    public string questReward;

    public abstract void AcceptQuest();
    public abstract void UpdateQuestProgress();
    public abstract void QuestObjectiveCompleted();
    public abstract void HandInQuest();
}
