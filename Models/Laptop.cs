using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab3_CNPM.Models
{
    public class Laptop
    {
        public Laptop()
        {

        }

        public Laptop(string id, string name, int price, string cpu, int ram, int storage)
        {
            ID = id;
            Name = name;
            Price = price;
            CPU = cpu;
            RAM = ram;
            Storage = storage;
        }

        public string ID { get; set; }
        [Required]
        [MaxLength(128)]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
        public string CPU { get; set; }
        public int RAM { get; set; }
        public int Storage { get; set; }

    }
}