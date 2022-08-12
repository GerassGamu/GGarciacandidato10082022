using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Materia
    {
        public int IdMateria { get; set; }

        public string Nombre { get; set; }
        public decimal Costo { get; set; }

        //Variable para llenar la lista
        public List<object> Materias { get; set; }


        //Metodos
        public static Result AddEF(Materia materia)
        {
            Result result = new Result();

            try
            {
                using (Datos.ControlEscolarEntities context = new Datos.ControlEscolarEntities())
                {
                    var query = context.MateriaAdd(materia.Nombre, materia.Costo);


                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se insertó la materia";
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
        public static Result UpdateEF(Materia materia)
        {
            Result result = new Result();
            try
            {

                using (Datos.ControlEscolarEntities context = new Datos.ControlEscolarEntities())
                {
                    var query = context.MateriaUpdate(materia.IdMateria, materia.Nombre, materia.Costo);
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se actualizó la Materia";
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

        public static Result DeleteEF(Materia materia)


        {
            Result result = new Result();
            try
            {

                using (Datos.ControlEscolarEntities context = new Datos.ControlEscolarEntities())
                {
                    var query = context.MateriaDelete(materia.IdMateria);
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se eliminó la Materia";
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


        public static Result GetAllEF()
        {
            Result result = new Result();

            try
            {
                using (Datos.ControlEscolarEntities context = new Datos.ControlEscolarEntities())
                {

                    var query = context.MateriaGetAll().ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var objMateria in query)
                        {

                            // Instancia de la Clase Materia
                            Materia materia = new Materia();
                            materia.IdMateria = objMateria.IdMateria;
                            materia.Nombre = objMateria.Nombre;
                            materia.Costo = objMateria.Costo.Value;



                            result.Objects.Add(materia);
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

        public static Result GetByIdEF(int IdMateria)
        {
            Result result = new Result();
            try
            {
                using (Datos.ControlEscolarEntities context = new Datos.ControlEscolarEntities())
                {

                    var query = context.MateriaGetById(IdMateria).FirstOrDefault();

                    result.Objects = new List<object>();

                    if (query != null)
                    {



                        //Instancia de la Clase
                        Materia materia = new Materia();
                        materia.IdMateria = query.IdMateria;
                        materia.Nombre = query.Nombre;
                        materia.Costo = query.Costo.Value;



                        /// Linea oara igualar el resultado de mi consulta
                        result.Object = materia;


                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrió un error al obtener los registros en la tabla Materia";
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




    }
}
