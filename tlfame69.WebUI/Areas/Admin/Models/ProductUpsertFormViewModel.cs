using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using tflame69.Models.dbo;

namespace tlfame69.WebUI.Areas.Admin.Models;

public class ProductUpsertFormViewModel
{
    public Product Product { get; set; }
    [ValidateNever]
    public IEnumerable<SelectListItem> CategorySelectOptions { get; set; }
}