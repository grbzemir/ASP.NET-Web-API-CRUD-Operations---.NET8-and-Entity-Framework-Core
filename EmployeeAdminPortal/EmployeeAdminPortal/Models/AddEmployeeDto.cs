namespace EmployeeAdminPortal.Models
{
    public class AddEmployeeDto
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public string? Phone { get; set; }
        public decimal Salary { get; set; }

        //public string? Address { get; set; }
        //= string.Empty;
        //public string? City { get; set; }
        //= string.Empty;
    }
}










