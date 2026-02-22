Console.WriteLine("=== Sistema de Facturacion con Control Antifraude ===");
Console.WriteLine("Seleccione el tipo de cliente");
Console.WriteLine("Estudiante(1) -- Docente(2) -- Administrativo(3) -- Externo(4)");
Console.Write("Opción: ");
int opcion = int.Parse(Console.ReadLine());

Console.Write("Monto base: ");
double montoBase = double.Parse(Console.ReadLine());

Console.WriteLine("Metodo de pago");
Console.WriteLine("Efectivo(1) -- Tarjeta(2) -- Transferencia(3)");
Console.Write("Opcion: ");
int metodoPago = int.Parse(Console.ReadLine());

Console.Write("¿Tiene cupon? (Si/No): ");
string tieneCupon = (Console.ReadLine());

string codigo = "";
if (tieneCupon == "Si")
{
    Console.Write("Ingrese codigo de cupon: ");
    codigo = Console.ReadLine();
}

Console.WriteLine("Reporte antifraude");
Console.WriteLine("Ninguno(1) -- Cupon invalido(2) -- Pagos rechazados(3)");
Console.Write("Opcion: ");
int fraude = int.Parse(Console.ReadLine());

if (montoBase <= 0)
{
    Console.WriteLine("Error: el monto tiene que ser mayor a 0");
    return;
}
else if (opcion < 1 || opcion > 4)
{
    Console.WriteLine("Error: opcion de cliente no valida");
    return;
}
else if (metodoPago < 1 || metodoPago > 3)
{
    Console.WriteLine("Error: metodo de pago no valido");
    return;
}

double porcentajeDescuento = 0;
double recargo = 0;
switch (opcion)
{
    case 1:
        if (metodoPago == 1)
        {
            porcentajeDescuento = 0.10;
        }
        else if (metodoPago == 2)
        {
            porcentajeDescuento = 0.07;
        }
        break;

    case 2:
        porcentajeDescuento = 0.05;
        break;
}

if (tieneCupon == "S" || tieneCupon == "s")
{
    if (codigo[0] == 'U' || codigo[0] == 'u')
    {
        int largo = codigo.Length;
        char ultimoChar = codigo[largo - 1];

        if (ultimoChar == '0' || ultimoChar == '2' || ultimoChar == '4' || ultimoChar == '6' || ultimoChar == '8')
        {
            porcentajeDescuento = porcentajeDescuento + 0.05;
        }
    }
}

if (fraude == 2 || fraude == 3)
{
    porcentajeDescuento = 0;
    recargo = montoBase * 0.15;
    Console.WriteLine("!!! ALERTA ANTIFRAUDE: Penalizacion aplicada !!!");
}