using Microsoft.AspNetCore.Mvc;
using Presupuestos;
using presupuestosRepository;

namespace tl2_tp7_2025_JuanMartinFeliu.Controllers;

[ApiController]
[Route("[controller]")]
public class PresupuestoController : ControllerBase
{
    private PresupuestoRepository presupuestoRepository;
    public PresupuestoController()
    {
        presupuestoRepository = new PresupuestoRepository();
    }

    /*
    ● POST /api/Presupuesto: Permite crear un Presupuesto.
    ● POST /api/Presupuesto/{id}/ProductoDetalle: Permite agregar un Producto existente
    y una cantidad al presupuesto.
    ● GET /api/Presupuesto/{id}: Obtener detalles de un Presupuesto por su ID.
    ● GET /api/presupuesto: Permite listar los presupuestos existentes.
    ● DETELE /api/Presupuesto/{id}: Permite eliminar un Presupuesto.
    */

    [HttpPost("CrearPresupuesto")]
    public ActionResult<string> CrearPresupuesto(Presupuesto presup)
    {
        presupuestoRepository.CrearPresupuesto(presup);
        return Ok("Presupuesto creado exitosamente");
    }

    [HttpGet("{id}")]
    public ActionResult<Presupuesto> obtenerPresupuesto(int idBuscado)
    {
        Presupuesto presu;
        presu = presupuestoRepository.ObtenerDetallesPresupuesto(idBuscado);
        return (presu);
    }

    [HttpGet("ListarPresupuestos")]
    public ActionResult<List<Presupuesto>> listarPresupuesto()
    {
        List<Presupuesto> listita;
        listita = presupuestoRepository.ListarPresupuestos();
        return (listita);

    }

    [HttpDelete("{id}")]
    public ActionResult<string> eliminarPresupuesto(int idBuscado)
    {
        presupuestoRepository.EliminarPresupuesto(idBuscado);
        return Ok("Presupuesto eliminado exitosamente");
    }
}