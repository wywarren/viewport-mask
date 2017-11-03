using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[ExecuteInEditMode]
public class PhoneMask : MonoBehaviour {
	public enum Device { IPHONE_X }
	[Header("Parameters")]
	public Device device;
	public ScreenOrientation orientation;
	public float marginSize;
	
	[Header("Visibility Toggles")]
	public bool showMask;
	public bool showZones;
	public bool showHomeBar;
	public bool showReferenceZone;
	public bool showMargins;
	
	
	[Header("Reference Objects")]
	public GameObject homeBar;
	public RectTransform mask;
	public RectTransform referenceZoneBackground;
	public RectTransform leftMargin;
	public RectTransform rightMargin;
	
	
	[Header("Zones")]
	public GameObject statusBarZone;
	public GameObject homeBarZone;
	public GameObject safeZone;
	public GameObject margins;
	public GameObject maskZone;
	public GameObject referenceZone;
	
	
	
	void Start () {
		
	}
	
	void Update () {
		UpdateOrientation();
		
		if(showMask){
			maskZone.SetActive(true);
		}
		else{
			maskZone.SetActive(false);
		}
		if(showZones){
			statusBarZone.SetActive(true);
			safeZone.SetActive(true);
			homeBarZone.SetActive(true);
		}
		else{
			statusBarZone.SetActive(false);
			safeZone.SetActive(false);
			homeBarZone.SetActive(false);
		}
		
		if(showMargins){
			margins.SetActive(true);
		}
		else{
			margins.SetActive(false);
		}
		
		if(showReferenceZone){
			referenceZone.SetActive(true);
		}
		else{
			referenceZone.SetActive(false);
		}
		if(showHomeBar){
			homeBar.SetActive(true);
		}
		else{
			homeBar.SetActive(false);
		}
		
		//match margin sizes
		leftMargin.sizeDelta = new Vector2(marginSize,0);
		rightMargin.sizeDelta = new Vector2(marginSize,0);
	}
	
	void UpdateOrientation(){
		Vector3 eulerAngle = Vector3.zero;
		switch(orientation){
		case ScreenOrientation.Portrait:
			//eulerAngle = Vector3.zero;
			break;
		case ScreenOrientation.PortraitUpsideDown:
			eulerAngle = new Vector3(0,0,180f);
			break;
		case ScreenOrientation.LandscapeRight:
			eulerAngle = new Vector3(0,0,90f);
			break;
		case ScreenOrientation.LandscapeLeft:
			eulerAngle = new Vector3(0,0,-90f);
			break;
		default:
			break;
		}
		
		mask.transform.localEulerAngles = eulerAngle;
		referenceZoneBackground.transform.localEulerAngles = eulerAngle;
	}
	
	
}
