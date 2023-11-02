// Класс
using System.Drawing;

public class MyClass
{
    public Model myClass = new Model();
    public string result = "";

    public class Model
    {
        public int Width { get; set; } = 180;
        public int Height { get; set; } = 52;
    }

    public void OnValidSubmit()
    {
        var program = new Program();
        program.Run(myClass.Width, myClass.Height);
        result = program.Result;
    }

    class Program
    {
        public string Result { get; private set; }

        public void Run(int consoleWidth, int consoleHeight)
        {
            var imagePath = "wwwroot/images/whore.jpg";
            using (var bitmap = new Bitmap(imagePath))
            {
                // Вычисляем шаги для масштабирования изображения
                var scaleX = (float)bitmap.Width / consoleWidth;
                var scaleY = (float)bitmap.Height / consoleHeight;

                // Создаем пустую строку, в которую будем записывать символы
                var result = "";

                for (int y = 0; y < bitmap.Height; y += (int)(scaleY * 0.5))
                {
                    // Создаем пустую строку для текущей строки символов
                    var line = "";

                    for (int x = 0; x < bitmap.Width; x += (int)(scaleX * 1.2))
                    {
                        if (x >= bitmap.Width)
                        {
                            break; // Прерываем цикл, если достигли конца строки
                        }

                        // Получаем цвет текущего пикселя
                        var color = bitmap.GetPixel(x, y);

                        // Вычисляем яркость цвета
                        var brightness = GetBrightness(color);

                        // Получаем символ, соответствующий яркости цвета
                        var symbol = GetSymbol(brightness);

                        // Добавляем символ к текущей строке
                        line += symbol;
                    }

                    // Добавляем текущую строку к результату
                    result += line + "\n";
                }

                Result = result;
            }
        }

        private float GetBrightness(Color color)
        {
            return (color.R + color.G + color.B) / 3f / 255f;
        }

        private char GetSymbol(float brightness)
        {
            var symbols = new[] { ' ', '.', ':', '-', '=', '+', '*', '#', '%', '@' };
            var index = (int)(brightness * (symbols.Length - 1));
            return symbols[index];
        }
    }
}
