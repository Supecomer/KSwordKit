/*************************************************************************
 *  Copyright (C), 2020-2021. All rights reserved.
 *
 *  FileName: ExamplesAssetManagementTest.cs
 *  Author: ks   
 *  Version: 1.0.0   
 *  CreateDate: 6/7/2020
 *  File Description:
 *    Ignore.
 *************************************************************************/

using KSwordKit.Core;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class Launch : MonoBehaviour
{
    [Header("��Դ����λ��")]
    public KSwordKit.Core.ResourcesManagement.ResourcesLoadingLocation ResourcesLoadingLocation;

    [Header("������")]
    public GameObject ProgressPanel;
    public RectTransform ProgressParentRT;
    public Image ProgressImage;
    public Text ProgressText;

    [Header("���Լ�����Դ���")]
    public GameObject TestLoadAssetsPanel;

    void Start()
    {
        ProgressImage.rectTransform.sizeDelta = new Vector2(0, ProgressImage.rectTransform.sizeDelta.y);
        // ��ʼ��
        KSwordKit.Core.ResourcesManagement.ResourcesManagement.Init(ResourcesLoadingLocation)
            .OnInitializing
            ((management, progress) =>
            {
                Debug.Log("���ڳ�ʼ�������� -> " + progress);
                ProgressImage.rectTransform.sizeDelta = new Vector2(progress * ProgressParentRT.rect.width, ProgressImage.rectTransform.sizeDelta.y);
                ProgressText.text = "���ؽ���: " + (progress * 100).ToString("f2") + "%";
            })
            .OnInitCompleted
            ((management, error) =>
            {
                Debug.Log("��ʼ����ɣ�error = " + (string.IsNullOrEmpty(error) ? "null" : error));
                if (string.IsNullOrEmpty(error))
                {
                    Debug.Log("��ǰ��ԴCRC��" + management.ResourcePackage.CRC);
                    foreach (var r in management.ResourcePackage.AssetBundleInfos)
                    {
                        Debug.Log("��Դ����" + r.AssetBundleName + "��·����" + r.AssetBundlePath);
                        foreach (var d in r.Dependencies)
                        {
                            Debug.Log("\t��������" + d);
                        }
                        foreach (var item in r.ResourceObjects)
                        {
                            Debug.Log("\t�ڲ�����Դ����" + item.ObjectName + "\n\t\t·����" + item.ResourcePath);
                        }
                    }

                    ProgressImage.rectTransform.sizeDelta = new Vector2(0, ProgressImage.rectTransform.sizeDelta.y);
                    // ������Դ��ʵ����
                    management.LoadAssetAsync("Assets/Examples/ExamplesResourcesManagement/Resources/prefabs/loadSceneButton.prefab", (_management, isdone, progress, _error, obj) =>
                    {
                        if (isdone)
                        {
                            if (string.IsNullOrEmpty(_error))
                            {
                                Debug.Log("����Ԥ���� loadSceneButton �ɹ���" + obj.name);
                                Instantiate(obj, GameObject.Find("Canvas").transform).name = obj.name;
                            }
                            else
                                Debug.LogError("����Ԥ���� loadSceneButton ʧ�ܣ�" + _error);
                        }
                        else
                        {
                            Debug.Log("���ڼ���Ԥ���� loadSceneButton ��" + progress);
                            ProgressImage.rectTransform.sizeDelta = new Vector2(progress * ProgressParentRT.rect.width, ProgressImage.rectTransform.sizeDelta.y);
                            ProgressText.text = "���ؽ���: " + (progress*100).ToString("f2") + "%";
                        }
                    });
                    // ����һ����Դ������ֵ
                    management.LoadAssetAsync<Sprite>(new string[] {
                        "Assets/Examples/ExamplesResourcesManagement/Resources/texture/������Ϣ/������Ϣͼ��.png",
                        "Assets/Examples/ExamplesResourcesManagement/Resources/texture/������Ϣ/������Ϣ�޸�����.png",
                        "Assets/Examples/ExamplesResourcesManagement/Resources/texture/��ť/ͼ��/1.png",
                        "Assets/Examples/ExamplesResourcesManagement/Resources/texture/��ť/ͼ��/2.png",
                        "Assets/Examples/ExamplesResourcesManagement/Resources/texture/��ť/ͼ��/5.png",
                        "Assets/Examples/ExamplesResourcesManagement/Resources/texture/����/������Ч.png"
                    }, (_management, isdone, progress, _error, objs) =>
                        {
                            if (isdone)
                            {
                                if (string.IsNullOrEmpty(_error))
                                    Debug.Log("����һ����Դȫ���ɹ���" + objs.Length);
                                else
                                    Debug.LogError("����һ����Դ ʧ�ܣ�" + _error);

                                for(var i = 0; i < TestLoadAssetsPanel.transform.childCount;i++)
                                {
                                    TestLoadAssetsPanel.transform.GetChild(i).GetComponent<Image>().sprite = objs[i] as Sprite;
                                }
                            }
                            else
                            {
                                Debug.Log("���ڼ���һ����Դ��" + progress);
                                ProgressImage.rectTransform.sizeDelta = new Vector2(progress * ProgressParentRT.rect.width, ProgressImage.rectTransform.sizeDelta.y);
                                ProgressText.text = "���ؽ���: " + (progress * 100).ToString("f2") + "%";
                            }
                        });
                }
            });
    }
}
