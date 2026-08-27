---
title: Konvertera PowerPoint-presentationer till Markdown i .NET
linktitle: PowerPoint till Markdown
type: docs
weight: 140
url: /sv/net/convert-powerpoint-to-markdown/
keywords:
- konvertera PowerPoint
- konvertera presentation
- konvertera bild
- konvertera PPT
- konvertera PPTX
- PowerPoint till MD
- presentation till MD
- bild till MD
- PPT till MD
- PPTX till MD
- spara PowerPoint som Markdown
- spara presentation som Markdown
- spara bild som Markdown
- spara PPT som MD
- spara PPTX som MD
- exportera PPT till MD
- exportera PPTX till MD
- Markdown-bildexport
- CDN-bildlänkar
- PowerPoint
- presentation
- Markdown
- .NET
- C#
- Aspose.Slides
description: "Konvertera PPT- och PPTX-presentationer till Markdown i .NET och kontrollera var exporterade bitmap-, metafil- och SVG-bilder sparas och refereras."
---
## **Översikt**

Aspose.Slides for .NET kan konvertera PPT‑ och PPTX‑presentationer till Markdown för dokumentation, statiska webbplatser, innehållsmigrering och versionskontrollarbetsflöden. Du kan välja en Markdown‑smak, styra hur bildinnehåll renderas och bestämma var exporterade bilder lagras samt hur den genererade Markdown‑referensen till dem ser ut.

Som standard använder Markdown‑export endast textutdata. För att exportera visuellt innehåll, sätt egenskapen [MarkdownSaveOptions.ExportType](https://reference.aspose.com/slides/sv/net/aspose.slides.export/markdownsaveoptions/exporttype/) till värdet `Sequential` eller `Visual` från uppräkningen [MarkdownExportType](https://reference.aspose.com/slides/sv/net/aspose.slides.export/markdownexporttype/). `Sequential` renderar bildobjekt separat och i ordning, medan `Visual` behåller grupperade objekt tillsammans för att bevara deras visuella relation. Värdet `TextOnly` emitterar inte bildresurser, så händelserna för bildsparning utlöses inte i det läget.

## **Konvertera en presentation till Markdown**

Läs in källfilen med klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/) och anropa sedan metoden [Presentation.Save](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/save/) med värdet `Md` från uppräkningen [SaveFormat](https://reference.aspose.com/slides/sv/net/aspose.slides.export/saveformat/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.md", SaveFormat.Md);
```

## **Välj en Markdown‑smak**

Egenskapen [MarkdownSaveOptions.Flavor](https://reference.aspose.com/slides/sv/net/aspose.slides.export/markdownsaveoptions/flavor/) styr vilken Markdown‑specifikation som används för utdata. Uppräkningen [Flavor](https://reference.aspose.com/slides/sv/net/aspose.slides.export/flavor/) innehåller CommonMark, GitHub Flavored Markdown och andra stödjade varianter.

Följande exempel exporterar en presentation som CommonMark:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var options = new MarkdownSaveOptions
{
    Flavor = Flavor.CommonMark
};

presentation.Save("presentation.md", SaveFormat.Md, options);
```

## **Exportera bilder med standardbeteendet för lokal lagring**

Klassen [MarkdownSaveOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/markdownsaveoptions/) tillhandahåller två egenskaper för lokalt sparade bilder:

- [BasePath](https://reference.aspose.com/slides/sv/net/aspose.slides.export/markdownsaveoptions/basepath/) anger baskatalogen för Markdown‑dokumentet och dess resurser.
- [ImagesSaveFolderName](https://reference.aspose.com/slides/sv/net/aspose.slides.export/markdownsaveoptions/imagessavefoldername/) anger bildundermappen. Standardvärdet är `Images`.

Följande exempel renderar visuellt innehåll, skriver bilder till `output/assets` och skapar relativa bildreferenser i Markdown‑dokumentet:

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

const string outputDirectory = "output";
Directory.CreateDirectory(outputDirectory);

using var presentation = new Presentation("presentation.pptx");
var options = new MarkdownSaveOptions
{
    ExportType = MarkdownExportType.Visual,
    BasePath = outputDirectory,
    ImagesSaveFolderName = "assets"
};

var markdownPath = Path.Combine(outputDirectory, "presentation.md");
presentation.Save(markdownPath, SaveFormat.Md, options);
```

Detta beteende fungerar också som återfall när en anpassad bildsparnings‑hanterare returnerar `false`.

## **Anpassa bildlagring och Markdown‑länkar**

Använd händelsen [MarkdownSaveOptions.ImageSaving](https://reference.aspose.com/slides/sv/net/aspose.slides.export/markdownsaveoptions/imagesaving/) för icke‑SVG‑bitmap‑ och metafilresurser som emitteras under Markdown‑export. Dess delegat [MarkdownImageSavingHandler](https://reference.aspose.com/slides/sv/net/aspose.slides.export/markdownsaveoptions.markdownimagesavinghandler/) får ett [IImage](https://reference.aspose.com/slides/sv/net/aspose.slides/iimage/)‑objekt, dess [ImageFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/imageformat/), och den genererade Markdown‑länken som en `ref string`‑parameter. Spara eller ladda upp bilden med det angivna formatet och ersätt `link` med referensen som ska förekomma i Markdown‑utdata.

Resurser som emitteras i SVG‑format hanteras separat. Prenumerera på händelsen [MarkdownSaveOptions.SvgImageSaving](https://reference.aspose.com/slides/sv/net/aspose.slides.export/markdownsaveoptions/svgimagesaving/), vars delegat [MarkdownSvgImageSavingHandler](https://reference.aspose.com/slides/sv/net/aspose.slides.export/markdownsaveoptions.markdownsvgimagesavinghandler/) får ett [ISvgImage](https://reference.aspose.com/slides/sv/net/aspose.slides/isvgimage/)‑objekt och parametern `ref string link`. En SVG har inget `ImageFormat`‑argument; skriv eller ladda upp dess XML‑data från egenskapen [ISvgImage.SvgData](https://reference.aspose.com/slides/sv/net/aspose.slides/isvgimage/svgdata/) istället. Beroende på exportläge och visuell gruppering kan en SVG i källpresentationen rasteriseras eller kombineras med annat innehåll; den resulterande icke‑SVG‑resursen skickas sedan till `ImageSaving`. Prenumerera på båda händelserna när varje exporterad visuell resurs kräver anpassad behandling.

Hanterarens returvärde avgör vem som behandlar bilden:

- Returnera `true` efter att hanteraren har sparat, laddat upp, transformerat eller på annat sätt bearbetat bilden och tilldelat ett giltigt värde till `link`. Aspose.Slides skriver det värdet till Markdown‑dokumentet och utför inte den lokala standardsparningen.
- Returnera `false` för att låta Aspose.Slides spara bilden lokalt och generera dess länk enligt [MarkdownSaveOptions.BasePath](https://reference.aspose.com/slides/sv/net/aspose.slides.export/markdownsaveoptions/basepath/) och [MarkdownSaveOptions.ImagesSaveFolderName](https://reference.aspose.com/slides/sv/net/aspose.slides.export/markdownsaveoptions/imagessavefoldername/).

{{% alert color="warning" title="Viktigt" %}}
En hanterare som returnerar `true` tar ansvar för bilden. Om den returnerar `true` utan att tilldela en giltig, icke‑tom länk misslyckas exporten med ett `InvalidOperationException`.
{{% /alert %}}

### **Spara bilder till en CDN‑ursprungs‑katalog och använd externa URL‑er**

Följande exempel behandlar `cdn-origin/presentations/quarterly-report` som en monterad eller synkroniserad CDN‑ursprungs‑katalog. Varje hanterare extraherar det genererade filnamnet, sparar bilden i den anpassade katalogen och ersätter den genererade lokala referensen med en offentlig CDN‑URL. Själva exemplet utför ingen nätverksuppladdning: URL‑en blir giltig först när katalogen är monterad som CDN‑ursprung eller dess filer publiceras till CDN. För objektlagring ersätt filsystems‑skrivet med lagrings‑SDK:ns uppladdningsoperation och tilldela `link` först när uppladdningen lyckas.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

const string outputDirectory = "output";
const string publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
var storageDirectory = Path.Combine("cdn-origin", "presentations", "quarterly-report");
Directory.CreateDirectory(outputDirectory);
Directory.CreateDirectory(storageDirectory);

static string GetFileNameFromLink(string generatedLink)
{
    var urlCompatibleLink = generatedLink.Replace('\\', '/');
    return urlCompatibleLink[(urlCompatibleLink.LastIndexOf('/') + 1)..];
}

static string BuildPublicUrl(string baseUrl, string fileName)
{
    return $"{baseUrl}/{Uri.EscapeDataString(fileName)}";
}

using var presentation = new Presentation("presentation.pptx");
var options = new MarkdownSaveOptions
{
    ExportType = MarkdownExportType.Visual,
    BasePath = outputDirectory,
    ImagesSaveFolderName = "fallback-images"
};

options.ImageSaving += (IImage image, ImageFormat format, ref string link) =>
{
    if (image.Width < 128 || image.Height < 128)
    {
        return false;
    }

    var fileName = GetFileNameFromLink(link);
    var storagePath = Path.Combine(storageDirectory, fileName);
    image.Save(storagePath, format);
    link = BuildPublicUrl(publicBaseUrl, fileName);
    return true;
};

options.SvgImageSaving += (ISvgImage svgImage, ref string link) =>
{
    var fileName = GetFileNameFromLink(link);
    var storagePath = Path.Combine(storageDirectory, fileName);
    File.WriteAllBytes(storagePath, svgImage.SvgData);
    link = BuildPublicUrl(publicBaseUrl, fileName);
    return true;
};

var markdownPath = Path.Combine(outputDirectory, "presentation.md");
presentation.Save(markdownPath, SaveFormat.Md, options);
```

Bitmap‑hanteraren returnerar medvetet `false` för bilder mindre än 128 × 128 pixlar, så Aspose.Slides sparar dessa bilder i `output/fallback-images` med standardbeteendet. Större bitmap‑ och metafilresurser samt SVG‑resurser hanteras av den anpassade koden. Till exempel blir en genererad lokal referens som `fallback-images/image1.png` till `https://cdn.example.com/presentations/quarterly-report/image1.png`. Hanterarna använder operativsystemets sökvägar endast när filer skrivs; länkar i Markdown använder snedstreck och URL‑kodade filnamn. Tillämpa samma regel när du bygger relativa länkar: använd `/`, inte plattforms‑specifika katalogseparatorer.

## **Vanliga frågor**

**Kan en hanterare bearbeta både rasterbilder och SVG‑bilder?**  
Nej. Använd [MarkdownSaveOptions.ImageSaving](https://reference.aspose.com/slides/sv/net/aspose.slides.export/markdownsaveoptions/imagesaving/) för emitterade bitmap‑ och metafilresurser och [MarkdownSaveOptions.SvgImageSaving](https://reference.aspose.com/slides/sv/net/aspose.slides.export/markdownsaveoptions/svgimagesaving/) för resurser som emitteras som SVG. Den förra levererar ett [IImage](https://reference.aspose.com/slides/sv/net/aspose.slides/iimage/)‑objekt och ett [ImageFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/imageformat/); den senare levererar ett [ISvgImage](https://reference.aspose.com/slides/sv/net/aspose.slides/isvgimage/)‑objekt vars SVG‑data kan läsas från [ISvgImage.SvgData](https://reference.aspose.com/slides/sv/net/aspose.slides/isvgimage/svgdata/). En käll‑SVG som rasteriseras under export bearbetas av `ImageSaving` istället.

**Vad händer när en bildsparande‑hanterare returnerar `false`?**  
Aspose.Slides använder sitt standardbeteende för lokal lagring. Bildplatsen och den genererade referensen styrs av [MarkdownSaveOptions.BasePath](https://reference.aspose.com/slides/sv/net/aspose.slides.export/markdownsaveoptions/basepath/) och [MarkdownSaveOptions.ImagesSaveFolderName](https://reference.aspose.com/slides/sv/net/aspose.slides.export/markdownsaveoptions/imagessavefoldername/).

**Kan en hanterare tillhandahålla en URL utan att spara bilden lokalt?**  
Ja. Hanteraren kan ladda upp bilden till objektlagring eller skicka den till en annan tjänst, tilldela den resulterande URL‑en till `link` och returnera `true`. Hanteraren måste slutföra behandlingen själv; att returnera `true` förhindrar den lokala standardsparningen.

**Varför kastar Markdown‑export ett `InvalidOperationException` från en hanterare?**  
Detta undantag uppstår när hanteraren returnerar `true` men inte tillhandahåller en giltig länk. Tilldela den relativa sökvägen eller externa URL‑en som ska skrivas till Markdown innan du returnerar `true`.

**Vilken sökvägsseparator bör bildlänkar använda?**  
Använd snedstreck (`/`) i Markdown‑länkar och URL‑er. Använd `Path.Combine` endast för filsystem‑sökvägar och bygg eller normalisera sedan Markdown‑referensen separat.

**Bevaras hyperlänkar under Markdown‑export?**  
Ja. Text [hyperlänkar](/slides/sv/net/manage-hyperlinks/) bevaras som vanliga Markdown‑länkar. Bild [övergångar](/slides/sv/net/slide-transition/) och [animationer](/slides/sv/net/powerpoint-animation/) konverteras inte.

**Kan presentationer konverteras till Markdown parallellt?**  
Du kan bearbeta olika presentationsfiler parallellt, men dela inte samma [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/)‑instans mellan trådar. Följ [multithreading guidelines](/slides/sv/net/multithreading/) och använd en separat instans för varje fil.