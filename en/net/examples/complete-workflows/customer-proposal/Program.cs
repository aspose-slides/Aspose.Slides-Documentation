using System.IO.Compression;
using System.Threading.Tasks;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Drawing;
using System.Security.Cryptography;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;
using Aspose.Slides.Vba;

internal static partial class Program
{
    private static void RunExample()
    {
        var request = JsonDocument.Parse(File.ReadAllText("customer.json")).RootElement;
        string customer = request.GetProperty("customer").GetString()!;
        int[] selected = request.GetProperty("product_indices").EnumerateArray().Select(v => v.GetInt32()).ToArray();
        using (var catalog = Deck("Analytics", "Planning", "Reporting")) catalog.Save("catalog.pptx", SaveFormat.Pptx);
        string original = Hash("catalog.pptx");
        using var source = new Presentation("catalog.pptx");
        Require(selected.All(i => i >= 0 && i < source.Slides.Count), "Unknown product selection.");
        using var proposal = Deck("Proposal for " + customer);
        foreach (int i in selected) proposal.Slides.AddClone(source.Slides[i]);
        proposal.Save("proposal.pptx", SaveFormat.Pptx); proposal.Save("proposal.pdf", SaveFormat.Pdf);
        using var reopened = new Presentation("proposal.pptx");
        Require(reopened.Slides.Count == selected.Length + 1 && Text(reopened.Slides[0]) == Context.ExpectedText("Proposal for " + customer), "Proposal identity or count is wrong.");
        string[] expectedOrder = selected.Select(i => Text(source.Slides[i])).ToArray();
        for (int i = 0; i < expectedOrder.Length; i++)
            Require(Text(reopened.Slides[i + 1]) == expectedOrder[i], "Product order changed.");
        Require(SavedText("proposal.pptx").Contains("Proposal for " + customer), "Persisted customer identity differs.");
        Require(Hash("catalog.pptx") == original, "Catalog was overwritten.");
        Preview(reopened, "preview.png");
        Report(new { customer, product_order = string.Join(",", expectedOrder), slides = reopened.Slides.Count, input_preserved = true });
    }
}
