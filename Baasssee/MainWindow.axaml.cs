using Avalonia;
using Avalonia.Controls;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Microsoft.EntityFrameworkCore;
using Baasssee.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Baasssee
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            LoadServices();
        }

        private void LoadServices()
        {
            var Clients = Helper.Database.Clients.Include(x => x.GenderNavigation);

            ClientsListBox.ItemsSource = Clients.Select(x => new
            {
                x.Id,
                x.Lastname,
                x.Firstname,
                x.Surname,
                Code = x.GenderNavigation.Namegender,
                x.Phone,
                x.Birthday,
                x.Email,
                x.Photopath,
                x.Registationdate,





            });
        }
    }
}