using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    private static void RunExample()
    {
        DateTime reviewDate = new DateTime(2026, 10, 1, 12, 0, 0, DateTimeKind.Utc);
        using (var created = new Presentation())
        {
            Label(created.Slides[0], "Metadata example");
            created.DocumentProperties.Title = "Original title";
            created.DocumentProperties.Subject = "Retain this subject";
            created.DocumentProperties.SetCustomPropertyValue("Existing", "keep");
            created.Save("input.pptx", SaveFormat.Pptx);
        }
        string inputHash = Hash("input.pptx");
        var info = PresentationFactory.Instance.GetPresentationInfo("input.pptx");
        Require(info.LoadFormat == LoadFormat.Pptx && !info.IsEncrypted, "Unexpected input format/security state.");
        using (var editable = new Presentation("input.pptx"))
        {
            var properties = editable.DocumentProperties;
            properties.Title = "Reviewed presentation";
            properties.Author = "Example author";
            properties.SetCustomPropertyValue("Customer", "Example company");
            properties.SetCustomPropertyValue("Revision", 7);
            properties.SetCustomPropertyValue("Approved", true);
            properties.SetCustomPropertyValue("ReviewDate", reviewDate);
            properties.SetCustomPropertyValue("Total", 123.5);
            editable.Save("output.pptx", SaveFormat.Pptx);
        }
        using (var reopened = new Presentation("output.pptx"))
        {
            var properties = reopened.DocumentProperties;
            properties.GetCustomPropertyValue("Customer", out string customer);
            properties.GetCustomPropertyValue("Revision", out int revision);
            properties.GetCustomPropertyValue("Approved", out bool approved);
            properties.GetCustomPropertyValue("ReviewDate", out DateTime actualDate);
            properties.GetCustomPropertyValue("Total", out double total);
            properties.GetCustomPropertyValue("Existing", out string existing);
            Require(properties.Title == "Reviewed presentation" && properties.Author == "Example author", "Built-in values differ.");
            Require(customer == "Example company" && revision == 7 && approved && actualDate.ToUniversalTime() == reviewDate && total == 123.5, "Typed custom values differ.");
            Require(existing == "keep" && properties.Subject == "Retain this subject", "Unrelated properties changed.");
            Require(reopened.Slides.Count == 1 && Text(reopened.Slides[0]) == Context.ExpectedText("Metadata example"), "Presentation content changed.");
        }
        Require(Hash("input.pptx") == inputHash, "Original metadata file changed.");
        Report(new { built_in_properties = true, string_value = true, integer_value = true, boolean_value = true, date_value = true, numeric_value = true, unrelated_retained = true, content_retained = true, input_format = "Pptx", original_unchanged = true });
    }
}
