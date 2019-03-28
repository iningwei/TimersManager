
using System;
using System.Collections.Generic;


/// <summary>
/// 实例ID分配器
/// </summary>
public class IdAssginer
{
    private static readonly long Default_ID_Begin = 100;
    private static Dictionary<IdType, long> mIds = new Dictionary<IdType, long>();
    private static object mLock = new object();

    public enum IdType
    {
        Coroutine = 1,
        Gun = 2,
        Bullet = 3,
        BufferDrop = 4,
        Germ = 5,


        Weapon=6,
        Times=7,


        Audio = 73,
        WWW = 74,

    }

    /// <summary>
    /// 返回实例Id （线程安全）
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public static long GetID(IdType type)
    {
        lock (mLock)
        {
            long startId;
            if (!mIds.TryGetValue(type, out startId))
            {
                mIds.Add(type, Default_ID_Begin);
            }
            return (long)((((UInt64)type & 0x00000000000000FF) << 56) | ((UInt64)((mIds[type]++) & 0x00FFFFFFFFFFFFFF)));
        }

    }

}
