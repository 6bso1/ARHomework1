using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PrefabCreator : MonoBehaviour
{
    [SerializeField] private GameObject butterflyPrefab;
    [SerializeField] private Vector3 prefabOffset;

    private GameObject butterfly;
    private ARTrackedImageManager aRTrackedImageManager;

    private void OnEnable()
    {
        aRTrackedImageManager = gameObject.GetComponent<ARTrackedImageManager>();
        aRTrackedImageManager.trackedImagesChanged += OnImageChanged;


    }

    private void OnImageChanged(ARTrackedImagesChangedEventArgs obj)
    {
        foreach(ARTrackedImage image in obj.added)
        {
            butterfly = Instantiate(butterflyPrefab, image.transform);
            butterfly.transform.position += prefabOffset;
        }
    }
}
