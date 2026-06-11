---
title: Konvertera PowerPoint-presentationer till HTML i .NET
linktitle: PowerPoint till HTML
type: docs
weight: 30
url: /sv/net/convert-powerpoint-to-html/
keywords:
- konvertera PowerPoint
- konvertera presentation
- konvertera bild
- konvertera PPT
- konvertera PPTX
- PowerPoint till HTML
- presentation till HTML
- bild till HTML
- PPT till HTML
- PPTX till HTML
- spara PowerPoint som HTML
- spara presentation som HTML
- spara bild som HTML
- spara PPT som HTML
- spara PPTX som HTML
- exportera PPT till HTML
- exportera PPTX till HTML
- .NET
- C#
- Aspose.Slides
description: "Konvertera PowerPoint-presentationer till HTML i .NET. Använd Aspose.Slides för att exportera PPT- och PPTX-filer, valda bilder, anteckningar, teckensnitt, bilder, SVG och media."
---
## **Översikt**

Aspose.Slides för .NET kan spara PowerPoint-presentationer som HTML utan Microsoft PowerPoint. Grundkonverteringen är en enda [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/) laddning och ett [Save](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/save/) anrop med [SaveFormat](https://reference.aspose.com/slides/sv/net/aspose.slides.export/saveformat/). Använd [HtmlOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/htmloptions/) när du behöver kontrollera det exporterade layouten, teckensnitt, bilder, anteckningar, kommentarer, SVG-utdata eller länkade resurser.

Denna guide fokuserar på praktiska HTML-exportscenarier:

- Exportera en hel presentation eller utvalda bilder.
- Generera HTML med fast layout, responsiv eller SVG-baserad.
- Inkludera föreläsaranteckningar och kommentarer.
- Kontrollera bildkvalitet och beskurna bilddata.
- Bädda in teckensnitt eller spara teckensnittsfiler separat.
- Välj hur externa resurser och mediafiler skrivs och refereras.

Som standard producerar HTML-export ett självständigt HTML-dokument där de flesta resurser är inbäddade. Detta är praktiskt för att dela en enda fil, men kan öka utdata storlek. För web publicering, överväg externa resurser, lägre bild-DPI och endast bädda in teckensnitt som inte är pålitligt tillgängliga i målmiljön.

## **Konvertera en presentation till HTML**

För att exportera en presentation till HTML, ladda den med [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/) och spara den med [SaveFormat.Html](https://reference.aspose.com/slides/sv/net/aspose.slides.export/saveformat/).

```csharp
using var presentation = new Presentation("presentation.pptx");

presentation.Save("presentation.html", SaveFormat.Html);
```

Detta exempel skriver en HTML-fil. presentationsobjektet tas bort av `using`-deklarationen, som frigör filhandtag och renderingsresurser efter export.

## **Använd HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/htmloptions/) är huvudkonfigurationsklassen för HTML-export. Vanliga inställningar inkluderar:

- `SlidesLayoutOptions`: lägger till anteckningar, kommentarer, handouts eller annan layoutinformation.
- `HtmlFormatter`: förändrar HTML-dokumentets struktur eller delegerar formatering till en kontroller.
- `SlideImageFormat`: förändrar hur bilder representeras, till exempel som SVG.
- `PicturesCompression`: styr bild-DPI och utdata storlek.
- `DeletePicturesCroppedAreas`: behåller eller tar bort beskurna bilddata.
- `SvgResponsiveLayout`: får exporterad SVG-innehåll att anpassa sig till sin container.
- `ShowHiddenSlides`: inkluderar dolda bilder när det behövs.

Följande sektioner visar de vanligaste alternativen separat så att du kan kombinera endast de som ditt arbetsflöde behöver.

## **Konvertera valda bilder till HTML**

Den [Presentation.Save](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/save/) överlagring som accepterar bildnummer använder 1-baserade bildpositioner. Loopen nedan sparar varje bild till en separat HTML-fil.

```csharp
using var presentation = new Presentation("presentation.pptx");

var slideCount = presentation.Slides.Count;

for (var slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    var slideNumber = slideIndex + 1;
    var slideNumbers = new[] { slideNumber };
    var htmlFileName = $"slide-{slideNumber}.html";

    presentation.Save(htmlFileName, slideNumbers, SaveFormat.Html);
}
```

Använd detta mönster när en webbplats eller applikation behöver en HTML-sida per bild. Om varje bild ska ha samma layout, skapa en [HtmlOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/htmloptions/) instans och skicka den till varje `Save`-anrop.

## **Skapa responsiv HTML**

[ResponsiveHtmlController](https://reference.aspose.com/slides/sv/net/aspose.slides.export/responsivehtmlcontroller/) tillhandahåller responsiv HTML-utdata via [HtmlFormatter](https://reference.aspose.com/slides/sv/net/aspose.slides.export/htmlformatter/). Använd den när den exporterade sidan bör anpassas bättre till webbläsarens bredd.

```csharp
using var presentation = new Presentation("presentation.pptx");

var controller = new ResponsiveHtmlController();
var formatter = HtmlFormatter.CreateCustomFormatter(controller);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

presentation.Save("presentation-responsive.html", SaveFormat.Html, htmlOptions);
```

För SVG-baserad responsiv layout, sätt `SvgResponsiveLayout` på [HtmlOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/htmloptions/). Detta är användbart när bildinnehållet exporteras som skalbar SVG-markup.

```csharp
using var presentation = new Presentation("presentation.pptx");

var htmlOptions = new HtmlOptions
{
    SvgResponsiveLayout = true
};

presentation.Save("presentation-svg-responsive.html", SaveFormat.Html, htmlOptions);
```

## **Inkludera föreläsaranteckningar och kommentarer**

Använd [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/notescommentslayoutingoptions/) via `HtmlOptions.SlidesLayoutOptions` för att inkludera föreläsaranteckningar eller kommentarer. Anteckningar och kommentarer är dolda som standard om du inte väljer deras positioner.

Anta att källpresentationen innehåller föreläsaranteckningar:

![Bild med föreläsaranteckningar i PowerPoint](slide_with_notes.png)

```csharp
using var presentation = new Presentation("presentation.pptx");

var layoutOptions = new NotesCommentsLayoutingOptions
{
    NotesPosition = NotesPositions.BottomFull
};

var htmlOptions = new HtmlOptions
{
    SlidesLayoutOptions = layoutOptions
};

presentation.Save("presentation-with-notes.html", SaveFormat.Html, htmlOptions);
```

Följande kod exporterar bildinnehållet med föreläsaranteckningar under bilden.

![HTML-utdata med bilden och föreläsaranteckningarna](HTML_with_notes.png)

För att exportera kommentarer, sätt `CommentsPosition`, till exempel till `CommentsPositions.Right` eller `CommentsPositions.Bottom`. Om du bara behöver kommentarer, utelämna `NotesPosition`. Om du behöver både anteckningar och kommentarer, sätt båda egenskaperna.

## **Kontrollera bildkvalitet och beskurna områden**

HTML-export kan komprimera bildbilder för att minska utdata storlek. Sätt `PicturesCompression` till ett värde från [PicturesCompression](https://reference.aspose.com/slides/sv/net/aspose.slides.export/picturescompression/) när du behöver högre bildkvalitet.

```csharp
using var presentation = new Presentation("presentation.pptx");

var htmlOptions = new HtmlOptions
{
    PicturesCompression = PicturesCompression.Dpi150
};

presentation.Save("presentation-dpi-150.html", SaveFormat.Html, htmlOptions);
```

Som standard kan beskurna bildområden tas bort från den exporterade utdata. Behåll beskurna data endast när användare måste kunna återställa eller inspektera dessa dolda bilddelar. Att behålla dem kan öka HTML-storleken.

```csharp
using var presentation = new Presentation("presentation.pptx");

var htmlOptions = new HtmlOptions
{
    DeletePicturesCroppedAreas = false
};

presentation.Save("presentation-with-cropped-areas.html", SaveFormat.Html, htmlOptions);
```

## **Lägg till CSS**

För enkel styling, skicka en CSS-sträng till [HtmlFormatter.CreateDocumentFormatter](https://reference.aspose.com/slides/sv/net/aspose.slides.export/htmlformatter/createdocumentformatter/). Detta förändrar det omgivande HTML-dokumentet medan Aspose.Slides fortsätter rendera bildinnehållet.

```csharp
using var presentation = new Presentation("presentation.pptx");

var cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
var formatter = HtmlFormatter.CreateDocumentFormatter(cssRules, true);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

presentation.Save("presentation-styled.html", SaveFormat.Html, htmlOptions);
```

För ett anpassat dokumenthuvud, en länkad CSS-fil eller anpassad markup runt bilder och former, implementera [IHtmlFormattingController](https://reference.aspose.com/slides/sv/net/aspose.slides.export/ihtmlformattingcontroller/) och skicka den till [HtmlFormatter](https://reference.aspose.com/slides/sv/net/aspose.slides.export/htmlformatter/) med `CreateCustomFormatter`.

## **Bädda in teckensnitt**

Om målmiljön kanske inte har presentationens teckensnitt installerade, bädda in teckensnitt i HTML med [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/sv/net/aspose.slides.export/embedallfontshtmlcontroller/). Inbäddning förbättrar visuell trohet men ökar utdata storlek.

```csharp
using var presentation = new Presentation("presentation.pptx");

string[] fontNamesToExclude = { "Arial", "Calibri" };
var fontController = new EmbedAllFontsHtmlController(fontNamesToExclude);
var formatter = HtmlFormatter.CreateCustomFormatter(fontController);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

presentation.Save("presentation-embedded-fonts.html", SaveFormat.Html, htmlOptions);
```

Uteslut teckensnitt endast när du är säker på att målwebbläsarna eller systemen redan tillhandahåller dem. För varumärkesteckensnitt eller mindre vanliga teckensnitt är inbäddning vanligtvis säkrare.

## **Länka teckensnittsfiler istället för att bädda in dem**

För att minska HTML-filens storlek kan du skriva teckensnittsdata till separata WOFF-filer och lägga till `@font-face` regler i HTML. Hjälpen nedan utökar [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/sv/net/aspose.slides.export/embedallfontshtmlcontroller/) och åsidosätter `WriteFont`.

```cs
using var presentation = new Presentation("presentation.pptx");

var outputDirectory = Path.Combine(Environment.CurrentDirectory, "html-output");
var fontsDirectory = Path.Combine(outputDirectory, "fonts");
Directory.CreateDirectory(outputDirectory);

var fontController = new LinkedFontsHtmlController(fontsDirectory, "fonts");
var formatter = HtmlFormatter.CreateCustomFormatter(fontController);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

var htmlFilePath = Path.Combine(outputDirectory, "presentation.html");
presentation.Save(htmlFilePath, SaveFormat.Html, htmlOptions);
```

```cs
public sealed class LinkedFontsHtmlController : EmbedAllFontsHtmlController
{
    private readonly string _fontOutputDirectory;
    private readonly string _fontUrlPrefix;

    public LinkedFontsHtmlController(
        string fontOutputDirectory,
        string fontUrlPrefix)
        : base(Array.Empty<string>())
    {
        _fontOutputDirectory = fontOutputDirectory;
        _fontUrlPrefix = fontUrlPrefix.TrimEnd('/') + "/";

        Directory.CreateDirectory(_fontOutputDirectory);
    }

    public override void WriteFont(
        IHtmlGenerator generator,
        IFontData originalFont,
        IFontData substitutedFont,
        string fontStyle,
        string fontWeight,
        byte[] fontData)
    {
        var font = substitutedFont ?? originalFont;
        var safeFontName = MakeSafeFileName(font.FontName);
        var safeFontStyle = string.IsNullOrWhiteSpace(fontStyle) ? "normal" : fontStyle;
        var safeFontWeight = string.IsNullOrWhiteSpace(fontWeight) ? "normal" : fontWeight;
        var fontFileName = $"{safeFontName}-{safeFontStyle}-{safeFontWeight}.woff";
        var fontFilePath = Path.Combine(_fontOutputDirectory, fontFileName);

        File.WriteAllBytes(fontFilePath, fontData);

        var fontUrl = _fontUrlPrefix + Uri.EscapeDataString(fontFileName);
        var fontFamily = font.FontName.Replace("\\", "\\\\").Replace("'", "\\'");

        generator.AddHtml("<style>");
        generator.AddHtml("@font-face {");
        generator.AddHtml($"font-family: '{fontFamily}';");
        generator.AddHtml($"font-style: {safeFontStyle};");
        generator.AddHtml($"font-weight: {safeFontWeight};");
        generator.AddHtml($"src: url('{fontUrl}') format('woff');");
        generator.AddHtml("}");
        generator.AddHtml("</style>");
    }

    private static string MakeSafeFileName(string fileName)
    {
        var invalidCharacters = Path.GetInvalidFileNameChars();
        var safeCharacters = fileName.ToCharArray();

        for (var characterIndex = 0; characterIndex < safeCharacters.Length; characterIndex++)
        {
            if (Array.IndexOf(invalidCharacters, safeCharacters[characterIndex]) >= 0)
            {
                safeCharacters[characterIndex] = '_';
            }
        }

        return new string(safeCharacters);
    }
}
```

I detta exempel sparas teckensnittsfiler till `html-output/fonts`, och HTML refererar dem med URL:er som `fonts/BrandFont-normal-400.woff`. Om HTML-filen och teckensnitten distribueras till en annan plats, välj `fontUrlPrefix` så att den matchar den distribuerade URL-sökvägen.

## **Spara resurser externt**

Självständigt HTML är lätt att flytta omkring, men inbäddade Base64-resurser kan göra filen stor. Om din applikation behöver externa bildfiler, implementera [ILinkEmbedController](https://reference.aspose.com/slides/sv/net/aspose.slides.export/ilinkembedcontroller/) och skicka den till [HtmlOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/htmloptions/htmloptions/) konstruktören.

När du externaliserar resurser, välj två sökvägar medvetet:

- Filsystemsutgångssökvägen, där din applikation skriver genererade bilder, teckensnitt, ljud eller video.
- URL-sökvägen, vilket är vad webbläsaren använder från HTML-dokumentet för att ladda dessa filer.

För en komplett bildlänkningsimplementation, se [Export Presentations to HTML with Externally Linked Images](/slides/sv/net/exporting-presentations-to-html-with-externally-linked-images/).

## **Exportera mediafiler**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/sv/net/aspose.slides.export/videoplayerhtmlcontroller/) exporterar video- och ljudfiler och skriver HTML som kan spela dem i en webbläsare. Dess konstruktor tar:

- `path`: katalogen där genererade mediafiler kommer att skrivas.
- `fileName`: HTML-filnamnet som genereras.
- `baseUri`: det absoluta URI-prefixet som används i HTML-länkarna till mediafiler.

Om HTML-filen är `html-output/presentation.html` och mediafiler sparas i `html-output/media`, bör `path` peka på media-katalogen på disk, medan `baseUri` bör peka på samma katalog från webbläsarens perspektiv. För lokal förhandsgranskning kan du bygga en `file:///` URI från media-katalogen. För en distribuerad applikation, använd den absoluta URL:en för den publicerade media-katalogen.

```csharp
var outputDirectory = Path.Combine(Environment.CurrentDirectory, "html-output");
var mediaDirectory = Path.Combine(outputDirectory, "media");
Directory.CreateDirectory(outputDirectory);
Directory.CreateDirectory(mediaDirectory);

var htmlFileName = "presentation.html";
var mediaBaseUri = new Uri(mediaDirectory + Path.DirectorySeparatorChar).AbsoluteUri;

using var presentation = new Presentation();
using var videoStream = new FileStream("intro.mp4", FileMode.Open, FileAccess.Read);

var video = presentation.Videos.AddVideo(videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
var slide = presentation.Slides[0];
slide.Shapes.AddVideoFrame(20, 20, 480, 270, video);

var controller = new VideoPlayerHtmlController(mediaDirectory, htmlFileName, mediaBaseUri);
var formatter = HtmlFormatter.CreateCustomFormatter(controller);
var svgOptions = new SVGOptions(controller);
var slideImageFormat = SlideImageFormat.Svg(svgOptions);

var htmlOptions = new HtmlOptions(controller)
{
    HtmlFormatter = formatter,
    SlideImageFormat = slideImageFormat
};

var htmlFilePath = Path.Combine(outputDirectory, htmlFileName);
presentation.Save(htmlFilePath, SaveFormat.Html, htmlOptions);
```

Använd utdata-kataloger som är unika per exportjobb, särskilt i serverapplikationer. Delade utdata-sökvägar kan leda till att filer från olika konverteringar skrivs över varandra.

## **Prestanda och resursförvaltning**

HTML-konvertering är en renderingsoperation, så behandlingstid och minnesanvändning beror på antal bilder, bildupplösning, teckensnitt, effekter, diagram och inbäddade media. Högre `PicturesCompression` DPI-värden, inbäddade teckensnitt, SVG-utdata och bevarade beskurna bildområden kan förbättra trohet men ökar vanligtvis utdata storlek.

För batchkonvertering:

- Ta bort varje [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/) instans omedelbart.
- Använd separata utdata-kataloger för separata jobb.
- Undvik att bädda in vanliga teckensnitt om inte trohet kräver det.
- Sänk bild-DPI när HTML är för förhandsgranskning eller miniatyrer.
- Behåll källpresentationen, genererad HTML och externa resurser tillsammans tills distributionssökvägarna är slutgiltiga.

## **FAQ**

**Bevaras hyperlänkar i HTML-utdata?**

Ja. Presentationshyperlänkar exporteras till HTML och förblir klickbara när mål-URL:en är giltig.

**Kan jag konvertera presentationer till HTML parallellt?**

Ja, men dela inte en [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/) instans mellan trådar. Processa olika filer med separata presentationsinstanser, separata strömmar och separata utdata-kataloger. Se [multithreading guidance](/slides/sv/net/multithreading/) för detaljer.

**Är ett Presentation-objekt trådsäkert?**

Nej. En enda [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/) instans bör laddas, modifieras, sparas och tas bort på en tråd. För parallellt arbete, skapa en oberoende instans per tråd eller process.

**Varför är den genererade HTML-filen stor?**

Standardexporten kan bädda in resurser direkt i HTML. Inbäddade teckensnitt, hög-DPI-bilder, media, SVG-innehåll och bevarade beskurna bildområden ökar också storleken. Använd externa resurser, uteslut vanliga teckensnitt från inbäddning, och sänk `PicturesCompression` när mindre utdata är viktigare än maximal trohet.

**Varför visas en PowerPoint-typsnittsstorlek såsom 24 pt som 17.999819 pt i HTML?**

Detta kan ske eftersom PowerPoint och HTML använder olika DPI-modeller. PowerPoint lagrar textstorlekar i typografiska punkter baserade på 72 DPI, medan HTML-layout är baserad på CSS-pixlar i en 96 DPI-modell. När Aspose.Slides exporterar en presentation till HTML översätts teckensnittsstorleken mellan dessa system, och konverteringen kan introducera små avrundningsskillnader.

Dessa värden indikerar ingen verklig visuell teckensnittsstorleksändring. De är bara en matematisk bieffekt av att konvertera textmått mellan PowerPoint och HTML.

**Hur ska jag välja baseUri för mediaexport?**

Välj `baseUri` ur webbläsarens perspektiv och skicka den som en absolut URI. För lokal förhandsgranskning kan du härleda den från utdata-katalogen med `new Uri(mediaDirectory + Path.DirectorySeparatorChar).AbsoluteUri`. För distribution, använd den absoluta URL:en till den publicerade media-katalogen. Filsystemets `path` och webbläsarens `baseUri` behöver inte vara samma sträng, men de måste beskriva samma resursplats.

**Kan jag inkludera dolda bilder?**

Ja. Sätt `ShowHiddenSlides = true` på [HtmlOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/htmloptions/) när dolda bilder måste exporteras.