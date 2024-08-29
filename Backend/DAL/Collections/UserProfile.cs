using System.Collections.Generic;
using Backend.DAL.Collections;

namespace Backend.DAL.Collections
{
    public class UserProfile: Document
    {
        public IList<User> Users { get; set; }
    }
    public class User : Document
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public string City { get; set; }
        public string LocationISO { get; set; }
    }
}
