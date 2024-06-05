using SQLite;
using System.Diagnostics;
using System.Xml.Linq;

namespace MauiCRUDtoo
{
    [Table("Person")]
    public class Person
    {
        [PrimaryKey]
        [AutoIncrement]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Person_name")]
        public string Name { get; set; }

        [Column("PhoneNumber")]
        public string PhoneNumber { get; set; }

        [Column("email")]
        public string Email { get; set; }

        public (bool IsValid, string? ErrorMessage) Validate()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                return (false, $"{nameof(Name)} is required.");
            }
            return (true, null);
        }
    }
}
