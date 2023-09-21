using TP02.Modelos;
using TP02.Repositorio;

namespace TP02.Paginas;

public partial class Editar : ContentPage
{
	private TaskModel currentTask;
    private readonly TaskRepository taskRepository;
    public Editar(TaskModel task)
	{
		InitializeComponent();

		currentTask = task;
		BindingContext = task;

        taskRepository = new TaskRepository();

    }

    private async void onEdit(object sender, EventArgs e)
    {
        taskRepository.Update(currentTask.Id, currentTask);
        await Navigation.PopModalAsync();
    }

    private async void onCancel(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();

    }
}