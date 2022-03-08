using Core.DTOs;
using Core.Model;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Web
{
    public class NotFoundFilter<T> : IAsyncActionFilter where T :  BaseEntity
    {
        private readonly IService<T> _service;

        public NotFoundFilter(IService<T> service)
        {
            _service = service;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var idValue = context.ActionArguments.Values.FirstOrDefault(); //take a first value

            if (idValue == null)
            {
                await next.Invoke(); //Do Continue
                return;
            }

            var id = (int)idValue;
            var anyEntity = await _service.AnyAsync(x => x.Id == id); //id control

            if (anyEntity)
            {
                await next.Invoke();
                return;
            }

            var errorViewModel = new ErrorViewModel();
            errorViewModel.Errors.Add($"{typeof(T).Name}({id}) NOT FOUND");

            context.Result = new RedirectToActionResult("Error", "Home", errorViewModel);
        }
    }
    
    
}
