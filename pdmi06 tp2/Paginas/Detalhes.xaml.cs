using System.Threading.Tasks;
using TP02.Modelos;
using TP02.Repositorio;

namespace TP02.Paginas;

public partial class Detalhes : ContentPage
{
    private TaskModel currenteTask;
    private readonly TaskRepository taskRepository;

    public Detalhes(TaskModel task)
	{
		InitializeComponent();

        currenteTask = task;
        BindingContext = task;

        taskRepository = new TaskRepository();
    }

    private async void OnEditarClick(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new Editar(currenteTask));
    }

    private async void OnExcluirClick(object sender, EventArgs e)
    {
        bool remove = await DisplayAlert("Excluir item",
                                        "Deseja realmente remover o item:\n" + currenteTask.Title,
                                        "Sim",
                                        "Não");

        if (currenteTask != null && remove)
        {
            taskRepository.Remove(currenteTask.Id);
        }

        await Navigation.PopAsync();
    }

    protected override void OnAppearing()
    {
        currenteTask = taskRepository.Get(currenteTask.Id);
        BindingContext = currenteTask;
        base.OnAppearing();
    }
}