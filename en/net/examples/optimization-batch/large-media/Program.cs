using System.Diagnostics;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    private static Task<int> Main(string[] args) => RunChecked(args);
    private static void ProcessLargeMedia()
    {
        Example.Setup();
        WriteWav("output/original.wav", 4 * 1024 * 1024);
        using (var audio = File.OpenRead("output/original.wav"))
        using (var p = new Presentation())
        {
            p.Slides[0].Shapes.AddAudioFrameEmbedded(40, 40, 80, 80, audio);
            p.Save("output/input.pptx", SaveFormat.Pptx);
        }

        string temp = Path.GetFullPath("output/blob-temp");
        Directory.CreateDirectory(temp);
        long baseline = Process.GetCurrentProcess().WorkingSet64;
        var watch = Stopwatch.StartNew();
        var options = new LoadOptions
        {
            BlobManagementOptions = new BlobManagementOptions
            {
                PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
                IsTemporaryFilesAllowed = true,
                TempFilesRootPath = temp,
                MaxBlobsBytesInMemory = 1024
            }
        };
        using (var p = new Presentation("output/input.pptx", options))
        {
            p.Save("output/processed.pptx", SaveFormat.Pptx);
        }

        watch.Stop();
        using (var exclusive = File.Open("output/input.pptx", FileMode.Open, FileAccess.ReadWrite, FileShare.None))
        {
        }

        int remainingFiles = Directory.GetFiles(temp, "*", SearchOption.AllDirectories).Length;
        using var result = new Presentation("output/processed.pptx");
        byte[] actual = result.Slides[0].Shapes.OfType<IAudioFrame>().Single().EmbeddedAudio.BinaryData;
        Example.Require(Example.Hash(actual) == Example.HashFile("output/original.wav"), "Audio changed.");
        Example.Require(remainingFiles == 0, "BLOB temporary files remain after disposal.");
        Example.Json("output/measurements.json", new { audio_bytes = actual.Length, baseline_working_set = baseline, process_peak_working_set = Process.GetCurrentProcess().PeakWorkingSet64, processing_elapsed_ms = watch.ElapsedMilliseconds, temp_files_after_disposal = remainingFiles, operating_system = System.Runtime.InteropServices.RuntimeInformation.OSDescription, runtime = System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription });
        Example.Result(new { media_bytes_preserved = true, input_unlocked_after_disposal = true, temp_files_cleaned = true, memory_measurement_recorded = true });
    }
}
