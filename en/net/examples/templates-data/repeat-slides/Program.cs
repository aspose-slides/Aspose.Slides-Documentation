using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

internal static partial class Program
{
    private sealed record Customer(string Name, double Amount, string Color);

    private static Presentation CreateTemplate()
    {
        var presentation = new Presentation();
        var template = presentation.Slides[0];
        Example.Text(template.Shapes, "Customer", "{{Customer}}", 35, 20, 600, 70);
        Example.Chart(template, "Sales");
        byte[] logoBytes = Example.Png(60, 60, Color.Gray);
        var logo = presentation.Images.AddImage(logoBytes);
        template.Shapes.AddPictureFrame(ShapeType.Rectangle, 600, 15, 60, 60, logo).Name = "Logo";
        return presentation;
    }

    private static void Generate(Customer[] customers, string path)
    {
        if (customers.Length == 0)
            return;
        using var presentation = CreateTemplate();
        var template = presentation.Slides[0];
        foreach (var customer in customers)
        {
            var slide = presentation.Slides.AddClone(template);
            var title = Example.Named<IAutoShape>(slide, "Customer");
            var chart = Example.Named<IChart>(slide, "Sales");
            var logo = Example.Named<IPictureFrame>(slide, "Logo");
            title.TextFrame.ReplaceText("{{Customer}}", customer.Name, new TextSearchOptions(), null);
            Example.ChartData(chart, ["Sales"], [customer.Name], [[customer.Amount]]);
            byte[] logoBytes = Example.Png(60, 60, Color.FromName(customer.Color));
            logo.PictureFormat.Picture.Image = presentation.Images.AddImage(logoBytes);
        }
        presentation.Slides.Remove(template);
        presentation.Save(path, SaveFormat.Pptx);
        Example.Render(presentation, path + ".png");
    }

    private static string[] VerifyReport(Customer[] customers, string path)
    {
        using var reopened = new Presentation(path);
        Example.Require(reopened.Slides.Count == customers.Length, "Default/template slide leaked.");
        var names = reopened.Slides.Select(slide => Example.Named<IAutoShape>(slide, "Customer").TextFrame.Text).ToArray();
        for (int i = 0; i < customers.Length; i++)
        {
            var chart = Example.Named<IChart>(reopened.Slides[i], "Sales");
            double amount = Convert.ToDouble(chart.ChartData.Series[0].DataPoints[0].Value.Data);
            Example.Require(amount == customers[i].Amount, "Record state leaked.");
            byte[] expectedLogo = Example.Png(60, 60, Color.FromName(customers[i].Color));
            byte[] savedLogo = Example.Named<IPictureFrame>(reopened.Slides[i], "Logo").PictureFormat.Picture.Image.BinaryData;
            Example.Require(Example.Hash(savedLogo) == Example.Hash(expectedLogo), "Logo differs for customer " + i);
        }
        return names;
    }

    private static void RunExample()
    {
        Example.Setup();
        string json = File.ReadAllText("customers.json");
        var customers = JsonSerializer.Deserialize<Customer[]>(json)
            ?? throw new InvalidDataException("Customer JSON contains no data.");
        if (!Context.IsLicensed)
            customers = customers.Select((customer, i) => customer with { Name = i == 0 ? "Acme" : "東京" }).ToArray();
        Generate(customers, "output/report.pptx");
        Generate(customers, "output/repeated.pptx");
        var first = customers.Length == 0 ? Array.Empty<string>() : VerifyReport(customers, "output/report.pptx");
        var second = customers.Length == 0 ? Array.Empty<string>() : VerifyReport(customers, "output/repeated.pptx");
        if (customers.Length == 0)
        {
            Example.Require(!File.Exists("output/report.pptx") && !File.Exists("output/repeated.pptx"), "Empty customer input produced a deck.");
        }
        Example.Require(first.SequenceEqual(customers.Select(customer => customer.Name)) && first.SequenceEqual(second), "Order or repeatability differs.");
        Generate([], "output/empty.pptx");
        Example.Require(!File.Exists("output/empty.pptx"), "Empty input produced a deck.");
        using var duplicate = new Presentation();
        Example.Text(duplicate.Slides[0].Shapes, "Duplicate", "A");
        Example.Text(duplicate.Slides[0].Shapes, "Duplicate", "B");
        bool rejected = Example.Throws(() => Example.Named<IAutoShape>(duplicate.Slides[0], "Duplicate"));
        Example.Require(rejected, "Duplicate name accepted.");
        Example.Result(new { slide_count = customers.Length, order_preserved = true, no_template_slide = true,
            no_state_leak = true, semantic_repeatability = true, duplicate_name_rejected = rejected });
    }
}
