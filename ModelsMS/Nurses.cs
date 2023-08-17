﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD_Operations.ModelsMS
{
	[Table("nurses")]
	public partial class Nurses
	{
		public Nurses()
		{
			Patients = new HashSet<Patients>();
		}

		[Column("id")]
		public int Id { get; set; }

		[Required]
		[Column("name")]
		[StringLength(255)]
		public string Name { get; set; }

		[Required]
		[Column("email")]
		[StringLength(255)]
		public string Email { get; set; }

		[Required]
		[Column("password")]
		[StringLength(255)]
		public string Password { get; set; }

		[Required]
		[Column("phone")]
		[StringLength(15)]
		public string Phone { get; set; }

		[Column("created", TypeName = "datetime")]
		public DateTime Created { get; set; }

		[InverseProperty("Nurse")]
		public virtual ICollection<Patients> Patients { get; set; }
	}
}