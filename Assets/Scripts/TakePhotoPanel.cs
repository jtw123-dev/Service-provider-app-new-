﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakePhotoPanel : MonoBehaviour
{
    [SerializeField] RawImage _photoTaken;
    [SerializeField] InputField _notesInput;
    [SerializeField] Text _caseNumberText;
    [SerializeField] GameObject _panel;
    private string _imgPath;

    public void OnEnable()
    {
        _caseNumberText.text = "CASE NUMBER" + UIManager.Instance.activeCase.caseID;
    }

    public void TakePictureButton()
    {
        TakePicture(512);
    }

    public void ProcessInfo()
    {
        byte[] imgData = null;
        if (string.IsNullOrEmpty(_imgPath) == false)
        {
            Texture2D img = NativeCamera.LoadImageAtPath(_imgPath, 512, false);
            imgData = img.EncodeToPNG();
        }

        _caseNumberText.text = "CASE NUMBER" + UIManager.Instance.activeCase.caseID;
        UIManager.Instance.activeCase.photoTaken = imgData;
        UIManager.Instance.activeCase.photoNotes = _notesInput.text;
    }

    private void TakePicture(int maxSize)
    {
        NativeCamera.Permission permission = NativeCamera.TakePicture((path) =>
        {
            Debug.Log("Image path: " + path);
            if (path != null)
            {
                // Create a Texture2D from the captured image
                Texture2D texture = NativeCamera.LoadImageAtPath(path, maxSize, false);
                if (texture == null)
                {
                    Debug.Log("Couldn't load texture from " + path);
                    return;
                }
                _photoTaken.texture = texture;
                _photoTaken.gameObject.SetActive(true);
                _imgPath = path;
            }
        }, maxSize);

        Debug.Log("Permission result: " + permission);
    }
}
