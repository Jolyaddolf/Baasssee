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
        private const int pageSize = 10;

        



        public MainWindow()
        {
            InitializeComponent();
           
            LoadServices();

            Nextbutton.Click += nextbutton;
            backbutton.Click += Backbutton;
            SearchTextBox.TextChanged += OnSearchText;
            


        }

        private void LoadServices( string searchItem = "", string shortBy= "Firstname")

           
             
        {
            var query = Helper.Database.Clients.Include(x => x.GenderNavigation).Skip(Curentindex * pageSize).Take(pageSize).AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchItem))
            {
                query = query.Where(x => x.Firstname.Contains(searchItem) ||
                                        x.Lastname.Contains(searchItem) ||
                                        x.Surname.Contains(searchItem) ||
                                        x.Email.Contains(searchItem) ||
                                        x.Phone.Contains(searchItem));

            }

            query = shortBy switch
            {
                "Firstname" => query.OrderBy(x => x.Firstname),
                "Lastname" => query.OrderBy(x => x.Lastname),
                "Registationdate" => query.OrderBy(x => x.Registationdate),
                _=> query.OrderBy(x => x.Firstname),
            };

            ClientsListBox.ItemsSource = query.Select(x => new
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

        private void OnSearchText(object sender, TextChangedEventArgs e)
        {

            var searchItem = SearchTextBox.Text;
            LoadServices(searchItem);
        }



    }
}