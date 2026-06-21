using System.ComponentModel;

namespace FraudGuard.Entities { 
    internal class User {

        public string Name { get; private set; }
        public Guid Id { get; private set; }
        public string UsualCountry { get; private set; }

        public User(string name, Guid id, string usualCountry) {

            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name is invalid.");

            if (id == Guid.Empty) throw new ArgumentException("User id is invalid.") ;

            if (string.IsNullOrWhiteSpace(usualCountry)) throw new ArgumentException("Usual country is invalid.");

            Name = name;
            Id = id;
            UsualCountry = usualCountry;
        }
    }
}
