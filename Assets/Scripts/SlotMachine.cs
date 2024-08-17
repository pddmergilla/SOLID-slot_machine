using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlotMachine : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI slot1Text;
    [SerializeField]
    private TextMeshProUGUI slot2Text;
    [SerializeField]
    private TextMeshProUGUI slot3Text;
    [SerializeField]
    private TextMeshProUGUI resultText;
    [SerializeField]
    private Button spinButton;

    private Slot[] slots;
    private ISlotDisplay slotDisplay;
    private ResultChecker resultChecker;
    private float rollDuration = 1.0f;

    void Start()
    {
        Randomizer rng = new Randomizer();
        slots = new Slot[]
        {
            new Slot(rng),
            new Slot(rng),
            new Slot(rng)
        };
        slotDisplay = new SlotDisplay(slot1Text, slot2Text, slot3Text, resultText);
        resultChecker = new ResultChecker();

        spinButton.onClick.AddListener(() => StartCoroutine(SpinSlots()));
    }

    IEnumerator SpinSlots()
    {
        int[] results = new int[slots.Length];

        // Start the roll animation for each slot
        for (int i = 0; i < slots.Length; i++)
        {
            int slotIndex = i;
            var chuchu = slots[i].RollSlot((value) => UpdateSlotText(slotIndex, value), rollDuration);
            StartCoroutine(chuchu);
        }

        // Wait for the roll animation to complete
        yield return new WaitForSeconds(rollDuration);

        for (int i = 0; i < slots.Length; i++)
        {
            results[i] = slots[i].Spin();
        }

        slotDisplay.DisplaySlots(results);

        if (resultChecker.CheckWin(results))
        {
            slotDisplay.DisplayResult("You Win!");
        }
        else
        {
            slotDisplay.DisplayResult("Try Again!");
        }
    }

    private void UpdateSlotText(int slotIndex, int value)
    {
        switch (slotIndex)
        {
            case 0:
                slot1Text.text = value.ToString();
                break;
            case 1:
                slot2Text.text = value.ToString();
                break;
            case 2:
                slot3Text.text = value.ToString();
                break;
        }
    }
}
