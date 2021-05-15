using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    #region Variables
    [SerializeField] 
    private Material emissionMaterial;

[SerializeField] 
    private AudioSource audioSource;

    private QuestManager questManagerScript;

    private bool isPassed;
    #endregion

    #region Hooks
    private void Start()
    {
        isPassed = false;
        GameObject questManager = GameObject.FindGameObjectWithTag("QuestManager");
        questManagerScript = questManager.GetComponent<QuestManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !isPassed)
        {
            SetEmissionMaterial();
            TurnOnCheckpointLight();
            questManagerScript.AddPassedCheckpoint();
            PlayCheckpointPassedAudio();

            isPassed = true;
        }
    }
    private void PlayCheckpointPassedAudio()
    {
        audioSource.PlayOneShot(audioSource.clip);
    }
    #endregion

    #region Methods
    private void SetEmissionMaterial()
    {
        GetComponent<Renderer>().material = emissionMaterial;
    }

    private void TurnOnCheckpointLight()
    {
        Light checkpointLight = GetComponentInChildren<Light>();
        checkpointLight.enabled = true;
    }
    #endregion
}
