
public class Parameters
{
    public string Configuration { get; private set; }
    public string Artifacts { get; private set; }
    public string VersionSuffix { get; private set; }
    public string NuGetPushBranch { get; private set; }
    public string NuGetPushRepoName { get; private set; }
    public bool PushNuGet { get; private set; }
    public bool IsNugetRelease { get; private set; }
    public (string path, string name)[] BuildProjects { get; private set; }
    public (string path, string name)[] TestProjects { get; private set; }
    public (string path, string name, string framework, string runtime)[] PublishProjects { get; private set; }
    public (string path, string name)[] PackProjects { get; private set; }

    public Parameters(ICakeContext context)
    {
        Configuration = context.Argument("configuration", "Release");
        Artifacts = context.Argument("artifacts", "./artifacts");

        VersionSuffix = context.Argument("suffix", default(string));
        if (VersionSuffix == null)
        {
            var build = context.EnvironmentVariable("APPVEYOR_BUILD_VERSION");
            VersionSuffix = build != null ? $"-build{build}" : "";
        }

        NuGetPushBranch = "master";
        NuGetPushRepoName = "wieslawsoltes/Core2D";

        var repoName = context.EnvironmentVariable("APPVEYOR_REPO_NAME");
        var repoBranch = context.EnvironmentVariable("APPVEYOR_REPO_BRANCH");
        var repoTag = context.EnvironmentVariable("APPVEYOR_REPO_TAG");
        var repoTagName = context.EnvironmentVariable("APPVEYOR_REPO_TAG_NAME");
        var pullRequestTitle = context.EnvironmentVariable("APPVEYOR_PULL_REQUEST_TITLE");

        if (pullRequestTitle == null 
            && string.Compare(repoName, NuGetPushRepoName, StringComparison.OrdinalIgnoreCase) == 0
            && string.Compare(repoBranch, NuGetPushBranch, StringComparison.OrdinalIgnoreCase) == 0)
        {
            PushNuGet = true;
        }

        if (pullRequestTitle == null 
            && string.Compare(repoTag, "True", StringComparison.OrdinalIgnoreCase) == 0
            && repoTagName != null)
        {
            IsNugetRelease = true;
        }

        BuildProjects = new []
        {
            ( "./src", "Core2D" ),
            ( "./src", "Core2D.Style" ),
            ( "./src", "Core2D.Data" ),
            ( "./src", "Core2D.Data.Extensions" ),
            ( "./src", "Core2D.Renderer" ),
            ( "./src", "Core2D.Shapes" ),
            ( "./src", "Core2D.Shapes.Extensions" ),
            ( "./src", "Core2D.Containers" ),
            ( "./src", "Core2D.Editor" ),
            ( "./src", "Core2D.FileSystem.DotNet" ),
            ( "./src", "Core2D.FileWriter.Dxf" ),
            ( "./src", "Core2D.FileWriter.Emf" ),
            ( "./src", "Core2D.FileWriter.PdfSharp" ),
            ( "./src", "Core2D.FileWriter.SkiaSharp" ),
            ( "./src", "Core2D.Log.Trace" ),
            ( "./src", "Core2D.Renderer.Avalonia" ),
            ( "./src", "Core2D.Renderer.Dxf" ),
            ( "./src", "Core2D.Renderer.PdfSharp" ),
            ( "./src", "Core2D.Renderer.SkiaSharp" ),
            ( "./src", "Core2D.Renderer.WinForms" ),
            ( "./src", "Core2D.Renderer.Wpf" ),
            ( "./src", "Core2D.ScriptRunner.Roslyn" ),
            ( "./src", "Core2D.Serializer.Newtonsoft" ),
            ( "./src", "Core2D.Serializer.Xaml" ),
            ( "./src", "Core2D.ServiceProvider.Autofac" ),
            ( "./src", "Core2D.TextFieldReader.CsvHelper" ),
            ( "./src", "Core2D.TextFieldWriter.CsvHelper" ),
            ( "./src", "Core2D.Utilities.Avalonia" ),
            ( "./src", "Core2D.Utilities.Wpf" ),
            ( "./src", "Core2D.Avalonia" )
        };

        TestProjects = new []
        {
            ( "./tests", "Core2D.UnitTests" ),
            ( "./tests", "Core2D.Style.UnitTests" ),
            ( "./tests", "Core2D.Data.UnitTests" ),
            ( "./tests", "Core2D.Renderer.UnitTests" ),
            ( "./tests", "Core2D.Shapes.UnitTests" ),
            ( "./tests", "Core2D.Containers.UnitTests" ),
            ( "./tests", "Core2D.Editor.UnitTests" ),
            ( "./tests", "Core2D.FileSystem.DotNet.UnitTests" )
        };

        PublishProjects = new []
        {
            ( "./src", "Core2D.Avalonia", "netcoreapp2.1", "win7-x64" )
        };

        PackProjects = new []
        {
            ( "./src", "Core2D" ),
            ( "./src", "Core2D.Style" ),
            ( "./src", "Core2D.Data" ),
            ( "./src", "Core2D.Data.Extensions" ),
            ( "./src", "Core2D.Renderer" ),
            ( "./src", "Core2D.Shapes" ),
            ( "./src", "Core2D.Shapes.Extensions" ),
            ( "./src", "Core2D.Containers" ),
            ( "./src", "Core2D.Editor" ),
            ( "./src", "Core2D.FileSystem.DotNet" ),
            ( "./src", "Core2D.FileWriter.Dxf" ),
            ( "./src", "Core2D.FileWriter.Emf" ),
            ( "./src", "Core2D.FileWriter.PdfSharp" ),
            ( "./src", "Core2D.FileWriter.SkiaSharp" ),
            ( "./src", "Core2D.Log.Trace" ),
            ( "./src", "Core2D.Renderer.Avalonia" ),
            ( "./src", "Core2D.Renderer.Dxf" ),
            ( "./src", "Core2D.Renderer.PdfSharp" ),
            ( "./src", "Core2D.Renderer.SkiaSharp" ),
            ( "./src", "Core2D.Renderer.WinForms" ),
            ( "./src", "Core2D.Renderer.Wpf" ),
            ( "./src", "Core2D.ScriptRunner.Roslyn" ),
            ( "./src", "Core2D.Serializer.Newtonsoft" ),
            ( "./src", "Core2D.Serializer.Xaml" ),
            ( "./src", "Core2D.ServiceProvider.Autofac" ),
            ( "./src", "Core2D.TextFieldReader.CsvHelper" ),
            ( "./src", "Core2D.TextFieldWriter.CsvHelper" ),
            ( "./src", "Core2D.Utilities.Avalonia" ),
            ( "./src", "Core2D.Utilities.Wpf" )
        };
    }
}
