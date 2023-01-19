using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Wpf.MVVM.SampleModel;
using Wpf.MVVM.Services;
using Wpf.MVVM.Command;
using System.Collections.ObjectModel;

namespace Wpf.MVVM.ViewModel
{
    public class CategoryViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        CatgegoryServices CatgegoryServices;
        public CategoryViewModel()
        {
            CatgegoryServices = new CatgegoryServices();
            LoadDate();
            CurrentCategories = new CategoriesModel();
            saveCommand = new RealyCommand(Save);
            searchCommand = new RealyCommand(Search);
            updateCommand = new RealyCommand(Update);
            deleteCommand = new RealyCommand(Delete);
        }

        private ObservableCollection<CategoriesModel> categories;

        public ObservableCollection<CategoriesModel> Categories
        {
            get { return categories; }
            set { categories = value; OnPropertyChanged("Categories"); }
        }
        private void LoadDate()
        {
            Categories =new ObservableCollection<CategoriesModel>( CatgegoryServices.GetAll());
        }

        private CategoriesModel currentCategories;
        public CategoriesModel CurrentCategories
        {
            get { return currentCategories; }
            set
            {
                currentCategories = value;
                OnPropertyChanged("CurrentCategories");
            }
        }

        #region Save
        private RealyCommand saveCommand;
        public RealyCommand SaveCommand {
            get { 
                return saveCommand;
            } 
           
        }
        private string message { get; set; }
        public string Message { 
            get { return message; } 
            set { message = value; OnPropertyChanged("Message"); } 
        }
        public void Save()
        {
            try
            {
                var IsSave = CatgegoryServices.AddCatgegory(CurrentCategories);
                LoadDate();
                if (IsSave)
                    Message = "Catgegory Save.";
                else
                    Message = "Catgegory Save failed";

            }
            catch (Exception ex)
            {

                Message = ex.Message;
            }
        }
        #endregion

        #region Search

        private RealyCommand searchCommand;
        public RealyCommand SearchCommand
        {
            get
            {
                return searchCommand;
            }

        }
        public void Search ()
        {
            CategoriesModel data = new CategoriesModel();
            try
            {
                 data = CatgegoryServices.GetCategories(CurrentCategories.CategoryID);
                if (data != null)
                {
                    CurrentCategories.CategoryName = data.CategoryName;
                    CurrentCategories.Description = data.Description;
                    CurrentCategories.CategoryID = data.CategoryID;
                }
                else
                    Message = "Catgegory not found";
            }
            catch (Exception ex)
            {

                Message = ex.Message;
            }
        }
        #endregion

        #region update
        private RealyCommand updateCommand;
        public RealyCommand UpdateCommand
        {
            get
            {
                return updateCommand;
            }

        }
        public void Update()
        {
            CategoriesModel data = new CategoriesModel();
            try
            {
                data = CatgegoryServices.GetCategories(CurrentCategories.CategoryID);
                if (data != null)
                {
                    data.CategoryName = CurrentCategories.CategoryName;
                    data.Description = CurrentCategories.Description;
                    data.CategoryID = CurrentCategories.CategoryID;
                    CatgegoryServices.UpdateCatgegory(data);
                    LoadDate();
                }
                else
                    Message = "Error in Catgegory update";
            }
            catch (Exception ex)
            {

                Message = ex.Message;
            }
        }
        #endregion

        #region update
        private RealyCommand deleteCommand;
        public RealyCommand DeleteCommand
        {
            get
            {
                return deleteCommand;
            }

        }
        public void Delete()
        {
            CategoriesModel data = new CategoriesModel();
            try
            {
                data = CatgegoryServices.GetCategories(CurrentCategories.CategoryID);
                if (data != null)
                {
                  
                    CatgegoryServices.DeleteCatgegory(CurrentCategories.CategoryID);
                    LoadDate();
                }
                else
                    Message = "Error in Catgegory delete";
            }
            catch (Exception ex)
            {

                Message = ex.Message;
            }
        }
        #endregion

    }
}
