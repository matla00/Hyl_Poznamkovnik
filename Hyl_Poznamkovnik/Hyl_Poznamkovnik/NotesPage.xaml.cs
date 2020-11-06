using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Hyl_Poznamkovnik.Model;

namespace Hyl_Poznamkovnik
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotesPage : ContentPage
    {
        public NotesPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.Database.GetNotesAsync();
        }

        async void add_note(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddNote
            {
                BindingContext = new Note()
            });
        }

        async void delete_note(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int ID = int.Parse(button.ClassId);

            Note note = await App.Database.GetNoteAsync(ID);
            await App.Database.DeleteNoteAsync(note);

            Navigation.InsertPageBefore(new NotesPage(), this);
            await Navigation.PopAsync();
        }
        async void edit_note(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int ID = int.Parse(button.ClassId);

            await Navigation.PushAsync(new EditNote(ID));
        }
    }
}
