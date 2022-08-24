using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using System.Collections.ObjectModel;

using System.Linq;

namespace learn_100_words
{

    public sealed partial class HomePage : Page
    {

        public HomePage()
        {
            this.InitializeComponent();
        }
        private void Check_Word_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button b)
            {
                string name = b.Name;

                switch (name)
                {
                    case "WordExerciseButton":
                        WordExercise.Text = "You clicked: " + name;
                        break;
               

                }
            }
        }

        private ObservableCollection<Contact> _contacts = new ObservableCollection<Contact>();

        public ObservableCollection<Contact> Contacts
        {
            get { return this._contacts; }
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);


            Contacts.Add(new Contact("John", "Doe", "Contoso, LTD."));
            Contacts.Add(new Contact("Jane", "Doe", "Fabrikam, Inc."));
            Contacts.Add(new Contact("Santa", "Claus", "Alpine Ski House"));
        }
    }

    public class Contact
    {
        #region Properties
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Company { get; private set; }
        public string Name => FirstName + " " + LastName;
        #endregion

        public Contact(string firstName, string lastName, string company)
        {
            FirstName = firstName;
            LastName = lastName;
            Company = company;
        }

    }

}
