using UnityEngine;

public class NPC_Trigger : MonoBehaviour
{
    [Header("NPC Chat")]
    [TextArea]
    [SerializeField] private string chatText;

    [Header("References")]
    [SerializeField] private MainScript mainScript;

    private void Awake()
    {
        if (mainScript == null)
        {
            Debug.LogError("MainScript가 연결되지 않았습니다.", this);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("myplayer")) return;

        mainScript.NPCChatEnter(chatText);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("myplayer")) return;

        mainScript.NPCChatExit();
    }
}