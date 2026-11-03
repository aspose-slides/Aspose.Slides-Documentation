using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Aspose.Slides;
using Aspose.Slides.AI;
using Aspose.Slides.Export;

internal static partial class Program
{
    private static async Task<int> RunExample()
    {
        try
        {
            using (var original = new Presentation())
            {
                original.SlideSize.SetSize(640, 360, SlideSizeScaleType.DoNotScale);
                var shape = original.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 30, 550, 65);
                shape.TextFrame.Text = "Hello world";
                var group = original.Slides[0].Shapes.AddGroupShape();
                group.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 130, 550, 65).TextFrame.Text = "Good morning";
                var table = original.Slides[0].Shapes.AddTable(40, 230, new double[] { 550 }, new double[] { 65 });
                table[0, 0].TextFrame.Text = "Thank you";
                original.Save("original.pptx", SaveFormat.Pptx);
                using var image = original.Slides[0].GetImage(new Size(640, 360));
                image.Save("original.png", Aspose.Slides.ImageFormat.Png);
            }

            byte[] originalHash = System.Security.Cryptography.SHA256.HashData(File.ReadAllBytes("original.pptx"));
            using var targetPresentation = new Presentation("original.pptx");
            double originalX = targetPresentation.Slides[0].Shapes[0].X;
            using var http = Http("default");
            using var client = new AsposeAIWebClient(http);
            await new SlidesAIAgent(client).TranslateAsync(targetPresentation, "Spanish");
            string translated = AllText(targetPresentation);
            Require(translated.Contains("hola", StringComparison.OrdinalIgnoreCase) && translated.Contains("buen", StringComparison.OrdinalIgnoreCase) && translated.Contains("gracias", StringComparison.OrdinalIgnoreCase), "Expected Spanish shape, group and table text.");
            targetPresentation.Save("translated.pptx", SaveFormat.Pptx);
            using var reopened = new Presentation("translated.pptx");
            Require(AllText(reopened) == translated, "Translated text changed after reopening.");
            Require(reopened.Slides[0].Shapes[0].X == originalX, "Shape position changed.");
            Require(originalHash.SequenceEqual(System.Security.Cryptography.SHA256.HashData(File.ReadAllBytes("original.pptx"))), "Original input changed.");
            using var preview = reopened.Slides[0].GetImage(new Size(640, 360));
            preview.Save("translated.png", Aspose.Slides.ImageFormat.Png);
            Require(Requests.Any(r => r.StatusCode == 200), "No real translation response.");
            Report(new { translated_shape_group_table = true, original_unchanged = true, reopened_text_matches = true, position_retained = true, text = translated, requests = Requests.ToArray() });
            return 0;
        }
        catch (Exception error)
        {
            int exit = error is OperationCanceledException ? 4 : error is HttpRequestException ? 3 : 2;
            File.WriteAllText("error.json", JsonSerializer.Serialize(new { error_type = error.GetType().Name, requests = Requests.ToArray(), exit_code = exit }));
            Console.Error.WriteLine("AI example failed: " + error.GetType().Name + ". Check configuration and provider access.");
            return exit;
        }
    }
}
