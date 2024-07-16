using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class ToolLearnWindow : EditorWindow
{
    private bool _isShow;

    private float _waitTime = 0.20f;

    private int _currentIndex = -1;
    private static readonly string _defaultPath = "/Editor/ColveTools/ToolBag/Tools/test.txt";
    private string DefaultPath => $"{Application.dataPath}{_defaultPath}";

    private static readonly string _learnPath = $"E:\\leidian\\LDPlayer9\\zone.txt";

    [MenuItem("Tools/LearnWindow")]
    public static void ShowWindow()
    {
        GetWindow(typeof(ToolLearnWindow), false, "ToolLearnWindow");
    }

    private void Init()
    {
        if (!Application.isPlaying)
        {
            _isShow = false;
        }
        
        if (_currentIndex >= 0)
        {
            return;
        }

        if (!File.Exists(DefaultPath))
        {
            File.Create(DefaultPath);
        }

        string str = File.ReadAllText(DefaultPath);

        int.TryParse(str, out _currentIndex);

        if (_currentIndex < 0)
        {
            _currentIndex = 0;
        }
    }
    
    private void OnEnable()
    {
        EditorApplication.update += WindowUpdate;
    }
    
    private void OnDisable()
    {
        EditorApplication.update -= WindowUpdate;
    }

    private void WindowUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            _isShow = true;
            Repaint();
            _waitTime = Time.time;
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            _isShow = false;
            Repaint();
        }

        if (_waitTime > Time.time)
        {
            return;
        }

        _waitTime = Time.time + 0.2f;

        if (Input.GetKey(KeyCode.S))
        {
            if (!_isShow)
            {
                return;
            }

            if (_currentIndex < 0)
            {
                return;
            }

            _currentIndex++;
            File.WriteAllText(DefaultPath, _currentIndex.ToString());
            ChangeShowStr();
            Repaint();
        }

        if (Input.GetKey(KeyCode.W))
        {
            if (!_isShow)
            {
                return;
            }

            if (_currentIndex < 0)
            {
                return;
            }

            if (_currentIndex - 1 < 0)
            {
                return;
            }

            _currentIndex--;
            File.WriteAllText(DefaultPath, _currentIndex.ToString());
            ChangeShowStr();
            Repaint();
        }
    }

    private void OnGUI()
    {
        Init();
        
        GUILayout.BeginVertical();
        
        if (GUILayout.Button("快速执行逻辑1"))
        {

        }

        if (GUILayout.Button(GetBtnName()))
        {
            
        }
        
        if (GUILayout.Button("快速执行逻辑3"))
        {
            
        }
        
        GUILayout.EndVertical();
    }

    private string _showStr;
    
    private string GetBtnName()
    {
        if (!_isShow || !Application.isPlaying)
        {
            return "快速执行逻辑2";
        }

        return string.IsNullOrEmpty(_showStr) ? "快速执行逻辑2" : _showStr;
    }

    private void ChangeShowStr()
    {
        if (!File.Exists(_learnPath))
        {
            return;
        }

        if (string.IsNullOrEmpty(_learnStr))
        {
            _learnStr = File.ReadAllText(_learnPath);
        }

        if (_currentIndex * 10 + 10 >= _learnStr.Length)
        {
            _showStr = String.Empty;
            return;
        }

        _showStr = _learnStr.Substring(_currentIndex * 10, 10);
    }

    private string _learnStr;
}
