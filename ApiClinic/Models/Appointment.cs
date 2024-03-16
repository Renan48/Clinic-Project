using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ApiClinic.Models;

[Table("Appointment")]
public partial class Appointment
{
    [Key]
    public int Id { get; set; }

    [Column("patient_Id")]
    public int PatientId { get; set; }

    [Column("doctor_Id")]
    public int DoctorId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime AppointmentDate { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string AppointmentType { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string AppointmentStatus { get; set; } = null!;

    [StringLength(3)]
    [Unicode(false)]
    public string Plano { get; set; } = null!;

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? Value { get; set; }

    [Column(TypeName = "text")]
    public string? Diagnosis { get; set; }

    [Column(TypeName = "text")]
    public string? Prescription { get; set; }

    [ForeignKey("DoctorId")]
    [InverseProperty("Appointments")]
    public virtual Doctor Doctor { get; set; } = null!;

    [ForeignKey("PatientId")]
    [InverseProperty("Appointments")]
    public virtual Patient Patient { get; set; } = null!;
}
