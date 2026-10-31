using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Threading.Tasks;
using Aspose.Slides;

/// <summary>Shared startup, paths and truthful action results for this download.</summary>
public static class ExampleBootstrap
{
    public static async Task<int> RunAsync(string[] args, Func<ExampleContext, Task> action)
    {
        string initialDirectory = Environment.CurrentDirectory;
        ExampleContext? context = null;
        string output = Path.Combine(AppContext.BaseDirectory, "output");
        string mode = "evaluation";
        try
        {
            var options = Parse(args);
            output = Path.GetFullPath(options.Output ?? output, initialDirectory);
            Directory.CreateDirectory(output);
            // Detect write failures before executing the demonstration.
            string probe = Path.Combine(output, ".write-" + Guid.NewGuid().ToString("N"));
            using (File.Create(probe)) { }
            File.Delete(probe);
            string? licensePath = options.License ?? Environment.GetEnvironmentVariable("ASPOSE_LICENSE_PATH");
            mode = options.Mode ?? (string.IsNullOrWhiteSpace(licensePath) ? "evaluation" : "licensed");
            context = new ExampleContext(output, mode, options.Remaining.ToArray());
            if (mode == "licensed")
            {
                if (string.IsNullOrWhiteSpace(licensePath) || !File.Exists(licensePath))
                    throw new ExamplePrerequisiteException("Licensed mode requires a readable license. Set ASPOSE_LICENSE_PATH or pass --license PATH for a license covering this Aspose.Slides release.");
                try
                {
                    var license = new License();
                    license.SetLicense(Path.GetFullPath(licensePath, initialDirectory));
                    if (!license.IsLicensed()) throw new InvalidOperationException();
                }
                catch (Exception)
                {
                    throw new ExamplePrerequisiteException("The supplied license could not activate this release. Supply a valid authorized Aspose.Slides license covering the package version, or use --mode evaluation.");
                }
                context.IsLicensed = true;
            }
            // Explicit evaluation mode deliberately ignores both license sources.
            context.PrepareFixtures();
            string fontRoot = Path.Combine(AppContext.BaseDirectory, "Fonts");
            if (Directory.Exists(fontRoot)) FontsLoader.LoadExternalFonts(new[] { fontRoot });
            Console.WriteLine("Mode: " + mode);
            Console.WriteLine("Output: " + output);
            Environment.CurrentDirectory = output;
            await action(context);
            if (context.Actions.Count == 0)
                throw new InvalidOperationException("No example action reported a verified result. Call context.Pass only after its checks pass.");
            context.WriteReport("passed");
            return 0;
        }
        catch (ExamplePrerequisiteException ex)
        {
            Console.Error.WriteLine("Prerequisite required: " + ex.Message);
            if (context != null) { context.RecordFailure("prerequisite_required", ex.Message); context.WriteReport("prerequisite_required"); }
            else TryWriteFailure(output, mode, "prerequisite_required", ex.Message);
            return 2;
        }
        catch (Exception ex)
        {
            string detail = ex is UnauthorizedAccessException ? "Output is not writable. Pass --output with a writable directory." : ex.Message;
            Console.Error.WriteLine("Example failed: " + detail);
            if (context != null) { context.RecordFailure("failed", detail); context.WriteReport("failed"); }
            else TryWriteFailure(output, mode, "failed", detail);
            return 1;
        }
        finally { Environment.CurrentDirectory = initialDirectory; }
    }

    private static void TryWriteFailure(string output, string mode, string status, string message)
    {
        try { var context = new ExampleContext(output, mode, Array.Empty<string>()); context.RecordFailure(status, message); context.WriteReport(status); }
        catch (Exception) { Console.Error.WriteLine("execution.json could not be written; no successful execution is claimed."); }
    }

    private static Options Parse(string[] args)
    {
        var result = new Options();
        for (int i = 0; i < args.Length; i++)
        {
            string key = args[i];
            if (key == "--") { result.Remaining.AddRange(args.Skip(i + 1)); break; }
            if (key is "--mode" or "--output" or "--license")
            {
                if (i + 1 == args.Length || args[i + 1].StartsWith("--", StringComparison.Ordinal))
                    throw new ExamplePrerequisiteException("Supply a value after " + key + ". Usage: --mode evaluation|licensed --output DIRECTORY --license PATH.");
                string value = args[++i];
                if (key == "--mode") result.Mode = value;
                if (key == "--output") result.Output = value;
                if (key == "--license") result.License = value;
            }
            else result.Remaining.Add(key);
        }
        if (result.Mode != null && result.Mode is not ("evaluation" or "licensed"))
            throw new ExamplePrerequisiteException("Unknown mode. Use --mode evaluation or --mode licensed.");
        return result;
    }

    private sealed class Options
    {
        internal string? Mode, Output, License;
        internal readonly List<string> Remaining = new();
    }
}

public sealed class ExampleContext
{
    public string FixtureRoot { get; } = Path.Combine(AppContext.BaseDirectory, "Fixtures");
    public string OutputRoot { get; }
    public bool IsLicensed { get; internal set; }
    public string Mode { get; }
    public string[] Arguments { get; }
    public string[] RemainingArgs => Arguments;
    public string ArticleId { get; }
    internal readonly List<Dictionary<string, object?>> Actions = new();
    private string? currentAction;

    internal ExampleContext(string output, string mode, string[] arguments)
    {
        OutputRoot = output; Mode = mode; Arguments = arguments;
        string manifest = Path.Combine(AppContext.BaseDirectory, "example-manifest.json");
        using var json = File.Exists(manifest) ? JsonDocument.Parse(File.ReadAllText(manifest)) : null;
        ArticleId = json?.RootElement.GetProperty("article_id").GetString() ?? "example";
    }

    public string Input(string relativePath)
    {
        if (Path.IsPathRooted(relativePath)) throw new ArgumentException("Input requires a relative fixture path.");
        string file = Path.GetFullPath(Path.Combine(FixtureRoot, relativePath));
        string prefix = Path.GetFullPath(FixtureRoot) + Path.DirectorySeparatorChar;
        if (!file.StartsWith(prefix, OperatingSystem.IsWindows() ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal))
            throw new ArgumentException("Input cannot leave the Fixtures directory.");
        if (!File.Exists(file)) throw new ExamplePrerequisiteException("Required fixture is missing: " + relativePath + ". Extract the complete download, including Fixtures.");
        return file;
    }

    /// <summary>Expected plain-text getter value for the pinned package's measured evaluation limit.</summary>
    public string ExpectedText(string written) => IsLicensed || written.Length <= 5
        ? written : written.Substring(0, 5) + "... text has been truncated due to evaluation version limitation.";

    public void BeginAction(string actionId)
    {
        if (string.IsNullOrWhiteSpace(actionId)) throw new ArgumentException("An action ID is required.");
        currentAction = actionId;
    }

    public void Require(bool condition, string message)
    {
        if (!condition) throw new InvalidOperationException(message);
    }

    public void Prerequisite(bool condition, string message)
    {
        if (!condition) throw new ExamplePrerequisiteException(message);
    }

    public void Pass(string actionId, params string[] checks)
    {
        if (checks.Length == 0 || checks.Any(string.IsNullOrWhiteSpace))
            throw new InvalidOperationException("A passed action requires named semantic checks.");
        Pass(actionId, checks.Distinct().ToDictionary(key => key, _ => true));
    }

    public void Pass(string actionId, IReadOnlyDictionary<string, bool> checks)
    {
        Require(!string.IsNullOrWhiteSpace(actionId), "A passed action requires a stable action ID.");
        Require(checks.Count > 0 && checks.All(pair => !string.IsNullOrWhiteSpace(pair.Key) && pair.Value), "All named semantic checks must pass.");
        Require(!Actions.Any(row => (string?)row["action_id"] == actionId), "An action cannot be reported twice: " + actionId);
        var row = Record(actionId, "passed"); row["checks"] = checks; row["evidence_kind"] = "functional"; Actions.Add(row);
        currentAction = null;
        Console.WriteLine("Passed: " + actionId);
    }

    internal void RecordFailure(string status, string error)
    {
        var row = Record(currentAction ?? ArticleId, status);
        row["evidence_kind"] = status == "prerequisite_required" ? "prerequisite_diagnostic" : "functional";
        row[status == "prerequisite_required" ? "unmet_prerequisites" : "error"] = status == "prerequisite_required" ? new[] { error } : error;
        Actions.Add(row);
    }

    private Dictionary<string, object?> Record(string actionId, string status) => new()
    {
        ["article_id"] = ArticleId, ["action_id"] = actionId, ["status"] = status, ["mode"] = Mode,
        ["runtime"] = new { version = Environment.Version.ToString(), framework = RuntimeInformation.FrameworkDescription, os = RuntimeInformation.OSDescription, architecture = RuntimeInformation.ProcessArchitecture.ToString() }
    };

    internal void WriteReport(string status)
    {
        var report = new { schema_version = 1, article_id = ArticleId, status, mode = Mode, actions = Actions };
        Directory.CreateDirectory(OutputRoot);
        File.WriteAllText(Path.Combine(OutputRoot, "execution.json"), JsonSerializer.Serialize(report, new JsonSerializerOptions { WriteIndented = true }) + Environment.NewLine);
    }

    internal void PrepareFixtures()
    {
        if (!Directory.Exists(FixtureRoot)) return;
        string fixture = Path.GetFullPath(FixtureRoot).TrimEnd(Path.DirectorySeparatorChar);
        string output = Path.GetFullPath(OutputRoot).TrimEnd(Path.DirectorySeparatorChar);
        var comparison = OperatingSystem.IsWindows() ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
        if (output.Equals(fixture, comparison) || output.StartsWith(fixture + Path.DirectorySeparatorChar, comparison)
            || fixture.StartsWith(output + Path.DirectorySeparatorChar, comparison))
            throw new InvalidOperationException("Output must be separate from the Fixtures directory. Pass --output with another directory.");
        foreach (string input in Directory.EnumerateFiles(FixtureRoot, "*", SearchOption.AllDirectories))
        {
            string target = Path.Combine(OutputRoot, Path.GetRelativePath(FixtureRoot, input));
            Directory.CreateDirectory(Path.GetDirectoryName(target)!);
            File.Copy(input, target, true);
        }
    }
}

public sealed class ExamplePrerequisiteException : Exception
{
    public ExamplePrerequisiteException(string message) : base(message) { }
}
