namespace TinkoffManager
{
    public class User
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Pass { get; set; }

        public User() { }

        public User(string login, string pass)
        {
            this.Login = login;
            this.Pass = pass;
        }
    }
}
