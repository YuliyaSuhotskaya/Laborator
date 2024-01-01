using Laborator.Entities;
using Laborator.Extensions;
using Laborator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Collections.Specialized.BitVector32;
using Laborator.Data;



namespace Laborator.Controllers
{
    public class ProductController : Controller
    {

  //      public List<Jewelry> _jewelries;
		//public List<JewelryGroup> _jewelryGroups;
        ApplicationDbContext _context;
        int _pageSize;
        
        public ProductController(ApplicationDbContext context)
        {
            _pageSize = 3;
            _context = context;
            //SetupData();
        }

        [Route("Catalog")]
        [Route("Catalog/Page_{pageNo}")]
        public IActionResult Index(int? group, int pageNo = 1)
        {
            
            var jewelriesFiltered = _context.Jewelries
                    .Where(d => !group.HasValue || d.JewelryGroupId == group.Value);
            // Поместить список групп во ViewData
            ViewData["Groups"] = _context.JewelryGroups;

            // Получить id текущей группы и поместить в TempData
            ViewData["CurrentGroup"] = group ?? 0;

            ViewData["Categories"] = _context.JewelryGroups;

            return View(ListViewModel<Jewelry>.GetModel(jewelriesFiltered, pageNo, _pageSize));

            // var items = _jewelries
            //.Skip((pageNo - 1) * _pageSize)
            //.Take(_pageSize)
            //.ToList();
            // return View(items);
        }
        /// <summary>
        /// Инициализация списков
        /// </summary>
       
        

        private void SetupData()
        {
                 //_jewelryGroups = new List<JewelryGroup>
                 //{
                 //    new JewelryGroup {JewelryGroupId=1, GroupName="Кольца"},
                 //    new JewelryGroup {JewelryGroupId=2, GroupName="Браслеты"},
                 //    new JewelryGroup {JewelryGroupId=3, GroupName="Серьги"},
                 //    new JewelryGroup {JewelryGroupId=4, GroupName="Подвески"},
                 //    new JewelryGroup {JewelryGroupId=5, GroupName="Броши"}
                     
                 //};
                 //_jewelries = new List<Jewelry>
                 //{
                 //   new Jewelry { JewelryId = 1, JewelryName="Браслет с аметистами", Description="Великолепный", Price =200, JewelryGroupId=2, Image="Браслет_с_аметистами.jpg" },
                 //   new Jewelry { JewelryId = 2, JewelryName="Браслет с гранатами", Description="Страстный", Price =330, JewelryGroupId=2, Image="Браслет_с_гранатами.jpg" },
                 //   new Jewelry { JewelryId = 3, JewelryName="Кольцо с бриллиантом", Description="Очень дорогое", Price =635, JewelryGroupId=1, Image="Кольцо_с_бриллиантом.jpg" }, 
                 //   new Jewelry { JewelryId = 4, JewelryName="Кольцо с топазом", Description="Загадочное", Price =524, JewelryGroupId=1, Image="Кольцо_с_топазом.jpg" },
                 //   new Jewelry { JewelryId = 5, JewelryName="Серьги из золота с бриллиантами", Description="Манящие", Price =180, JewelryGroupId=3, Image="Серьги_из_золота_с_бриллиантами.jpg" },
                 //   new Jewelry { JewelryId = 6, JewelryName="Брошь с сапфирами", Description="Строгая", Price =220, JewelryGroupId=5, Image="Брошь_с_сапфирами.jpg"}
                 //};
        }
    }
}

