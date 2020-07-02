/*************************************************************************
 *  Copyright (C), 2020-2021. All rights reserved.
 *
 *  FileName: SceneInfo.cs
 *  Author: ks   
 *  Version: 1.0.0   
 *  CreateDate: 2020-7-2
 *  File Description: Ignore.
 *************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KSwordKit.Core.ResourcesManagement
{
    /// <summary>
    /// ������Ϣ��
    /// </summary>
    public class SceneInfo : UnityEngine.Object
    {
        /// <summary>
        /// ��������
        /// </summary>
        public string SceneName { get; internal set; }
        /// <summary>
        /// ������Դ����·��
        /// </summary>
        public string SceneAssetPath { get; internal set; }
        bool _allowSceneActivation = true;
        /// <summary>
        /// һ��������Դ���غ���֮���Ƿ��������
        /// <para>Ĭ��Ϊtrue</para>
        /// </summary>
        public bool AllowSceneActivation {
            get { return _allowSceneActivation; } 
            set { _allowSceneActivation = value; }
        }
        /// <summary>
        /// ���ܵ�ͬ�� <see cref="UnityEngine.AsyncOperation.priority"/>
        /// </summary>
        public int Priority;
        /// <summary>
        /// ���������¼�
        /// <para>�ص������ĺ��壺�Ƿ񼤻���ɡ�������ȡ���������в����Ĵ�����Ϣ</para>
        /// </summary>
        public event System.Action<bool, float, string> SceneActivationEvent;
        /// <summary>
        /// ��������״̬
        /// </summary>
        /// <param name="isdone">�Ƿ����</param>
        /// <param name="progress">����</param>
        /// <param name="error">������Ϣ</param>
        internal void SceneActivationStatus(bool isdone, float progress, string error)
        {
            if (SceneActivationEvent != null)
                SceneActivationEvent(isdone, progress, error);
        }
    }

}
