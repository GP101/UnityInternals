﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// step 1
public class RuntimeGameDataManager : MonoBehaviour
{
    //static public RuntimeGameDataManager instance;
    private static int _count = 0;
    private static int _levelCount = 0;
    private static int _level = 1;
    private static bool _isWin = false;
    private static int _dataStamp = 0;

    public delegate void DataUpdatedAction();
    public static event DataUpdatedAction OnDataUpdated;
    public static int _actionDataStamp = 0;

    void Awake()
    {
        //if( instance == null )
        //    instance = this;
    }

    public static void AddCount( int c )
    {
        _count += 1;
        _levelCount += 1;
        if( _levelCount >= 3 )
        {
            _levelCount = 0;
            _level += 1;
        }
        if( _count >= 12 )
            _isWin = true;
        _UpdateDataStamp();
    }

    public static int GetCount()
    {
        return _count;
    }

    public static bool IsWin()
    {
        return _isWin;
    }

    private static void _UpdateDataStamp()
    {
        _dataStamp += 1;
        if( _dataStamp <= 0 )
            _dataStamp = 1;
    }
    public static int GetDataStamp()
    {
        return _dataStamp;
    }

    private void Update()
    {
        if( _actionDataStamp != _dataStamp )
        {
            _actionDataStamp = _dataStamp;
            if( OnDataUpdated != null )
            {
                OnDataUpdated.Invoke();
            }
        }
    }

}