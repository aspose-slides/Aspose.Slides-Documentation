using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Aspose.Slides;

internal static partial class Program
{
    private static ExampleContext Context = null!;
    private static string? runtimeLicense;
    private static string? runtimeInput;
    private static Task<int> Main(string[] args)
    {
        string? path = Value(args, "--license") ?? Environment.GetEnvironmentVariable("ASPOSE_LICENSE_PATH");
        runtimeLicense = string.IsNullOrWhiteSpace(path) ? null : Path.GetFullPath(path);
        string? input = Value(args, "--input");
        runtimeInput = string.IsNullOrWhiteSpace(input) ? null : Path.GetFullPath(input);
        return ExampleBootstrap.RunAsync(args, async context =>
        {
            Context = context;
            bool verify = context.Arguments.Contains("--verify-container") || Value(context.Arguments, "--input") == null;
            string actionId = verify ? "application-integration/docker/block-001" : "application-integration/docker/convert-file";
            context.BeginAction(actionId);
            if (verify)
                await BuildAndRunContainer();
            else
                await ConvertInsideContainer(runtimeInput!);
            using var result = JsonDocument.Parse(File.ReadAllText("result.json"));
            var root = result.RootElement;
            if (verify)
                context.Require(root.GetProperty("slides").GetInt32() == 2 && root.GetProperty("fixture_text_retained").GetBoolean(), "The synthetic two-slide text fixture must survive conversion.");
            context.Require(root.GetProperty("input_unchanged").GetBoolean(), "Input bytes changed.");
            if (context.IsLicensed)
                context.Require(root.GetProperty("full_text_retained").GetBoolean(), "Licensed full text changed.");
            var checks = new System.Collections.Generic.Dictionary<string, bool>();
            if (verify && context.IsLicensed)
            {
                foreach (string field in new[]
                {
                    "linux",
                    "full_text_retained",
                    "input_unchanged",
                    "no_license_in_image",
                    "networking_disabled"
                }

                )
                {
                    context.Require(root.GetProperty(field).GetBoolean(), "Container check failed: " + field);
                    checks["licensed-" + field] = true;
                }

                checks["licensed-slides"] = true;
            }
            else if (verify)
            {
                checks["evaluation-semantic-effect"] = true;
                checks["evaluation-valid-output"] = true;
            }
            else
            {
                checks["input slide count retained"] = true;
                checks["input bytes unchanged"] = true;
                checks["valid PDF and preview"] = true;
            }

            context.Pass(actionId, checks);
        });
    }

    private static string AllText(IPresentation p) => string.Join(" ", p.Slides.SelectMany(s => s.Shapes.OfType<IAutoShape>()).Select(s => s.TextFrame.Text));
    private static string ProjectRoot()
    {
        for (var d = new DirectoryInfo(AppContext.BaseDirectory); d != null; d = d.Parent)
            if (File.Exists(Path.Combine(d.FullName, "Dockerfile")) && File.Exists(Path.Combine(d.FullName, "Example.csproj")))
                return d.FullName;
        throw new ExamplePrerequisiteException("Run --verify-container from the complete extracted project so Dockerfile and source are available.");
    }

    private static Task<string> Docker(params string[] args) => RunProcess("docker", args);
    private static async Task<string> RunProcess(string executable, params string[] args)
    {
        var start = new ProcessStartInfo(executable)
        {
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
        };
        foreach (string argument in args)
            start.ArgumentList.Add(argument);
        Process process;
        try
        {
            process = Process.Start(start) ?? throw new InvalidOperationException();
        }
        catch (System.ComponentModel.Win32Exception)
        {
            throw new ExamplePrerequisiteException("Install Docker Desktop or a compatible Linux engine and start it before container verification.");
        }

        using (process)
        {
            Task<string> stdout = process.StandardOutput.ReadToEndAsync();
            Task<string> stderr = process.StandardError.ReadToEndAsync();
            await process.WaitForExitAsync();
            string output = await stdout;
            string error = await stderr;
            if (executable == "docker" && args[0] == "build")
                await File.WriteAllTextAsync("docker-build.log", output + error);
            if (process.ExitCode != 0)
            {
                if (executable == "docker" && args[0] is "version" or "info")
                    throw new ExamplePrerequisiteException("Docker engine is unavailable. Start a Linux container engine and retry.");
                throw new InvalidOperationException(executable + " operation failed: " + error);
            }

            Console.WriteLine(output);
            return output;
        }
    }

    private static string? Value(string[] args, string name)
    {
        int i = Array.IndexOf(args, name);
        return i >= 0 && i + 1 < args.Length ? args[i + 1] : null;
    }
}
