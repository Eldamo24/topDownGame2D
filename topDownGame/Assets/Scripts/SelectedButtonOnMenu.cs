using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectedButtonOnMenu : MonoBehaviour
{
    [SerializeField] private GameObject restartButton;
    [SerializeField] private EventSystem eventSystem;
    private void OnEnable()
    {
        eventSystem.SetSelectedGameObject(restartButton);
    }
}
