using Microsoft.AspNetCore.Mvc;

public class ImageController : Controller
{
    private readonly MyClass _myClass;

    public ImageController(MyClass myClass)
    {
        _myClass = myClass;
    }

    public IActionResult Index()
    {
        return View(_myClass);
    }
}
