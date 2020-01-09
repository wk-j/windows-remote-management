using System;
using System.IO;
using Naos.WinRM;

namespace WinRM {
    class Program {
        static void Main(string[] args) {
            // this is the entrypoint to interact with the system (interfaced for testing).
            var machineManager = new MachineManager(
                "192.168.33.30",
                "vagrant",
                "vagrant".ToSecureString(),
                autoManageTrustedHosts: true);

            // will perform a user initiated reboot.
            machineManager.Reboot();

            // can transfer files to AND from the remote server (over WinRM's protocol!).
            var localFilePath = @"README.md";
            var fileBytes = File.ReadAllBytes(localFilePath);
            var remoteFilePath = @"/README.md";

            machineManager.SendFile(remoteFilePath, fileBytes);
            var downloadedBytes = machineManager.RetrieveFile(remoteFilePath);
        }
    }
}
