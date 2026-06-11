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
description: "Konvertera bilder från PPT, PPTX och ODP till bilder i JavaScript med Aspose.Slides för Node.js via Java — snabb, högkvalitativ rendering med tydliga kodexempel."
---
## **Introduktion**

Aspose.Slides för Node.js via Java gör det enkelt att konvertera PowerPoint‑ och OpenDocument‑presentationer till olika bildformat, inklusive BMP, PNG, JPG (JPEG), GIF och andra.

För att konvertera en bild till en bildfil, följ dessa steg:

1. Definiera önskade konverteringsinställningar och välj de bilder du vill exportera genom att använda:
    - Klassen [TiffOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/tiffoptions/), eller
    - Klassen [RenderingOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/renderingoptions/).
2. Generera bildfilen genom att anropa metoden [getImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slide/#getImage).

I Aspose.Slides för Node.js via Java är en [IImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/iimage/) en klass som låter dig arbeta med bilder definierade av pixeldata. Du kan använda denna klass för att spara bilder i ett brett sortiment av format (BMP, JPG, PNG osv.).

## **Konvertera bilder till bitmap och spara dem i PNG**

Du kan konvertera en bild till ett bitmap‑objekt och använda det direkt i din applikation. Alternativt kan du konvertera en bild till en bitmap och sedan spara den i JPEG eller något annat önskat format.

Denna JavaScript‑kod visar hur du konverterar den första bilden i en presentation till ett bitmap‑objekt och sedan sparar bilden i PNG‑format:

```js
let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Konvertera den första bilden i presentationen till en bitmap.
    let image = presentation.getSlides().get_Item(0).getImage();
    try {
        // Spara bilden i PNG-format.
        image.save("Slide_0.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Konvertera bilder till bilder med anpassade storlekar**

Du kan behöva en bild i en viss storlek. Genom att använda en överlagring av [getImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slide/#getImage) kan du konvertera en bild till en bild med specifika dimensioner (bredd och höjd).

Denna exempelkod visar hur du gör detta:

```js
let imageSize = java.newInstanceSync("java.awt.Dimension", 1820, 1040);

let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Konvertera den första bilden i presentationen till en bitmap med angiven storlek.
    let image = presentation.getSlides().get_Item(0).getImage(imageSize);
    try {
        // Spara bilden i JPEG-format.
        image.save("Slide_0.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Konvertera bilder med anteckningar och kommentarer till bilder**

Vissa bilder kan innehålla anteckningar och kommentarer.

Aspose.Slides tillhandahåller två klasser—[TiffOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/tiffoptions/) och [RenderingOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/renderingoptions/)—som låter dig styra rendering av presentationsbilder till bilder. Båda klasserna innehåller metoden `setSlidesLayoutOptions`, som gör det möjligt att konfigurera rendering av anteckningar och kommentarer på en bild när den konverteras till en bild.

Med klassen [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/notescommentslayoutingoptions/) kan du ange din föredragna position för anteckningar och kommentarer i den resulterande bilden.

Denna JavaScript‑kod visar hur du konverterar en bild med anteckningar och kommentarer:

```js
const scaleX = 2;
const scaleY = scaleX;

// Load a presentation file.
let presentation = new aspose.slides.Presentation("Presentation_with_notes_and_comments.pptx");
try {
    let notesCommentsOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesCommentsOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);                  // Ange positionen för anteckningarna.
    notesCommentsOptions.setCommentsPosition(aspose.slides.CommentsPositions.Right);                      // Ange positionen för kommentarerna.
    notesCommentsOptions.setCommentsAreaWidth(500);                                                       // Ange bredden på kommentarsområdet.
    notesCommentsOptions.setCommentsAreaColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));  // Ange färgen för kommentarsområdet.

    // Skapa renderingsalternativen.
    let options = new aspose.slides.RenderingOptions();
    options.setSlidesLayoutOptions(notesCommentsOptions);
 
    // Konvertera den första bilden i presentationen till en bild.
    let image = presentation.getSlides().get_Item(0).getImage(options, scaleX, scaleY);
    try {
        // Spara bilden i GIF-format.
        image.save("Image_with_notes_and_comments_0.gif", aspose.slides.ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
I alla bild‑till‑bild‑konverteringsprocesser kan metoden [setNotesPosition](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) inte tillämpa `BottomFull` (för att ange positionen för anteckningar) eftersom en antecknings text kan vara för stor och därmed inte få plats i den angivna bildstorleken.
{{% /alert %}} 

## **Konvertera bilder till bilder med TIFF‑alternativ**

Klassen [TiffOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/tiffoptions/) ger större kontroll över den resulterande TIFF‑bilden genom att låta dig specificera parametrar som storlek, upplösning, färgpalett och mer.

Denna JavaScript‑kod visar en konverteringsprocess där TIFF‑alternativ används för att generera en svart‑vit bild med 300 DPI‑upplösning och en storlek på 2160 × 2800:

```js
// Läs in en presentationsfil.
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // Hämta den första bilden från presentationen.
    let slide = presentation.getSlides().get_Item(0);

    // Konfigurera inställningarna för den utgående TIFF-bilden.
    let tiffOptions = new aspose.slides.TiffOptions();
    tiffOptions.setImageSize(java.newInstanceSync("java.awt.Dimension", 2160, 2880));  // Ange bildstorlek.
    tiffOptions.setPixelFormat(aspose.slides.ImagePixelFormat.Format1bppIndexed);      // Ange pixelformaten (svartvitt).
    tiffOptions.setDpiX(300);                                                          // Ange horisontell upplösning.
    tiffOptions.setDpiY(300);                                                          // Ange vertikal upplösning.

    // Konvertera bilden till en bild med de angivna alternativen.
    let image = slide.getImage(tiffOptions);
    try {
        // Spara bilden i TIFF-format.
        image.save("output.tiff", aspose.slides.ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
Tiff‑stöd garanteras inte i versioner äldre än JDK 9.
{{% /alert %}} 

## **Konvertera alla bilder till bilder**

Aspose.Slides låter dig konvertera alla bilder i en presentation till bilder, vilket effektivt omvandlar hela presentationen till en serie bilder.

Denna exempelkod visar hur du konverterar alla bilder i en presentation till bilder i JavaScript:

```js
const scaleX = 2;
const scaleY = scaleX;

let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Rendera presentationen till bilder bild för bild.
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        // Hantera dolda bilder (rendera inte dolda bilder).
        if (presentation.getSlides().get_Item(i).getHidden()) {
            continue;
        }

        // Konvertera bilden till en bild.
        let image = presentation.getSlides().get_Item(i).getImage(scaleX, scaleY);
        try {
            // Spara bilden i JPEG-format.
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

**Stöder Aspose.Slides rendering av bilder med animationer?**

Nej, metoden `getImage` sparar bara en statisk bild av bilden, utan animationer.

**Kan dolda bilder exporteras som bilder?**

Ja, dolda bilder kan behandlas precis som vanliga. Se bara till att de inkluderas i bearbetningsslingan.

**Kan bilder sparas med skuggor och effekter?**

Ja, Aspose.Slides stöder rendering av skuggor, transparens och andra grafiska effekter när bilder sparas som bilder.