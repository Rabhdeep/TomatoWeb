﻿using Abby.DataAccess.Repository.IRepository;
using Abby.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AbbyWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [Authorize]
        public IActionResult Get(string? status=null)
        {
            var orderHeaderList = _unitOfWork.OrderHeader.GetAll(includeProperties:"ApplicationUser");
            if(status=="cancelled")
            {
                orderHeaderList = orderHeaderList.Where(u => u.Status == SD.StatusCancelled || u.Status == SD.StatusRejected);
            }
            else
            {
                if (status == "completed")
                {
                    orderHeaderList = orderHeaderList.Where(u => u.Status == SD.StatusCompleted);
                }
                else
                {
                    if(status=="ready")
                    {
                        orderHeaderList = orderHeaderList.Where(u => u.Status == SD.StatusReady);
                    }
                    else
                    {
                        orderHeaderList = orderHeaderList.Where(u => u.Status == SD.StatusSubmitted || u.Status == SD.StatusInProcess);
                    }
                }
            }
            return Json(new { data = orderHeaderList});
        }
    }
}
