using System.Linq;
using System.Management;
using System.Net.NetworkInformation;

namespace MachineUniqueId
{
    public class Machine
    {
        public string GetCpuId() => GetWmiProp("win32_processor", "processorID");
        public string GetHddId() => GetWmiProp("Win32_DiskDrive", "SerialNumber");

        public string GetMacAddress() => NetworkInterface
            .GetAllNetworkInterfaces()
            .Where(nic => nic.OperationalStatus == OperationalStatus.Up && nic.NetworkInterfaceType != NetworkInterfaceType.Loopback)
            .Select(nic => nic.GetPhysicalAddress().ToString())
            .FirstOrDefault() ?? string.Empty;

        private static string GetWmiProp(string className, string property)
        {
            var managementObjects = new ManagementClass(className).GetInstances();
            foreach (var mo in managementObjects)
            {
                //Get only the first CPU's ID
                var cpu = mo.Properties[property].Value.ToString();
                if (!string.IsNullOrWhiteSpace(cpu))
                    return cpu;
            }
            return string.Empty;
        }

        public override int GetHashCode() => (GetCpuId().GetHashCode() * 13) ^ (GetHddId().GetHashCode() * 17) ^ (GetMacAddress().GetHashCode() * 23);

        public override string ToString() => $"CPU: {GetCpuId()}, HDD: {GetHddId()}, MAC: {GetMacAddress()}";

        public override bool Equals(object obj) => obj is Machine other && other.GetMacAddress() == GetMacAddress() &&
                                                   other.GetCpuId() == GetCpuId() && other.GetHddId() == GetHddId();
    }
}
