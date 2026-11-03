using System.Collections.Generic;
using System.IO;
using System.Linq;
using Aspose.Slides;
using System.Threading.Tasks;

internal static partial class Program
{
    private static Task<int> Main(string[] args) => RunChecked(args);
    private sealed record ImageRef(int Slide, string Shape, string File, string Sha256);
    private static string ImageExtension(string contentType) => contentType.ToLowerInvariant() switch
    {
        "image/png" => ".png",
        "image/jpeg" => ".jpg",
        "image/gif" => ".gif",
        "image/bmp" => ".bmp",
        "image/tiff" => ".tiff",
        "image/svg+xml" => ".svg",
        _ => ".bin"
    };
    private static void ExtractImages()
    {
        var(blue, orange) = CreateInput();
        using var input = new Presentation("output/input.pptx");
        string imageRoot = Directory.CreateDirectory("output/images").FullName;
        var seen = new HashSet<string>();
        var refs = new List<ImageRef>();
        var links = new List<object>();
        for (int i = 0; i < input.Slides.Count; i++)
        {
            int slideNumber = i + 1;
            foreach (var frame in Example.Walk(input.Slides[i].Shapes).OfType<IPictureFrame>())
            {
                var picture = frame.PictureFormat.Picture;
                if (!string.IsNullOrWhiteSpace(picture.LinkPathLong))
                {
                    links.Add(new { slide = slideNumber, shape = frame.Name, url = picture.LinkPathLong });
                    continue;
                }

                byte[] bytes = picture.Image.BinaryData;
                string hash = Example.Hash(bytes);
                string filename = hash + ImageExtension(picture.Image.ContentType);
                string relativePath = "images/" + filename;
                if (seen.Add(hash))
                {
                    string outputPath = Example.SafeOutput(imageRoot, filename);
                    File.WriteAllBytes(outputPath, bytes);
                }

                refs.Add(new ImageRef(slideNumber, frame.Name, relativePath, hash));
            }
        }

        Example.Json("output/images.json", new { images = refs, external_links = links });
        VerifyExtraction(blue, orange, seen, refs, links);
    }
}
