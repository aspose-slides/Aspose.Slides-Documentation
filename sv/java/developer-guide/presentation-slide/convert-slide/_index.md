---
title: "Konvertera presentationsbilder till bilder i Java"
linktitle: "Bildruta till bild"
type: docs
weight: 35
url: /sv/java/convert-slide/
keywords:
- konvertera bildruta
- exportera bildruta
- bildruta till bild
- spara bildruta som bild
- bildruta till PNG
- bildruta till JPEG
- bildruta till bitmap
- bildruta till TIFF
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Konvertera bildrutor från PPT, PPTX och ODP till bilder i Java med Aspose.Slides—snabb, högkvalitativ rendering med tydliga kodexempel."
---
## **Introduktion**

Aspose.Slides for Java gör det enkelt att konvertera PowerPoint- och OpenDocument-presentationer till olika bildformat, inklusive BMP, PNG, JPG (JPEG), GIF och andra.

För att konvertera en bildruta till en bild, följ dessa steg:

1. Definiera önskade konverteringsinställningar och välj de bildrutor du vill exportera genom att använda:
    - ITiffOptions‑gränssnittet,
    - IRenderingOptions‑gränssnittet.
2. Generera bildrutsbilden genom att anropa metoden [getImage](https://reference.aspose.com/slides/sv/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-) .

I Aspose.Slides for Java är ett [IImage](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iimage/) ett gränssnitt som gör att du kan arbeta med bilder definierade av pixeldata. Du kan använda detta gränssnitt för att spara bilder i ett brett spektrum av format (BMP, JPG, PNG osv.).

## **Konvertera bildrutor till bitmapp och spara bilderna i PNG**

Du kan konvertera en bildruta till ett bitmapp‑objekt och använda det direkt i din applikation. Alternativt kan du konvertera en bildruta till en bitmapp och sedan spara bilden i JPEG eller ett annat föredrivet format.

Denna kod demonstrerar hur du konverterar den första bildrutan i en presentation till ett bitmapp‑objekt och sedan sparar bilden i PNG‑format:

```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // Konvertera den första bildrutan i presentationen till en bitmap.
    IImage image = presentation.getSlides().get_Item(0).getImage();
    try {
        // Spara bilden i PNG-format.
        image.save("Slide_0.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Konvertera bildrutor till bilder med anpassade storlekar**

Du kan behöva en bild i en viss storlek. Genom att använda en överlagring av [getImage](https://reference.aspose.com/slides/sv/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-) kan du konvertera en bildruta till en bild med specifika dimensioner (bredd och höjd).

Denna exempelkod visar hur du gör detta:

```java
Dimension imageSize = new Dimension(1820, 1040);

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // Konvertera den första bildrutan i presentationen till en bitmap med angiven storlek.
    IImage image = presentation.getSlides().get_Item(0).getImage(imageSize);

    try {
        // Spara bilden i JPEG-format.
        image.save("Slide_0.jpg", ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Konvertera bildrutor med anteckningar och kommentarer till bilder**

Vissa bildrutor kan innehålla anteckningar och kommentarer.

Aspose.Slides tillhandahåller två gränssnitt—[ITiffOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itiffoptions/) och [IRenderingOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/irenderingoptions/)—som låter dig styra rendering av presentationsbildrutor till bilder. Båda gränssnitten innehåller metoden `setSlidesLayoutOptions`, som gör det möjligt att konfigurera rendering av anteckningar och kommentarer på en bildruta när den konverteras till en bild.

Med klassen [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/notescommentslayoutingoptions/) kan du ange din föredragna position för anteckningar och kommentarer i den resulterande bilden.

Denna kod demonstrerar hur du konverterar en bildruta med anteckningar och kommentarer:

```java
float scaleX = 2;
float scaleY = scaleX;

// Läs in en presentationsfil.
Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    NotesCommentsLayoutingOptions notesCommentsOptions = new NotesCommentsLayoutingOptions();
    notesCommentsOptions.setNotesPosition(NotesPositions.BottomTruncated);  // Ange positionen för anteckningarna.
    notesCommentsOptions.setCommentsPosition(CommentsPositions.Right);      // Ange positionen för kommentarerna.
    notesCommentsOptions.setCommentsAreaWidth(500);                         // Ange bredden på kommentarsområdet.
    notesCommentsOptions.setCommentsAreaColor(Color.LIGHT_GRAY);            // Ange färgen för kommentarsområdet.

    // Skapa renderingsalternativen.
    RenderingOptions options = new RenderingOptions();
    options.setSlidesLayoutOptions(notesCommentsOptions);

    // Konvertera den första bildrutan i presentationen till en bild.
    IImage image = presentation.getSlides().get_Item(0).getImage(options, scaleX, scaleY);

    try {
        // Spara bilden i GIF-format.
        image.save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 

I alla bildruta‑till‑bild‑konverteringsprocesser kan inte metoden [setNotesPosition](https://reference.aspose.com/slides/sv/java/com.aspose.slides/inotescommentslayoutingoptions/#setNotesPosition-int-) tillämpa `BottomFull` (för att ange position för anteckningar) eftersom en antecknings text kan vara för stor, vilket gör att den inte får plats inom den angivna bildstorleken.

{{% /alert %}} 

## **Konvertera bildrutor till bilder med TIFF‑alternativ**

[ITiffOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itiffoptions/)-gränssnittet ger större kontroll över den resulterande TIFF‑bilden genom att låta dig ange parametrar som storlek, upplösning, färgpalett och mer.

Denna kod demonstrerar en konverteringsprocess där TIFF‑alternativ används för att skapa en svart‑vit bild med en upplösning på 300 DPI och en storlek på 2160 × 2800:

```java
// Läs in en presentationsfil.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Hämta den första bildrutan från presentationen.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Konfigurera inställningarna för den utgående TIFF‑bilden.
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setImageSize(new Dimension(2160, 2880));             // Ange bildens storlek.
    tiffOptions.setPixelFormat(ImagePixelFormat.Format1bppIndexed);  // Ange pixelformatet (svartvitt).
    tiffOptions.setDpiX(300);                                        // Ange horisontell upplösning.
    tiffOptions.setDpiY(300);                                        // Ange vertikal upplösning.

    // Konvertera bildrutan till en bild med angivna alternativ.
    IImage image = slide.getImage(tiffOptions);

    try {
        // Spara bilden i TIFF-format.
        image.save("output.tiff", ImageFormat.Tiff);
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

## **Konvertera alla bildrutor till bilder**

Aspose.Slides låter dig konvertera alla bildrutor i en presentation till bilder, vilket effektivt omvandlar hela presentationen till en serie bilder.

Denna exempelkod demonstrerar hur du konverterar alla bildrutor i en presentation till bilder i Java:

```java
float scaleX = 2;
float scaleY = scaleX;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // Rendera presentationen till bilder bildruta för bildruta.
    for (int i = 0 ; i < presentation.getSlides().size(); i++)
    {
        // Kontrollera dolda bildrutor (rendera inte dolda bildrutor).
        if (presentation.getSlides().get_Item(i).getHidden())
            continue;

        // Konvertera bildrutan till en bild.
        IImage image = presentation.getSlides().get_Item(i).getImage(scaleX, scaleY);

        try {
            // Spara bilden i JPEG-format.
            image.save("Slide_" + i + ".jpg", ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
} 
```

## **FAQ**

**Stöder Aspose.Slides rendering av bildrutor med animationer?**

Nej, metoden `getImage` sparar endast en statisk bild av bildrutan, utan animationer.

**Kan dolda bildrutor exporteras som bilder?**

Ja, dolda bildrutor kan behandlas som vanliga. Se bara till att de inkluderas i bearbetningsloopen.

**Kan bilder sparas med skuggor och effekter?**

Ja, Aspose.Slides stöder rendering av skuggor, transparens och andra grafiska effekter när bildrutor sparas som bilder.