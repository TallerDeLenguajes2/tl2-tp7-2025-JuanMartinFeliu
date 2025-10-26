using Microsoft.AspNetCore.Mvc;
using Productos;
using productoRepository;

namespace tl2_tp7_2025_JuanMartinFeliu.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductoController : ControllerBase
{
    private ProductoRepository productoRepository;
    public ProductoController()
    {
        productoRepository = new ProductoRepository();
    }

    /*
    ● POST /api/Producto: Permite crear un nuevo Producto.
    ● PUT /api/Producto/{Id}: Permite modificar un nombre de un Producto.
    ● GET /api/Producto: Permite listar los Productos existentes.
    ● GET /api/Producto/{Id}: Obtener detalles de un Productos por su ID.
    ● DELETE /api/Producto: Eliminar un Producto por ID
    */
    [HttpPost("CrearProducto")]
    public ActionResult<string> crearProducto(Producto nuevoProd)
    {
        productoRepository.CrearProducto(nuevoProd);
        return Ok("Producto creado exitosamente");

    }

    [HttpPut("{id}")]
    public ActionResult<string> modificarProducto(Producto prod, int idProductoBuscado)
    {
        productoRepository.ModificarProductos(prod, idProductoBuscado);
        return Ok("Producto modificado exitosamente");
    }

    [HttpGet("ListarProductos")]
    public ActionResult<List<Producto>> listarProductos()
    {
        List<Producto> listita;
        listita = productoRepository.ListarProductos();
        return Ok(listita);
    }

    [HttpGet("{id}")]
    public ActionResult<Producto> ObtenerProducto(int idBuscado)
    {
        Producto produ;
        produ = productoRepository.ObtenerDetallesProducto(idBuscado);
        return Ok(produ);
    }

    [HttpDelete("{id}")]
    public ActionResult<string> Eliminar(int idBuscado)
    {
        productoRepository.EliminarProductos(idBuscado);
        return Ok("Producto eliminado exitosamente");

    }
}