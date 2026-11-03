using System;
using System.IO;
using System.Net;
using System.Drawing;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    private static void RunExample()
    {
        using (var input = CreateDeck("<Planning & Review>", "<Planning & Review>", "Результаты"))
            input.Save("презентация.pptx", SaveFormat.Pptx);
        using var source = new Presentation("презентация.pptx");
        var items = new System.Collections.Generic.List<GalleryItem>();
        var html = new System.Text.StringBuilder("""<!doctype html><html lang="en"><meta charset="utf-8"><meta name="viewport" content="width=device-width,initial-scale=1"><title>Presentation gallery</title><body><h1>Presentation gallery</h1>""");
        for (int i = 0; i < source.Slides.Count; i++)
        {
            string file = $"slide-{i + 1}.png";
            string title = Text(source.Slides[i]);
            using var image = source.Slides[i].GetImage(new Size(320, 180));
            image.Save(file, Aspose.Slides.ImageFormat.Png);
            items.Add(new GalleryItem(i + 1, title, file));
        }

        foreach (var item in items)
        {
            html.Append($"""<figure><img width="320" height="180" src="{WebUtility.HtmlEncode(item.Thumbnail)}" alt="Slide {item.Slide}"><figcaption>{item.Slide}. {WebUtility.HtmlEncode(item.Title)}</figcaption></figure>""");
        }

        html.Append("</body></html>");
        string galleryHtml = html.ToString();
        File.WriteAllText("gallery.html", galleryHtml);
        File.WriteAllText("gallery.json", JsonSerializer.Serialize(items, new JsonSerializerOptions { WriteIndented = true, PropertyNamingPolicy = JsonNamingPolicy.CamelCase }));
        Require(galleryHtml.Contains(WebUtility.HtmlEncode(Context.ExpectedText("<Planning & Review>"))), "HTML labels must be escaped.");
        Require(!galleryHtml.Contains("<Planning", StringComparison.Ordinal), "Raw label HTML remains.");
        Report(new { slides = items.Count, unique_filenames = true, escaped_labels = true });
    }

    private sealed record GalleryItem(int Slide, string Title, string Thumbnail);
}
