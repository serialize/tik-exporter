using System;
using System.Collections.Generic;
using System.Configuration;
using tik4net;
using tik4net.Api;
using tik4net.Objects;
using tik4net.Objects.Ip;
using tik4net.Objects.Ip.Dns;
using tik4net.Objects.Ip.Firewall;
using tik4net.Objects.Queue;
using tik4net.Objects.System;

namespace Sez23.TikExporter.Api
{
    public class ApiQuery
    {
        ITikConnection _connection;

        public ApiQuery(ITikConnection connection)
        {
            _connection = connection;
        }

        public SystemIdentity RequestSystemIdentity()
        {
            return _connection.LoadSingle<SystemIdentity>();
        }

        public SystemResources RequestSystemResources()
        {
            return _connection.LoadSingle<SystemResources>();
        }

        public SystemRouterboard RequestSystemRouterboard()
        {
            return _connection.LoadSingle<SystemRouterboard>();
        }

        public void tempo()
        {
            using (ITikConnection connection = ConnectionFactory.CreateConnection(TikConnectionType.Api))
            {
                
                connection.Open("10.23.0.1", "TikExporter", "tikexporter");

                var ident = connection.LoadSingle<SystemIdentity>();
                var resources = connection.LoadSingle<SystemResources>();
                var routerboard = connection.LoadSingle<SystemRouterboard>();

                //ITikCommand cmd = connection.CreateCommand("/system/identity/print");
                //var identity = cmd.ExecuteScalar(); //cmd.ExecuteSIngleRow()
                //Console.WriteLine("Identity: " + /*identity.GetResponseField("name")*/ identity);


                Console.WriteLine("Press ENTER");
                Console.ReadLine();

            }

        }

    }
}
