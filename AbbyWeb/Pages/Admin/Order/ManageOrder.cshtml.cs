using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
using Abby.Models.ViewModel;
using Abby.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Admin.Order
{
    [Authorize(Roles =$"{SD.ManagerRole},{SD.KitchenRole}")]
    public class ManageOrderModel : PageModel
    {
        private readonly IUnitOfWork unitOfWork;
        public List<OrderDetailVM> OrderDeatilVMs { get; set; }
        public ManageOrderModel(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public void OnGet()
        {
            OrderDeatilVMs = new();
            List<OrderHeader> orderHeaders  = unitOfWork.OrderHeader.GetAll(u=>u.Status==SD.StatusSubmitted || u.Status==SD.StatusInProcess).ToList();
            foreach (OrderHeader item in orderHeaders)
            {
                OrderDetailVM orderDetailVM = new OrderDetailVM()
                {
                    OrderHeader = item,
                    OrderDetails = unitOfWork.OrderDetail.GetAll(u => u.OrderId == item.Id).ToList()
                };
                OrderDeatilVMs.Add(orderDetailVM);
            }
        }

        public IActionResult OnPostOrderInProcess(int orderId)
        {
            unitOfWork.OrderHeader.UpdateStatus(orderId, SD.StatusInProcess);
            unitOfWork.Save();
            return RedirectToPage("ManageOrder");
        }
        public IActionResult OnPostOrderReady(int orderId)
        {
            unitOfWork.OrderHeader.UpdateStatus(orderId, SD.StatusReady);
            unitOfWork.Save();
            return RedirectToPage("ManageOrder");
        }
        public IActionResult OnPostOrderCancel(int orderId)
        {
            unitOfWork.OrderHeader.UpdateStatus(orderId, SD.StatusCancelled);
            unitOfWork.Save();
            return RedirectToPage("ManageOrder");
        }
    }
}
