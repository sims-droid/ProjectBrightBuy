using Microsoft.Extensions.Logging;

namespace ProjectBrightBuy
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>();

        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "brightbuy.db3");
        App.Database = new Database(dbPath);

        return builder.Build();
    }
}