using System.ComponentModel.DataAnnotations.Schema;

namespace MapExample.Models
{
    [Table("StoreModel",Schema ="dbo")]
    public class StoreModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public decimal Latitude { get; set; } // X eksenindeki konum (örneğin: Enlem)
        public decimal Longitude { get; set; } // Y eksenindeki konum (örneğin: Boylam)
    }
}
