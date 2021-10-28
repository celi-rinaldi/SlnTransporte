using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades.Models;
using Datos.Admin;
using System.Data;

namespace WebTransportes
{
    public partial class VistaAuto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                LlenarCombosMarcas();
                MostrarDatos();
            }
        }

        private void LlenarCombosMarcas()
        {
            DataTable dt = AdmAuto.listarMarcas();
            ddlMarcas.DataSource = dt;
            ddlMarcas.DataValueField = dt.Columns["Marca"].ToString();
            ddlMarcas.DataTextField = dt.Columns["Marca"].ToString();

            DataTable buscarPorMarca = AdmAuto.listarMarcas();
            ddlBuscarPorMarca.DataSource = buscarPorMarca;
            ddlBuscarPorMarca.DataValueField = buscarPorMarca.Columns["Marca"].ToString();
            ddlBuscarPorMarca.DataTextField = buscarPorMarca.Columns["Marca"].ToString();
            DataRow fila = buscarPorMarca.NewRow();
            fila["Marca"] = 0;
            fila["Marca"] = "[TODAS]";
            buscarPorMarca.Rows.InsertAt(fila, 0);
            ddlBuscarPorMarca.DataBind();
            ddlMarcas.DataBind();
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Auto auto = new Auto()
            {
                Marca = ddlMarcas.SelectedValue.ToString(),
                Modelo = txtModelo.Text,
                Matricula = txtMatricula.Text,
                Precio = Convert.ToInt32(txtPrecio.Text)
            };
            int filasAfectadas = AdmAuto.Insertar(auto); 
            if(filasAfectadas > 0)
            {
                MostrarDatos();
            }
        }

        private void MostrarDatos()
        {
            gridAutos.DataSource = AdmAuto.Listar();
            gridAutos.DataBind(); 
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            Auto auto = new Auto()
            {
                Id = Convert.ToInt32(txtId.Text),
                Marca = ddlMarcas.SelectedValue.ToString(),
                Modelo = txtModelo.Text,
                Matricula = txtMatricula.Text,
                Precio = Convert.ToInt32(txtPrecio.Text)
            };
            int filasAfectadas = AdmAuto.Modificar(auto);
            if (filasAfectadas > 0)
            {
                MostrarDatos();
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            int filasAfectadas = AdmAuto.Eliminar(id); 
            if(filasAfectadas > 0)
            {
                MostrarDatos(); 
            }
        }

        protected void ddlBuscarPorMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            string marca = ddlBuscarPorMarca.SelectedValue.ToString(); 
            if(marca == "[TODAS]")
            {
                MostrarDatos();
            }
            else
            {
                gridAutos.DataSource = AdmAuto.Listar(marca);
                gridAutos.DataBind(); 
            }
        }
    }
}