public static class GlobalVariables
{
    // Expresiones Regulares
    public const string patronCedula = "^[EP]\\d{10}$";
    public const string formatoFecha = "dd/MM/yyyy";

    //URLs
    public const string urlHospedaje = "http://200.24.219.58/ws_gatlas/phospedaje.php";
    public const string urlAlimentacion = "http://200.24.219.58/ws_gatlas/palimentacion.php";
    public const string urlLogin = "http://200.24.219.58/ws_gatlas/plogin.php";

    //Cases Login
    public const string supervisor = "Supervisor";
    public const string hospedaje = "Hospedaje";
    public const string alimentacion = "Alimentacion";
    public const string hospedaje_alimentacion = "Hospedaje y Alimentacion";

    //Mensajes Varios
    public const string alerta = "Alerta";
    public const string cerrar = "Cerrar";
    public const string aceptar = "Aceptar";
    public const string bienvenido = "¡Bienvenido!";
    public const string error = "Error";
    public const string datos_eliminados = "Datos Eliminados";
   
    //Mensajes de error
    public const string msgRegConsumoError = "¡Error al ingresar consumo!";
    public const string msgCamposVacios = "Llena todos los campos para procesar tu registro";
    public const string msgCedulaError = "Error cédula incorrecta";
    public const string msgIncioError = "Error de inicio de sesión";
    public const string msgRolError = "El rol no es válido";
    public const string msgCredError = "Las credenciales son inválidas";

    //Mensajes de éxito
    public const string msgRegConsumoExito = "¡Ingreso de consumo correcto!";
    public const string msgInicioCorrecto = "Inicio de sesión exitoso";
    public const string msgDatosActualizadosExito = "Datos Actualizados Correctamente";

}