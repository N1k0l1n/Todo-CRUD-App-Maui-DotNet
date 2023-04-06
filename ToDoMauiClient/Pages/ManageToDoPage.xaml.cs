using System.Diagnostics;
using ToDoMauiClient.DataServices;
using ToDoMauiClient.Models;

namespace ToDoMauiClient.Pages;

//Catch Navigation Parameters
[QueryProperty(nameof(ToDo), "ToDo")]
public partial class ManageToDoPage : ContentPage
{
    private readonly IRestDataService _dataService;
    ToDo _toDo;
    bool _isNew;

    public ToDo ToDo
    {
        get => _toDo;
        set
        {
            _isNew = IsNew(value);
            _toDo = value;
            OnPropertyChanged();
        }
    }

    public ManageToDoPage(IRestDataService dataService)
    {
        InitializeComponent();

        _dataService = dataService;
        BindingContext = this;
    }

    bool IsNew(ToDo toDo)
    {
        if (toDo.Id == 0)
            return true;
        return false;
    }



    //Event Handler for Buttons


    //Save Button
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        if (_isNew) 
        {
            Debug.WriteLine("---> Add new Item");
            await _dataService.AddToDoAsync(ToDo);
        }
        else
        {
            Debug.WriteLine("---> Update an Item");
            await _dataService.UpdateToDoAsync(ToDo);
        }

        await Shell.Current.GoToAsync("..");
    }


    //Delete Button
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        await _dataService.DeleteToDoAsync(ToDo.Id);
        //Back to were u came
        await Shell.Current.GoToAsync("..");
    }

    //Cancel Button
    async void onCancelButtonClicked(object sender, EventArgs e)
    {
        //Back to were u came
        await Shell.Current.GoToAsync("..");
    }
}