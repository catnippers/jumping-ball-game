using UnityEngine;

public class LightStoneAnimController : MonoBehaviour
{
    private Animator anim;
    
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void PlayMainLightStoneBreakDown()
    {
        anim.Play("LightStoneBreakDown");
    }
}
