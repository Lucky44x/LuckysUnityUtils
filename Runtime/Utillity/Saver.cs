using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Lucky44.Util
{
    public class Saver
    {
        public static void Save<T>(T t, string fileName)
        {
#if UNITY_EDITOR
            Debug.Log($"Saving data of type {t.GetType().Name} in {Application.persistentDataPath}/{fileName}");
#endif

            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/" + fileName;
            FileStream stream = new FileStream(path, FileMode.Create);

            formatter.Serialize(stream, t);
            stream.Close();
        }
    }

    public class Loader
    {
        public static T loadData<T>(string fileName)
        {
            string path = Application.persistentDataPath + "/" + fileName;

#if UNITY_EDITOR
            Debug.Log($"Loading data in {Application.persistentDataPath}/{fileName}");
#endif

            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);

                T data = (T)formatter.Deserialize(stream);
                stream.Close();
                return data;
            }
            else
            {
                return default;
            }
        }
    }
}
