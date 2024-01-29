namespace EmpleadosApp.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es Obligatorio")]
        [MinLength(3, ErrorMessage = "Debe ingresar minimo 3 letras")]


        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }
    }
}
