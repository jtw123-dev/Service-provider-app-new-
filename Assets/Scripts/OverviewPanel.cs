
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class OverviewPanel : MonoBehaviour
{
    [SerializeField] private Text _caseNumberTitle, _nameTitle, _dateTitle, _locationTitle, _locationNotes, _photoNotes;
    [SerializeField] private RawImage _photoTaken;

    public void OnEnable()
    {
        _caseNumberTitle.text = "CASE NUMBER " + UIManager.Instance.activeCase.caseID;
        _nameTitle.text = UIManager.Instance.activeCase.name;
        _dateTitle.text = DateTime.Today.ToString();
        _locationNotes.text = "LOCATION NOTES " + UIManager.Instance.activeCase.locationNotes;

        Texture2D reconstructedImage = new Texture2D(1, 1);
        reconstructedImage.LoadImage(UIManager.Instance.activeCase.photoTaken);
        //Texture img = (Texture)reconstructedImage;


        _photoTaken.texture = (Texture) reconstructedImage;// UIManager.Instance.activeCase.photoTaken;
        _photoNotes.text = "PHOTO NOTES " + UIManager.Instance.activeCase.photoNotes;
    }

}