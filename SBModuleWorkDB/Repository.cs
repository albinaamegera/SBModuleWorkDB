using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBModuleWorkDB
{
    public static class Repository
    {
        public static readonly ObservableCollection<Client> Clients;

        static Repository() => Clients = new ObservableCollection<Client>();

        public static Client GetLast()
        {
            return Clients.Count() == 0 ? null : Clients.Last();
        }
        public static void AddClient(Client client) => Clients.Add(client);
    }
}
