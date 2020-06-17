using NET_TVShowPlaylist.TVShowDetails;
using Prism.Events;
using Prism.Ioc;
using Prism.Regions;
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

			// Register TV Show Detail window as a "pop-up dialog".
			containerRegistry.RegisterDialog<TVShowDetail, TVShowDetailViewModel>("TVShowDetail");

			// TODO: will need 2 more dialog windows, one for adding a TV Show and one for adding episode details
		}
	}
}
