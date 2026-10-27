using Microsoft.Maui.Graphics;

namespace DigitalClock;

public class ClockDrawable : IDrawable
{
    public string TimeText { get; set; } = "00:00:00";

    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        //стиль часов
        canvas.StrokeColor = Colors.Green;
        canvas.StrokeSize = 8;
        canvas.StrokeLineCap = LineCap.Square;

        float digitWidth = 40;
        float digitHeight = 80;
        float spacing = 30;
        float startX = 30;
        float startY = 50;

        for (int i = 0; i < TimeText.Length; i++)
        {
            char c = TimeText[i];
            float x = startX + i * (digitWidth + spacing);

            //двоеточие
            if (c == ':')
            {
                canvas.FillColor = Colors.Green;
                canvas.FillCircle(x + digitWidth / 2, startY + digitHeight / 3, 5);
                canvas.FillCircle(x + digitWidth / 2, startY + digitHeight * 2 / 3, 5);
                continue;
            }

            //Рисуем цифру
            DrawDigit(canvas, c, x, startY, digitWidth, digitHeight);
        }
    }

    private void DrawDigit(ICanvas canvas, char digit, float x, float y, float w, float h)
    {
        float top = y;
        float mid = y + h / 2;
        float bot = y + h;
        float left = x;
        float right = x + w;

        //циферки
        if (digit == '0')
        {
            canvas.DrawLine(left, top, right, top);
            canvas.DrawLine(right, top, right, bot);
            canvas.DrawLine(right, bot, left, bot);
            canvas.DrawLine(left, bot, left, top);
        }
        else if (digit == '1')
        {
            canvas.DrawLine(right, top, right, bot);
        }
        else if (digit == '2')
        {
            canvas.DrawLine(left, top, right, top);
            canvas.DrawLine(right, top, right, mid);
            canvas.DrawLine(right, mid, left, mid);
            canvas.DrawLine(left, mid, left, bot);
            canvas.DrawLine(left, bot, right, bot);
        }
        else if (digit == '3')
        {
            canvas.DrawLine(left, top, right, top);
            canvas.DrawLine(right, top, right, bot);
            canvas.DrawLine(right, bot, left, bot);
            canvas.DrawLine(left, mid, right, mid);
        }
        else if (digit == '4')
        {
            canvas.DrawLine(left, top, left, mid);
            canvas.DrawLine(left, mid, right, mid);
            canvas.DrawLine(right, top, right, bot);
        }
        else if (digit == '5')
        {
            canvas.DrawLine(right, top, left, top);
            canvas.DrawLine(left, top, left, mid);
            canvas.DrawLine(left, mid, right, mid);
            canvas.DrawLine(right, mid, right, bot);
            canvas.DrawLine(right, bot, left, bot);
        }
        else if (digit == '6')
        {
            canvas.DrawLine(right, top, left, top);
            canvas.DrawLine(left, top, left, bot);
            canvas.DrawLine(left, bot, right, bot);
            canvas.DrawLine(right, bot, right, mid);
            canvas.DrawLine(right, mid, left, mid);
        }
        else if (digit == '7')
        {
            canvas.DrawLine(left, top, right, top);
            canvas.DrawLine(right, top, right, bot);
        }
        else if (digit == '8')
        {
            canvas.DrawLine(left, top, right, top);
            canvas.DrawLine(right, top, right, bot);
            canvas.DrawLine(right, bot, left, bot);
            canvas.DrawLine(left, bot, left, top);
            canvas.DrawLine(left, mid, right, mid);
        }
        else if (digit == '9')
        {
            canvas.DrawLine(left, mid, right, mid);
            canvas.DrawLine(right, mid, right, bot);
            canvas.DrawLine(right, bot, left, bot);
            canvas.DrawLine(left, top, left, mid);
            canvas.DrawLine(left, top, right, top);
            canvas.DrawLine(right, top, right, mid);
        }
    }
}