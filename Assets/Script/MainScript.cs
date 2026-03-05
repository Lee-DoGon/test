using UnityEngine;
using TMPro;

public class MainScript : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private GameObject npcDialog;
    [SerializeField] private TMP_Text npcText;

    private void Awake()
    {
        if (npcDialog == null)
            Debug.LogError("NPCDialog가 연결되지 않았습니다.", this);

        if (npcText == null)
            Debug.LogError("NPCText(TMP)가 연결되지 않았습니다.", this);
    }

    private void Start()
    {
        npcDialog.SetActive(false);
    }

    public void NPCChatEnter(string text)
    {
        npcText.text = text;
        npcDialog.SetActive(true);
    }

    public void NPCChatExit()
    {
        npcText.text = string.Empty;
        npcDialog.SetActive(false);
    }
}