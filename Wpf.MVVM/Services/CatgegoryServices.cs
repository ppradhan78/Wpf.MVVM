using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.MVVM.SampleModel;

namespace Wpf.MVVM.Services
{
    public class CatgegoryServices
    {
        private static List<CategoriesModel> _categorieslist;
        public CatgegoryServices()
        {
            _categorieslist = new List<CategoriesModel>()
            {
                new CategoriesModel{CategoryID=1,CategoryName="Food",Description="Foods" }
            };
        }

        public List<CategoriesModel> GetAll()
        {
            return _categorieslist;

        }
        public CategoriesModel GetCategories(int CategoryID)
        {
            if (CategoryID < 0)
            {
                throw new ArgumentException("Invalid CategoryID");
            }
            var category = _categorieslist.FirstOrDefault(c => c.CategoryID == CategoryID);

            return category;

        }
        public bool AddCatgegory(CategoriesModel input)
        {
            if (string.IsNullOrEmpty(input.CategoryName))
            {
                throw new ArgumentException("Invalid category name");
            }
            _categorieslist.Add(input);
            return true;

        }
        public bool UpdateCatgegory(CategoriesModel input)
        {
            if (string.IsNullOrEmpty(input.CategoryName))
            {
                throw new ArgumentException("Invalid category name");
            }
            if (input.CategoryID < 0)
            {
                throw new ArgumentException("Invalid CategoryID");
            }
            bool isUpdate = false;
            var category = _categorieslist.Find(c => c.CategoryID == input.CategoryID);
            if (category != null)
            {
                category.CategoryName = input.CategoryName;
                category.Description = input.Description;
                isUpdate = true;
            }

            return isUpdate;

        }
        public bool DeleteCatgegory(int CategoryID)
        {

            if (CategoryID < 0)
            {
                throw new ArgumentException("Invalid CategoryID");
            }
            bool isDelete = false;
            var category = _categorieslist.Find(c => c.CategoryID == CategoryID);
            if (category != null)
            {
                _categorieslist.Remove(category);
                isDelete = true;
            }

            return isDelete;

        }
    }
}
