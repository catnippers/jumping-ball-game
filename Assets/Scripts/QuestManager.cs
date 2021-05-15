using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Vehicles.Ball;

public class QuestManager : MonoBehaviour
{
    #region Variables
    
    #region Private Variables
    
    private Ball ballScript;
    private BallUserControl ballUserControlScript;
    private LightSwitchAnimController lightSwitchAnimController;
    private BlueLightAnimController blueLightAnimController;
    private OrangeLightAnimController orangeLightAnimController;
    private LightStoneAnimController lightStoneAnimController;
    private Timer timerScript;
    
    private int passedCheckpointsCount;
    private int checkpointsSum;
    private int currentQuestNumber = 0;
    
    private bool isResetEnabled;
    private bool isGameOver;

    #endregion

    #region Serialized Fields & Public Variables
    
    [SerializeField] 
    private Canvas questDisplay;

    [SerializeField] 
    private GameObject player;

    [SerializeField] 
    private GameObject questText;
    
    [SerializeField] 
    private GameObject timerText;
    
    [SerializeField] 
    private GameObject timesUpText;
    
    [SerializeField] 
    private GameObject finishedLevelText;

    [SerializeField]
    private GameObject lightSwitchButton;

    [SerializeField] private GameObject dustStormParticle;

    [SerializeField] private GameObject orangeLight;

    [SerializeField] private GameObject blueLight;

    [SerializeField] private GameObject lightStone;

    #endregion

    #endregion
    
    #region Hooks
    private void Start()
    {
        isResetEnabled = false;
        isGameOver = false;
        SetUpAnimControllers();
        SetUpPlayerScripts();
        passedCheckpointsCount = 0;
        checkpointsSum = GameObject.FindGameObjectsWithTag("Checkpoint").Length;
    }

    private void Update()
    {
        CheckIfSpecialQuestFinished();
        if (Input.GetKeyDown(KeyCode.R) && isResetEnabled)
        {
            SceneManager.LoadScene("Game");
        }
    }

    #endregion

    #region Methods

    #region Private Methods

    private void SetUpAnimControllers()
    {
        lightSwitchAnimController = lightSwitchButton.GetComponent<LightSwitchAnimController>();
        orangeLightAnimController = orangeLight.GetComponent<OrangeLightAnimController>();
        blueLightAnimController = blueLight.GetComponent<BlueLightAnimController>();
        lightStoneAnimController = lightStone.GetComponent<LightStoneAnimController>();
    }
    
    private void SetUpPlayerScripts()
    {
        ballUserControlScript = player.GetComponent<BallUserControl>();
        ballScript = player.GetComponent<Ball>();
    }
    
    private void DisableTimerDisplay()
    {
        timerText.SetActive(false);
    }

    private void DisplayTimesUpText()
    {
        timesUpText.SetActive(true);
    }

    private void DisplayFinishedLevelText()
    {
        finishedLevelText.SetActive(true);
    }

    private void EnableReset()
    {
        isResetEnabled = true;
    }

    private void CheckIfSpecialQuestFinished()
    {
        if (passedCheckpointsCount == checkpointsSum && currentQuestNumber == 0) // First quest require animation afterwards
        {
            FinishQuestAndIncreaseCurrentQuestNumber();
            lightSwitchAnimController.PlayRiseLightSwitch(); //Rise the final-ultimate-epic button on the level end
        }

        if (currentQuestNumber == 3) // This means if level ends (because there are only 3 quests)
        {
            FinishLevel();
        }
    }
    
    private void EnableDustStorm()
    {
        dustStormParticle.SetActive(true);
    }

    private void PlayBreakDownAnimations()
    {
        orangeLightAnimController.PlayOrangeLightBreakDown();
        blueLightAnimController.PlayBlueLightBreakDown();
        lightStoneAnimController.PlayMainLightStoneBreakDown();
    }
    
    private void FinishLevel()
    {
        if (!isGameOver)
        {
            isGameOver = true;
            DisableQuestDisplayAndTimerAndPlayer();
            DisplayFinishedLevelText();
            EnableReset();
        }
    }

    private void DisableQuestDisplayAndTimerAndPlayer()
    {
        DisableQuestDisplay();
        DisableTimerDisplay();
        DisablePlayerController();
    }

    #endregion

    #region Public Methods

    public void AddPassedCheckpoint()
    {
        passedCheckpointsCount++;
    }

    public int GetCheckpointsSum()
    {
        return checkpointsSum;
    }
        
    public int GetPassedCheckpointsCount()
    {
        return passedCheckpointsCount;
    }
        
    public void DisableQuestDisplay()
    {
        questText.SetActive(false);
    }
        
    public void DisablePlayerController()
    {
        ballUserControlScript.enabled = false;
        ballScript.enabled = false;
    }

    public void FinishQuestAndIncreaseCurrentQuestNumber()
    {
        currentQuestNumber++;
    }
        
    public int GetCurrentQuestNumber()
    {
        return currentQuestNumber;
    }
        
    public void PerformAnnihilation()
    {
        if (!isGameOver)
        {
            isGameOver = true;
            EnableDustStorm();
            DisableQuestDisplayAndTimerAndPlayer();
            DisplayTimesUpText();
            EnableReset();
            PlayBreakDownAnimations();
        }
    }

    #endregion
    
    #endregion
}