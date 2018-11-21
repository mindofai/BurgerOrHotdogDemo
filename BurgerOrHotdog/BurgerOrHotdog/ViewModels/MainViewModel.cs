using BurgerOrHotdog.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BurgerOrHotdog.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        CustomVisionService _service;


        private string _urlText;
        private ImageSource _image;
        private string _predictionText;

        public string UrlText
        {
            get
            {
                return _urlText;
            }
            set
            {
                _urlText = value;
                OnPropertyChanged();
            }
        }
        public string PredictionText
        {
            get
            {
                return _predictionText;
            }
            set
            {
                _predictionText = value;
                OnPropertyChanged();
            }
        }


        public ImageSource Image
        {
            get
            {
                return _image;
            }
            set
            {
                _image = value;
                OnPropertyChanged();
            }
        }

        public Command PredictCommand => new Command(async () =>
        {
            if (!string.IsNullOrEmpty(UrlText))
                await PredictImage();
        });

        public MainViewModel()
        {
            _service = new CustomVisionService();
        }

        private async Task PredictImage()
        {

            Image = ImageSource.FromUri(new Uri(UrlText));
            var result = await _service.PredictImage(UrlText);

            PredictionText = string.IsNullOrEmpty(result) ? "There seems to be an issue with the image/service. Please try again" : "This is a " + result;

        }

        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
