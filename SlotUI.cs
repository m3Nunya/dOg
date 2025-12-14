using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlotUI : MonoBehaviour
{
    public int slotNumber;

    [Header("UI References")]
    public RawImage previewImage;
    public TextMeshProUGUI slotText;

    [Header("Saved Slot Image")]
    public Texture savedSlotTexture;

    void Start()
    {
        RefreshSlot();
    }

    public void RefreshSlot()
    {
        SaveData data = SaveSystem.LoadGame(slotNumber);

        if (data != null)
        {
            // Show image if available
            previewImage.texture = savedSlotTexture;
            previewImage.enabled = savedSlotTexture != null;

            slotText.text = " ";
        }
        else
        {
            previewImage.enabled = false;
            slotText.text = "EMPTY SLOT";
        }
    }
}
