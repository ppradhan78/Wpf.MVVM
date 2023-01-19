using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf.MVVM.SampleModel
{
	using System.ComponentModel;
	public class CategoriesModel : INotifyPropertyChanged
	{
		public int categoryID;
		public string categoryName;
		public string description;

		public event PropertyChangedEventHandler? PropertyChanged;
		private void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
		public int CategoryID
		{
			get { return categoryID; }
            set
            {
				categoryID = value;
				OnPropertyChanged("CategoryID");
			}
		}
		public string CategoryName
		{
			get { return categoryName; }
			set
			{
				categoryName = value;
				OnPropertyChanged("CategoryName");
			}
		}
		public string Description
		{
			get { return description; }
			set
			{
				description = value;
				OnPropertyChanged("Description");
			}
		}
	}
}
