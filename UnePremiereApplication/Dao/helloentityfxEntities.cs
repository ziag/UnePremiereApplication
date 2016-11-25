using System;
using System.Data.Entity.Core.EntityClient;

namespace UnePremiereApplication
{
    internal class helloentityfxEntities : IDisposable
    {
        private EntityConnection conn;

        public helloentityfxEntities()
        {
        }

        public helloentityfxEntities(EntityConnection conn)
        {
            this.conn = conn;
        }

        public object Auteur { get; internal set; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}