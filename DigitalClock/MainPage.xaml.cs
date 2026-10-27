namespace DigitalClock;

public partial class MainPage : ContentPage
{
    private ClockDrawable _drawable;
    private IDispatcherTimer _timer;

    public MainPage()
    {
        InitializeComponent();

        //оздали объект для рисования
        _drawable = new ClockDrawable();
        ClockView.Drawable = _drawable;

        //таймер
        _timer = Dispatcher.CreateTimer();
        _timer.Interval = TimeSpan.FromSeconds(1);

        //каждый тик секунды чо надо
        _timer.Tick += (s, e) =>
        {
            _drawable.TimeText = DateTime.Now.ToString("HH:mm:ss"); //получил время
            ClockView.Invalidate(); //меняется холст
        };

        _timer.Start();
    }
}