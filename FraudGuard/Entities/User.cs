using FraudGuard.Enums;

namespace FraudGuard.Entities { 
    internal class User {

        public string Name { get; private set; }
        public Guid Id { get; private set; }
        public Country UsualCountry { get; private set; }

        public User(string name, Guid id, Country usualCountry) {

            if (string.IsNullOrWhiteSpace(name) || name.Trim().Length < 3) throw new ArgumentException("Name is invalid.");

            if (id == Guid.Empty) throw new ArgumentException("User id is invalid.") ;

            if (!Enum.IsDefined(usualCountry)) throw new ArgumentException("Usual country is invalid.");

            Name = name;
            Id = id;
            UsualCountry = usualCountry;
        }
    }
}
