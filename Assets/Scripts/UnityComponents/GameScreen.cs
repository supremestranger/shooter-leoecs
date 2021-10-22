using TMPro;
using UnityEngine;

public class GameScreen : Screen
{
    // Для инкапсуляции мы можем даже сделать поля приватными и пометить атрибутом SerializeField, чтобы они были видны в инспекторе
    [SerializeField] private TextMeshProUGUI currentInMagazineLabel;
    [SerializeField] private TextMeshProUGUI totalAmmoLabel;

    public void SetAmmo(int current, int total)
    {
        currentInMagazineLabel.text = current.ToString();
        totalAmmoLabel.text = total.ToString();
    }
}
