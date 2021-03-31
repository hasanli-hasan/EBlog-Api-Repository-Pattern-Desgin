using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Net;
using System.Threading.Tasks;

namespace EBlogger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetIPController : ControllerBase
    {
        [HttpGet("ip")]
        public ActionResult GetIp()
        {
            //for ip address
            IPHostEntry iphostinfo = Dns.GetHostEntry(Dns.GetHostName());
            string ipAdress = Convert.ToString(iphostinfo.AddressList
                .FirstOrDefault(address => address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork));
            //For Mac -id
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = mc.GetInstances();
            string MACAdress = String.Empty;

            foreach (ManagementObject mo in moc)
            {
                if (MACAdress == string.Empty) // only return MAC address from first card
                {
                    if ((bool)mo["IPEnabled"] == true) MACAdress = mo["MacAddress"].ToString();
                }
                mo.Dispose();
            }

            MACAdress = MACAdress.Replace(":", "-");


            return Ok(MACAdress);
        }
    }
}
