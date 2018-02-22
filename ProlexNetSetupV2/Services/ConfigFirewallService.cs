﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProlexNetSetupV2.Services
{
    internal class ConfigFirewallService
    {
        public static void AddRules(string serverPort)
        {
            var updaterPort = Convert.ToInt32(serverPort) + 1;
            var firebirdPort = "3050";

            RemoveRules();

            NetshAdd("ProlexNet_Firebird", "in", $"{firebirdPort}");
            NetshAdd("ProlexNet_Firebird", "out", $"{firebirdPort}");

            NetshAdd("ProlexNet", "in", $"{serverPort}");
            NetshAdd("ProlexNet", "out", $"{serverPort}");

            NetshAdd("ProlexNet_Updater", "in", $"{updaterPort}");
            NetshAdd("ProlexNet_Updater", "out", $"{updaterPort}");
        }

        public static void RemoveRules()
        {
            NetshRemove("ProlexNet_Firebird");
            NetshRemove("ProlexNet");
            NetshRemove("ProlexNet_Updater");
        }

        private static void NetshRemove(string name)
        {
            try
            {
                Process process = new Process();
                var netshArgs = $"netsh advfirewall firewall delete rule name={name}";
                process.StartInfo.FileName = "netsh";
                process.StartInfo.Arguments = netshArgs;
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.Start();
                process.WaitForExit();
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"{nameof(ConfigFirewallService)}:{nameof(NetshRemove)}:{ex.Message}");
            }
        }

        private static void NetshAdd(string name, string direction, string port)
        {
            try
            {
                Process process = new Process();
                var netshArgs = $"advfirewall firewall add rule name=\"{name}\" dir={direction} action=allow protocol=TCP localport={port}";
                process.StartInfo.FileName = "netsh";
                process.StartInfo.Arguments = netshArgs;
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.Start();
                process.WaitForExit();
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"{nameof(ConfigFirewallService)}:{nameof(NetshAdd)}:{ex.Message}");
            }
        }
    }
}