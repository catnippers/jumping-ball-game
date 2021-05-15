using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    #region Variables
    
    [SerializeField]
    private Text timerText;

    [SerializeField] 
    private GameObject questManager;
    
    public float timeLimit;
    
    private float timeLeft;
    private QuestManager questManagerScript;

    #endregion

    #region Hooks

    private void Start()
    {
        timeLeft = timeLimit;
        questManagerScript = questManager.GetComponent<QuestManager>();
    }

    private void Update()
    {
        timeLeft -= Time.deltaTime;
        CheckIfTimesUp();
    }
    #endregion

    #region Methods
    private void CheckIfTimesUp()
    {
        if (timeLeft < 0)
        {
            questManagerScript.PerformAnnihilation();
        }
        else
        {
            timerText.text = $"{timeLeft}";
        }
    }

    public float GetTimeScore()
    {
        return timeLimit - timeLeft;
    }
    
    #endregion
}
