namespace M_LOGITge25
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object? sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";
            Bot_Image.Rotation += 15;
            SemanticScreenReader.Announce(CounterBtn.Text);

            var random = new Random();
            var randomColor = Color.FromRgb(
                random.Next(0, 256), // Red
                random.Next(0, 256), // Green
                random.Next(0, 256)  // Blue
            );

            // Rakendame värvi teisele nupule või taustale
            ResetBtn.BackgroundColor = randomColor;



            if (count >= 5)
            {
                CounterBtn.BackgroundColor = Colors.Red;
                CounterBtn.TextColor = Colors.White;

            }

            if (count >= 10)
            {
                Cats.IsVisible = false; // Peidab pildi
                CounterLabel.Text = "Pilt kadus ära! Vajuta Reset.";
            }

            Cats.Opacity += 0.1;
            Cats.Scale += 0.1;
            CounterBtn.CornerRadius += 1;
  
        }
            // Kui loendur on 5 või rohkem, muuda nupu värvi


        private void CounterBtn1_Clicked(object sender, EventArgs e)
        {
            count--;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";
            Bot_Image.Rotation -= 15;

            SemanticScreenReader.Announce(CounterBtn.Text);

            var random = new Random();
            var randomColor = Color.FromRgb(
                random.Next(0, 256), // Red
                random.Next(0, 256), // Green
                random.Next(0, 256)  // Blue
            );

            // Rakendame värvi teisele nupule või taustale
            ResetBtn.BackgroundColor = randomColor;

            if (count <= 9)
            {
                Cats.IsVisible = true; // Peidab pildi
                CounterLabel.Text = "Pilt kadus ära! Vajuta Reset.";
            }

            Cats.Opacity -= 0.1;
            Cats.Scale -= 0.1;
            CounterBtn.CornerRadius -= 1;
        }

        private void ResetBtn_Clicked(object sender, EventArgs e)
        {
            count = 0;
            CounterBtn.Text = "Vajuta mind";
            CounterLabel.Text = "Alustame uuesti!";
            Bot_Image.Rotation = 0; // Pilt läheb otseks tagasi
            Cats.IsVisible = true;
            ResetBtn.ClearValue(BackgroundColorProperty);
            CounterBtn.ClearValue(BackgroundColorProperty);
            CounterBtn.ClearValue(Button.TextColorProperty);
            Cats.Opacity = 1;
            Cats.Scale = 1;
            CounterBtn.CornerRadius = 1;
            // Liigutame pildi paremasse serva


            // VÕI teeme loogika: kui on vasakul, liiguta paremale, ja vastupidi
            if (Cats.HorizontalOptions == LayoutOptions.Start)
            {
                Cats.HorizontalOptions = LayoutOptions.End;
            }
            else
            {
                Cats.HorizontalOptions = LayoutOptions.Start;
            }
        }
    }
}
