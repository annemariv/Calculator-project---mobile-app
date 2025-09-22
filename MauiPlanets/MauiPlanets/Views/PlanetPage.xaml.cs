using MauiPlanets.Services;

namespace MauiPlanets.Views;

public partial class PlanetPage : ContentPage
{
	private const uint AnimationDuration = 800u;

    public PlanetPage()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

		//lstPopularPlanets.ItemSource = PlanetService.GetFeaturedPlanets();
  //      lstAllPlanets.ItemSource = PlanetService.GetAllPlanets();
    }

    async void ProfilePic_Clicked(System.Object sender, System.EventArgs e)
    {
        // fire-and-forget animatsioon (ei oota lõppu)
        _ = MainContentGrid.TranslateTo(
            -this.Width * 0.5,
            this.Height * 0.1,
            AnimationDuration,
            Easing.CubicIn);

        // ootab, kuni ScaleTo lõpeb
        await MainContentGrid.ScaleTo(0.8, AnimationDuration);
    }

}