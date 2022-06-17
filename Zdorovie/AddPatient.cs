using System;

namespace Zdorovie
{
    internal class AddPatient : Uri
    {
        private ZdorovyeEntities context;

        public AddPatient(ZdorovyeEntities context)
        {
            this.context = context;
        }

        public AddPatient(ZdorovyeEntities context, Patient pacient)
        {
            this.context = context;
        }
    }
}