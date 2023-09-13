using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace multitool.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Svipe(int x, int y) {
            Svipe(ref x, ref y);
            ViewBag.Data = $"Измененные x= {x} и y = {y}";
            return PartialView();
        }

        private void Svipe(ref int x, ref int y) {
            x = x + y;
            y = x - y;
            x = x - y;
        }

        public ActionResult Expand(string num) {
            var res = num.Reverse().ToArray();
            ViewBag.Data = $"{String.Concat(res)}";
            return PartialView("Result");
        }

        public ActionResult Hours(int h) {

            h = h % 12;

            int res = (360 / 12) * h;

            ViewBag.Data = $"Градус между часовой стелкой и минутной: {res}";

            return PartialView("Result");
        }
        
        public ActionResult Counting(int N, int X, int Y) {

            string res = "";
            int count = 0;
            for (int i = 1; i <= N; i++) {
                if (i % X == 0 && i % Y == 0) {
                    count++;
                    res += i.ToString()+" ";
                }
            }

            ViewBag.Data = $"Числа меньше {N}, которые имеют простые делители {X} и {Y}: {res}. Кол-во {count}";

            return PartialView("Result");
        }
    }
}