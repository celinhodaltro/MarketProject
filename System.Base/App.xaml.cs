﻿using Application = Microsoft.Maui.Controls.Application;

namespace System.Base
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Microsoft.Maui.Controls.NavigationPage(new MainPage());
        }
    }


}
