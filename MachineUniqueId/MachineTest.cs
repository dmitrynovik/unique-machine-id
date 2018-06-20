using System;
using NUnit.Framework;

namespace MachineUniqueId
{
    [TestFixture]
    public class MachineTest
    {
        [Test]
        public void GetName()
        {
            var name = new Machine().GetName();
            Console.WriteLine($"CPU: {name}");
            Assert.IsNotEmpty(name);
        }

        [Test]
        public void GetCpu()
        {
            var cpu = new Machine().GetCpuId();
            Console.WriteLine($"CPU: {cpu}");
            Assert.IsNotEmpty(cpu);
        }

        [Test]
        public void GetHdd()
        {
            var hdd = new Machine().GetHddId();
            Console.WriteLine($"CPU: {hdd}");
            Assert.IsNotEmpty(hdd);
        }

        [Test]
        public void GetMac()
        {
            var mac = new Machine().GetMacAddress();
            Console.WriteLine($"MAC: {mac}");
            Assert.IsNotEmpty(mac);
        }

        [Test]
        public void GetHardDriveUniqueId()
        {
            var hdd = new Machine().GetHddId();
            Console.WriteLine($"HDD: {hdd}");
            Assert.IsNotEmpty(hdd);
        }
    }
}
