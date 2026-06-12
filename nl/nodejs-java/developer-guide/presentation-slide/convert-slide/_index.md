---
title: Presentatieslides omzetten naar afbeeldingen in JavaScript
linktitle: Slide naar afbeelding
type: docs
weight: 35
url: /nl/nodejs-java/convert-slide/
keywords:
- slide omzetten
- slide exporteren
- slide naar afbeelding
- slide opslaan als afbeelding
- slide naar PNG
- slide naar JPEG
- slide naar bitmap
- slide naar TIFF
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Slides van PPT, PPTX en ODP omzetten naar afbeeldingen in JavaScript met Aspose.Slides voor Node.js via Java - snelle, hoogwaardige rendering met duidelijke code-voorbeelden."
---
## **Inleiding**

Aspose.Slides for Node.js via Java stelt u in staat om eenvoudig PowerPoint- en OpenDocument‑presentatieslides om te zetten naar verschillende afbeeldingsformaten, waaronder BMP, PNG, JPG (JPEG), GIF en andere.

Om een slide om te zetten naar een afbeelding, volgt u deze stappen:

1. Definieer de gewenste conversie‑instellingen en selecteer de slides die u wilt exporteren met behulp van:
    - De [TiffOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/tiffoptions/) klasse, of
    - De [RenderingOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/renderingoptions/) klasse.
2. Genereer de slide‑afbeelding door de [getImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slide/#getImage) methode aan te roepen.

In Aspose.Slides for Node.js via Java is een [IImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/iimage/) een klasse die u toestaat te werken met afbeeldingen gedefinieerd door pixelgegevens. U kunt deze klasse gebruiken om afbeeldingen op te slaan in een breed scala aan formaten (BMP, JPG, PNG, enz.).

## **Slides omzetten naar bitmap en de afbeeldingen opslaan in PNG**

U kunt een slide converteren naar een bitmap‑object en deze direct in uw applicatie gebruiken. Alternatief kunt u een slide converteren naar een bitmap en vervolgens de afbeelding opslaan in JPEG of een ander gewenst formaat.

Deze JavaScript‑code toont hoe u de eerste slide van een presentatie naar een bitmap‑object converteert en vervolgens de afbeelding opslaat in PNG‑formaat:

```js
let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Converteer de eerste slide in de presentatie naar een bitmap.
    let image = presentation.getSlides().get_Item(0).getImage();
    try {
        // Sla de afbeelding op in PNG-formaat.
        image.save("Slide_0.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Slides omzetten naar afbeeldingen met aangepaste afmetingen**

U heeft mogelijk een afbeelding van een bepaalde grootte nodig. Met een overload van de [getImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slide/#getImage) kunt u een slide converteren naar een afbeelding met specifieke afmetingen (breedte en hoogte). 

Deze voorbeeldcode toont hoe u dit doet:

```js
let imageSize = java.newInstanceSync("java.awt.Dimension", 1820, 1040);

let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Converteer de eerste slide in de presentatie naar een bitmap met de opgegeven grootte.
    let image = presentation.getSlides().get_Item(0).getImage(imageSize);
    try {
        // Sla de afbeelding op in JPEG-formaat.
        image.save("Slide_0.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Slides met notities en opmerkingen omzetten naar afbeeldingen**

Sommige slides kunnen notities en opmerkingen bevatten.

Aspose.Slides biedt twee klassen—[TiffOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/tiffoptions/) en [RenderingOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/renderingoptions/)—die u controle geven over het renderen van presentatieslides naar afbeeldingen. Beide klassen bevatten de `setSlidesLayoutOptions`‑methode, waarmee u de weergave van notities en opmerkingen op een slide kunt configureren bij het omzetten naar een afbeelding.

Met de [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/notescommentslayoutingoptions/) klasse kunt u de gewenste positie voor notities en opmerkingen in de resulterende afbeelding opgeven.

Deze JavaScript‑code toont hoe u een slide met notities en opmerkingen converteert:

```js
const scaleX = 2;
const scaleY = scaleX;

// Load a presentation file.
let presentation = new aspose.slides.Presentation("Presentation_with_notes_and_comments.pptx");
try {
    let notesCommentsOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesCommentsOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);                  // Stel de positie van de notities in.
    notesCommentsOptions.setCommentsPosition(aspose.slides.CommentsPositions.Right);                      // Stel de positie van de opmerkingen in.
    notesCommentsOptions.setCommentsAreaWidth(500);                                                       // Stel de breedte van het opmerkingengebied in.
    notesCommentsOptions.setCommentsAreaColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));  // Stel de kleur van het opmerkingengebied in.

    // Maak de renderopties aan.
    let options = new aspose.slides.RenderingOptions();
    options.setSlidesLayoutOptions(notesCommentsOptions);
 
    // Converteer de eerste slide van de presentatie naar een afbeelding.
    let image = presentation.getSlides().get_Item(0).getImage(options, scaleX, scaleY);
    try {
        // Sla de afbeelding op in GIF-formaat.
        image.save("Image_with_notes_and_comments_0.gif", aspose.slides.ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 

In elk slide‑naar‑afbeelding‑conversieproces kan de [setNotesPosition](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition)‑methode `BottomFull` (om de positie voor notities op te geven) niet toepassen, omdat de tekst van een notitie mogelijk te groot is om binnen de opgegeven afbeeldingsgrootte te passen.

{{% /alert %}} 

## **Slides omzetten naar afbeeldingen met TIFF‑opties**

De [TiffOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/tiffoptions/) klasse biedt meer controle over de resulterende TIFF‑afbeelding door parameters zoals grootte, resolutie, kleurbetalings en meer te specificeren.

Deze JavaScript‑code toont een conversieproces waarbij TIFF‑opties worden gebruikt om een zwart‑wit afbeelding met een resolutie van 300 dpi en een grootte van 2160 × 2800 te genereren:

```js
// Laad een presentatiebestand.
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // Haal de eerste slide uit de presentatie.
    let slide = presentation.getSlides().get_Item(0);

    // Configureer de instellingen van de TIFF-uitvoerafbeelding.
    let tiffOptions = new aspose.slides.TiffOptions();
    tiffOptions.setImageSize(java.newInstanceSync("java.awt.Dimension", 2160, 2880));  // Stel de afbeeldingsgrootte in.
    tiffOptions.setPixelFormat(aspose.slides.ImagePixelFormat.Format1bppIndexed);      // Stel het pixelformaat in (zwart-wit).
    tiffOptions.setDpiX(300);                                                          // Stel de horizontale resolutie in.
    tiffOptions.setDpiY(300);                                                          // Stel de verticale resolutie in.

    // Converteer de slide naar een afbeelding met de opgegeven opties.
    let image = slide.getImage(tiffOptions);
    try {
        // Sla de afbeelding op in TIFF-formaat.
        image.save("output.tiff", aspose.slides.ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 

Tiff‑ondersteuning is niet gegarandeerd in versies ouder dan JDK 9.

{{% /alert %}} 

## **Alle slides omzetten naar afbeeldingen**

Aspose.Slides stelt u in staat om alle slides in een presentatie om te zetten naar afbeeldingen, waardoor de volledige presentatie wordt geconverteerd naar een reeks afbeeldingen.

Deze voorbeeldcode toont hoe u alle slides in een presentatie naar afbeeldingen converteert in JavaScript:

```js
const scaleX = 2;
const scaleY = scaleX;

let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Render de presentatie naar afbeeldingen dia per dia.
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        // Beheer verborgen dia's (render geen verborgen dia's).
        if (presentation.getSlides().get_Item(i).getHidden()) {
            continue;
        }

        // Converteer de dia naar een afbeelding.
        let image = presentation.getSlides().get_Item(i).getImage(scaleX, scaleY);
        try {
            // Sla de afbeelding op in JPEG-formaat.
            image.save("Slide_" + i + ".jpg", aspose.slides.ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Ondersteunt Aspose.Slides het renderen van slides met animaties?**

Nee, de `getImage`‑methode slaat alleen een statische afbeelding van de slide op, zonder animaties.

**Kunnen verborgen slides geëxporteerd worden als afbeeldingen?**

Ja, verborgen slides kunnen net als normale slides verwerkt worden. Zorg er alleen voor dat ze in de verwerkingslus worden meegenomen.

**Kunnen afbeeldingen opgeslagen worden met schaduwen en effecten?**

Ja, Aspose.Slides ondersteunt het renderen van schaduwen, transparantie en andere grafische effecten bij het opslaan van slides als afbeeldingen.