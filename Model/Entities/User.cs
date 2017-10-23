using Core.Interfaces;
using System;

namespace Model.Entities
{
    public class User : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
