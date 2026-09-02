---
title: Low-Code presentationsoperationer i .NET
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
- ta bort oanvända master-bilder
- ta bort oanvända layout-bilder
- komprimera inbäddade teckensnitt
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Använd Aspose.Slides low-code API i .NET för att konvertera och slå ihop presentationer, iterera genom innehåll, samla former och minska presentationsstorlek."
---
## **Översikt**

Namnområdet [Aspose.Slides.LowCode](https://reference.aspose.com/slides/sv/net/aspose.slides.lowcode/) tillhandahåller statiska hjälparklasser för vanliga presentationsoperationer. Dessa hjälparklasser kapslar in ofta använda objekt‑modell‑arbetsflöden i fokuserade metoder, så att du kan konvertera eller slå ihop filer, bearbeta presentations­element, samla former och ta bort oanvänt innehåll med mindre kod.

Low‑code‑hjälparklasser är mest användbara när operationen gäller en hel fil eller presentation och standardarbetsflödet uppfyller dina krav. Använd den fullständiga [Aspose.Slides‑objektmodellen](https://reference.aspose.com/slides/sv/net/aspose.slides/) när du behöver fin‑kontroll över enskilda bilder, master‑bilder, layouter, former, exportinställningar eller relationer mellan presentations­element.

Följande tabell sammanfattar de tillgängliga hjälparklasserna:

| Hjälpmedel | Användning |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/sv/net/aspose.slides.lowcode/convert/) | Konvertera en presentation till ett annat format med ett direkt fil‑till‑fil‑anrop. |
| [Merger](https://reference.aspose.com/slides/sv/net/aspose.slides.lowcode/merger/) | Kombinera hela presentationsfiler av samma format. |
| [ForEach](https://reference.aspose.com/slides/sv/net/aspose.slides.lowcode/foreach/) | Köra en åtgärd för varje bild, form, stycke eller textdel. |
| [Collect](https://reference.aspose.com/slides/sv/net/aspose.slides.lowcode/collect/) | Hämta former från hela presentationen för återkommande bearbetning eller analys. |
| [Compress](https://reference.aspose.com/slides/sv/net/aspose.slides.lowcode/compress/) | Ta bort oanvända master‑ och layout‑bilder och minska inbäddad teckensnittsdata. |

## **Konvertera en presentation**

Använd [Convert.AutoByExtension](https://reference.aspose.com/slides/sv/net/aspose.slides.lowcode/convert/autobyextension/) när filändelsen på utdata är tillräcklig för att välja exportformat. Metoden öppnar källpresentationen, bestämmer det erforderliga formatet från sökvägen för utdata och skriver resultatet.

```csharp
using Aspose.Slides.LowCode;

Convert.AutoByExtension("input.pptx", "output.pdf");
```

Klassen [Convert](https://reference.aspose.com/slides/sv/net/aspose.slides.lowcode/convert/) erbjuder också dedikerade metoder för PDF, SVG, JPEG, PNG och TIFF. Använd den fullständiga objektmodellen när du måste inspektera eller ändra presentationen före export eller konfigurera ett exportalternativ som inte exponeras av den valda hjälparklassen. Se [Konvertera presentation](/net/convert-presentation/) för format‑specifika arbetsflöden och alternativ.

## **Slå samman presentationer**

Använd [Merger.Process](https://reference.aspose.com/slides/sv/net/aspose.slides.lowcode/merger/process/) för att kombinera hela presentationsfiler med ett anrop. Inmatnings‑presentationerna måste ha samma filformat.

```csharp
using Aspose.Slides.LowCode;

var inputFiles = new[] { "part-1.pptx", "part-2.pptx" };
Merger.Process(inputFiles, "merged.pptx");
```

Hjälparklassen är lämplig när alla bilder ska läggas till i ett resultat utan att välja eller ommappa dem individuellt. Använd den fullständiga objektmodellen när du måste slå samman utvalda bilder, tillämpa en mål‑master‑ eller layout‑bild, bevara sektioner uttryckligen eller hantera olika bildstorlekar. Se [Slå ihop presentationer](/net/merge-presentation/) för dessa scenarier.

## **Iterera genom presentationselement**

Klassen [ForEach](https://reference.aspose.com/slides/sv/net/aspose.slides.lowcode/foreach/) anropar en återuppringning för varje begärd typ av presentations­element. Den undviker nästlade samlingsloopar och är bekväm för presentations‑omfattande inspektion eller formateringsändringar.

Följande exempel använder [ForEach.Slide](https://reference.aspose.com/slides/sv/net/aspose.slides.lowcode/foreach/slide/), [ForEach.Shape](https://reference.aspose.com/slides/sv/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/sv/net/aspose.slides.lowcode/foreach/paragraph/) och [ForEach.Portion](https://reference.aspose.com/slides/sv/net/aspose.slides.lowcode/foreach/portion/) för att inspektera respektive element:

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

Som standard inkluderar traversering av hela presentationen former och text på normala, master‑ och layout‑bilder. Överlagringar med en `includeNotes`‑parameter kan även bearbeta notes‑bilder. Använd direkta samlingsloopar när traverseringsordning, tidig avbrytning, filtrering före återuppringning eller detaljerad förälder‑barn‑kontroll är viktig.

## **Samla former**

Använd [Collect.Shapes](https://reference.aspose.com/slides/sv/net/aspose.slides.lowcode/collect/shapes/) när du behöver en samling av alla former i en presentation snarare än en återuppringning för varje form. Detta är användbart när samma mängd ska filtreras, räknas eller bearbetas flera gånger.

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

Klassen [Compress](https://reference.aspose.com/slides/sv/net/aspose.slides.lowcode/compress/) kan ta bort oanvända strukturella element och minska inbäddad teckensnittsdata:

- [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/sv/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) tar bort layout‑bilder som ingen normal bild refererar.
- [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/sv/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) tar bort master‑bilder som inte längre används.
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

Ta bort oanvända layouter innan oanvända master‑bilder så att en master som blir orefererad efter layout‑rensning också kan tas bort. Spara den optimerade presentationen till en ny fil om du eventuellt behöver de ursprungliga master‑bilderna, layouterna eller fullständig inbäddad teckensnittsdata senare. För mer detaljer, se [Slide Master](/net/slide-master/) och [Embedded Font](/net/embedded-font/).

## **Vanliga frågor**

**När bör jag använda low-code API:et istället för hela objektmodellen?**

Använd low‑code‑hjälparklasser när en standardoperation gäller en hel fil eller presentation och inte kräver detaljerad kontroll över enskilda element. Använd den fullständiga objektmodellen när du måste välja specifika bilder, kontrollera master‑ och layout‑relationer, inspektera mellansteg eller konfigurera beteende som hjälparklassen inte exponerar.

**Kan Merger kombinera presentationer i olika filformat?**

Nej. [Merger.Process](https://reference.aspose.com/slides/sv/net/aspose.slides.lowcode/merger/process/) kräver att inmatnings‑presentationerna har samma format. Konvertera indatafilerna till ett gemensamt format först, till exempel med [Convert.AutoByExtension](https://reference.aspose.com/slides/sv/net/aspose.slides.lowcode/convert/autobyextension/), och slå sedan ihop de konverterade filerna.

**Processar ForEach master‑, layout‑ och notes‑bilder?**

[ForEach.Slide](https://reference.aspose.com/slides/sv/net/aspose.slides.lowcode/foreach/slide/) itererar genom normala presentationsbilder. Presentations‑omfattande [ForEach.Shape](https://reference.aspose.com/slides/sv/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/sv/net/aspose.slides.lowcode/foreach/paragraph/) och [ForEach.Portion](https://reference.aspose.com/slides/sv/net/aspose.slides.lowcode/foreach/portion/) inkluderar som standard normala, master‑ och layout‑bilder. Använd deras överlagringar med `includeNotes` satt till `true` för att även inkludera notes‑bilder.

**Vad är skillnaden mellan ForEach.Shape och Collect.Shapes?**

Använd [ForEach.Shape](https://reference.aspose.com/slides/sv/net/aspose.slides.lowcode/foreach/shape/) för att bearbeta varje form omedelbart via en återuppringning. Använd [Collect.Shapes](https://reference.aspose.com/slides/sv/net/aspose.slides.lowcode/collect/shapes/) när du behöver ett enumererbart resultat som kan behållas, filtreras, räknas eller traverseras flera gånger.

**Gör Compress alltid presentationsfilen mindre?**

Inte nödvändigtvis. Resultatet beror på om presentationen innehåller oanvända layouter, oanvända master‑bilder eller inbäddade teckensnitt med oanvända tecken. Om ingen av dessa finns kan de motsvarande [Compress](https://reference.aspose.com/slides/sv/net/aspose.slides.lowcode/compress/)-operationerna missa att minska filstorleken.

**Sparas ändringar som görs av ForEach eller Compress automatiskt?**

Nej. Dessa hjälparklasser arbetar på det inlästa [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/)-objektet i minnet. Efter att ha ändrat element i en [ForEach](https://reference.aspose.com/slides/sv/net/aspose.slides.lowcode/foreach/)-återuppringning eller kört [Compress](https://reference.aspose.com/slides/sv/net/aspose.slides.lowcode/compress/), anropa [Presentation.Save](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/save/) för att skriva resultatet.

## **Relaterade artiklar**

- [Konvertera presentation](/net/convert-presentation/)
- [Slå ihop presentationer](/net/merge-presentation/)
- [Slide Master](/net/slide-master/)
- [Hantera textruta](/net/manage-textbox/)
- [Embedded Font](/net/embedded-font/)