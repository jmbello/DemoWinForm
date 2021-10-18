using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinDemo
{
    public class Persona
    {
        private int nroDocumento;
        private string nombreApellido;
        private string correo;
        private string telefono;
        private string fecha;

        public Persona()
        {
            nroDocumento = 0;
            nombreApellido = "";
            correo = "";
            telefono = "";
            fecha = "";
        }
        public int NroDocumento
        {
            get
            {
                return this.nroDocumento;
            }
            set
            {
                this.nroDocumento = value;
            }
        }

        public string NombreApellido
        {
            get
            {
                return this.nombreApellido;
            }
            set
            {
                this.nombreApellido = value;
            }
        }

        public string Correo
        {
            get
            {
                return this.correo;
            }
            set
            {
                this.correo = value;
            }
        }

        public string Telefono
        {
            get
            {
                return this.telefono;
            }
            set
            {
                this.telefono = value;
            }
        }

        public string FechaNacimiento
        {
            get
            {
                return this.fecha;
            }
            set
            {
                this.fecha = value;
            }
        }

        public SqlParameter getNroDocumento()
        {
            SqlParameter ParamNroDocumento = new SqlParameter("@nro_documento", SqlDbType.Int)
            {
                Direction = ParameterDirection.Input,
                Value = this.nroDocumento
            };
            return ParamNroDocumento;
        }

        public SqlParameter getNombre()
        {
            SqlParameter ParamNombre = new SqlParameter("@nombre_apellido", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = this.nombreApellido
            };
            return ParamNombre;
        }

        public SqlParameter getCorreo()
        {
            SqlParameter ParamCorreo = new SqlParameter("@correo", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = this.correo
            };
            return ParamCorreo;
        }

        public SqlParameter getTelefono()
        {
            SqlParameter ParamTelefono = new SqlParameter("@telefono", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = this.telefono 
            };
            return ParamTelefono;
        }

        public SqlParameter getFecha()
        {
            SqlParameter ParamFecha = new SqlParameter("@fecha_nacimiento", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = this.fecha
            };
            return ParamFecha;
        }
    }
}
