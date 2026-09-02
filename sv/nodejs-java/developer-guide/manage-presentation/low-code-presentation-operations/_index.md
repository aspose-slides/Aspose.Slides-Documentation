---
title: Low-Code-presentationer i JavaScript
linktitle: Low-Code API
type: docs
weight: 50
url: /sv/nodejs-java/low-code-presentation-operations/
keywords:
- low-code presentations-API
- konvertera presentation
- slå samman presentationer
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Använd Aspose.Slides low-code API i JavaScript för att konvertera och slå samman presentationer, iterera genom innehåll, samla former och minska presentationsstorleken."
---
## **Översikt**

`aspose.slides`‑namnutrymmet tillhandahåller statiska hjälparklasser för vanliga presentationer. Dessa hjälpare kapslar in ofta använda objekt‑modellarbetsflöden i fokuserade metoder, så att du kan konvertera eller slå samman filer, behandla presentationselement, samla former och ta bort oanvänd innehåll med mindre kod.

Low‑code‑hjälparna är mest användbara när operationen gäller en hel fil eller presentation och standardarbetsflödet passar dina krav. Använd hela [Aspose.Slides object model](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/) när du behöver finstyrning av enskilda bilder, huvudbilder, layouter, former, exportinställningar eller relationer mellan presentationselement.

Följande tabell sammanfattar de tillgängliga hjälparna:

| Hjälpare | Använd den för |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/convert/) | Konvertera en presentation till ett annat format med ett direkt fil‑till‑fil‑anrop. |
| [Merger](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/merger/) | Kombinera hela presentationsfiler av samma format. |
| [ForEach](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/foreach/) | Köra en åtgärd för varje bild, form, stycke eller textdel. |
| [Collect](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/collect/) | Hämta former från hela presentationen för återkommande bearbetning eller analys. |
| [Compress](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/compress/) | Ta bort oanvända huvudbilder och layouter samt minska inbäddade teckensnitt. |

## **Konvertera en presentation**

Använd [Convert.autoByExtension](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/convert/#autoByExtension) när filändelsen på utdata räcker för att välja exportformatet. Metoden öppnar källpresentationen, bestämmer det erforderliga formatet från sökvägen för utdata och skriver resultatet.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

aspose.slides.Convert.autoByExtension("input.pptx", "output.pdf");
```

[Convert]-klassen tillhandahåller också dedikerade metoder för PDF-, SVG-, JPEG-, PNG- och TIFF‑utdata. Använd hela objektmodellen när du behöver inspektera eller ändra presentationen före export eller konfigurera ett exportalternativ som inte exponeras av den valda hjälparen. Se [Convert Presentation](/slides/sv/nodejs-java/convert-presentation/) för format‑specifika arbetsflöden och alternativ.

## **Slå samman presentationer**

Använd [Merger.process](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/merger/#process) för att kombinera hela presentationsfiler med ett anrop. Inmatningspresentationerna måste ha samma filformat.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const inputFiles = ["first.pptx", "second.pptx"];
aspose.slides.Merger.process(inputFiles, "merged.pptx");
```

Hjälparen är lämplig när alla bilder ska läggas till i ett resultat utan att välja eller ommappa dem individuellt. Använd hela objektmodellen när du behöver slå samman valda bilder, tillämpa ett mål‑master‑ eller layout‑element, bevara sektioner explicit eller harmonisera olika bildstorlekar. Se [Merge Presentations](/slides/sv/nodejs-java/merge-presentation/) för dessa scenarier.

## **Iterera genom presentationselement**

[ForEach]-klassen anropar en återuppringning för varje begärd typ av presentationselement. Den undviker nästlade samlingsloopar och är praktisk för presentation‑omfattande inspektion eller formateringsändringar. I Node.js skapar du implementationer av återuppringnings‑gränssnitten med `java.newProxy`.

Följande exempel använder [ForEach.slide](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/foreach/#slide), [ForEach.shape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/foreach/#paragraph) och [ForEach.portion](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/foreach/#portion) för att inspektera motsvarande element:

```javascript
const java = require("java");
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slideCallback = java.newProxy("com.aspose.slides.ForEach$ForEachSlideCallback", {
        invoke: function (slide, index) {
            console.log(`Slide ${index}: ${slide.getShapes().size()} shapes`);
        }
    });
    aspose.slides.ForEach.slide(presentation, slideCallback);

    const shapeCallback = java.newProxy("com.aspose.slides.ForEach$ForEachShapeCallback", {
        invoke: function (shape, slide, index) {
            console.log(`Shape ${index} on ${slide.getClass().getSimpleName()}: ${shape.getName()}`);
        }
    });
    aspose.slides.ForEach.shape(presentation, shapeCallback);

    const paragraphCallback = java.newProxy("com.aspose.slides.ForEach$ForEachParagraphCallback", {
        invoke: function (paragraph, slide, index) {
            console.log(`Paragraph ${index} on ${slide.getClass().getSimpleName()}: ${paragraph.getText()}`);
        }
    });
    aspose.slides.ForEach.paragraph(presentation, paragraphCallback);

    const portionCallback = java.newProxy("com.aspose.slides.ForEach$ForEachPortionCallback", {
        invoke: function (portion, paragraph, slide, index) {
            console.log(`Portion ${index} on ${slide.getClass().getSimpleName()}: ${portion.getText()}`);
        }
    });
    aspose.slides.ForEach.portion(presentation, portionCallback);
} finally {
    presentation.dispose();
}
```

Som standard inkluderar traversal av former och text i hela presentationen vanliga, master‑ och layout‑bilder. Överlagringar med en `includeNotes`‑parameter kan också behandla noteringsbilder. Använd direkta samlingsloopar när traverseringsordning, tidig avbrytning, filtrering före återuppringning eller detaljerad förälder‑barn‑kontroll är viktig.

## **Samla former**

Använd [Collect.shapes](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/collect/#shapes) när du behöver en samling av alla former i en presentation snarare än en återuppringning för varje form. Detta är användbart när samma uppsättning ska filtreras, räknas eller bearbetas flera gånger.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const shapes = aspose.slides.Collect.shapes(presentation);
    const iterator = shapes.iterator();

    while (iterator.hasNext()) {
        const shape = iterator.next();
        console.log(`${shape.getName()}: ${shape.getClass().getSimpleName()}`);
    }
} finally {
    presentation.dispose();
}
```

Använd [ForEach.shape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/foreach/#shape) istället när varje form kan hanteras omedelbart och du inte behöver behålla det samlade resultatet.

## **Komprimera presentationsinnehåll**

[Compress]-klassen kan ta bort oanvända strukturelement och minska inbäddade teckensnittsdatan:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) tar bort layout‑bilder som ingen normal bild refererar till.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/compress/#removeUnusedMasterSlides) tar bort master‑bilder som inte längre används.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/compress/#compressEmbeddedFonts) tar bort oanvända tecken från inbäddade teckensnitt.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(presentation);
    aspose.slides.Compress.removeUnusedMasterSlides(presentation);
    aspose.slides.Compress.compressEmbeddedFonts(presentation);

    presentation.save("compressed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ta bort oanvända layouter innan oanvända master‑bilder så att en master som blir orefererad efter rensning av layouter också kan tas bort. Spara den optimerade presentationen till en ny fil om du kan behöva de ursprungliga master‑bilderna, layouterna eller fullständig inbäddad teckensnittsdatan senare. För mer detaljer, se [Slide Master](/slides/sv/nodejs-java/slide-master/) och [Embedded Font](/slides/sv/nodejs-java/embedded-font/).

## **Vanliga frågor**

**När bör jag använda low‑code‑API:t istället för hela objektmodellen?**

Använd low‑code‑hjälparna när en standardoperation gäller en hel fil eller presentation och inte kräver detaljerad kontroll över enskilda element. Använd hela objektmodellen när du behöver välja specifika bilder, styra relationer mellan master och layout, inspektera mellansteg eller konfigurera ett beteende som hjälparen inte exponerar.

**Kan Merger kombinera presentationer i olika filformat?**

Nej. [Merger.process](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/merger/#process) kräver att inmatningspresentationerna har samma format. Konvertera indatafilerna till ett gemensamt format först, till exempel med [Convert.autoByExtension](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/convert/#autoByExtension), och slå sedan samman de konverterade filerna.

**Behandlar ForEach master‑, layout‑ och noteringsbilder?**

[ForEach.slide](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/foreach/#slide) itererar genom vanliga presentationsbilder. Presentation‑omfattande [ForEach.shape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/foreach/#paragraph) och [ForEach.portion](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/foreach/#portion) inkluderar som standard vanliga, master‑ och layout‑bilder. Använd deras överlagringar med `includeNotes` satt till `true` för att inkludera noteringsbilder.

**Vad är skillnaden mellan ForEach.shape och Collect.shapes?**

Använd [ForEach.shape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/foreach/#shape) för att bearbeta varje form omedelbart via en återuppringning. Använd [Collect.shapes](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/collect/#shapes) när du behöver ett itererbart resultat som kan behållas, filtreras, räknas eller traverseras flera gånger.

**Gör Compress alltid presentationsfilen mindre?**

Inte nödvändigtvis. Resultatet beror på om presentationen innehåller oanvända layouter, oanvända master‑bilder eller inbäddade teckensnitt med oanvända tecken. Om ingen av dessa finns kan de motsvarande [Compress]-operationerna inte minska filens storlek.

**Sparas ändringar som görs av ForEach eller Compress automatiskt?**

Nej. Dessa hjälparbeten verkar på det inlästa [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/)-objektet i minnet. Efter att ha ändrat element i en [ForEach](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/foreach/)-återuppringning eller kört [Compress](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/compress/), anropa [Presentation.save](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/#save) för att skriva resultatet.

## **Relaterade artiklar**

- [Konvertera presentation](/slides/sv/nodejs-java/convert-presentation/)
- [Slå samman presentationer](/slides/sv/nodejs-java/merge-presentation/)
- [Slide Master](/slides/sv/nodejs-java/slide-master/)
- [Hantera textruta](/slides/sv/nodejs-java/manage-textbox/)
- [Inbäddat teckensnitt](/slides/sv/nodejs-java/embedded-font/)