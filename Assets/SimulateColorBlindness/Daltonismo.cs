using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Daltonismo : MonoBehaviour
{

	public enum ColorBlindnessType
	{
		NormalVision = 0,
		Protanopia = 1,
		Deuteranopia = 3,
		Tritanopia = 5,
		Achromatopsia = 7,
	}

	[SerializeField]
	public ColorBlindnessType type = ColorBlindnessType.NormalVision;
	public ColorBlindnessType colorBlindnessType
	{
		set
		{
			if (type != value)
			{
				type = value;
				UpdateMaterial();
			}
		}
		get
		{
			return type;
		}
	}

	[SerializeField]
	public KeyCode keyToCycleType = KeyCode.None;

	public Material material;

	void Start()
	{
		UpdateMaterial();
	}

	void Update()
	{
		if (keyToCycleType != KeyCode.None && Input.GetKeyDown(keyToCycleType))
			colorBlindnessType = (ColorBlindnessType)(((int)colorBlindnessType + 1) % 9);
	}

	void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (material != null)
			Graphics.Blit(source, destination, material);
	}

	private void UpdateMaterial()
	{
		if (material == null)
			return;

		switch (type)
		{
			default:
			case ColorBlindnessType.NormalVision:
				Matrix4x4 normalMatrix = Matrix4x4.identity;
				material.SetMatrix("_colorTransform", normalMatrix);
				break;
			case ColorBlindnessType.Protanopia:
				Matrix4x4 protanopiaMatrix = Matrix4x4.identity;
				protanopiaMatrix.SetColumn(0, new Vector4(0.567f, 0.433f, 0f, 0f));
				protanopiaMatrix.SetColumn(1, new Vector4(0.558f, 0.442f, 0f, 0f));
				protanopiaMatrix.SetColumn(2, new Vector4(0f, 0.242f, 0.758f, 0f));
				protanopiaMatrix.SetColumn(3, new Vector4(0f, 0f, 0f, 1f));
				material.SetMatrix("_colorTransform", protanopiaMatrix);
				break;
			case ColorBlindnessType.Tritanopia:
				Matrix4x4 tritanopiaMatrix = Matrix4x4.identity;
				tritanopiaMatrix.SetColumn(0, new Vector4(0.95f, 0.05f, 0f, 0f));
				tritanopiaMatrix.SetColumn(1, new Vector4(0f, 0.433f, 0.567f, 0f));
				tritanopiaMatrix.SetColumn(2, new Vector4(0f, 0.475f, 0.525f, 0f));
				tritanopiaMatrix.SetColumn(3, new Vector4(0f, 0f, 0f, 1f));
				material.SetMatrix("_colorTransform", tritanopiaMatrix);
				break;
			case ColorBlindnessType.Deuteranopia:
				Matrix4x4 deuteranopiaMatrix = Matrix4x4.identity;
				deuteranopiaMatrix.SetColumn(0, new Vector4(0.625f, 0.375f, 0f, 0f));
				deuteranopiaMatrix.SetColumn(1, new Vector4(0.7f, 0.3f, 0f, 0f));
				deuteranopiaMatrix.SetColumn(2, new Vector4(0f, 0.3f, 0.7f, 0f));
				deuteranopiaMatrix.SetColumn(3, new Vector4(0f, 0f, 0f, 1f));
				material.SetMatrix("_colorTransform", deuteranopiaMatrix);
				break;
			
			case ColorBlindnessType.Achromatopsia:
				Matrix4x4 achromatopsiaMatrix = Matrix4x4.identity;
				achromatopsiaMatrix.SetColumn(0, new Vector4(0.299f, 0.587f, 0.114f, 0f));
				achromatopsiaMatrix.SetColumn(1, new Vector4(0.299f, 0.587f, 0.114f, 0f));
				achromatopsiaMatrix.SetColumn(2, new Vector4(0.299f, 0.587f, 0.114f, 0f));
				achromatopsiaMatrix.SetColumn(3, new Vector4(0f, 0f, 0f, 1f));
				material.SetMatrix("_colorTransform", achromatopsiaMatrix);
				break;
		}

		Debug.Log("Currently simulating '" + type.ToString() + "'.");
	}


}
