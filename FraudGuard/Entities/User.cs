using FraudGuard.Enums;

namespace FraudGuard.Entities {
    internal class User {

        public string Name { get; private set; }
        public Guid Id { get; private set; }
        public Country UsualCountry { get; private set; }

        public User(string name, Guid id, Country usualCountry) {

            ValidateName(name);
            ValidateId(id);
            ValidateCountry(usualCountry);

            Name = name;
            Id = id;
            UsualCountry = usualCountry;
        }

        private void ValidateName(string name) {
            if (string.IsNullOrWhiteSpace(name) || name.Trim().Length < 3) throw new ArgumentException("Name is invalid.");
        }
        public void UpdateName(string newName) {

            if (Name == newName) return;

            ValidateName(newName);
            Name = newName;
        }

        private void ValidateId(Guid id) {
            if (id == Guid.Empty) throw new ArgumentException("User id is invalid.");
        }

        private void ValidateCountry(Country country) {
            if (!Enum.IsDefined(typeof(Country), country)) throw new ArgumentException("User country is invalid.");
        }

        public void UpdateCountry(Country newCountry) {

            if (UsualCountry == newCountry) return;

            ValidateCountry(newCountry);
            UsualCountry = newCountry;
        }

    }
}

