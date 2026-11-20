using Microsoft.Maui.Controls.Shapes;

namespace M_LOGITge25;

public partial class FigurePage : ContentPage
{
	BoxView boxview;
	Ellipse pall;
	Polygon kolmnurk;
	Random rnd=new Random();
	HorizontalStackLayout hsl;
	List<string> nupud = new List<string>() {"Tagasi","Avaleht","Edasi" };
	VerticalStackLayout vsl;


	public FigurePage()
	{


		// teeme random 3 inti et saada random rgb värv 
		int r = rnd.Next(256);
        int g = rnd.Next(256);
        int b = rnd.Next(256);

		// teeme uue boxview default suuruste ja seadetega
		boxview = new BoxView
		{
			Color = Color.FromRgb(r, g, b),
			WidthRequest = 200,
			HeightRequest = 200,
			HorizontalOptions = LayoutOptions.Center,
			BackgroundColor = Color.FromRgba(0,0,0,0),
			CornerRadius = 30
		};

		//teeme conditioni et kui vajutada siis midagi juhtub.
		TapGestureRecognizer tap = new TapGestureRecognizer();
		boxview.GestureRecognizers.Add(tap);
		tap.Tapped += (sender, e) =>
		{
            int r = rnd.Next(256);
            int g = rnd.Next(256);
            int b = rnd.Next(256);
			boxview.Color = Color.FromRgb(r,g,b);
			boxview.WidthRequest = boxview.Width + 20; //suurendame laiust defaultist
			boxview.HeightRequest = boxview.Height + 20; // suurendame kõrgust defaultist

			//Kui ekraan on väiksem kui meie boxview siis teeb ta selle suurusel 200 x 200
			if (boxview.WidthRequest > (int)DeviceDisplay.MainDisplayInfo.Width / 3) 
			{
				boxview.WidthRequest = 200;
				boxview.HeightRequest = 200;
			}
        };

		pall = new Ellipse
		{
			WidthRequest = 200,
			HeightRequest = 200,
			Fill = new SolidColorBrush(Color.FromRgb(b , g , r)),
			Stroke = Colors.LightPink,
			StrokeThickness = 5,
			HorizontalOptions = LayoutOptions.Center,
		};
		pall.GestureRecognizers.Add(tap);

		kolmnurk = new Polygon
		{
			Points = new PointCollection
			{
				new Point(0,200),
				new Point(100,0),
				new Point(200,200)
			},
			Fill = new SolidColorBrush(Color.FromRgb(g,b,r)),
			Stroke = Colors.Aquamarine,
			StrokeThickness = 5,
			HorizontalOptions = LayoutOptions.Center,
			VerticalOptions = LayoutOptions.Center
		};
		TapGestureRecognizer tap_kolmnurk = new TapGestureRecognizer();
		tap_kolmnurk.NumberOfTapsRequired = 2;
		kolmnurk.GestureRecognizers.Add(tap_kolmnurk);
		tap_kolmnurk.Tapped += (sender, e) =>
		{
			//iga kord kui 2 korda tappida siis kaob kolnurk vaikselt ja ka muudab tausta värvi
			kolmnurk.Opacity -= 0.1;
            int r = rnd.Next(256);
            int g = rnd.Next(256);
            int b = rnd.Next(256);
			kolmnurk.BackgroundColor = Color.FromRgb(b,r,g);
        };
		hsl = new HorizontalStackLayout
		{
			Spacing = 20, HorizontalOptions = LayoutOptions.Center
		};
		for(int j = 0; j < nupud.Count;j++) 
		{
			Button nupp = new Button
			{
				Text = nupud[j],
				FontSize = 20,
				FontFamily = "Luffio",
				TextColor = Colors.Chocolate,
				BackgroundColor = Colors.Beige,
				CornerRadius = 10,
				HeightRequest = 50,
				ZIndex = j
			};
			hsl.Add(nupp);
			nupp.Clicked += Liikumine;
		}
		vsl = new VerticalStackLayout
		{
			Padding = 20,
			Spacing = 15,
			Children = {boxview, pall, kolmnurk, hsl },
			HorizontalOptions = LayoutOptions.Center
		};
		Content = vsl;
    }
    private void Liikumine(object? sender, EventArgs e)
    {
        Button nupp = sender as Button;
        if (nupp.ZIndex == 0)
        {
            Navigation.PushAsync(new TextPage());
        }
        else if (nupp.ZIndex == 1)
        {
            Navigation.PopToRootAsync();
			kolmnurk.Opacity = 100;
        }
        else if (nupp.ZIndex == 2)
        {
            Navigation.PushAsync(new FigurePage()); //siia lisame uue lehe, et saaks edasi liikuda
        }
    }

}