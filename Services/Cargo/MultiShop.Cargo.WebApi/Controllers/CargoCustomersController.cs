using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomersController : ControllerBase
    {
        private readonly ICargoCustomerService _cargoCustomerService;

        public CargoCustomersController(ICargoCustomerService cargoCustomerService)
        {
            _cargoCustomerService = cargoCustomerService;
        }
        [HttpGet]
        public IActionResult CargoCustomerList()
        {
            var values = _cargoCustomerService.TGetAll();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetCargoCustomerById(int id)
        {
            var values = _cargoCustomerService.TGetById(id);
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCargoCustomer(CreateCargoCustomerDto createCargoCustomerDto)
        {
            CargoCustomer cargoCustomer = new CargoCustomer()
            {
               Address=createCargoCustomerDto.Address,
               City=createCargoCustomerDto.City,
               District=createCargoCustomerDto.District,
               Email=createCargoCustomerDto.Email,
               Name=createCargoCustomerDto.Name,
               Phone=createCargoCustomerDto.Phone,
               Surname = createCargoCustomerDto.Surname
            };
            _cargoCustomerService.TInsert(cargoCustomer);
            return Ok("Kargo müşteri ekleme başarıyla yapıldı.");
        }
        [HttpDelete]
        public IActionResult RemoveCargoCustomer(int id)
        {
            _cargoCustomerService.TDelete(id);
            return Ok("Kargo müşterisi başarıyla silindi");
        }
        

        [HttpPut]
        public IActionResult UpdateCargoCustomer(UpdateCargoCustomerDto updateCargoCustomerDto)
        {
            CargoCustomer cargoCustomer = new CargoCustomer()
            {
                Surname=updateCargoCustomerDto.Surname,
                Address=updateCargoCustomerDto.Address,
                City=updateCargoCustomerDto.City,
                Phone=updateCargoCustomerDto.Phone,
                Name=updateCargoCustomerDto.Name,
                Email=updateCargoCustomerDto.Email,
                District =updateCargoCustomerDto.District,
                CargoCustomerId = updateCargoCustomerDto.CargoCustomerId
            };
            _cargoCustomerService.TUpdate(cargoCustomer);
            return Ok("Kargo müşterisi başarıyla güncellendi.");
        }
    }
}
