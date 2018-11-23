using UnityEngine;
using System.Collections;
using System.IO;

public class FileLoger : MonoBehaviour
{
    private string output = "";
    private string stack = "";
    private string path;
    private StreamWriter sw;
    public bool stackActive = false;
    

    private void Start()
    {
        path = Application.dataPath + "/StreamingAssets/Debug.txt";
        sw = new StreamWriter(path);
      
    }
    void OnEnable()
    {
        Application.logMessageReceived += HandleLog;
    }

    void OnDisable()
    {
        Application.logMessageReceived -= HandleLog;
    }

    void HandleLog(string logString, string stackTrace, LogType type)
    {
        output = logString;
        stack = stackTrace;

        
       
        sw.WriteLine("\n"+output);
        if (stackActive)
        {
            sw.WriteLine(stack);
        }
     
    }
    private void OnApplicationQuit()
    {
        sw.Close();
    }
}