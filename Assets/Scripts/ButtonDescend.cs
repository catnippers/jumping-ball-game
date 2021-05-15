using UnityEngine;

public class ButtonDescend : MonoBehaviour
{
    #region Variables

    #region Private Variables

    private LightSwitchAnimController lightSwitchAnimController;
    private QuestManager questManagerScript;
    private bool buttonPressedBefore;

    #endregion

    #region Serialized Fields & Public Variables

[SerializeField] 
    private AudioSource audioSource;

    [SerializeField]
    private GameObject lightSwitchButton;
    
    [SerializeField] 
    private GameObject player;

    [SerializeField] 
    private GameObject questManager;

    #endregion

    #endregion

    #region Hooks

    private void Start()
    {
        buttonPressedBefore = false;
        lightSwitchAnimController = lightSwitchButton.GetComponent<LightSwitchAnimController>();
        questManagerScript = questManager.GetComponent<QuestManager>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player") && !buttonPressedBefore)
        {
            PlayButtonDescendAudio();
            lightSwitchAnimController.PlayButtonDescend();
            questManagerScript.FinishQuestAndIncreaseCurrentQuestNumber();
            buttonPressedBefore = true;
        }
    }
        private void PlayButtonDescendAudio()
    {
        audioSource.PlayOneShot(audioSource.clip);
    }

    #endregion
    
}