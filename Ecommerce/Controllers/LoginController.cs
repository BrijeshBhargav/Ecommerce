using Microsoft.AspNetCore.Mvc;
using Ecommerce.Models;
using Ecommerce.BusinessLogic_bl;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.Configuration;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.Data.SqlClient;
using MessagePack;
using static System.Reflection.Metadata.BlobBuilder;
using Microsoft.AspNetCore.Http;

namespace Ecommerce.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Home()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Home2()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Display()
        {
            return View(Ecommerce_bl.GetAllData2());
        }
        [HttpGet]
        public IActionResult products()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Products(List<IFormFile> PostedFiles, Products products)
        {
            foreach (IFormFile PostedFile in PostedFiles)
            {
                string fileName = Path.GetFileName(PostedFile.FileName);
                string type = PostedFile.ContentType;
                byte[] bytes = null;
                using (MemoryStream ms = new MemoryStream())
                {
                    PostedFile.CopyTo(ms);
                    bytes = ms.ToArray();
                }
                var dbconfig = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
                string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
                using (SqlConnection con = new SqlConnection(dbconnectionstr))
                {
                    SqlCommand cmd = new SqlCommand("sp_Ecommerceinsert", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@P_Name", products.P_Name);
                    cmd.Parameters.AddWithValue("@P_Price", Convert.ToInt32(products.P_Price));
                    cmd.Parameters.AddWithValue("@Names", fileName);
                    cmd.Parameters.AddWithValue("@ContentType", type);
                    cmd.Parameters.AddWithValue("@Data", bytes);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult dummy()
        {
            return View();
        }
    }
}
