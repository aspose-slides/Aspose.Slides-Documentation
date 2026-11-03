using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    private static Task<int> Main(string[] args) => RunChecked(args);
    private sealed record JobResult(string Source, string Output, bool Success, string? Error);
    private static async Task<(JobResult[] Results, int Peak)> ConvertAll(string[] files, string directory, int workerLimit)
    {
        Directory.CreateDirectory(directory);
        var results = new ConcurrentBag<JobResult>();
        int active = 0, peak = 0;
        await Parallel.ForEachAsync(files, new ParallelOptions { MaxDegreeOfParallelism = workerLimit }, (path, cancellation) =>
        {
            int current = Interlocked.Increment(ref active);
            int observed;
            do
            {
                observed = Volatile.Read(ref peak);
                if (current <= observed)
                    break;
            }
            while (Interlocked.CompareExchange(ref peak, current, observed) != observed);
            try
            {
                results.Add(ConvertOne(path, directory));
            }
            finally
            {
                Interlocked.Decrement(ref active);
            }

            return ValueTask.CompletedTask;
        });
        return (results.OrderBy(r => r.Source, StringComparer.Ordinal).ToArray(), peak);
    }

    private static async Task ConvertBatch()
    {
        CreateInput();
        string[] files = Directory.GetFiles("output/inputs", "*.pptx", SearchOption.AllDirectories).OrderBy(p => p, StringComparer.Ordinal).ToArray();
        var sequential = await ConvertAll(files, "output/sequential", 1);
        var parallel = await ConvertAll(files, "output/parallel", 2);
        VerifyOutput(sequential, parallel);
    }

    private static JobResult ConvertOne(string path, string directory)
    {
        string identity = Example.Hash(Encoding.UTF8.GetBytes(Path.GetRelativePath("output/inputs", path)))[..12];
        string destination = Path.Combine(directory, Path.GetFileNameWithoutExtension(path) + "-" + identity + ".pdf");
        try
        {
            if (PresentationFactory.Instance.GetPresentationInfo(path).LoadFormat != LoadFormat.Pptx)
                return new(path, destination, false, "Expected PPTX content.");
            using var p = new Presentation(path, new LoadOptions { LoadFormat = LoadFormat.Pptx });
            p.Save(destination, SaveFormat.Pdf);
            Example.Require(File.ReadAllBytes(destination).Take(5).SequenceEqual(Encoding.ASCII.GetBytes("%PDF-")), "Invalid PDF header.");
            return new(path, destination, true, null);
        }
        catch (Exception ex)
        {
            if (File.Exists(destination))
                File.Delete(destination);
            return new(path, destination, false, ex.GetType().Name + ": " + ex.Message);
        }
    }
}
