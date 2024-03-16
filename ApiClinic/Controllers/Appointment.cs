// using ApiClinic.Models;
// using Microsoft.AspNetCore.Mvc;

// [Route("api/[controller]")]
// [ApiController]
// public class AppointmentController : ControllerBase
// {
//     private readonly ApplicationDbContext _context;

//     public AppointmentController(ApplicationDbContext context)
//     {
//         _context = context;
//     }

//     [HttpGet("appointments")]
//     public async Task<ActionResult<List<Appointment>>> GetAppointments()
//     {
//         try
//         {
//             var appointments = await _context.Appointments.ToListAsync();

//             return Ok(appointments);
//         }
//         catch (Exception)
//         {
//             return StatusCode(500, "An error occurred while processing the request.");
//         }
//     }


//     [HttpPost("PostAppointments")]
//     public async Task<ActionResult<List<Appointment>>> PosAppointment([FromBody] Appointment model)
//     {
//         try
//         {
//             if (model.DoctorId == null)
//                 return BadRequest("It is not possible to record a consultation without a doctor");

//             if (model.PatientId == null)
//                 return BadRequest("It is not possible to record a consultation without a patient");

//             if (!await CheckExistingDoctor(model.DoctorId))
//                 return BadRequest($"Unable to find Doctor with ID {model.DoctorId}");

//             if (!await CheckExistingDoctor(model.PatientId))
//                 return BadRequest($"Unable to find Patient with ID {model.PatientId}");

//             var newAppointment = new Appointment
//             {
//                 PatientId = model.PatientId,
//                 DoctorId = model.DoctorId,
//                 AppointmentDate = model.AppointmentDate,
//                 AppointmentType = model.AppointmentType,
//                 AppointmentStatus = model.AppointmentStatus,
//                 Value = model.Value,
//                 Diagnosis = model.Diagnosis,
//                 Prescription = model.Prescription
//             };

//             _context.Appointments.Add(newAppointment);
//             await _context.SaveChangesAsync();

//             return Ok(newAppointment);

//         }
//         catch (Exception)
//         {
//             throw;
//         }
//     }

//     [HttpPut("PutAppointment{id:int}")]

//     public async Task<ActionResult<List<Appointment>>> PutAppointment(int id, [FromBody] Appointment model)
//     {

//         try
//         {
//             var appointment = await _context.Appointments.FindAsync(id);
//             if (appointment == null)
//                 return BadRequest($"Unable to find appointment with {id}");

//             if (model.DoctorId == null)
//                 return BadRequest($"It is not possible to record a consultation without a doctor {id}");

//             if (model.PatientId == null)
//                 return BadRequest($"It is not possible to record a consultation without a patient {id}");

//             if (!await CheckExistingDoctor(model.DoctorId))
//                 return BadRequest($"Unable to find Doctor with ID {model.DoctorId}");

//             if (!await CheckExistingDoctor(model.PatientId))
//                 return BadRequest($"Unable to find Patient with ID {model.PatientId}");

//             appointment.PatientId = model.PatientId;
//             appointment.DoctorId = model.DoctorId;
//             appointment.AppointmentDate = model.AppointmentDate;
//             appointment.AppointmentType = model.AppointmentType;
//             appointment.Value = model.Value;
//             appointment.Diagnosis = model.Diagnosis;
//             appointment.Prescription = model.Prescription;

//             _context.Appointments.Update(appointment);
//             await _context.SaveChangesAsync();

//             return Ok(appointment);
//         }
//         catch (Exception)
//         {
//             throw;
//         }
//     }

//     [HttpDelete("DeleteAppointiment{id:int}")]
//     public async Task<ActionResult<Appointment>> DeleteAppointiment(int id)
//     {

//         try
//         {
//             var appointment = await _context.Appointments.FindAsync(id);
//             if (appointment == null)
//                 return BadRequest($"Unable to find appointment with {id}");

//             _context.Appointments.Remove(appointment);
//             await _context.SaveChangesAsync();

//             return Ok(appointment);
//         }
//         catch (System.Exception)
//         {

//             throw;
//         }
//     }
//     private async Task<bool> CheckExistingDoctor(int Id)
//     {
//         try
//         {
//             var doctor = await _context.Doctors.FirstOrDefaultAsync(e => e.Id == Id);

//             if (doctor == null)
//                 return false;

//             return true;
//         }
//         catch (Exception)
//         {
//             return false;
//         }
//     }

//     private async Task<bool> CheckExistingPatient(int Id)
//     {
//         try
//         {
//             var patient = await _context.Patients.FirstOrDefaultAsync(e => e.Id == Id);

//             if (patient == null)
//                 return false;

//             return true;
//         }
//         catch (Exception)
//         {
//             return false;
//         }
//     }
// }