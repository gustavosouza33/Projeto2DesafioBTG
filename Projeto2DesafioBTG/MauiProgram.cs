using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;
using Projeto2DesafioBTG.Interfaces;
using Projeto2DesafioBTG.Models;
using Projeto2DesafioBTG.Services;
using Projeto2DesafioBTG.ViewModels;
using Projeto2DesafioBTG.Views;
#if WINDOWS
            using Microsoft.UI;
            using Microsoft.UI.Windowing;
            using Windows.Graphics;
#endif
namespace Projeto2DesafioBTG
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()

                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont(filename: "MaterialSymbolsOutlined.ttf", alias: "MaterialIconsOutlined-Regular");
                    fonts.AddFont(filename: "NotoSans-Bold.ttf", alias: "NotoSans-Bold");
                    fonts.AddFont(filename: "NotoSans-Medium.ttf", alias: "NotoSans-Medium");
                    fonts.AddFont(filename: "NotoSans-Regular.ttf", alias: "NotoSans-Regular");
                    fonts.AddFont(filename: "NotoSans-SemiBold.ttf", alias: "NotoSans-SemiBold");
                });

#if WINDOWS
 
  builder.ConfigureLifecycleEvents(events =>
                {
                    events.AddWindows(windowsLifecycleBuilder =>
                        {
                            windowsLifecycleBuilder.OnWindowCreated(window =>
                                {
                                    window.ExtendsContentIntoTitleBar = false;
                                    var handle = WinRT.Interop.WindowNative.GetWindowHandle(window);
                                    var id = Win32Interop.GetWindowIdFromWindow(handle);
                                    var appWindow = AppWindow.GetFromWindowId(id);
                                    switch (appWindow.Presenter)
                                    {
                                        case OverlappedPresenter overlappedPresenter:
                                            overlappedPresenter.SetBorderAndTitleBar(false, false);
                                            overlappedPresenter.Maximize();
                                            break;
                                    }
                                });
                        });
                });
#endif
            RegisterServices(builder);
            RegisterViewModels(builder);
            RegisterViews(builder);
            RegisterModels(builder);



#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }


        public static void RegisterServices(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddScoped<IClienteService, ClienteService>();
        }

        public static void RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<IncluirClienteViewModel>();
            mauiAppBuilder.Services.AddSingleton<EditarClienteViewModel>();
            mauiAppBuilder.Services.AddSingleton<VisualizarClienteViewModel>();
        }

        public static void RegisterViews(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<IncluirClientePage>();
            mauiAppBuilder.Services.AddSingleton<EditarClientePage>();
            mauiAppBuilder.Services.AddSingleton<VisualizarClientePage>();
        }

        public static void RegisterModels(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<Cliente>();
        }
    }
}
