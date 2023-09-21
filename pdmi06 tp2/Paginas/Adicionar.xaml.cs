using TP02.Modelos;
using TP02.Repositorio;

namespace TP02.Paginas;

public partial class Adicionar : ContentPage
{
    private readonly TaskRepository taskRepository;
	public Adicionar()
	{
		InitializeComponent();

        taskRepository = new TaskRepository();
	}

    private async void onAdd(object sender, EventArgs e)
    {
        var task = currentTask();
        
        if (task != null)
        {
            taskRepository.Add(task);
            await Navigation.PopModalAsync();
        }
    }

    private async void onCancel(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();

    }

    private TaskModel currentTask()
    {
        if (string.IsNullOrWhiteSpace(txtTitle.Text) ||
            string.IsNullOrWhiteSpace(txtDescription.Text) ||
            txtCreated.Date == null ||
            string.IsNullOrWhiteSpace(txtPriority.Text))
        {
            DisplayAlert("", "Preencha todos os campos!", "Ok");
            return null;
        }

        return new TaskModel(Guid.NewGuid(), txtTitle.Text, txtDescription.Text, txtCreated.Date, short.Parse(txtPriority.Text));
    }
}