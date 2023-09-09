using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Chitro
{
	/// <summary>
	/// Main window of the application.
	/// </summary>
	public partial class MainWindow : Window
	{
		private ObservableCollection<BitmapImage> photo;
		private int currentPhotoIndex;

		public MainWindow()
		{
			InitializeComponent();

			photo = new ObservableCollection<BitmapImage>();
			currentPhotoIndex = 0;

			PreviousCommand = new RelayCommand(PreviousButton, CanNavigatePrevious);
			NextCommand = new RelayCommand(NextButton, CanNavigateNext);
		}

		public ObservableCollection<BitmapImage> Photo
		{
			get { return photo; }
			set
			{
				photo = value;
				OnPropertyChanged(nameof(Photo));
			}
		}

		public BitmapImage CurrentPhoto
		{
			get
			{
				if (photo.Count > 0 && currentPhotoIndex >= 0 && currentPhotoIndex < photo.Count)
				{
					return photo[currentPhotoIndex];
				}

				return null;
			}
		}

		public ICommand PreviousCommand { get; private set; }
		public ICommand NextCommand { get; private set; }

		private void PreviousButton(object parameter, RoutedEventArgs routedEventArgs)
		{
			if (currentPhotoIndex > 0)
			{
				currentPhotoIndex--;
				OnPropertyChanged(nameof(CurrentPhoto));
			}
		}

		private void NextButton(object parameter, RoutedEventArgs routedEventArgs)
		{
			if (currentPhotoIndex < photo.Count - 1)
			{
				currentPhotoIndex++;
				OnPropertyChanged(nameof(CurrentPhoto));
			}
		}
		
		private bool CanNavigatePrevious(object parameter)
		{
			return currentPhotoIndex > 0;
		}
		
		private bool CanNavigateNext(object parameter)
		{
			return currentPhotoIndex < photo.Count - 1;
		}
	}
}