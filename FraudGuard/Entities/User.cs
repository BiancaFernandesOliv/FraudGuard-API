namespace FraudGuard.Entities { 
    internal class User {

        public string Name { get; private set; }
        public Guid Id { get; private set; }
        public string UsualCountry { get; private set; }

        public User(string name, Guid id, string usualCountry) {
            Name = name;
            Id = id;
            UsualCountry = usualCountry;
        }
    }
}
