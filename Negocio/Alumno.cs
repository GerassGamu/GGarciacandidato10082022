using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Alumno
    {
        ///Propiedades///
        public int IdAlumno { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }

        //Variable para llenar la lista
        public List<object> Alumnos { get; set; }


        ///Metodos
        public static Negocio.Result AddEF(Alumno alumno)
        {
            Result result = new Result();

            try
            {
                using (Datos.ControlEscolarEntities context = new Datos.ControlEscolarEntities())
                {
                    var query = context.AlumnoAdd(alumno.Nombre, alumno.ApellidoPaterno, alumno.ApellidoMaterno);


                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se insertó el Alumno";
                    }

                    result.Correct = true;

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }


        public static Negocio.Result UpdateEF(Alumno alumno)
        {
            Result result = new Result();
            try
            {

                using (Datos.ControlEscolarEntities context = new Datos.ControlEscolarEntities())
                {
                    var query = context.AlumnoUpdate(alumno.IdAlumno, alumno.Nombre, alumno.ApellidoPaterno, alumno.ApellidoMaterno);
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se actualizó el Alumno";
                    }
                }
            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public static Negocio.Result DeleteEF(Alumno alumno)
        {
            Result result = new Result();
            try
            {

                using (Datos.ControlEscolarEntities context = new Datos.ControlEscolarEntities())
                {
                    var query = context.AlumnoDelete(alumno.IdAlumno);
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se eliminó el Alumno";
                    }
                }
            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public static Negocio.Result GetAllEF()
        {
            Result result = new Result();

            try
            {
                using (Datos.ControlEscolarEntities context = new Datos.ControlEscolarEntities())
                {

                    var query = context.AlumnoGetAll().ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var objAlumno in query)
                        {

                            // Instancia de la Clase Alumno
                            Alumno alumno = new Alumno();

                            alumno.IdAlumno = objAlumno.IdAlumno;
                            alumno.Nombre = objAlumno.Nombre;
                            alumno.ApellidoPaterno = objAlumno.ApellidoPaterno;
                            alumno.ApellidoMaterno = objAlumno.ApellidoMaterno;





                            result.Objects.Add(alumno);
                        }

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros.";
                    }
                }
            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }

            return result;
        }

        public static Negocio.Result GetByIdEF(int IdAlumno)
        {
            Result result = new Result();
            try
            {
                using (Datos.ControlEscolarEntities context = new Datos.ControlEscolarEntities())
                {

                    var query = context.AlumnoGetById(IdAlumno).FirstOrDefault();

                    result.Objects = new List<object>();

                    if (query != null)
                    {



                        //Instancia de la Clase
                        Alumno alumno = new Alumno();
                        alumno.IdAlumno = query.IdAlumno;
                        alumno.Nombre = query.Nombre;
                        alumno.ApellidoPaterno = query.ApellidoPaterno;
                        alumno.ApellidoMaterno = query.ApellidoMaterno;


                        /// Linea oara igualar el resultado de mi consulta
                        result.Object = alumno;


                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrió un error al obtener los registros en la tabla Alumno";
                    }

                }


            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }


        public static Negocio.Result GetByNombreEF(string Nombre)
        {
            Result result = new Result();
            try
            {
                using (Datos.ControlEscolarEntities context = new Datos.ControlEscolarEntities())
                {

                    var query = context.AlumnoGetByNombre(Nombre).FirstOrDefault();

                    result.Objects = new List<object>();

                    if (query != null)
                    {



                        //Instancia de la Clase
                        Alumno alumno = new Alumno();
                        alumno.IdAlumno = query.IdAlumno;
                        alumno.Nombre = query.Nombre;
                        alumno.ApellidoPaterno = query.ApellidoPaterno;
                        alumno.ApellidoMaterno = query.ApellidoMaterno;


                        /// Linea oara igualar el resultado de mi consulta
                        result.Object = alumno;


                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrió un error al obtener los registros en la tabla Alumno";
                    }

                }


            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }


        //public static Result GetByNombreEF(string Nombre)
        //{
        //    Result result = new Result();
        //    try
        //    {
        //        using (Datos.ControlEscolarEntities context = new Datos.ControlEscolarEntities())
        //        {
        //            var usuarios = context.Usuarios.FromSqlRaw($"UsuarioGetByEmail '{Nombre}'").AsEnumerable().FirstOrDefault();

        //            // var query = context.Usuarios.FromSqlRaw($"UsuarioGetByEmail '{email}'").AsEnumerable().FirstOrDefault();

        //            result.Objects = new List<object>();

        //            if (usuarios != null)
        //            {

        //                ML.Usuario usuario = new ML.Usuario();
        //                usuario.IdUsuario = usuarios.IdUsuario;
        //                usuario.UserName = usuarios.UserName;
        //                usuario.Nombre = usuarios.Nombre;
        //                usuario.ApellidoPaterno = usuarios.ApellidoPaterno;
        //                usuario.ApellidoMaterno = usuarios.ApellidoMaterno;
        //                usuario.Email = usuarios.Email;
        //                usuario.Sexo = usuarios.Sexo;
        //                usuario.Telefono = usuarios.Telefono;
        //                usuario.Celular = usuarios.Celular;
        //                usuario.FechaNacimiento = usuarios.FechaNacimiento.Value.ToString("dd-MM-yyyy");
        //                usuario.CURP = usuarios.Curp;
        //                usuario.Imagen = usuarios.Imagen;
        //                usuario.Passwordu = usuarios.Passwordu;

        //                usuario.Rol = new ML.Rol();
        //                usuario.Rol.IdRol = usuarios.IdRol.Value;
        //                usuario.Rol.Nombre = usuarios.RolNombre;

        //                usuario.Direccion = new ML.Direccion();
        //                usuario.Direccion.IdDireccion = usuarios.IdDireccion.Value;
        //                usuario.Direccion.Calle = usuarios.Calle;
        //                usuario.Direccion.NumeroInterior = usuarios.NumeroInterior;
        //                usuario.Direccion.NumeroExterior = usuarios.NumeroExterior;

        //                usuario.Direccion.Colonia = new ML.Colonia();
        //                usuario.Direccion.Colonia.IdColonia = usuarios.IdColonia.Value;
        //                usuario.Direccion.Colonia.Nombre = usuarios.ColoniaNombre;
        //                usuario.Direccion.Colonia.CodigoPostal = usuarios.CodigoPostal;

        //                usuario.Direccion.Colonia.Municipio = new ML.Municipio();
        //                usuario.Direccion.Colonia.Municipio.IdMunicipio = usuarios.IdMunicipio.Value;
        //                usuario.Direccion.Colonia.Municipio.Nombre = usuarios.MunicipioNombre;

        //                usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
        //                usuario.Direccion.Colonia.Municipio.Estado.IdEstado = usuarios.IdEstado.Value;
        //                usuario.Direccion.Colonia.Municipio.Estado.Nombre = usuarios.EstadoNombre;

        //                usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
        //                usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais = usuarios.IdPais.Value;
        //                usuario.Direccion.Colonia.Municipio.Estado.Pais.Nombre = usuarios.PaisNombre;





        //                result.Object = usuario;


        //                result.Correct = true;
        //            }
        //            else
        //            {
        //                result.Correct = false;
        //                result.ErrorMessage = "Ocurrió un error al obtener los registros en la tabla Usuario";
        //            }

        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //        result.Ex = ex;
        //    }

        //    return result;
        //}

    }
}
