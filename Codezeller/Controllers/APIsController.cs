using Codezeller.Models; // Import the models from the Codezeller application
using System.Linq; // Import LINQ to enable querying collections
using System.Web.Mvc; // Import MVC functionalities
using System.Net; // Import HTTP status codes

namespace Codezeller.Controllers
{
    public class APIsController : Controller
    {
        // Login action method
        public ActionResult Login(string email, string password)
        {
            // Initialize the database context
            codezellerEntities db = new codezellerEntities();

            // Find a user with the matching email and password
            User user = db.Users.Where(o => o.Email == email && o.password == password).FirstOrDefault();

            // If user is found
            if (user != null)
            {
                // Set user ID and name in session
                Session["id"] = user.Id;
                Session["name"] = user.FirstName;

                // Return success response
                return Json(new { code = HttpStatusCode.OK, message = "Logged in successfully" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                // Return error response if user is not found
                return Json(new { code = HttpStatusCode.InternalServerError, message = "Something went wrong, please try again" }, JsonRequestBehavior.AllowGet);
            }
        }

        // Logout action method
        public ActionResult Logout()
        {
            // Clear user ID and name from session
            Session["id"] = null;
            Session["name"] = null;

            // Redirect to the pages route
            return Redirect("/pages");
        }

        // Signup action method
        [HttpPost]
        public ActionResult Signup(string fname, string lname, string email, string password, string repassword)
        {
            // Check if the passwords match
            if (password != repassword)
                return Json(new { code = HttpStatusCode.BadRequest, message = "Passwords do not match" });

            // Initialize the database context
            codezellerEntities db = new codezellerEntities();

            // Check if a user with the same email already exists
            User user_ = db.Users.Where(o => o.Email == email).FirstOrDefault();
            if (user_ != null)
                return Json(new { code = HttpStatusCode.Conflict, message = "Email already registered" });

            // Create a new user object and set its properties
            User user = new User();
            user.Email = email;
            user.password = password;
            user.FirstName = fname;
            user.LastName = lname;

            // Add the new user to the database
            db.Users.Add(user);

            // Save changes to the database and check if successful
            if (db.SaveChanges() > 0)
            {
                // Set user ID and name in session
                Session["id"] = user.Id;
                Session["name"] = user.FirstName;

                // Return success response
                return Json(new { code = HttpStatusCode.OK });
            }
            else
            {
                // Return error response if saving changes failed
                return Json(new { code = HttpStatusCode.InternalServerError, message = "Something went wrong, please try again" });
            }
        }
    }
}
