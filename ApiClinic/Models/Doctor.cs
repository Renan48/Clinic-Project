using System;
using System.Collections.Generic;

namespace ApiClinic.Models;

public partial class Doctor
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Crm { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Number { get; set; } = null!;

    public string Specialty { get; set; } = null!;

    public string OfficeHours { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Notes { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
