using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectPanel : MonoBehaviour
{
    [SerializeField] private Text _informationText;

    public void OnEnable()
    { 
            _informationText.text = "Name " + UIManager.Instance.activeCase.name;    
    }

}