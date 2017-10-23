using Core.Interfaces;

namespace Model.Entities
{
    public class Customer : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public string EmailAddress { get; set; }
    }
}
