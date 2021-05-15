using UnityEngine;

public class LightSwitchAnimController : MonoBehaviour
{
    private Animator anim;

[SerializeField] 
    private AudioSource audioSource;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void PlayRiseLightSwitch()
    {
        PlayLightSwitchAudio();
        anim.Play("LightSwitchRise");

    }

    public void PlayButtonDescend()
    {
        anim.Play("ButtonDescend");
    }

     private void PlayLightSwitchAudio()
    {
        audioSource.PlayOneShot(audioSource.clip);
    }
}
