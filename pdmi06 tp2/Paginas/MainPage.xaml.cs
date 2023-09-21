using System.Collections.ObjectModel;
using TP02.Paginas;
using TP02.Modelos;
using TP02.Repositorio;
using System.Threading.Tasks;

namespace TP02;

public partial class MainPage : ContentPage
{
    private readonly TaskRepository taskRepository;

    public MainPage()
    {
        InitializeComponent();

        taskRepository = new TaskRepository();
    }

    private async void OnAddTask(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new Adicionar());
    }

    private async void OnOpenDetails(object sender, EventArgs e)
    {
        if (sender is TextCell textCell && textCell.BindingContext is TaskModel task)
        {
            await Navigation.PushAsync(new Detalhes(task));
        }
    }

    protected override void OnAppearing()
    {
        listTasks.ItemsSource = new ObservableCollection<TaskModel>(taskRepository.List());
        base.OnAppearing();
    }
}