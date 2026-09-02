---
title: "Dia's van presentaties converteren naar afbeeldingen in JavaScript"
linktitle: "Dia naar afbeelding"
type: docs
weight: 35
url: /nl/nodejs-java/convert-slide/
keywords:
- "dia converteren"
- "dia exporteren"
- "dia naar afbeelding"
- "dia opslaan als afbeelding"
- "dia naar EMF"
- "dia naar PNG"
- "dia naar JPEG"
- "dia naar bitmap"
- "dia naar TIFF"
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Dia's van PPT-, PPTX- en ODP-presentaties omzetten naar PNG, JPEG, GIF, TIFF, EMF en andere afbeeldingsformaten in JavaScript met Aspose.Slides."
---
## **Introductie**

Aspose.Slides for Node.js via Java kan individuele dia's uit PowerPoint- en OpenDocument‑presentaties renderen als PNG, JPEG, GIF, TIFF en andere afbeeldingsformaten.

Om een dia om te zetten naar een afbeelding, volg deze stappen:

1. Laad de presentatie met de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) klasse.
2. Selecteer de dia die je wilt renderen.
3. Configureer indien nodig het renderen met de [RenderingOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/renderingoptions/) of [TiffOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/tiffoptions/) klasse.
4. Roep de [Slide.getImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slide/#getImage) methode aan. Deze retourneert een [IImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/iimage/) object.
5. Roep de [IImage.save](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/iimage/#save) methode aan en specificeer het uitvoerformaat met een [ImageFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/imageformat/) waarde.

## **Een dia omzetten naar een PNG‑afbeelding**

De eenvoudigste conversie gebruikt de standaard renderinstellingen. Het resulterende [IImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/iimage/) object kan in het geheugen worden verwerkt of naar een bestand worden opgeslagen.

Het volgende JavaScript‑voorbeeld rendert de eerste dia en slaat deze op als een PNG‑afbeelding:

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

## **Dia's omzetten naar afbeeldingen met aangepaste afmetingen**

Gebruik de overload van [Slide.getImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slide/#getImage) die een `java.awt.Dimension`‑waarde accepteert om een dia te renderen met exacte pixelafmetingen.

Het volgende voorbeeld maakt een JPEG‑afbeelding van 1820 × 1040:

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

## **Dia's met notities en opmerkingen omzetten naar afbeeldingen**

Standaard bevatten dia‑afbeeldingen geen notities of opmerkingen. Geef een [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/notescommentslayoutingoptions/) object door aan de [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) methode om te bepalen waar notities en opmerkingen verschijnen.

Het volgende voorbeeld plaatst afgekorte notities onder de dia en opmerkingen rechts ervan:

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

{{% alert title="Waarschuwing" color="warning" %}}
Voor de conversie van dia naar afbeelding mag je niet [BottomFull](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/notespositions/) doorgeven aan de [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) methode. Notities kunnen meer tekst bevatten dan de vaste afbeeldingsgrootte kan bevatten. Gebruik [BottomTruncated](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/notespositions/) in plaats daarvan.
{{% /alert %}}

## **Dia's omzetten naar afbeeldingen met TIFF‑opties**

De [TiffOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/tiffoptions/) klasse stelt je in staat de grootte, resolutie en andere eigenschappen van de gerenderde TIFF‑afbeelding te regelen.

Het volgende voorbeeld rendert de eerste dia als een 2160 × 2880 TIFF‑afbeelding met 300 DPI:

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

{{% alert title="Waarschuwing" color="warning" %}}
TIFF‑ondersteuning wordt niet gegarandeerd in Java‑versies ouder dan JDK 9.
{{% /alert %}}

## **Alle dia's omzetten naar afbeeldingen**

Itereer door de diacollectie om de volledige presentatie om te zetten in een reeks afbeeldingen. Verborgen dia's worden opgenomen tenzij je ze expliciet overslaat.

Het volgende voorbeeld rendert elke dia als een JPEG‑afbeelding met horizontale en verticale schaalfactoren van 2:

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

## **Enhanced Metafile‑output maken**

Enhanced Metafile (EMF) is handig wanneer vectorgebaseerde graphics moeten worden uitgewisseld met Microsoft Office of andere Windows‑toepassingen die Windows‑metabestanden ondersteunen. In tegenstelling tot een pixelgebaseerde afbeelding kan een EMF vectortekenbewerkingen behouden die zonder verlies van scherpte schalen. EMF is echter primair een compatibiliteitsformaat voor toepassingen met Windows‑metabestandsondersteuning, geen universeel uitwisselformaat. Bovendien kan complexe dia‑inhoud, zoals bitmap‑afbeeldingen en sommige effecten, opgeslagen worden als gerasterde elementen binnen de vector‑metabestandcontainer.

### **Een dia exporteren naar EMF**

De [Slide.writeAsEmf](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slide/#writeAsEmf) methode schrijft een dia naar een doel‑stream in EMF‑formaat. Het volgende voorbeeld laadt een presentatie, selecteert de eerste dia en schrijft deze naar een EMF‑bestandsstream:

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

De aanroeper bezit de stream die aan [Slide.writeAsEmf](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slide/#writeAsEmf) wordt doorgegeven en is verantwoordelijk voor het sluiten ervan, zoals hierboven getoond.

### **Een SVG‑afbeelding omzetten naar EMF en toevoegen aan een presentatie**

Gebruik [SvgImage.writeAsEmf](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/svgimage/#writeAsEmf) om SVG‑inhoud naar EMF te converteren. De resulterende bytes kunnen via [ImageCollection.addImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/imagecollection/#addImage) aan de presentatie worden toegevoegd en op een dia worden geplaatst met [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shapecollection/#addPictureFrame).

Het volgende voorbeeld maakt een [SvgImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/svgimage/) van SVG‑markup, converteert deze naar een in‑memory EMF, voegt het metafile toe op de eerste dia en slaat de presentatie op:

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

[SvgImage.writeAsEmf](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/svgimage/#writeAsEmf) neemt geen eigendom van de bestemmingsstream. Een `java.io.ByteArrayOutputStream` slaat alle gegenereerde data in het geheugen op, zodat er geen positie‑reset nodig is voordat `toByteArray` wordt aangeroepen. Het geretourneerde byte‑array blijft geldig nadat de stream is gesloten.

EMF‑generatie is beschikbaar op de besturingssystemen die worden ondersteund door de geselecteerde Aspose.Slides for Node.js via Java en JDK‑configuratie, maar het renderen kan per platform verschillen wanneer lettertypen of grafische afhankelijkheden ontbreken. Installeer de lettertypen die door de broninhoud worden gebruikt of configureer geschikte substituties, volg de [platform‑vereisten](/slides/nl/nodejs-java/system-requirements/) voor Aspose.Slides for Node.js via Java, en controleer het resultaat in de doel‑EMF‑consument‑applicatie. Linux‑ en macOS‑toepassingen hebben vaak beperkte of inconsistente ondersteuning voor het weergeven en bewerken van Windows‑metabestanden.

## **Kleurrijke Emoji‑rendering**

{{% alert title="Opmerking" color="info" %}}
Om kleuren‑emoji’s correct te renderen bij het omzetten van presentatiedia’s naar afbeeldingen, moeten de emoji‑lettertypen die in de presentatie worden gebruikt geïnstalleerd en beschikbaar zijn op het systeem dat de conversie uitvoert. Bijvoorbeeld, als de presentatie **Segoe UI Emoji** gebruikt en dit lettertype ontbreekt, kunnen emoji’s monochroom verschijnen in de uitvoerafbeeldingen.
{{% /alert %}}

## **FAQ**

**Ondersteunt Aspose.Slides het renderen van dia's met animaties?**

Nee. De [Slide.getImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slide/#getImage) methode rendert een statische afbeelding van de dia en exporteert geen animaties.

**Kunnen verborgen dia's worden geëxporteerd als afbeeldingen?**

Ja. Verborgen dia's kunnen worden gerenderd net als normale dia's. Neem ze op in de verwerkingslus, zoals weergegeven in het voorbeeld hierboven.

**Worden schaduwen en andere effecten behouden in dia‑afbeeldingen?**

Ja. Aspose.Slides rendert schaduwen, transparantie en andere ondersteunde grafische effecten in dia‑afbeeldingen.