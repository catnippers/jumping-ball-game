using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestDescription : MonoBehaviour
{
    #region Variables
    
    [SerializeField]
    private Text questDescription;

    private QuestManager questManagerScript;
    private int currentCheckpointsCount = 0;
    private int checkpointsSum = 4;
    private int currentQuestNumber = 0;
    
    /*
     Preferably done with separate database
     */
    private List<string> questsList = new List<string>
    {
        "Przedostań się przez wszystkie punkty kontrolne ",
        "Wskocz na pomarańczowy przycisk",
        "Hop do dziury!"
    };
    
    #endregion
    
    #region Hooks
    void Start()
    {
        GameObject questManager = GameObject.FindGameObjectWithTag("QuestManager");
        questManagerScript = questManager.GetComponent<QuestManager>();
            
        CheckCheckpointsSum();
        UpdateQuestDescription(GetCurrentQuestDescription());
    }

    private void Update()
    {
        UpdateQuestDescription(GetCurrentQuestDescription());
    }
    #endregion
    
    #region Methods
    
    private string GetCurrentQuestDescription()
    { 
        return questsList[currentQuestNumber];
    }
    
    private void UpdateQuestDescription(string questNewDescription)
    {
        CheckCurrentQuestNumber();
        if (currentQuestNumber == 0)
        {
            CheckCurrentCheckpointsCount();
            questDescription.text = $"{questNewDescription} ({currentCheckpointsCount}/{checkpointsSum})";
        }
        else
        {
            questDescription.text = $"{questNewDescription}";
        }
    }

    private void CheckCurrentCheckpointsCount()
    {
        currentCheckpointsCount = questManagerScript.GetPassedCheckpointsCount();
    }

    private void CheckCheckpointsSum()
    {
        if (questManagerScript.GetCheckpointsSum() != 0)
            checkpointsSum = questManagerScript.GetCheckpointsSum();
    }

    private void CheckCurrentQuestNumber()
    {
        currentQuestNumber = questManagerScript.GetCurrentQuestNumber();
    }
        
    #endregion
}