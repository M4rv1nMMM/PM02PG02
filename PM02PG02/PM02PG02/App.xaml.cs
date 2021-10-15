﻿using PM02PG02.Controller;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM02PG02
{
    public partial class App : Application
    {

        static DataBaseSQLite basedatos;

        public static DataBaseSQLite BaseDatos
        {
            get 
            {
                if (basedatos == null)
                {
                    basedatos = new DataBaseSQLite(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PM02.db3"));
                }
                
                return basedatos;
            }

        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
