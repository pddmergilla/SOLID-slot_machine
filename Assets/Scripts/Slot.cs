using System.Collections;
using UnityEngine;

public class Slot
{
    private readonly Randomizer _randomizer;

    public Slot(Randomizer randomNumberGenerator)
    {
        _randomizer = randomNumberGenerator;
    }

    public int Spin()
    {
        return _randomizer.Generate();
    }

    public IEnumerator RollSlot(System.Action<int> updateSlotText, float duration)
    {
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            int randomValue = _randomizer.Generate();
            updateSlotText(randomValue);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        updateSlotText(Spin());
    }
}
