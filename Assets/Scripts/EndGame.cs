using UnityEngine;

public class EndGame : MonoBehaviour
{
        [SerializeField] 
    private AudioSource audioSource;

    [SerializeField] private GameObject questManager;
    private QuestManager questManagerScript;

    private void Start()
    {
      
        questManagerScript = questManager.GetComponent<QuestManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
              PlayEndGameAudio();
            /*
            This would extend currentQuestNumber to 3 which ends the game
             */
            questManagerScript.FinishQuestAndIncreaseCurrentQuestNumber(); 
            
        }
    }
    private void PlayEndGameAudio()
{
        audioSource.PlayOneShot(audioSource.clip);
    }
}
