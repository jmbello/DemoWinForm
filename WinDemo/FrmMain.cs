using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinDemo
{
        
    public partial class FrmMain : Form
    {

        public enum ACCION
        {
            AGREGAR = 0,
            MODIFICAR = 1,
            ELIMINAR = 2
        }

        SqlConnection conn;

        public FrmMain()
        {
            InitializeComponent();
            string connstring = String.Format("Server={0};Database={1};Integrated Security = SSPI;",
                "localhost", "WINDEMO");
            conn = new SqlConnection(connstring);
            try
            {
                conn.Open();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            TxtNroDocumento.Text = "";
            TxtNombreApellido.Text = "";
            TxtCorreo.Text = "";
            MskFechaNacimiento.Text = "";
            TxtTelefono.Text = "";
            TxtNroDocumento.Focus();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            SetParametros(ACCION.AGREGAR);
        }

        private void SetParametros(ACCION accion)
        {
            var p = new Persona();
            p.NroDocumento = int.Parse(TxtNroDocumento.Text);
            p.NombreApellido = TxtNombreApellido.Text;
            p.Correo = TxtCorreo.Text;
            p.Telefono = TxtTelefono.Text;
            p.FechaNacimiento = MskFechaNacimiento.Text;
            if (ExecPA(accion, p) == 0)
            {
                MessageBox.Show("Operación finalizada con éxito");
            }
            else
            {
                MessageBox.Show("Ocurrió un error al operar con el registro");
            }
        }

        private int ExecPA(ACCION accion, Persona p)
        {
            if (conn.State != ConnectionState.Open)
            {
                return -1;
            }
            string nombre_pa = "";
            var varRetorno = 0;
            //var mensaje = "";
            var cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            switch (accion)
            {
                case ACCION.AGREGAR:
                    nombre_pa = "pa_alta_persona";
                    cmd.Parameters.Add(p.getNroDocumento());
                    cmd.Parameters.Add(p.getNombre());
                    cmd.Parameters.Add(p.getCorreo());
                    cmd.Parameters.Add(p.getTelefono());
                    cmd.Parameters.Add(p.getFecha());
                    break;
                case ACCION.MODIFICAR:
                    nombre_pa = "pa_modifica_persona";
                    cmd.Parameters.Add(p.getNroDocumento());
                    cmd.Parameters.Add(p.getNombre());
                    cmd.Parameters.Add(p.getCorreo());
                    cmd.Parameters.Add(p.getTelefono());
                    cmd.Parameters.Add(p.getFecha());
                    break;
                case ACCION.ELIMINAR:
                    nombre_pa = "pa_elimina_persona";
                    cmd.Parameters.Add(p.getNroDocumento());
                    break;
            }
            
            SqlParameter valorOut = new SqlParameter("@valor_retorno", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output,
                Value = 0
            };
            cmd.CommandText = nombre_pa;
            cmd.Parameters.Add(valorOut);

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("error " + ex.Message);
            }

            //varRetorno.valorRetorno = (int)valorOut.Value;
            //varRetorno.mensajeRetorno = mensajeOut.Value.ToString ();
            return varRetorno;
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            SetParametros(ACCION.MODIFICAR);
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            SetParametros(ACCION.ELIMINAR);
        }
    }
}
