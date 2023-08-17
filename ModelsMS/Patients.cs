﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD_Operations.ModelsMS
{
	[Table("patients")]
	public partial class Patients
	{
		[Column("id")]
		public int Id { get; set; }
		[Required]
		[Column("name")]
		[StringLength(255)]
		public string Name { get; set; }
		[Required]
		[Column("phone")]
		[StringLength(15)]
		public string Phone { get; set; }
		[Column("gender")]
		public int Gender { get; set; }
		[Required]
		[Column("health_condition")]
		[StringLength(255)]
		public string HealthCondition { get; set; }
		[Column("doctor_id")]
		public int DoctorId { get; set; }
		[Column("nurse_id")]
		public int NurseId { get; set; }
		[Column("created", TypeName = "datetime")]
		public DateTime Created { get; set; }

		[ForeignKey("DoctorId")]
		[InverseProperty("Patients")]
		public virtual Doctors Doctor { get; set; }
		[ForeignKey("NurseId")]
		[InverseProperty("Patients")]
		public virtual Nurses Nurse { get; set; }
	}
}
