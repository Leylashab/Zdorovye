using System;

namespace Zdorovie
{
    internal class AddWorker : Uri
    {
        private ZdorovyeEntities context;

        public AddWorker(ZdorovyeEntities context)
        {
            this.context = context;
        }

        public AddWorker(ZdorovyeEntities context, Worker worker)
        {
            this.context = context;
        }
    }
}