using Avalonia;
using Avalonia.Controls;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Microsoft.EntityFrameworkCore;
using Baasssee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml.MarkupExtensions;


namespace Baasssee
{
    public partial class MainWindow : Window
    {

        private int Curentindex = 0;
        private const int pageSize = 9;

        



        public MainWindow()
        {
            InitializeComponent();
           
            LoadServices();

            Nextbutton.Click += nextbutton;
            backbutton.Click += Backbutton;

        }

        private void LoadServices()
        {
            var Clients = Helper.Database.Clients.Include(x => x.GenderNavigation).Skip(Curentindex * pageSize).Take(pageSize).Select(x => new
            {


                x.Id,
                x.Lastname,
                x.Firstname,
                x.Surname,
                Code = x.GenderNavigation.Namegender,
                x.Phone,
                x.Birthday,
                x.Email,
                x.Photo,
                x.Registationdate,


            }).ToList();

            ClientsListBox.ItemsSource = Clients;

            
        }

       
            
        private void Backbutton(object sender, RoutedEventArgs e) 
        {
            if (Curentindex > 0)
            {  
                Curentindex--;
                LoadServices();
            
            }
        
        
        
        
        }
        private void nextbutton(object sender, RoutedEventArgs e)
        {
            
            
                Curentindex++;
                LoadServices();

            




        }



    }
}