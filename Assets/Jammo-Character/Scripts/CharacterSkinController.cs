using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterSkinController : MonoBehaviour
{
    private Animator animator;
    private Renderer[] characterMaterials;

    public Texture2D[] albedoList;

    [ColorUsage(true, true)]
    public Color[] eyeColors;

    public enum EyePosition
    {
        normal,
        happy,
        angry,
        dead
    }

    public EyePosition eyeState;

    private void Start()
    {
        animator = GetComponent<Animator>();
        characterMaterials = GetComponentsInChildren<Renderer>();
    }

    private void Update()
    {
        if (Keyboard.current == null) return;

        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            ChangeEyeOffset(EyePosition.normal);
            ChangeAnimatorIdle("normal");
        }

        if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            ChangeEyeOffset(EyePosition.angry);
            ChangeAnimatorIdle("angry");
        }

        if (Keyboard.current.digit3Key.wasPressedThisFrame)
        {
            ChangeEyeOffset(EyePosition.happy);
            ChangeAnimatorIdle("happy");
        }

        if (Keyboard.current.digit4Key.wasPressedThisFrame)
        {
            ChangeEyeOffset(EyePosition.dead);
            ChangeAnimatorIdle("dead");
        }
    }

    private void ChangeAnimatorIdle(string trigger)
    {
        animator.SetTrigger(trigger);
    }

    private void ChangeMaterialSettings(int index)
    {
        for (int i = 0; i < characterMaterials.Length; i++)
        {
            if (characterMaterials[i].transform.CompareTag("PlayerEyes"))
            {
                characterMaterials[i].material.SetColor("_EmissionColor", eyeColors[index]);
            }
            else
            {
                characterMaterials[i].material.SetTexture("_MainTex", albedoList[index]);
            }
        }
    }

    private void ChangeEyeOffset(EyePosition pos)
    {
        Vector2 offset = Vector2.zero;

        switch (pos)
        {
            case EyePosition.normal:
                offset = new Vector2(0f, 0f);
                break;

            case EyePosition.happy:
                offset = new Vector2(0.33f, 0f);
                break;

            case EyePosition.angry:
                offset = new Vector2(0.66f, 0f);
                break;

            case EyePosition.dead:
                offset = new Vector2(0.33f, 0.66f);
                break;
        }

        for (int i = 0; i < characterMaterials.Length; i++)
        {
            if (characterMaterials[i].transform.CompareTag("PlayerEyes"))
            {
                characterMaterials[i].material.SetTextureOffset("_MainTex", offset);
            }
        }
    }
}