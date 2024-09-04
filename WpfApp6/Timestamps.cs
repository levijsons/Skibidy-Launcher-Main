using System;

namespace Frost
{
    internal class Timestamps
    {
        private DateTime utcNow;

        public Timestamps(DateTime utcNow)
        {
            this.utcNow = utcNow;
        }
    }
}