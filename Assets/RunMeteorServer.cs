using UnityEngine;
using System.Diagnostics;
using System;

public class RunMeteorServer : MonoBehaviour
{
    private Process meteorProcess;

    void Start()
    {
        StartMeteorServer();
    }

    void StartMeteorServer()
    {
        try
        {
            ProcessStartInfo startInfo = new ProcessStartInfo()
            {
                FileName = "cmd.exe",
                Arguments = "/c py \"D:\\Unity\\pesky-meteor-apocalypse\\meteor_server.py\"",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };

            meteorProcess = new Process();
            meteorProcess.StartInfo = startInfo;
            meteorProcess.EnableRaisingEvents = true;

            // Optional: log output for debugging
            meteorProcess.OutputDataReceived += (sender, e) =>
            {
                if (!string.IsNullOrEmpty(e.Data))
                    UnityEngine.Debug.Log($"[MeteorServer] {e.Data}");
            };
            meteorProcess.ErrorDataReceived += (sender, e) =>
            {
                if (!string.IsNullOrEmpty(e.Data))
                    UnityEngine.Debug.LogError($"[MeteorServer ERROR] {e.Data}");
            };

            meteorProcess.Start();
            meteorProcess.BeginOutputReadLine();
            meteorProcess.BeginErrorReadLine();

            UnityEngine.Debug.Log("Meteor server started successfully.");
        }
        catch (Exception ex)
        {
            UnityEngine.Debug.LogError($"Failed to start Meteor server: {ex.Message}");
        }
    }

    void StopMeteorServer()
    {
        if (meteorProcess != null && !meteorProcess.HasExited)
        {
            try
            {
                meteorProcess.Kill();
                meteorProcess.Dispose();
                UnityEngine.Debug.Log("Meteor server terminated.");
            }
            catch (Exception ex)
            {
                UnityEngine.Debug.LogWarning($"Error stopping Meteor server: {ex.Message}");
            }
        }
    }

    void OnApplicationQuit()
    {
        StopMeteorServer();
    }

    void OnDestroy()
    {
        StopMeteorServer();
    }
}
