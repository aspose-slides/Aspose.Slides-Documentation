---
title: Konvertera presentationsbilder till bilder i JavaScript
linktitle: Bild till bild
type: docs
weight: 35
url: /sv/nodejs-java/convert-slide/
keywords:
- konvertera bild
- exportera bild
- bild till bild
- spara bild som bild
- bild till EMF
- bild till PNG
- bild till JPEG
- bild till bitmap
- bild till TIFF
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Konvertera bilder från PPT-, PPTX- och ODP-presentationer till PNG, JPEG, GIF, TIFF, EMF och andra bildformat i JavaScript med Aspose.Slides."
---
## **Introduktion**

Aspose.Slides för Node.js via Java kan rendera individuella bilder från PowerPoint- och OpenDocument-presentationer som PNG, JPEG, GIF, TIFF och andra bildformat.

För att konvertera en bild till en bild, följ dessa steg:

1. Läs in presentationen med klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/).
2. Välj den bild du vill rendera.
3. Om nödvändigt, konfigurera rendering med klassen [RenderingOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/renderingoptions/) eller [TiffOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/tiffoptions/).
4. Anropa metoden [Slide.getImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slide/#getImage). Den returnerar ett [IImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/iimage/)‑objekt.
5. Anropa metoden [IImage.save](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/iimage/#save) och ange utdataformatet med ett [ImageFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/imageformat/)‑värde.

## **Konvertera en bild till en PNG‑bild**

Den enklaste konverteringen använder standardinställningarna för rendering. Det resulterande [IImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/iimage/)‑objektet kan bearbetas i minnet eller sparas till en fil.

Följande JavaScript‑exempel renderar den första bilden och sparar den som en PNG‑bild:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage();
    try {
        image.save("Slide_0.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Konvertera bilder till bildformat med anpassade storlekar**

Använd överlagringen av [Slide.getImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slide/#getImage) som accepterar ett `java.awt.Dimension`‑värde för att rendera en bild med exakta pixeldimensioner.

Följande exempel skapar en 1820 × 1040 JPEG‑bild:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const imageSize = java.newInstanceSync("java.awt.Dimension", 1820, 1040);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage(imageSize);
    try {
        image.save("Slide_0.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Konvertera bilder med anteckningar och kommentarer till bilder**

Som standard innehåller bildfilerna inga anteckningar eller kommentarer. Skicka ett [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/notescommentslayoutingoptions/)‑objekt till metoden [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) för att styra var anteckningar och kommentarer visas.

Följande exempel placerar avkortade anteckningar under bilden och kommentarer till höger om den:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const scaleX = 2;
const scaleY = scaleX;

const commentsAreaColor = java.newInstanceSync("java.awt.Color", 250, 235, 215);

const layoutOptions = new aspose.slides.NotesCommentsLayoutingOptions();
layoutOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);
layoutOptions.setCommentsPosition(aspose.slides.CommentsPositions.Right);
layoutOptions.setCommentsAreaWidth(500);
layoutOptions.setCommentsAreaColor(commentsAreaColor);

const renderingOptions = new aspose.slides.RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutOptions);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage(renderingOptions, scaleX, scaleY);
    try {
        image.save("Image_with_notes_and_comments_0.gif", aspose.slides.ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Varning" color="warning" %}}
Vid konvertering från bild till bildfil får du inte skicka [BottomFull](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/notespositions/) till metoden [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition). Anteckningar kan innehålla mer text än den fasta bildstorleken kan rymma. Använd [BottomTruncated](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/notespositions/) istället.
{{% /alert %}}

## **Konvertera bilder till bildformat med TIFF‑alternativ**

Klassen [TiffOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/tiffoptions/) låter dig styra storlek, upplösning och andra egenskaper för den renderade TIFF‑bilden.

Följande exempel renderar den första bilden som en 2160 × 2880 TIFF‑bild med 300 DPI:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const imageSize = java.newInstanceSync("java.awt.Dimension", 2160, 2880);

const tiffOptions = new aspose.slides.TiffOptions();
tiffOptions.setImageSize(imageSize);
tiffOptions.setDpiX(300);
tiffOptions.setDpiY(300);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage(tiffOptions);
    try {
        image.save("output.tiff", aspose.slides.ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Varning" color="warning" %}}
TIFF‑stöd garanteras inte i Java‑versioner äldre än JDK 9.
{{% /alert %}}

## **Konvertera alla bilder till bildformat**

Iterera genom bildsamlingen för att konvertera hela presentationen till en serie bilder. Dolda bilder inkluderas såvida du inte explicit hoppar över dem.

Följande exempel renderar varje bild som en JPEG‑bild med horisontella och vertikala skalfaktorer på 2:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const scaleX = 2;
const scaleY = scaleX;

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        const slide = presentation.getSlides().get_Item(index);
        const image = slide.getImage(scaleX, scaleY);
        try {
            image.save("Slide_" + index + ".jpg", aspose.slides.ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Skapa Enhanced Metafile‑utdata**

Enhanced Metafile (EMF) är användbart när vektorgrafik måste utbytas med Microsoft Office eller andra Windows‑program som stöder Windows‑metafiler. Till skillnad från en pixelbaserad bild kan en EMF behålla vektorritningsoperationer som skalas utan samma förlust av skärpa. EMF är dock främst ett kompatibilitetsformat för program med stöd för Windows‑metafiler, inte ett universellt utbytesformat. Dessutom kan komplext bildinnehåll, såsom bitmapbilder och vissa effekter, lagras som rasteriserade element i den vektor‑metafilkontainern.

### **Exportera en bild till EMF**

Metoden [Slide.writeAsEmf](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slide/#writeAsEmf) skriver en bild till ett målstöm i EMF‑format. Följande exempel läser in en presentation, väljer den första bilden och skriver den till ett EMF‑filström:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const emfStream = java.newInstanceSync("java.io.FileOutputStream", "Slide_0.emf");
    try {
        slide.writeAsEmf(emfStream);
    } finally {
        emfStream.close();
    }
} finally {
    presentation.dispose();
}
```

Anroparen äger strömmen som skickas till [Slide.writeAsEmf](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slide/#writeAsEmf) och är ansvarig för att stänga den, som visas ovan.

### **Konvertera en SVG‑bild till EMF och lägg till den i en presentation**

Använd [SvgImage.writeAsEmf](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/svgimage/#writeAsEmf) för att konvertera SVG‑innehåll till EMF. De resulterande bytena kan läggas till i presentationen via [ImageCollection.addImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/imagecollection/#addImage) och placeras på en bild med [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shapecollection/#addPictureFrame).

Följande exempel skapar en [SvgImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/svgimage/) från SVG‑markup, konverterar den till ett EMF‑objekt i minnet, infogar metafilen på den första bilden och sparar presentationen:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
const svgImage = new aspose.slides.SvgImage(svgContent);

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const emfStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    try {
        svgImage.writeAsEmf(emfStream);

        const emfData = java.newArray("byte", Array.from(emfStream.toByteArray()));
        const image = presentation.getImages().addImage(emfData);
        slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 100, image);
    } finally {
        emfStream.close();
    }

    presentation.save("Presentation_with_emf.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[SvgImage.writeAsEmf](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/svgimage/#writeAsEmf) tar inte ägandeskap över destinationsströmmen. En `java.io.ByteArrayOutputStream` lagrar all genererad data i minnet, så ingen positionsåterställning behövs innan `toByteArray` anropas. Den returnerade byte‑arrayen förblir giltig efter att strömmen har stängts.

EMF‑generering är tillgänglig på de operativsystem som stöds av den valda Aspose.Slides för Node.js via Java och JDK‑konfiguration, men rendering kan variera mellan plattformar när teckensnitt eller grafikberoenden saknas. Installera de teckensnitt som används av källinnehållet eller konfigurera lämpliga substitutioner, följ [plattformskraven](/slides/sv/nodejs-java/system-requirements/) för Aspose.Slides för Node.js via Java och validera resultatet i den mål‑EMF‑konsumerande applikationen. Linux‑ och macOS‑program har ofta begränsat eller inkonsekvent stöd för att visa och redigera Windows‑metafiler.

## **Rendering av färg‑emoji**

{{% alert title="Notering" color="info" %}}
För att rendera färg‑emoji korrekt när presentationens bilder konverteras till bildformat måste de emoji‑teckensnitt som används i presentationen vara installerade och tillgängliga på systemet som utför konverteringen. Till exempel, om presentationen använder **Segoe UI Emoji** och detta teckensnitt saknas, kan emoji visas i monokrom i utdata‑bilderna.
{{% /alert %}}

## **Vanliga frågor**

**Stöder Aspose.Slides rendering av bilder med animationer?**

Nej. Metoden [Slide.getImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slide/#getImage) renderar en statisk bild av sliden och exporterar inte animationer.

**Kan dolda bilder exporteras som bilder?**

Ja. Dolda bilder kan renderas som vanliga bilder. Inkludera dem i bearbetningsloopen, som i exemplet ovan.

**Bevaras skuggor och andra effekter i bildfilerna?**

Ja. Aspose.Slides renderar skuggor, genomskinlighet och andra stödda grafiska effekter i bildfilerna.