public class ResultChecker
{
    public bool CheckWin(int[] slots)
    {
        if (slots.Length == 0) return false;

        int first = slots[0];
        foreach (int slot in slots)
        {
            if (slot != first) return false;
        }
        return true;
    }
}
