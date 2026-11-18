using System.Security.Cryptography.X509Certificates;

namespace M_LOGITge25;

public partial class valgusfoor : ContentPage
{
    bool NightClicked = false;
    bool Cycle = false;
    public valgusfoor()
	{
        InitializeComponent();
    }

    private async void StartBtn_Clicked(object sender, EventArgs e)
    {
        Cycle = true;
        NightClicked = false;
        ResetToDefault(this, EventArgs.Empty);



        while (Cycle == true) 
        {
            ResetToDefault(this, EventArgs.Empty);
            GreenLight.Color = Colors.Green;
            await Task.Delay(2000);

            ResetToDefault(this, EventArgs.Empty);
            YellowLight.Color = Colors.Yellow;
            await Task.Delay(2000);

            ResetToDefault(this, EventArgs.Empty);
            RedLight.Color = Colors.Red;
            await Task.Delay(2000);
            ResetToDefault(this, EventArgs.Empty);
        }

    }

    /// <summary>
    /// Stops the traffic light by changing all lights to gray.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The event data.</param>
    private async void StopBtn_Clicked(object sender, EventArgs e)
    {
        ResetToDefault(this, EventArgs.Empty);
        Cycle = false;
        NightClicked = false;
        ResetToDefault(this, EventArgs.Empty);
        await Task.Delay(2000);
        ResetToDefault(this, EventArgs.Empty);
    }

    private async void NighBtn_Clicked(object sender, EventArgs e)
    {
        ResetToDefault(this, EventArgs.Empty);
        Cycle = false;
        NightClicked = true;
        while (NightClicked == true) 
        {
            YellowLight.Color = Colors.Yellow;
            await Task.Delay(2000);

            YellowLight.Color = Colors.Gray;
            await Task.Delay(2000);
        }
        
        
    }
    public async void ResetToDefault(object sender, EventArgs e) 
    {

        GreenLight.Color = Colors.Gray;
        RedLight.Color = Colors.Gray;
        YellowLight.Color = Colors.Gray;
    }
}