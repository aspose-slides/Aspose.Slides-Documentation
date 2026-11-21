---
title: Ändra anteckningssidans storlek och orientering i JavaScript
linktitle: Anteckningssidans storlek
type: docs
weight: 10
url: /sv/nodejs-java/notes-size/
keywords:
- anteckningssidans storlek
- anteckningsorientering
- liggande anteckningar
- stående anteckningar
- handout‑storlek
- PowerPoint
- presentation
- PPT
- PPTX
- Node.js
- JavaScript
- Aspose.Slides
description: "Läs och ändra anteckningssidans dimensioner i Aspose.Slides för Node.js via Java, växla orientering, verifiera sparade storlekar och exportera anteckningar eller handouts till PDF och bilder."
---
## **Översikt**

Använd [Presentation.getNotesSize](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/getnotessize/) för att komma åt presentationens anteckningssidinställningar. Den returnerar ett [NotesSize](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/notessize/)‑objekt vars [setSize](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/notessize/setsize/) metod anger sidans mått. Även om inställningsobjektet självt inte kan ersättas kan du tilldela nya mått via denna metod.

Bredd och höjd anges i **points**, med 72 points per tum. Till exempel motsvarar 900 × 600 points 12,5 × 8⅓ tum. Dessa inställningar gäller för presentationen, snarare än för en enskild slides anteckningar.

| Inställning | Syfte |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/getnotessize/) | Kontrollerar anteckningssidans dimensioner och de siddimensioner som används för handout‑export. |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/getslidesize/) | Kontrollerar vanliga presentation slide‑dimensioner via [SlideSize](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slidesize/). |

Att ändra någon av inställningarna ändrar inte automatiskt den andra. Att ändra anteckningssidans orientering roterar inte heller de vanliga bilderna. Se [Slide Size](/slides/sv/nodejs-java/slide-size/) för att ändra storlek på vanliga slides.

Exemplen nedan använder en befintlig `sample.pptx`. För exportexemplen, använd en presentation med minst en slide som innehåller talarnoter. Varje exempel kan köras oberoende.

## **Läs anteckningssidans storlek och orientering**

Läs bredden och höjden och jämför dem för att bestämma orienteringen: en bredare sida är liggande, en högre sida är stående, och lika dimensioner beskriver en kvadratisk sida. Detta exempel skriver ut de faktiska dimensionerna i points, utan att anta en standardpappersstorlek.

```javascript
const slides = require("aspose.slides.via.java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = presentation.getNotesSize().getSize();
    let orientation = "Square";

    if (size.getWidth() > size.getHeight()) {
        orientation = "Landscape";
    } else if (size.getWidth() < size.getHeight()) {
        orientation = "Portrait";
    }

    console.log("Notes page: " + size.getWidth() + " x " + size.getHeight() + " points");
    console.log("Orientation: " + orientation);
} finally {
    presentation.dispose();
}
```

## **Växla till liggande utan att ändra pappersstorleken**

För att bara ändra orienteringen, byt bredd och höjd. Detta bevarar längden på båda sidor, även för en anpassad pappersstorlek. Villkoret nedan förhindrar att en redan liggande sida byts tillbaka till stående och lämnar en kvadratisk sida oförändrad.

```javascript
const slides = require("aspose.slides.via.java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = presentation.getNotesSize().getSize();

    if (size.getWidth() < size.getHeight()) {
        let width = size.getWidth();
        size.setSize(size.getHeight(), width);
        presentation.getNotesSize().setSize(size);
    }

    presentation.save("landscape-notes.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

För stående orientering, använd samma tilldelning när `size.getWidth() > size.getHeight()`. Ersätt inte A4- eller Letter-dimensioner om du inte också vill ändra pappersstorleken.

## **Ställ in och verifiera en anpassad anteckningssidstorlek**

Tilldela båda dimensionerna samtidigt, och använd sedan [Presentation.save](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/save/) för att skriva presentationen. Detta exempel sätter en 900 × 600-point liggande sida, sparar den som PPTX och öppnar den sparade filen igen för att kontrollera de bestående värdena. Jämförelsen tillåter en tolerans på 0,01 point för flyttalsvärden; det är ingen garanti för precision för varje filformat.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let expectedSize = java.newInstanceSync("java.awt.Dimension", 900, 600);
    presentation.getNotesSize().setSize(expectedSize);

    presentation.save("custom-notes.pptx", slides.SaveFormat.Pptx);

    let reopened = new slides.Presentation("custom-notes.pptx");
    try {
        let actualSize = reopened.getNotesSize().getSize();
        let widthMatches = Math.abs(actualSize.getWidth() - expectedSize.getWidth()) < 0.01;
        let heightMatches = Math.abs(actualSize.getHeight() - expectedSize.getHeight()) < 0.01;
        let preserved = widthMatches && heightMatches;

        console.log("Stored notes page: " + actualSize.getWidth() + " x " + actualSize.getHeight() + " points");
        console.log("Size preserved: " + preserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Det förväntade resultatet är `900 x 600 points` och `Size preserved: true`. Att kontrollera en nyöppnad presentation verifierar den sparade filen, snarare än endast de minnesbaserade inställningarna.

## **Exportera anteckningar och handouts**

Sidans dimensioner definierar det tillgängliga området för antecknings- eller handout‑layouter. De aktiverar inte dessa layouter automatiskt: konfigurera även exportalternativen. Vanlig slide‑export fortsätter att använda slide‑dimensionerna.

### **Exportera anteckningar till PDF och PNG**

Tilldela [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/notescommentslayoutingoptions/) till [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) för att inkludera anteckningar i PDF:en. Detta exempel renderar också den första sliden med anteckningar till PNG med hjälp av [Slide.getImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slide/#getImage) och [RenderingOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/renderingoptions/).

[BottomTruncated](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/notespositions/)‑läget behåller anteckningarna på en sida; anteckningar som inte får plats kan trunkeras. PDF‑filen använder 900 × 600-point sidor. Vid bildskalan 1 × 1 som används nedan blir PNG‑filen 900 × 600 pixlar. Points beskriver sidans geometri; pixlar beskriver rasterutdata, vars dimensioner också beror på renderingsskalan.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = java.newInstanceSync("java.awt.Dimension", 900, 600);
    presentation.getNotesSize().setSize(size);

    let layout = new slides.NotesCommentsLayoutingOptions();
    layout.setNotesPosition(slides.NotesPositions.BottomTruncated);

    let pdfOptions = new slides.PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("notes.pdf", slides.SaveFormat.Pdf, pdfOptions);

    let renderingOptions = new slides.RenderingOptions();
    renderingOptions.setSlidesLayoutOptions(layout);

    let image = presentation.getSlides().get_Item(0).getImage(renderingOptions, 1, 1);
    try {
        image.save("first-slide-notes.png", slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

För PDF‑export med långa anteckningar tillåter [BottomFull](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/notespositions/) ytterligare sidor vid behov. Använd inte det läget med den enkelslide‑bild‑anropet ovan, som inte stödjer det. Efter storleksändring, inspektera resultatet för avklippta anteckningar och placeringen av befintliga notes‑master‑objekt; att bara ändra sidans dimensioner bör inte betraktas som en garanti för att allt innehåll får plats. Se [Convert PowerPoint to PDF with Notes](/slides/sv/nodejs-java/convert-powerpoint-to-pdf-with-notes/) för mer om anteckningsexport.

### **Exportera handouts till PDF**

Använd [HandoutLayoutingOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/handoutlayoutingoptions/) för flera slide‑miniatyrer på en sida. Följande exempel sätter en 900 × 600-point sida och använder [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/handouttype/) för att arrangera upp till fyra slides per sida. Den horisontella förinställningen styr slide‑ordningen; sidans orientering kommer från dess bredd och höjd.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = java.newInstanceSync("java.awt.Dimension", 900, 600);
    presentation.getNotesSize().setSize(size);

    let layout = new slides.HandoutLayoutingOptions();
    layout.setHandout(slides.HandoutType.Handouts4Horizontal);

    let pdfOptions = new slides.PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("handouts.pdf", slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Att ändra sidans storlek ändrar området som är tillgängligt för handout‑rutnätet utan att ändra källslide‑dimensionerna. För handout‑bilder, använd [Presentation.getImages](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/getimages/) med handout‑layouten, snarare än en enskild slides bildmetod. I Aspose.Slides använder handout‑rendering på presentationsnivå anteckningssidans dimensioner, medan den enskilda slide‑bildanropet inte producerar handout‑sidan. Se [Handout Mode](/slides/sv/nodejs-java/convert-powerpoint-in-handout-mode/) för layoutalternativ.

## **Sidstorlek i visare, export och utskrift**

Håll den lagrade presentationsstorleken, den exporterade sidstorleken och den utskrivna pappersstorleken separata:

- **Presentation viewers:** En visare kan visa eller skriva ut anteckningar med sina egna layoutregler. Om ett annat program sparar filen, öppna den igen och kontrollera dimensionerna igen; det programmets formatkonvertering kan normalisera dem.
- **Export formats:** Antecknings‑ och handout‑PDF‑exemplen ovan använder de konfigurerade siddimensionerna. Rasterbilder använder heltals‑pixeldimensioner och en renderingsskala, så bråkdelar av points kan avrundas i bildutdata. Export av vanliga slides använder inte anteckningssidans storlek.
- **Printer drivers:** Val av papper, automatisk rotation och inställningar för anpassning till sida kan förändra det fysiska resultatet utan att ändra dimensionerna som lagras i presentationen eller PDF:en. För en specifik pappersstorlek, matcha skrivarinställningarna och inspektera utskriftsförhandsvisningen.

## **FAQ**

**Kan jag ange anteckningsstorleken för bara en slide?**

Anteckningssidans storlek är en inställning på presentationsnivå. Enskilda slides kan ha olika anteckningsinnehåll, men den här egenskapen ger ingen separat sidstorlek för varje slide.

**Varför ändrade inte förändring av anteckningsorienteringen mina slides?**

Anteckningssidor och vanliga slides har oberoende dimensioner. Använd de vanliga slide‑storleksinställningarna när du vill ändra storlek på själva slides.

**Varför har mitt sparade eller utskrivna resultat en annan storlek?**

Öppna först den sparade presentationen igen och jämför dess anteckningsdimensioner. Om de har ändrats, kontrollera om sparande eller konvertering av filen i ett annat program har ändrat sidinställningarna. Om de inte har gjort det, kontrollera exportlayouten, bildskalan, visarens inställningar och skrivarens pappersval.