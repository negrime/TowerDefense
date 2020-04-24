using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrepareStageView : MonoBehaviour
{

    [SerializeField]
    private GameObject _panel;
    
    [SerializeField]
    private Text _foundationCount;

    public void UpdateFoundationCountText(int value)
    {
        _foundationCount.text = $"Foundation count: {value}";
    }

    public void SetActivePanel(bool value)
    {
        _panel.SetActive(value);
    }
}
