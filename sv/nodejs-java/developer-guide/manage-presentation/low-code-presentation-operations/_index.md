---
title: Lågkodspresentationer i JavaScript
linktitle: Lågkod API
type: docs
weight: 50
url: /sv/nodejs-java/low-code-presentation-operations/
keywords:
- Lågkod presentations-API
- konvertera presentation
- slå ihop presentationer
- iterera bilder
- iterera former
- iterera text
- samla former
- komprimera presentation
- ta bort oanvända mastrbilder
- ta bort oanvända layoutbilder
- komprimera inbäddade teckensnitt
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Använd Aspose.Slides lågkod-API i JavaScript för att konvertera och slå ihop presentationer, iterera genom innehåll, samla former och minska presentationsstorleken."
---
## **Översikt**

`aspose.slides`‑namnrymden tillhandahåller statiska hjälparklasser för vanliga presentationsoperationer. Dessa hjälpare omsluter ofta använda arbetsflöden i objektmodellen i fokuserade metoder, så att du kan konvertera eller slå ihop filer, bearbeta presentationselement, samla former och ta bort oanvänt innehåll med mindre kod.

Low‑code‑hjälpare är mest användbara när operationen gäller en hel fil eller presentation och standardarbetsflödet matchar dina krav. Använd den fullständiga [Aspose.Slides‑objektmodellen](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/) när du behöver fin‑inställning av enskilda bilder, mastrar, layouter, former, exportinställningar eller relationer mellan presentationselement.

Följande tabell sammanfattar de tillgängliga hjälparna:

| Hjälpare | Använd den för |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/convert/) | Konvertera en presentation till ett annat format med ett direkt fil‑till‑fil‑anrop. |
| [Merger](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/merger/) | Kombinera kompletta presentationsfiler av samma format. |
| [ForEach](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/foreach/) | Utföra en åtgärd för varje bild, form, stycke eller textdel. |
| [Collect](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/collect/) | Hämta former från hela presentationen för upprepad bearbetning eller analys. |
| [Compress](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/compress/) | Ta bort oanvända mastrar och layouter samt minska inbäddade teckensnittsdaten. |

## **Konvertera en presentation**

Använd [Convert.autoByExtension](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/convert/#autoByExtension) när filändelsen på utdata är tillräcklig för att välja exportformat. Metoden öppnar källpresentationen, bestämmer det erforderliga formatet från utsökvägen och skriver resultatet.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

aspose.slides.Convert.autoByExtension("input.pptx", "output.pdf");
```

Klassen [Convert](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/convert/) erbjuder även dedikerade metoder för PDF, SVG, JPEG, PNG och TIFF‑utdata. Använd den fullständiga objektmodellen när du måste inspektera eller ändra presentationen före export eller konfigurera ett exportalternativ som inte exponeras av den valda hjälparen. Se [Convert Presentation](/nodejs-java/convert-presentation/) för format‑specifika arbetsflöden och alternativ.

## **Sammanfoga presentationer**

Använd [Merger.process](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/merger/#process) för att kombinera kompletta presentationsfiler med ett anrop. Ingångspresentationerna måste ha samma filformat.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const inputFiles = ["first.pptx", "second.pptx"];
aspose.slides.Merger.process(inputFiles, "merged.pptx");
```

Hjälparen är lämplig när alla bilder ska läggas till i ett resultat utan att de väljs eller omkartas individuellt. Använd den fullständiga objektmodellen när du måste slå ihop utvalda bilder, applicera en destinationsmastr eller layout, bevara sektioner uttryckligen, eller förena olika bildstorlekar. Se [Merge Presentations](/nodejs-java/merge-presentation/) för sådana scenarier.

## **Iterera genom presentationselement**

Klassen [ForEach](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/foreach/) anropar en återuppringning för varje begärt typ av presentationselement. Den undviker nästlade samlingsloopar och är bekväm för presentations‑omfattande inspektion eller formateringsändringar. I Node.js skapar du implementationer av återuppringnings‑gränssnitten med `java.newProxy`.

Följande exempel använder [ForEach.slide](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/foreach/#slide), [ForEach.shape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/foreach/#paragraph) och [ForEach.portion](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/foreach/#portion) för att inspektera de motsvarande elementen:

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

Som standard inkluderar presentations‑omfattande traversal av former och text normala, mastr‑ och layout‑bilder. Överlagringar med en `includeNotes`‑parameter kan också bearbeta noteringsbilder. Använd direkta samlingsloopar när traverseringsordning, tidig avslutning, filtrering före återuppringning eller detaljerad förälder‑barn‑kontroll är viktigt.

## **Samla former**

Använd [Collect.shapes](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/collect/#shapes) när du behöver en samling av alla former i en presentation snarare än en återuppringning för varje form. Detta är användbart när samma uppsättning ska filtreras, räknas eller bearbetas mer än en gång.

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

Använd [ForEach.shape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/foreach/#shape) istället när varje form kan hanteras omedelbart och du inte behöver behålla det insamlade resultatet.

## **Komprimera presentationsinnehåll**

Klassen [Compress](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/compress/) kan ta bort oanvända strukturella element och minska inbäddade teckensnittsdatan:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) tar bort layoutbilder som ingen normal bild refererar till.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/compress/#removeUnusedMasterSlides) tar bort mastrbilder som inte längre används.
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

Ta bort oanvända layouter innan oanvända mastrar så att en mastr som blir orefererad efter layout‑rensning också kan tas bort. Spara den optimerade presentationen till en ny fil om du kan behöva de ursprungliga mastrarna, layouterna eller hela den inbäddade teckensnittsdatan senare. För mer detaljer, se [Slide Master](/nodejs-java/slide-master/) och [Embedded Font](/nodejs-java/embedded-font/).

## **FAQ**

**När ska jag använda low‑code‑API:t istället för den fullständiga objektmodellen?**

Använd low‑code‑hjälpare när en standardoperation gäller en komplett fil eller presentation och inte kräver detaljerad kontroll över enskilda element. Använd den fullständiga objektmodellen när du måste välja specifika bilder, kontrollera mastr‑ och layout‑relationer, inspektera mellanstadier eller konfigurera beteende som hjälparen inte exponeras.

**Kan Merger kombinera presentationer i olika filformat?**

Nej. [Merger.process](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/merger/#process) kräver att inmatningspresentationerna har samma format. Konvertera indatafilerna till ett gemensamt format först, till exempel med [Convert.autoByExtension](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/convert/#autoByExtension), och slå sedan ihop de konverterade filerna.

**Bearbetar ForEach mastr, layout och noteringsbilder?**

[ForEach.slide](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/foreach/#slide) itererar genom normala presentationsbilder. Presentations‑omfattande [ForEach.shape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/foreach/#paragraph) och [ForEach.portion](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/foreach/#portion) inkluderar normala, mastr‑ och layout‑bilder som standard. Använd deras överlagringar med `includeNotes` satt till `true` för att inkludera noteringsbilder.

**Vad är skillnaden mellan ForEach.shape och Collect.shapes?**

Använd [ForEach.shape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/foreach/#shape) för att bearbeta varje form omedelbart via en återuppringning. Använd [Collect.shapes](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/collect/#shapes) när du behöver ett itererbart resultat som kan behållas, filtreras, räknas eller traverseras flera gånger.

**Gör Compress alltid presentationsfilen mindre?**

Inte nödvändigtvis. Resultatet beror på om presentationen innehåller oanvända layouter, oanvända mastrar eller inbäddade teckensnitt med oanvända tecken. Om ingen av dessa finns kan de motsvarande [Compress](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/compress/)-operationerna misslyckas med att minska filstorleken.

**Sparas ändringar gjorda av ForEach eller Compress automatiskt?**

Nej. Dessa hjälpare arbetar på det laddade [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/)‑objektet i minnet. Efter att ha ändrat element i ett [ForEach](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/foreach/)-återuppringnings‑callback eller kört [Compress](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/compress/), anropa [Presentation.save](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/#save) för att skriva resultatet.

## **Relaterade artiklar**

- [Convert Presentation](/nodejs-java/convert-presentation/)
- [Merge Presentations](/nodejs-java/merge-presentation/)
- [Slide Master](/nodejs-java/slide-master/)
- [Manage Text Box](/nodejs-java/manage-textbox/)
- [Embedded Font](/nodejs-java/embedded-font/)