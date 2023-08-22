using Microsoft.AspNetCore.Mvc;
public class ProductController: Controller
{
    private static List<Product> _items = new List<Product>
    {
        new Product { Id = 1, ProductName = "Milk", Price = 1000.99f , Company ="Amul" },
        new Product { Id = 2, ProductName = "Tea", Price = 20.49f , Company ="Tata" },
    };

    public IActionResult Index()
    {
        ViewBag.Message = TempData["Message"] as string;
        return View(_items);
    } 
    public IActionResult Create()    
    {        
        return View();
    }

    [HttpPost]
    public IActionResult Create(Product product)  
      {       
         product.Id = _items.Count + 1;
        _items.Add(product);
        TempData["Message"] ="Product Added Successfully";        
        return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)   
     {      
          Product pro = _items.FirstOrDefault(t => t.Id == id);   
          if (pro == null)
        {         
           return NotFound();
        }       
        return View(pro);
    }

    [HttpPost]
    public IActionResult Edit(Product updatedProduct)   
     {       
         Product uptask = _items.FirstOrDefault(t => t.Id == updatedProduct.Id);
         if (uptask == null)
        {
         return NotFound();
        }
        uptask.ProductName = updatedProduct.ProductName;
        uptask.Price = updatedProduct.Price;
        uptask.Company= updatedProduct.Company;
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
      Product prod = _items.FirstOrDefault(t => t.Id == id);
        if (prod == null)
        {
          return NotFound();
        }
       return View(prod);
    }


    [HttpPost]
    public IActionResult DeleteConfirmed(int id)
    {
      Product proDel = _items.FirstOrDefault(t => t.Id == id);
      if (proDel != null)
    {
      _items.Remove(proDel);
    }
    return RedirectToAction("Index");
    }
}
