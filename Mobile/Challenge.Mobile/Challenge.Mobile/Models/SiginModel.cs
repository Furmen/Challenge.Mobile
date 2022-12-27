using SQLite;

namespace Challenge.Mobile.Models
{
    public class SiginModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public string CreateLoginDate { get; set; }
        public string UpdateLoginDate { get; set; }
    }
}