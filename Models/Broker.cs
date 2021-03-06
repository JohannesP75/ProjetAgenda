using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjetAgenda.Models
{
    public partial class Broker
    {
        public Broker()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int IdBroker { get; set; }
        [Display(Name ="Nom de famille")]
        public string Lastname { get; set; } = null!;
        [Display(Name = "Prénom")]
        public string Firstname { get; set; } = null!;
        [Display(Name = "Adresse email")]
        public string Mail { get; set; } = null!;
        [Display(Name = "Numéro de téléphone")]
        public string PhoneNumber { get; set; } = null!;

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
