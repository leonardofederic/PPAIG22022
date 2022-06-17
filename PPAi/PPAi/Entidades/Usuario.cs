﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPAi.AccesoDatos;
using PPAi.Entidades;




namespace PPAi.Entidades
{
    public class Usuario
    {
        private string usuario;
        private string clave;
        private bool habilitado;

        public Usuario()
        {

        }

        public Usuario(string nombreUsuario, string password, bool habilitado)
        {
            this.usuario = nombreUsuario;
            this.clave = password;
            this.habilitado = habilitado;
        }

        public string NombreDeUsuario
        {
            get => this.usuario;
            set => this.usuario = value;
        }

        public string Password
        {
            get => clave;
            set => clave = value;
        }

        public bool Habilitar
        {
            get => habilitado;
            set => habilitado = true;
        }

        public bool Inhabilitar
        {
            get => habilitado;
            set => habilitado = false;
        }

        public bool esUsuario(string nombreUsuario)
        {
            usuario = "admin";
            clave = "admin";
            if (nombreUsuario.Equals(usuario))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Usuario obtenerPersonal()
        {
            return this;
        }
    }

}

