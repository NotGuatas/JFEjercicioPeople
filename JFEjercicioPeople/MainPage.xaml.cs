using JFEjercicioPeople.Models;
using System.Collections.Generic;


namespace JFEjercicioPeople;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    public void OnNewButtonClicked(object sender, EventArgs args)
    {
        statusMessage.Text = "";

        App.PersonRepo.AddNewPerson(newPerson.Text);
        statusMessage.Text = App.PersonRepo.StatusMessage;
    }

    public void OnGetButtonClicked(object sender, EventArgs args)
    {
        statusMessage.Text = "";

        List<JFPerson> people = App.PersonRepo.GetAllPeople();
        peopleList.ItemsSource = people;
    }
}
