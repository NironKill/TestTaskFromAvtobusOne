﻿using Microsoft.AspNetCore.Mvc;
using ShorteningLink.Models;
using System.Diagnostics;

namespace ShorteningLink.Controllers
{
    public class ErrorController : Controller
    {
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
