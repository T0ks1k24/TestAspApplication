﻿using System.ComponentModel.DataAnnotations;

namespace EmployeeAdminPortal.Models.DTO.Employee
{
    public class AddEmployeeDto
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string? Phone { get; set; }

        public decimal Salary { get; set; }
    }
}
