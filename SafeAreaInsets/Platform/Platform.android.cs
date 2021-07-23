using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using AndroidX.Core.View;
using Java.Interop;
using ResourceA = global::Android.Resource;

namespace SafeAreaInsets
{
    /// <summary>Platform specific helpers.</summary>
    public static partial class Platform
    {
        internal static int requestCode = 1111;

        /// <summary>Initialize Xamarin.MediaGallery with Android's activity and bundle.</summary>
        /// <param name="activity">Activity to use for initialization.</param>
        /// <param name="bundle">Bundle of the activity.</param>
        public static void Init(Activity activity, Bundle bundle)
        {
            var view = (FrameLayout)activity.FindViewById(ResourceA.Id.Content);
            //ViewCompat.SetOnApplyWindowInsetsListener(view, new Listener());


            //var aa = activity.FromPixels(1);
            //var type = WindowInsets.Type.Ime();

            //var height = view.WindowInsetsController.AddOnControllableInsetsChangedListener

        }

        internal static Activity AppActivity
            => Xamarin.Essentials.Platform.CurrentActivity
            ?? throw new NullReferenceException("The current Activity can not be detected. " +
                $"Ensure that you have called Xamarin.Essentials.Platform.Init in your Activity or Application class.");

        internal static bool HasSdkVersion(int version)
            => (int)Build.VERSION.SdkInt >= version;
    }

    class Listener : Java.Lang.Object, IOnApplyWindowInsetsListener
    {
        private InputMethodManager _inputMethodManager;
        bool isKeyboardShowh;

        public WindowInsetsCompat OnApplyWindowInsets(View v, WindowInsetsCompat insets)
        {
            GetInputMethodManager();

            if (_inputMethodManager.IsAcceptingText)
            {
                isKeyboardShowh = true;
                // notify keyboard show
            }
            else if (isKeyboardShowh)
            {
                // notify keyboard hide
                isKeyboardShowh = false;
            }
            else
            {
                // notyfy safe area
            }

            return insets;
        }

        void GetInputMethodManager()
        {
            if (_inputMethodManager == null || _inputMethodManager.Handle == IntPtr.Zero)
                _inputMethodManager = (InputMethodManager)Xamarin.Essentials.Platform.CurrentActivity.GetSystemService(Context.InputMethodService);
        }
    }
}
