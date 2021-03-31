﻿/*
 * Created by SharpDevelop.
 * User: lextm
 * Date: 2008/8/9
 * Time: 12:24
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Net;
using System.Threading.Tasks;
using Lextm.SharpSnmpLib;
using Lextm.SharpSnmpLib.Messaging;

namespace snmpdiscover
{
    class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length != 0)
            {
                return;
            }

            DiscoverAsync().Wait();
        }

        public static async Task DiscoverAsync()
        {

            Discoverer discoverer = new Discoverer();
            discoverer.AgentFound += DiscovererAgentFound;
            Console.WriteLine("v1 discovery");
            await discoverer.DiscoverAsync(VersionCode.V1, new IPEndPoint(IPAddress.Broadcast, 161), new OctetString("public"), 6000);
            Console.WriteLine("v2 discovery");
            await discoverer.DiscoverAsync(VersionCode.V2, new IPEndPoint(IPAddress.Broadcast, 161), new OctetString("public"), 6000);
            Console.WriteLine("v3 discovery");
            await discoverer.DiscoverAsync(VersionCode.V3, new IPEndPoint(IPAddress.Broadcast, 161), null, 6000);
}

        static void DiscovererAgentFound(object sender, AgentFoundEventArgs e)
        {
            Console.WriteLine("{0} announces {1}", e.Agent, (e.Variable == null ? "it supports v3" : e.Variable.Data.ToString()));
        }
    }
}