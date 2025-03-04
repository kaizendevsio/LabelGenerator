namespace LabelGenerator;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        const int newWidth = 800;
        const int newHeight = 800;

        var window = new Window(new MainPage())
        {
            Width = newWidth,
            Height = newHeight,
            Title = "ID1 Label Program"
        };

        return window;
    }
}