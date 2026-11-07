---
title: Low-Code presentationsoperationer i .NET
linktitle: Low-Code API
type: docs
weight: 50
url: /sv/net/low-code-presentation-operations/
keywords:
- low-code presentations-API
- konvertera presentation
- sammanfoga presentationer
- iterera bilder
- iterera former
- iterera text
- samla former
- komprimera presentation
- ta bort oanvända masterbilder
- ta bort oanvända layoutbilder
- komprimera inbäddade teckensnitt
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Använd Aspose.Slides low-code API i .NET för att konvertera och sammanfoga presentationer, iterera genom innehåll, samla former och minska presentationsstorlek."
---
## **Översikt**

Namnområdet [Aspose.Slides.LowCode](https://reference.aspose.com/slides/net/aspose.slides.lowcode/) tillhandahåller statiska hjälparklasser för vanliga presentationsoperationer. Dessa hjälparklasser kapslar in vanliga arbetsflöden i objektmodellen i fokuserade metoder, så att du kan konvertera eller slå ihop filer, bearbeta presentationselement, samla former och ta bort oanvänt innehåll med mindre kod.

Low-code‑hjälparna är mest användbara när operationen gäller en hel fil eller presentation och standardarbetsflödet matchar dina krav. Använd hela [Aspose.Slides object model](https://reference.aspose.com/slides/net/aspose.slides/) när du behöver finjusterad kontroll över enskilda bilder, masterbilder, layouter, former, exportinställningar eller relationer mellan presentationselement.

Följande tabell sammanfattar de tillgängliga hjälparna:

| Hjälpare | Använd för |
| --- | --- |
| [Konvertera](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/) | Konvertera en presentation till ett annat format med ett direkt fil‑till‑fil‑anrop. |
| [Sammanfoga](https://reference.aspose.com/slides/net/aspose.slides.lowcode/merger/) | Kombinera hela presentationsfiler av samma format. |
| [FörVarje](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/) | Kör en åtgärd för varje bild, form, stycke eller textdel. |
| [Samla](https://reference.aspose.com/slides/net/aspose.slides.lowcode/collect/) | Hämtar former från hela presentationen för upprepad bearbetning eller analys. |
| [Komprimera](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) | Tar bort oanvända master-/layouter, minskar inbäddade teckensnittsdata och komprimerar bilder. |

## **Konvertera en presentation**

Använd [Convert.AutoByExtension](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/autobyextension/) när filändelsen för utdata är tillräcklig för att välja exportformatet. Metoden öppnar källpresentationen, bestämmer det erforderliga formatet från utdatavägen och skriver resultatet.

```csharp
using Aspose.Slides.LowCode;

Convert.AutoByExtension("input.pptx", "output.pdf");
```

Klassen [Convert](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/) erbjuder också dedikerade metoder för PDF, SVG, JPEG, PNG och TIFF‑utdata. Använd hela objektmodellen när du behöver inspektera eller ändra presentationen innan export eller konfigurera ett exportalternativ som inte exponeras av den valda hjälparen. Se [Convert Presentation](/slides/sv/net/convert-presentation/) för format‑specifika arbetsflöden och alternativ.

## **Sammanfoga presentationer**

Använd [Merger.Process](https://reference.aspose.com/slides/net/aspose.slides.lowcode/merger/process/) för att kombinera hela presentationsfiler med ett anrop. Ingångspresentationerna måste ha samma filformat.

```csharp
using Aspose.Slides.LowCode;

var inputFiles = new[] { "part-1.pptx", "part-2.pptx" };
Merger.Process(inputFiles, "merged.pptx");
```

Hjälparen är lämplig när alla bilder ska läggas till i ett resultat utan att välja eller ommappa dem individuellt. Använd hela objektmodellen när du behöver slå ihop utvalda bilder, tillämpa ett destinations‑master eller -layout, bevara sektioner explicit eller hantera olika bildstorlekar. Se [Merge Presentations](/slides/sv/net/merge-presentation/) för dessa scenarier.

## **Iterera genom presentationselement**

Klassen [ForEach](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/) anropar en återuppringning för varje begärt typ av presentationselement. Den undviker nästlade samlingsloopar och är bekväm för presentations‑omfattande inspektion eller formatändringar.

Följande exempel använder [ForEach.Slide](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/slide/), [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/paragraph/) och [ForEach.Portion](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/portion/) för att inspektera de motsvarande elementen:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

ForEach.Slide(presentation, (slide, index) =>
{
    Console.WriteLine($"Slide {index}: {slide.Shapes.Count} shapes");
});

ForEach.Shape(presentation, (shape, slide, index) =>
{
    Console.WriteLine($"Shape {index} on {slide.GetType().Name}: {shape.Name}");
});

ForEach.Paragraph(presentation, (paragraph, slide, index) =>
{
    Console.WriteLine($"Paragraph {index} on {slide.GetType().Name}: {paragraph.Text}");
});

ForEach.Portion(presentation, (portion, paragraph, slide, index) =>
{
    Console.WriteLine($"Portion {index} on {slide.GetType().Name}: {portion.Text}");
});
```

Som standard inkluderar traversering av former och text på presentationsnivå normala, master‑ och layoutbilder. Överlagringar med en `includeNotes`‑parameter kan också bearbeta notisbilder. Använd direkta samlingsloopar när traverseringsordning, tidig avbrytning, filtrering före återuppringning eller detaljerad förälder‑barn‑kontroll är viktigt.

## **Samla former**

Använd [Collect.Shapes](https://reference.aspose.com/slides/net/aspose.slides.lowcode/collect/shapes/) när du behöver en samling av alla former i en presentation snarare än en återuppringning för varje form. Detta är användbart när samma uppsättning ska filtreras, räknas eller bearbetas mer än en gång.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
var shapes = Collect.Shapes(presentation);

foreach (var shape in shapes)
{
    Console.WriteLine($"{shape.Name}: {shape.GetType().Name}");
}
```

Använd [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/) istället när varje form kan hanteras omedelbart och du inte behöver behålla det insamlade resultatet.

## **Komprimera presentationsinnehåll**

Klassen [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) kan ta bort oanvända struktur‑element och minska inbäddade teckensnittsdata:

- [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) tar bort layoutbilder som ingen normal bild refererar till.
- [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) tar bort masterbilder som inte längre används.
- [Compress.CompressEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressembeddedfonts/) tar bort oanvända tecken från inbäddade teckensnitt.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

Compress.RemoveUnusedLayoutSlides(presentation);
Compress.RemoveUnusedMasterSlides(presentation);
Compress.CompressEmbeddedFonts(presentation);

presentation.Save("compressed.pptx", SaveFormat.Pptx);
```

Ta bort oanvända layouter innan oanvända masterbilder så att en master som blir orefererad efter layout‑städning också kan tas bort. Spara den optimerade presentationen till en ny fil om du kan behöva de ursprungliga masterna, layouterna eller hela de inbäddade teckensnittsdata senare. För mer detaljer, se [Slide Master](/slides/sv/net/slide-master/) och [Embedded Font](/slides/sv/net/embedded-font/).

### **Komprimera hela presentationen**

Aspose.Slides for .NET 26.11 lägger till [Compress.CompressPresentation](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compresspresentation/). Den kombinerar borttagning av oanvända layout-/master‑bilder, delmängdsbildning av inbäddade teckensnitt till använda tecken och bildkomprimering på 150 DPI. Använd de individuella operationerna ovan när du behöver styra vilka förändringar som appliceras.

Installera [Aspose.Slides for .NET](/slides/sv/net/installation/) 26.11 eller senare och ange `input.pptx`. Spara till en separat fil: borttagna layouter, teckensnittstecken och beskurna bildpixlar kan behövas för senare redigering.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressPresentation(presentation);
presentation.Save("compressed.pptx", SaveFormat.Pptx);
```

### **Komprimera bilder med vald upplösning**

Använd [Compress.CompressImages](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressimages/) för att bearbeta berättigade bilder utan att också ta bort layouter eller skapa delmängder av teckensnitt. Detta exempel använder 96 DPI; välj ett annat [PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/picturescompression/)‑värde för dina utdata‑behov.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressImages(presentation, PicturesCompression.Dpi96);
presentation.Save("compressed-images.pptx", SaveFormat.Pptx);
```

Båda hjälparna använder följande bild‑bearbetningsomfång:

| Innehåll | Behandling |
| --- | --- |
| Rasterbilder och bildfyllningar i former på vanliga, master‑ och layoutbilder, inklusive grupperade former | Kvalificerade för komprimering. |
| Bilder som redan är på eller under den begärda upplösningen | Inte uppskalade. Beskurna områden kan fortfarande tas bort. |
| Beskurna bildområden | Dolda pixlar tas permanent bort och beskärningsoffsets återställs. |
| Bildbakgrunder och tabellcellfyllningar | Bearbetas inte av dessa hjälpar. |
| Diagram/SmartArt-interna, GIF‑ och vektorformat som SVG, EMF och WMF | Utanför det dokumenterade bildkomprimeringsområdet. |

I 26.11 undviker [PicturesCompression.DocumentResolution](https://reference.aspose.com/slides/net/aspose.slides.export/picturescompression/) upplösnings‑baserad ner-sampling av en obehandlad bild, men **bevarar inte beskurna pixlar**. En beskuren bild kan fortfarande skrivas om med dess dolda områden borttagna. Ingen av hjälparna exponerar ett bevara‑beskär‑alternativ. För individuell kontroll, se [per-picture compression example](/slides/sv/net/examples/optimization-batch/compression/).

Jämför utdata‑utseendet och filstorleken innan du ersätter originalet. Besparingar beror på källbilderna, deras visade storlek och oanvänt innehåll; komprimering garanterar inte en mindre fil. Se [Embedded Fonts](/slides/sv/net/embedded-font/) för implikationerna av teckensnitts‑delmängdsbildning.

## **Vanliga frågor**

**När bör jag använda low-code‑API:t istället för hela objektmodellen?**

Använd low-code‑hjälparna när en standardoperation gäller en komplett fil eller presentation och inte kräver detaljerad kontroll över enskilda element. Använd hela objektmodellen när du måste välja specifika bilder, styra master‑ och layout‑relationer, inspektera mellanliggande tillstånd eller konfigurera beteende som inte exponeras av hjälparen.

**Kan Merger kombinera presentationer i olika filformat?**

Nej. [Merger.Process](https://reference.aspose.com/slides/net/aspose.slides.lowcode/merger/process/) kräver att ingångspresentationerna har samma format. Konvertera först indata‑filerna till ett gemensamt format, till exempel med [Convert.AutoByExtension](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/autobyextension/), och slå sedan samman de konverterade filerna.

**Bearbetar ForEach master-, layout- och notisbilder?**

[ForEach.Slide](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/slide/) itererar genom vanliga presentationsbilder. Presentations‑omfattande [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/paragraph/) och [ForEach.Portion](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/portion/) inkluderar normala, master‑ och layoutbilder som standard. Använd deras överlagringar med `includeNotes` satt till `true` för att inkludera notisbilder.

**Vad är skillnaden mellan ForEach.Shape och Collect.Shapes?**

Använd [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/) för att bearbeta varje form omedelbart via en återuppringning. Använd [Collect.Shapes](https://reference.aspose.com/slides/net/aspose.slides.lowcode/collect/shapes/) när du behöver ett enumererbart resultat som kan behållas, filtreras, räknas eller traverseras flera gånger.

**Gör Compress alltid presentationsfilen mindre?**

Inte nödvändigtvis. Besparingar beror på oanvända layouter/mastrar, inbäddade teckensnitt med oanvända tecken och bilder som drar nytta av komprimering. [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/)-hjälparna kan lämna storleken oförändrad eller till och med skapa en större fil för vissa indata. Jämför både storlek och renderad kvalitet, och behåll originalet.

**Sparas förändringar gjorda av ForEach eller Compress automatiskt?**

Nej. Dessa hjälpar arbetar på det inlästa [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑objektet i minnet. Efter att ha ändrat element i ett [ForEach](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/)-callback eller kört [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/), anropa [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) för att skriva resultatet.

## **Relaterade artiklar**

- [Konvertera presentation](/slides/sv/net/convert-presentation/)
- [Sammanfoga presentationer](/slides/sv/net/merge-presentation/)
- [Slide Master](/slides/sv/net/slide-master/)
- [Hantera textruta](/slides/sv/net/manage-textbox/)
- [Inbäddat teckensnitt](/slides/sv/net/embedded-font/)