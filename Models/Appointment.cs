﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjetAgenda.Models
{
    public partial class Appointment
    {
        public int IdAppointment { get; set; }
        [Display(Name = "Date et heure")]
        public DateTime DateHour { get; set; }
        [Display(Name = "Sujet")]
        public string Subject { get; set; } = null!;
        public int IdCustomer { get; set; }
        public int IdBroker { get; set; }

        public virtual Broker IdBrokerNavigation { get; set; } = null!;
        public virtual Customer IdCustomerNavigation { get; set; } = null!;
    }
}
