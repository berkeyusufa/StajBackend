using System;

namespace BusManagement.Models
{
    public class BaseModel
    {
        private int _id; // Backing field

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public DateTime CreatedDate { get; set; }= DateTime.Now;
        public string? CreatedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
