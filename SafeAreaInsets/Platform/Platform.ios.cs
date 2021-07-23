using System;
using UIKit;

namespace SafeAreaInsets
{
    public static partial class Platform
    {
        static Func<UIViewController> getCurrentController;

        public static void Init(Func<UIViewController> getCurrentUIViewController)
            => getCurrentController = getCurrentUIViewController;

        internal static bool HasOSVersion(int major) =>
            UIDevice.CurrentDevice.CheckSystemVersion(major, 0);

        internal static UIViewController GetCurrentUIViewController()
          => getCurrentController?.Invoke()
            ?? Xamarin.Essentials.Platform.GetCurrentUIViewController()
            ?? throw new InvalidOperationException("Could not find current view controller.");
    }
}
