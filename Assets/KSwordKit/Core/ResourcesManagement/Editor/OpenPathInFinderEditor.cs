/*************************************************************************
 *  Copyright (C), 2020-2021. All rights reserved.
 *
 *  FileName: OpenPathInFinderEditor.cs
 *  Author: ks   
 *  Version: 1.0.0   
 *  CreateDate: 2020-7-1
 *  File Description: Ignore.
 *************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace KSwordKit.Core.ResourcesManagement.Editor
{
    public class OpenPathInFinderEditor
    {
        [MenuItem("Assets/KSwordKit/��Դ����/����Դ������Ŀ¼��Ĭ��λ�ã�����ǰ����ƽ̨��", false, 2000)]
        [MenuItem("KSwordKit/��Դ����/����Դ������Ŀ¼��Ĭ��λ�ã�����ǰ����ƽ̨��", false, 2000)]
        public static void OpenResourcePackagePathInFinder()
        {
            try
            {
                var outputPath = BuildAssetBundlesEditor.assetBundleOutputDirectory();
                EditorUtility.RevealInFinder(outputPath);
                UnityEngine.Debug.Log(BuildAssetBundlesEditor.KSwordKitName + ": ����Դ������Ŀ¼��Ĭ��λ�ã�����ǰ����ƽ̨��-> ���! ");
            }
            catch (System.Exception e)
            {
                Debug.LogError(BuildAssetBundlesEditor.KSwordKitName + ": ִ�� `����Դ������Ŀ¼��Ĭ��λ�ã�����ǰ����ƽ̨��` ʱ���������� -> " + e.Message);
            }
        }
        [MenuItem("Assets/KSwordKit/��Դ����/����Դ������Ŀ¼��StreamingAssets������ǰ����ƽ̨��", false, 2000)]
        [MenuItem("KSwordKit/��Դ����/����Դ������Ŀ¼��StreamingAssets������ǰ����ƽ̨��", false, 2000)]
        public static void OpenResourcePackageStreamingAssetsPathInFinder()
        {
            try
            {
                var outputPath = System.IO.Path.Combine(Application.streamingAssetsPath, BuildAssetBundlesEditor.AssetBundles);
                outputPath = System.IO.Path.Combine(outputPath, EditorUserBuildSettings.activeBuildTarget.ToString());
                outputPath = System.IO.Path.Combine(outputPath, BuildAssetBundlesEditor.ResourceRootDirectoryName);

                EditorUtility.RevealInFinder(outputPath);
                UnityEngine.Debug.Log(BuildAssetBundlesEditor.KSwordKitName + ": ����Դ������Ŀ¼��StreamingAssets������ǰ����ƽ̨��-> ���! ");
            }
            catch (System.Exception e)
            {
                Debug.LogError(BuildAssetBundlesEditor.KSwordKitName + ": ִ�� `����Դ������Ŀ¼��StreamingAssets������ǰ����ƽ̨��` ʱ���������� -> " + e.Message);
            }
        }
        [MenuItem("Assets/KSwordKit/��Դ����/����Դ������Ŀ¼��PersistentDataPath������ǰ����ƽ̨��", false, 2000)]
        [MenuItem("KSwordKit/��Դ����/����Դ������Ŀ¼��PersistentDataPath������ǰ����ƽ̨��", false, 2000)]
        public static void OpenResourcePackagePersistentDataPathPathInFinder()
        {
            try
            {
                var outputPath = System.IO.Path.Combine(Application.persistentDataPath, BuildAssetBundlesEditor.AssetBundles);
                outputPath = System.IO.Path.Combine(outputPath, EditorUserBuildSettings.activeBuildTarget.ToString());
                outputPath = System.IO.Path.Combine(outputPath, BuildAssetBundlesEditor.ResourceRootDirectoryName);

                EditorUtility.RevealInFinder(outputPath);
                UnityEngine.Debug.Log(BuildAssetBundlesEditor.KSwordKitName + ": ����Դ������Ŀ¼��PersistentDataPath������ǰ����ƽ̨��-> ���! ");
            }
            catch (System.Exception e)
            {
                Debug.LogError(BuildAssetBundlesEditor.KSwordKitName + ": ִ�� `����Դ������Ŀ¼��PersistentDataPath������ǰ����ƽ̨��` ʱ���������� -> " + e.Message);
            }
        }
    }
}

