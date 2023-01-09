using AutoMapper;
using AutoMapper.QueryableExtensions;
using InventoryAppEFCore.DataLayer;
using InventoryAppEFCore.DataLayer.DTOs;
using InventoryAppEFCore.DataLayer.Profiles;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAppEFCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly InventoryAppEfCoreContext inventoryAppEfCoreContext;

        public ClientController(InventoryAppEfCoreContext inventoryAppEfCoreContext)
        {
            this.inventoryAppEfCoreContext = inventoryAppEfCoreContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            var client = inventoryAppEfCoreContext.Clients.ProjectTo<ClientDTO>(config).ToList();
            return Ok(client);
        }
    }
}
