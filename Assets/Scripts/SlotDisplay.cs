using TMPro;

public class SlotDisplay : ISlotDisplay
{
    private readonly TextMeshProUGUI _slot1Text;
    private readonly TextMeshProUGUI _slot2Text;
    private readonly TextMeshProUGUI _slot3Text;
    private readonly TextMeshProUGUI _resultText;

    public SlotDisplay(TextMeshProUGUI slot1Text, TextMeshProUGUI slot2Text, TextMeshProUGUI slot3Text, TextMeshProUGUI resultText)
    {
        _slot1Text = slot1Text;
        _slot2Text = slot2Text;
        _slot3Text = slot3Text;
        _resultText = resultText;
    }

    public void DisplaySlots(int[] slots)
    {
        _slot1Text.text = slots[0].ToString();
        _slot2Text.text = slots[1].ToString();
        _slot3Text.text = slots[2].ToString();
    }

    public void DisplayResult(string result)
    {
        _resultText.text = result;
    }
}
