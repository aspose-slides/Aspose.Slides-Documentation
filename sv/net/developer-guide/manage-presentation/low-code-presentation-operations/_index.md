---
title: Low-Code-presentationer i .NET
linktitle: Low-Code API
type: docs
weight: 50
url: /sv/net/low-code-presentation-operations/
keywords:
- low-code presentations-API
- konvertera presentation
- slå ihop presentationer
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
description: "Använd Aspose.Slides low-code API i .NET för att konvertera och slå ihop presentationer, iterera genom innehåll, samla former och minska presentationsstorleken."
---
## **Översikt**

Namnområdet Aspose.Slides.LowCode tillhandahåller statiska hjälparklasser för vanliga presentationsoperationer. Dessa hjälpare kapslar in ofta använda arbetsflöden i objektmodellen i fokuserade metoder, så att du kan konvertera eller slå ihop filer, bearbeta presentations‑element, samla former och ta bort oanvänt innehåll med mindre kod.

Low‑code‑hjälpare är mest användbara när operationen gäller en hel fil eller presentation och standardarbetsflödet matchar dina krav. Använd den fullständiga Aspose.Slides‑objektmodellen när du behöver fin‑granulär kontroll över enskilda bilder, mästar‑ och layout‑bilder, former, exportinställningar eller relationer mellan presentations‑element.

Den följande tabellen sammanfattar de tillgängliga hjälparna:

| Hjälpare | Använd den för |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/sv/net/aspose.slides.lowcode/convert/) | Konvertera en presentation till ett annat format med ett direkt fil‑till‑fil‑anrop. |
| [Merger](https://reference.aspose.com/slides/sv/net/aspose.slides.lowcode/merger/) | Kombinera hela presentationsfiler av samma format. |
| [ForEach](https://reference.aspose.com/slides/sv/net/aspose.slides.lowcode/foreach/) | Köra en åtgärd för varje bild, form, stycke eller textdel. |
| [Collect](https://reference.aspose.com/slides/sv/net/aspose.slides.lowcode/collect/) | Hämta former från hela presentationen för upprepad bearbetning eller analys. |
| [Compress](https://reference.aspose.com/slides/sv/net/aspose.slides.lowcode/compress/) | Ta bort oanvända mästare och layouter och reducera inbäddade teckensnittsdata. |

## **Konvertera en presentation**

Använd [Convert.AutoByExtension](https://reference.aspose.com/slides/sv/net/aspose.slides.lowcode/convert/autobyextension/) när filändelsen för utdata räcker för att välja exportformatet. Metoden öppnar källpresentationen, bestämmer det erforderliga formatet från sökvägen för utdata och skriver resultatet.

```csharp
using Aspose.Slides.LowCode;

Convert.AutoByExtension("input.pptx", "output.pdf");
```

Klassen [Convert](https://reference.aspose.com/slides/sv/net/aspose.slides.lowcode/convert/) tillhandahåller också dedikerade metoder för PDF, SVG, JPEG, PNG och TIFF‑utdata. Använd den fullständiga objektmodellen när du behöver inspektera eller ändra presentationen innan export eller konfigurera ett exportalternativ som inte exponeras av den valda hjälparen. Se [Convert Presentation](/slides/sv/net/convert-presentation/) för format‑specifika arbetsflöden och alternativ.

## **Slå ihop presentationer**

Använd [Merger.Process](https://reference.aspose.com/slides/sv/net/aspose.slides.lowcode/merger/process/) för att kombinera hela presentationsfiler med ett anrop. Inmatningspresentationerna måste ha samma filformat.

```csharp
using Aspose.Slides.LowCode;

var inputFiles = new[] { "part-1.pptx", "part-2.pptx" };
Merger.Process(inputFiles, "merged.pptx");
```

Hjälparen är lämplig när alla bilder ska läggas till i ett resultat utan att de väljs eller omkartläggs individuellt. Använd den fullständiga objektmodellen när du behöver slå ihop utvalda bilder, tillämpa en destinations‑mästare eller layout, bevara avsnitt explicit, eller förena olika bildstorlekar. Se [Merge Presentations](/slides/sv/net/merge-presentation/) för dessa scenarier.

## **Iterera genom presentations‑element**

Klassen [ForEach](https://reference.aspose.com/slides/sv/net/aspose.slides.lowcode/foreach/) anropar en återuppringning för varje begärd typ av presentations‑element. Den undviker nästlade samlingsloopar och är bekväm för presentation‑omfattande inspektion eller formateringsändringar.

Det följande exemplet använder [ForEach.Slide](https://reference.aspose.com/slides/sv/net/aspose.slides.lowcode/foreach/slide/), [ForEach.Shape](https://reference.aspose.com/slides/sv/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/sv/net/aspose.slides.lowcode/foreach/paragraph/), och [ForEach.Portion](https://reference.aspose.com/slides/sv/net/aspose.slides.lowcode/foreach/portion/) för att inspektera de motsvarande elementen:

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

Som standard inkluderar presentations‑omfattande form‑ och texttraversering normala, mästar‑ och layout‑bilder. Överlagringar med ett `includeNotes`‑parameter kan också bearbeta notisbilder. Använd direkta samlingsloopar när traverseringsordning, tidig avbrytning, filtrering innan återuppringning eller detaljerad förälder‑barn‑kontroll är viktig.

## **Samla former**

Använd [Collect.Shapes](https://reference.aspose.com/slides/sv/net/aspose.slides.lowcode/collect/shapes/) när du behöver en samling av alla former i en presentation snarare än en återuppringning för varje form. Detta är användbart när samma uppsättning kommer att filtreras, räknas eller bearbetas mer än en gång.

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

Använd [ForEach.Shape](https://reference.aspose.com/slides/sv/net/aspose.slides.lowcode/foreach/shape/) istället när varje form kan hanteras omedelbart och du inte behöver behålla det insamlade resultatet.

## **Komprimera presentationsinnehåll**

Klassen [Compress](https://reference.aspose.com/slides/sv/net/aspose.slides.lowcode/compress/) kan ta bort oanvända strukturella element och reducera inbäddade teckensnittsdata:

- [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/sv/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) tar bort layoutbilder som ingen normal bild refererar till.
- [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/sv/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) tar bort mästare som inte längre används.
- [Compress.CompressEmbeddedFonts](https://reference.aspose.com/slides/sv/net/aspose.slides.lowcode/compress/compressembeddedfonts/) tar bort oanvända tecken från inbäddade teckensnitt.

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

Ta bort oanvända layouter innan oanvända mästare så att en mästare som blir orefererad efter layout‑rensning också kan tas bort. Spara den optimerade presentationen till en ny fil om du kan behöva de ursprungliga mästarna, layouterna eller komplett inbäddad teckensnittsdata senare. För mer detalj, se [Slide Master](/slides/sv/net/slide-master/) och [Embedded Font](/slides/sv/net/embedded-font/).

## **FAQ**

**När bör jag använda low‑code‑API:t istället för den fullständiga objektmodellen?**

Använd low‑code‑hjälpare när en standardoperation gäller en komplett fil eller presentation och inte kräver detaljerad kontroll över enskilda element. Använd den fullständiga objektmodellen när du behöver välja specifika bilder, kontrollera relationer mellan mästare och layouter, inspektera mellanstadier eller konfigurera beteende som hjälparen inte exponeras.

**Kan Merger kombinera presentationer i olika filformat?**

Nej. [Merger.Process](https://reference.aspose.com/slides/sv/net/aspose.slides.lowcode/merger/process/) kräver att inmatningspresentationerna har samma format. Konvertera indatafilerna till ett gemensamt format först, till exempel med [Convert.AutoByExtension](https://reference.aspose.com/slides/sv/net/aspose.slides.lowcode/convert/autobyextension/), och slå sedan samman de konverterade filerna.

**Bearbetar ForEach mästare, layout och notisbilder?**

[ForEach.Slide](https://reference.aspose.com/slides/sv/net/aspose.slides.lowcode/foreach/slide/) itererar genom normala presentationsbilder. Presentation‑omfattande [ForEach.Shape](https://reference.aspose.com/slides/sv/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/sv/net/aspose.slides.lowcode/foreach/paragraph/) och [ForEach.Portion](https://reference.aspose.com/slides/sv/net/aspose.slides.lowcode/foreach/portion/) inkluderar normal, mästar‑ och layout‑bilder som standard. Använd deras överlagringar med `includeNotes` satt till `true` för att inkludera notisbilder.

**Vad är skillnaden mellan ForEach.Shape och Collect.Shapes?**

Använd [ForEach.Shape](https://reference.aspose.com/slides/sv/net/aspose.slides.lowcode/foreach/shape/) för att bearbeta varje form omedelbart via en återuppringning. Använd [Collect.Shapes](https://reference.aspose.com/slides/sv/net/aspose.slides.lowcode/collect/shapes/) när du behöver ett enumererbart resultat som kan behållas, filtreras, räknas eller traverseras flera gånger.

**Gör Compress alltid presentationsfilen mindre?**

Inte nödvändigtvis. Resultatet beror på om presentationen innehåller oanvända layouter, oanvända mästare eller inbäddade teckensnitt med oanvända tecken. Om ingen av dessa finns kan motsvarande [Compress](https://reference.aspose.com/slides/sv/net/aspose.slides.lowcode/compress/)‑operationer missa att minska filstorleken.

**Sparas ändringar som gjorts av ForEach eller Compress automatiskt?**

Nej. Dessa hjälpare opererar på det inlästa [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/)‑objektet i minnet. Efter att ha ändrat element i ett [ForEach](https://reference.aspose.com/slides/sv/net/aspose.slides.lowcode/foreach/)‑callback eller kört [Compress](https://reference.aspose.com/slides/sv/net/aspose.slides.lowcode/compress/), anropa [Presentation.Save](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/save/) för att skriva resultatet.

## **Relaterade artiklar**

- [Konvertera presentation](/slides/sv/net/convert-presentation/)
- [Slå ihop presentationer](/slides/sv/net/merge-presentation/)
- [Slide Master](/slides/sv/net/slide-master/)
- [Hantera textruta](/slides/sv/net/manage-textbox/)
- [Embedded Font](/slides/sv/net/embedded-font/)