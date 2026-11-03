using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Warnings;

internal static partial class Program
{
    private static Task<int> Main(string[] args) => RunChecked(args);
    private sealed class WarningLog : IWarningCallback
    {
        public List<string> Messages { get; } = new List<string>();

        public ReturnAction Warning(IWarningInfo warning)
        {
            Messages.Add(warning.Description);
            return ReturnAction.Continue;
        }
    }

    private static void LoadCustomFonts()
    {
        LoadVerifiedFonts("NotoSans-Regular.ttf", "NotoNaskhArabic-Regular.ttf", "NotoSansCJKsc-Regular.otf");
        try
        {
            using (var source = new Presentation())
            {
                source.SlideSize.SetSize(640, 360, SlideSizeScaleType.DoNotScale);
                var text = Label(source.Slides[0], "Latin مرحبا 中文");
                text.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData("Missing Example Font 42");
                source.Save("input.pptx", SaveFormat.Pptx);
            }

            var log = new WarningLog();
            using var presentation = new Presentation("input.pptx", new LoadOptions { WarningCallback = log });
            byte[] loaded = presentation.FontsManager.GetFontBytes(new FontData("Noto Sans"), FontStyleType.Regular);
            Require(Convert.ToHexString(SHA256.HashData(loaded)).ToLowerInvariant() == Hash("fonts/NotoSans-Regular.ttf"), "Requested custom font did not resolve to the supplied file.");
            presentation.Save("missing-font.pdf", SaveFormat.Pdf, new PdfOptions { WarningCallback = log });
            Require(log.Messages.Count > 0, "The deliberately missing font did not produce a warning.");
            var substitutions = new FontSubstRuleCollection();
            substitutions.Add(new FontSubstRule(new FontData("Missing Example Font 42"), new FontData("Noto Sans"), FontSubstCondition.WhenInaccessible));
            presentation.FontsManager.FontSubstRuleList = substitutions;
            var fallback = new FontFallBackRulesCollection();
            fallback.Add(new FontFallBackRule(0x0600, 0x06FF, "Noto Naskh Arabic"));
            fallback.Add(new FontFallBackRule(0x4E00, 0x9FFF, "Noto Sans CJK SC"));
            presentation.FontsManager.FontFallBackRulesCollection = fallback;
            presentation.Save("fallback.pdf", SaveFormat.Pdf, new PdfOptions { WarningCallback = log });
            Render(presentation.Slides[0], "preview.png");
            File.WriteAllText("warnings.txt", string.Join(Environment.NewLine, log.Messages));
            Report(new { loaded_font_bytes_match = true, warning_received = true, substitution_rule = true, arabic_cjk_fallback = true });
        }
        finally
        {
            FontsLoader.ClearCache();
        }
    }
}
