using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Hyl_Poznamkovnik.Model;
using SQLite;

namespace Hyl_Poznamkovnik
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditNote : ContentPage
    {
        public int ID;
        public EditNote(int ID_set)
        {
            InitializeComponent();
            ID = ID_set;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            Note note = await App.Database.GetNoteAsync(ID);

            Title.Text = note.Name;
            Text.Text = note.Text;
            Date_created.Text = note.Date_created.ToString();
            Date_edited.Text = note.Date_edited.ToString();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            Note note = await App.Database.GetNoteAsync(ID);
            note.Name = this.FindByName<Editor>("Title").Text;
            note.Text = this.FindByName<Editor>("Text").Text;
            note.Date_edited = DateTime.Now;
            await App.Database.SaveNoteAsync(note);
            await Navigation.PopAsync();
        }
    }
}