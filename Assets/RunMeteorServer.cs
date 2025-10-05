using UnityEngine;
using System.Diagnostics; // For Process
using System;             // For EventHandler

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
            // Setup the process start info
            ProcessStartInfo startInfo = new ProcessStartInfo()
            {
                FileName = "cmd.exe",
                Arguments = "/c py -m --app meteor_server run", // '/c' runs the command then exits
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };

            // Start the process
            meteorProcess = new Process();
            meteorProcess.StartInfo = startInfo;
            meteorProcess.EnableRaisingEvents = true;

            // Optional: capture output for debugging
            meteorProcess.OutputDataReceived += (sender, e) => {
                if (!string.IsNullOrEmpty(e.Data))
                    UnityEngine.Debug.Log($"[MeteorServer] {e.Data}");
            };
            meteorProcess.ErrorDataReceived += (sender, e) => {
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

    void OnApplicationQuit()
    {
        StopMeteorServer();
    }

    void OnDestroy()
    {
        StopMeteorServer();
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
}
