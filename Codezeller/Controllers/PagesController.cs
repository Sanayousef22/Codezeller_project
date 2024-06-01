using Codezeller.Models; // Import the models from the Codezeller application
using System; // Import base class library support for application
using System.Collections.Generic; // Import collection generic for using list
using System.Linq; // Import LINQ to enable querying collections
using System.Web.Mvc; // Import MVC functionalities

namespace Codezeller.Controllers
{
    public class PagesController : Controller
    {
        // GET: Pages/Index
        public ActionResult Index()
        {
            // Initialize the database context
            codezellerEntities db = new codezellerEntities();

            // Get all languages from the database
            List<Languge> langs = db.Languges.ToList();

            // Get all blogs from the database
            List<Blog> blogs = db.Blogs.ToList();

            // Pass the blogs and languages to the view using ViewBag
            ViewBag.blogs = blogs;
            ViewBag.langs = langs;

            // Return the Index view
            return View();
        }

        // GET: Pages/Dashboard
        public ActionResult Dashboard()
        {
            // Initialize the database context
            codezellerEntities db = new codezellerEntities();

            // Get all languages from the database
            List<Languge> langs = db.Languges.ToList();

            // Pass the languages to the view using ViewBag
            ViewBag.langs = langs;

            // Return the Dashboard view
            return View();
        }

        // GET: Pages/Tasks/{id}
        public ActionResult Tasks(int id)
        {
            // Initialize the database context
            codezellerEntities db = new codezellerEntities();

            // Get tasks by language ID from the database
            List<task> tasks = db.tasks.Where(o => o.langugeID == id).ToList();

            // Pass the tasks to the view using ViewBag
            ViewBag.tasks = tasks;

            // Return the Tasks view
            return View();
        }

        // GET: Pages/Blogs
        public ActionResult Blogs()
        {
            // Initialize the database context
            codezellerEntities db = new codezellerEntities();

            // Get all blogs from the database
            List<Blog> blogs = db.Blogs.ToList();

            // Pass the blogs to the view using ViewBag
            ViewBag.blogs = blogs;

            // Return the Blogs view
            return View();
        }

        // GET: Pages/Content/{id}
        public ActionResult Content(int id)
        {
            // Initialize the database context
            codezellerEntities db = new codezellerEntities();

            // Get blog content by blog ID from the database
            List<BlogContent> content = db.BlogContents.Where(o => o.BlogId == id).ToList();

            // Pass the content to the view using ViewBag
            ViewBag.content = content;

            // Find the blog by ID and pass it to the view using ViewBag
            Blog blog = db.Blogs.Find(id);
            ViewBag.blog = blog;

            // Return the Content view
            return View();
        }

        // GET: Pages/Solve/{id}
        public ActionResult Solve(int id)
        {
            // Initialize the database context
            codezellerEntities db = new codezellerEntities();

            // Find the task by ID and pass it to the view using ViewBag
            task task = db.tasks.Find(id);
            ViewBag.task = task;

            // Return the Solve view
            return View();
        }

        // GET: Pages/Profile
        public ActionResult Profile()
        {
            // For demo purposes, use a static user ID
            int id = 1;

            // Initialize the database context
            codezellerEntities db = new codezellerEntities();

            // Find the user by ID and pass it to the view using ViewBag
            User user = db.Users.Find(id);
            ViewBag.user = user;

            // Return the Profile view
            return View();
        }

        // GET: Pages/Signup
        public ActionResult Signup()
        {
            // Return the Signup view
            return View();
        }

        // GET: Pages/Login
        public ActionResult Login()
        {
            // Return the Login view
            return View();
        }
    }
}
