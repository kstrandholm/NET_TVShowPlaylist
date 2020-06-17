using NET_TVShowPlaylist.TVShowDetails;
using Prism.Events;
using Prism.Ioc;
using Prism.Regions;
using Prism.Services.Dialogs;
using Prism.Unity;
using System.Windows;

namespace NET_TVShowPlaylist
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : PrismApplication
	{
		protected override Window CreateShell()
		{
			return Container.Resolve<MainWindow.MainWindow>();
		}

		protected override void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.Register<IEventAggregator, EventAggregator>();
			containerRegistry.Register<IRegionManager, RegionManager>();
			containerRegistry.Register<IDialogService, DialogService>();

			// Register TV Show Detail window as a "pop-up dialog".
			containerRegistry.RegisterDialog<TVShowDetail, TVShowDetailViewModel>("TVShowDialog");

			// TODO: will need 2 more dialog windows---
			// 3 total: 1) Edit/View TV Show Details, (ADDED)
			//			2) Add new TV Show,
			//		    3) Add new episode to selected TVShow
		}
	}
}
