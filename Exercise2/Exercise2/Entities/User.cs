using System;

namespace Exercise2.Entities
{
    public class User : Entity<int>
    {
        public virtual string Name { get; set; }

        public virtual Uri ImageUrl { get; set; }

        public virtual UserType UserType { get; set; }
    }
}
