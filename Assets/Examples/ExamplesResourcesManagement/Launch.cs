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


    void Start()
    {
        KSwordKit.Core.ResourcesManagement.ResourcesManagement.Init(ResourcesLoadingLocation)
            .OnInitializing((management, progress) =>
            {
                Debug.Log("���ڳ�ʼ��������" + progress);
            })
            .OnInitCompleted((management, error) =>
            {
                Debug.Log("��ʼ����ɣ�error = " + (string.IsNullOrEmpty(error) ? "null" : error));
                if (string.IsNullOrEmpty(error))
                {
                    Debug.Log("��ǰ��ԴCRC��" + management.ResourcePackage.CRC);
                    foreach (var r in management.ResourcePackage.AssetBundleInfos)
                    {
                        Debug.Log("��Դ����" + r.AssetBundleName + "\n·����" + r.AssetBundlePath);
                        foreach (var d in r.Dependencies)
                        {
                            Debug.Log("\t������" + d);
                        }
                        foreach (var item in r.ResourceObjects)
                        {
                            Debug.Log("\t�ڲ�����Դ����" + item.ObjectName + "\n\t\t·����" + item.ResourcePath);
                        }
                    }
                }
            });
    }
}
