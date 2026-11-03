using System.Collections.Generic;
using System.IO;
using System.Linq;
using Aspose.Slides;
using System.Threading.Tasks;

internal static partial class Program
{
    private static Task<int> Main(string[] args) => RunChecked(args);
    private sealed record Payload(int Slide, string Shape, string Kind, string File, string Sha256);
    private sealed record ExternalLink(int Slide, string Shape, string Url);
    private static string Extension(string contentType) => contentType.ToLowerInvariant() switch
    {
        "audio/wav" or "audio/x-wav" => "wav",
        "audio/mpeg" => "mp3",
        "video/avi" or "video/x-msvideo" or "video/msvideo" => "avi",
        "video/mp4" => "mp4",
        _ => "bin"
    };
    private static string SafeExtension(string extension)
    {
        string clean = extension.TrimStart('.');
        return clean.Length > 0 && clean.Length <= 12 && clean.All(char.IsLetterOrDigit) ? clean.ToLowerInvariant() : "bin";
    }

    private static void ExtractMedia()
    {
        var(audio, video, ole) = CreateInput();
        using var input = new Presentation("output/input.pptx");
        string outputDirectory = Directory.CreateDirectory("output/extracted").FullName;
        var rows = new List<Payload>();
        var links = new List<ExternalLink>();
        void Save(int slide, IShape shape, string kind, string extension, byte[] data)
        {
            string hash = Example.Hash(data);
            string filename = $"{kind}-{hash}.{SafeExtension(extension)}";
            string outputPath = Example.SafeOutput(outputDirectory, filename);
            File.WriteAllBytes(outputPath, data);
            rows.Add(new Payload(slide, shape.Name, kind, "extracted/" + filename, hash));
        }

        for (int i = 0; i < input.Slides.Count; i++)
        {
            foreach (var shape in Example.Walk(input.Slides[i].Shapes))
            {
                switch (shape)
                {
                    case IAudioFrame audioFrame:
                        if (audioFrame.EmbeddedAudio is { } embeddedAudio)
                            Save(i + 1, shape, "audio", Extension(embeddedAudio.ContentType), embeddedAudio.BinaryData);
                        else
                            links.Add(new ExternalLink(i + 1, shape.Name, audioFrame.LinkPathLong));
                        break;
                    case IVideoFrame videoFrame:
                        if (videoFrame.EmbeddedVideo is { } embeddedVideo)
                            Save(i + 1, shape, "video", Extension(embeddedVideo.ContentType), embeddedVideo.BinaryData);
                        else
                            links.Add(new ExternalLink(i + 1, shape.Name, videoFrame.LinkPathLong));
                        break;
                    case IOleObjectFrame embeddedObject:
                        if (embeddedObject.IsObjectLink)
                            links.Add(new ExternalLink(i + 1, shape.Name, embeddedObject.LinkPathLong));
                        else
                            Save(i + 1, shape, "ole", embeddedObject.EmbeddedData.EmbeddedFileExtension, embeddedObject.EmbeddedData.EmbeddedFileData);
                        break;
                }
            }
        }

        Example.Json("output/manifest.json", new { payloads = rows, external_links = links });
        VerifyExtraction(audio, video, ole, rows, links.Cast<object>().ToList());
    }
}
