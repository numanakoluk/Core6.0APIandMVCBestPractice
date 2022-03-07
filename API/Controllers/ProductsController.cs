using API.Filters;
using AutoMapper;
using Core.DTOs;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [ValidateFilterAttribute] //This proccess not best pratice.This's must be global(Program.cs)

    public class ProductsController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IProductService _service;

        public ProductsController(IService<Product> service, IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _service = productService;
        }

        //Get api/products/GetProductsWithCategory
        [HttpGet("GetProductsWithCategory")] //[HttpGet"[action]"]: simple
        public async Task<IActionResult> GetProductsWithCategory()
        {
            //One Code Clean
            return CreateActionResult(await _service.GetProductsWithCategory());

        }


        //Get Api/products
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var products = await _service.GetAllAsync();

            var productsDto = _mapper.Map<List<ProductDto>>(products.ToList());
            //return CustomResponseDto<List<ProductDto>>.Success(200, productsDto); Not Clean
            return CreateActionResult<List<ProductDto>>(CustomResponseDto<List<ProductDto>>.Success(200, productsDto));
        }
        //Get /Api/product/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetByIdAsyn(id);


            //Bad Process
            //if (product==null)
            //{
            //    return CreateActionResult(CustomResponseDto<ProductDto>.Fail(400, "This Id Owner Product Not Found"));

            //}

            var productsDto = _mapper.Map<ProductDto>(product);
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(200, productsDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            var product = await _service.AddAsync(_mapper.Map<Product>(productDto));

            var productsDto = _mapper.Map<ProductDto>(product);
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(201, productsDto)); //201 Create
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto productDto)
        {
            await _service.UpdateAsync(_mapper.Map<Product>(productDto));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        // api/products/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var product = await _service.GetByIdAsyn(id);

            //Not Best PRACTİCE
            //if (product==null)
            //{
            //    return CreateActionResult(CustomResponseDto<NoContentDto>.Fail(404, "This id Product Not Found"));
            //}

            await _service.RemoveAsync(product);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
