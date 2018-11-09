﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using capaEntidades;
using capaNegocio;

namespace FormJif
{
    public partial class FCredito : Form
    {
        public FCredito()
        {
            InitializeComponent();
        }
        logicaNegocioCredito lN = new logicaNegocioCredito();
        private void btnguardarcred_Click(object sender, EventArgs e)
        {
            
            try
            {
                Credito objcredito = new Credito();
                objcredito.Fecha_inicio = txtfechainicio.Text;
                objcredito.Fecha_cancelacion = txtfechacancel.Text;
                objcredito.monto_total = float.Parse(txtmonto.Text);
                objcredito.estado = txtestado.Text;

                if (lN.insertarCredito(objcredito) > 0)
                {
                    MessageBox.Show("Agregado con exito");
                    txtfechainicio.Text = "";
                    txtfechacancel.Text = "";
                    txtmonto.Text = "";
                    txtestado.Text = "";
                }
                else { MessageBox.Show("Error al agregar credito!"); }
            }
            catch 
            {
                MessageBox.Show("Errorrrrr");
            }
        }

        private void FCredito_Load(object sender, EventArgs e)
        {
            txtid.Visible = false;
            lblid.Visible = false;
            dgvcredito.DataSource = lN.ListarCredito();
        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            List<Credito> Lista = lN.BuscaCreditoDatos(txtbuscar.Text);
            dgvcredito.DataSource = Lista;
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            txtid.Visible = true;
            txtid.Enabled = false;
            lblid.Visible = true;

            txtfechainicio.Text = dgvcredito.CurrentRow.Cells["Fecha_inicio"].Value.ToString();
            txtfechacancel.Text = dgvcredito.CurrentRow.Cells["Fecha_cancelacion"].Value.ToString();
            txtmonto.Text = dgvcredito.CurrentRow.Cells["monto_total"].Value.ToString();
            txtestado.Text = dgvcredito.CurrentRow.Cells["estado"].Value.ToString();
            txtid.Text = dgvcredito.CurrentRow.Cells["id_credito"].Value.ToString();

            tabControlcredito.SelectedTab = tpdetalle;
            btnguardarcred.Text = "Actualizar";

        }

        private void btnguardarcred_Click_1(object sender, EventArgs e)
        {
            try
            {
                if(btnguardarcred.Text == "Guardar")
                {
                    Credito objcredito = new Credito();
                    objcredito.Fecha_inicio = txtfechainicio.Text;
                    objcredito.Fecha_cancelacion = txtfechacancel.Text;
                    objcredito.monto_total = float.Parse(txtmonto.Text);
                    objcredito.estado = txtestado.Text;

                    if (lN.insertarCredito(objcredito) > 0)
                    {
                        MessageBox.Show("Agregado con exito!");
                        dgvcredito.DataSource = lN.ListarCredito();
                        txtfechainicio.Text = "";
                        txtfechacancel.Text = "";
                        txtmonto.Text = "";
                        txtestado.Text = "";
                        tabControlcredito.SelectedTab = tpdetalle;
                    }
                    else { MessageBox.Show("Error al agregar credito"); }
                }
                if(btnguardarcred.Text == "Actualizar")
                {
                    Credito objcredito = new Credito();
                    objcredito.id_credito = Convert.ToInt32(txtid.Text);
                    objcredito.Fecha_inicio = txtfechainicio.Text;
                    objcredito.Fecha_cancelacion = txtfechacancel.Text;
                    objcredito.monto_total = float.Parse(txtmonto.Text);
                    objcredito.estado = txtestado.Text;

                    if (lN.EditarCredito(objcredito) > 0)
                    {
                        MessageBox.Show("Actualizado con exito!");
                        dgvcredito.DataSource = lN.ListarCredito();
                        txtfechainicio.Text = "";
                        txtfechacancel.Text = "";
                        txtmonto.Text = "";
                        txtestado.Text = "";
                        tabControlcredito.SelectedTab = tpdetalle;
                    }
                    else { MessageBox.Show("Error al actualizar credito"); }

                    btnguardarcred.Text = "Guardar";
                }
            }
            catch 
            {
                MessageBox.Show("Errorrrrr");
            }
        }
    }
}
