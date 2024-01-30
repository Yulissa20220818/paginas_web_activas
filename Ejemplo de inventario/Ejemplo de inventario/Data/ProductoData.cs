using System.Data.SqlClient;
using Ejemplo_de_inventario.Models;

namespace Ejemplo_de_inventario.Data
{
    public class ProductoData
    {
        string conecction = "Data Source=CDS1-PC11;Initial Catalog=inventario;Integrated Security=True";

        public IEnumerable<ProductoModel> GetAll()
        {
            List<ProductoModel> ProductoList = new List<ProductoModel>();

            using (var connection = new SqlConnection(conecction))
            {
                connection.Open();

            }

            return ProductoList;
        }
    }
}
