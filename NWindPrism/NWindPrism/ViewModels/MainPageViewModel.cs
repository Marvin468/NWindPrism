using NWindPrism.Model;
using NWindPrism.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWindPrism.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        /* public MainPageViewModel(INavigationService navigationService)
             : base(navigationService)
         {

         }*/
        public DelegateCommand AddCommand { get; }
        public DelegateCommand<BatFamily>DeleteCommand { get; }
        private IBatFamilyService BatItemService { get; }
        private IEnumerable<BatFamily> BatFamilyAll;
        private string inputText;
        public MainPageViewModel(INavigationService navigationService,IBatFamilyService BatSericeParam)
            :base(navigationService)
        {
            BatItemService = BatSericeParam;
            this.AddCommand = new DelegateCommand(AddTodoItem, () => !string.IsNullOrEmpty(InputText)).ObservesProperty(()=>this.InputText);
            DeleteCommand = new DelegateCommand<BatFamily>(this.DeleteTodoItem);
        }
        public IEnumerable<BatFamily> BatFamilyAlls
        {
            get { return BatFamilyAll; }
            set { SetProperty(ref this.BatFamilyAll, value); }
        }
        public string InputText
        {
            get { return this.inputText; }
            set
            {
                this.SetProperty(ref this.inputText, value);
            }
        }
        private void DeleteTodoItem(BatFamily BatParent)
        {
            BatItemService.Delete(BatParent.Id);
            BatFamilyAlls = BatItemService.GetAll();
        }
        private void AddTodoItem()
        {
            BatItemService.Insert(new BatFamily { Nombre = InputText });
            InputText = "";
            BatFamilyAlls = BatItemService.GetAll();
        }
        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }
        public void OnNavigatedTo(NavigationParameters parameters)
        {
            BatFamilyAlls = BatItemService.GetAll();
        }
    }
}
