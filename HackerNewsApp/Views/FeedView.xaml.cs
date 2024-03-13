using HackerNewsApp.ViewModels;

namespace HackerNewsApp.Views;

public partial class FeedView : ContentPage
{
    private FeedViewModel ViewModel => (BindingContext as FeedViewModel)!;
    
    public FeedView()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await ViewModel.RefreshFeed();
    }
}