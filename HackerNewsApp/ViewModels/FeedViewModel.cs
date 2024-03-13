using System.Collections.ObjectModel;
using HackerNewsApp.Services;
using HackerNewsApp.ViewModels.Common;

namespace HackerNewsApp.ViewModels;

public class FeedViewModel: BaseViewModel
{
    private readonly ApiService _apiService = new();
    
    private ObservableCollection<int> _storyIds = null!;

    public ObservableCollection<int> StoryIds
    {
        get => _storyIds;
        set
        {
            if (Equals(value, _storyIds)) return;
            _storyIds = value;
            OnPropertyChanged();
        }
    }

    public async Task RefreshFeed()
    {
        try
        {
            StoryIds = new ObservableCollection<int>(await _apiService.GetFeedStoryIds());
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
}