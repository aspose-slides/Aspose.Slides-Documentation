---
title: Konvertera presentationsbilder till bilder i Java
linktitle: Bildspel till bild
type: docs
weight: 35
url: /sv/java/convert-slide/
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
- Java
- Aspose.Slides
description: "Konvertera bildspel från PPT, PPTX och ODP till bilder i Java med Aspose.Slides—snabb, högkvalitativ rendering med tydliga kodexempel."
---
## **Introduktion**

Aspose.Slides för Java gör det enkelt att konvertera PowerPoint- och OpenDocument-presentationer till olika bildformat, inklusive BMP, PNG, JPG (JPEG), GIF och andra.

För att konvertera ett bildspel till en bild, följ dessa steg:

1. Definiera önskade konverteringsinställningar och välj de bildspel du vill exportera genom att använda:
    - gränssnittet [ITiffOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itiffoptions/) eller
    - gränssnittet [IRenderingOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/irenderingoptions/).
2. Generera bildspelet som bild genom att anropa metoden [getImage](https://reference.aspose.com/slides/sv/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-).

I Aspose.Slides för Java är ett [IImage](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iimage/) ett gränssnitt som låter dig arbeta med bilder definierade av pixeldata. Du kan använda detta gränssnitt för att spara bilder i ett brett sortiment av format (BMP, JPG, PNG osv.).

## **Konvertera bildspel till bitmapp och spara bilderna i PNG**

Du kan konvertera ett bildspel till ett bitmap‑objekt och använda det direkt i din applikation. Alternativt kan du konvertera ett bildspel till en bitmap och sedan spara bilden i JPEG eller något annat föredraget format.

Denna kod visar hur du konverterar den första bilden i en presentation till ett bitmap‑objekt och sedan sparar bilden i PNG‑format:

```java 
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // Konvertera den första bilden i presentationen till en bitmap.
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

## **Konvertera bildspel till bilder med anpassade storlekar**

Du kan behöva en bild av en viss storlek. Genom att använda en överlagring av [getImage](https://reference.aspose.com/slides/sv/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-) kan du konvertera ett bildspel till en bild med specifika dimensioner (bredd och höjd).

Denna exempelkod visar hur du gör detta:

```java 
Dimension imageSize = new Dimension(1820, 1040);

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // Konvertera den första bilden i presentationen till en bitmap med angiven storlek.
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

## **Konvertera bildspel med anteckningar och kommentarer till bilder**

Vissa bildspel kan innehålla anteckningar och kommentarer.

Aspose.Slides tillhandahåller två gränssnitt—[ITiffOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itiffoptions/) och [IRenderingOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/irenderingoptions/)—som låter dig styra renderingen av presentationsbilder till bilder. Båda gränssnitten innehåller metoden `setSlidesLayoutOptions`, som gör det möjligt att konfigurera renderingen av anteckningar och kommentarer på en bild när den konverteras till en bild.

Med klassen [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/notescommentslayoutingoptions/) kan du ange din föredragna position för anteckningar och kommentarer i den resulterande bilden.

Denna kod visar hur du konverterar ett bildspel med anteckningar och kommentarer:

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

    // Konvertera den första bilden i presentationen till en bild.
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

{{% alert title="Obs" color="warning" %}} 
I någon bild‑till‑bild‑konverteringsprocess kan metoden [setNotesPosition](https://reference.aspose.com/slides/sv/java/com.aspose.slides/inotescommentslayoutingoptions/#setNotesPosition-int-) inte tillämpa `BottomFull` (för att ange position för anteckningar) eftersom en antecknings text kan vara för stor för att få plats inom den angivna bildstorleken.
{{% /alert %}} 

## **Konvertera bildspel till bilder med TIFF‑alternativ**

Gränssnittet [ITiffOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itiffoptions/) ger större kontroll över den resulterande TIFF‑bilden genom att låta dig specificera parametrar såsom storlek, upplösning, färgpalett och mer.

Denna kod demonstrerar en konverteringsprocess där TIFF‑alternativ används för att skapa en svart‑vit bild med 300 DPI upplösning och en storlek på 2160 × 2800:

```java 
// Läs in en presentationsfil.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Hämta den första bilden från presentationen.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Konfigurera inställningarna för den utgående TIFF-bilden.
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setImageSize(new Dimension(2160, 2880));             // Ange bildstorleken.
    tiffOptions.setPixelFormat(ImagePixelFormat.Format1bppIndexed);  // Ange pixelformatet (svartvitt).
    tiffOptions.setDpiX(300);                                        // Ange den horisontella upplösningen.
    tiffOptions.setDpiY(300);                                        // Ange den vertikala upplösningen.

    // Konvertera bilden till en bild med angivna alternativ.
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

{{% alert title="Obs" color="warning" %}} 
Tiff‑stöd garanteras inte i versioner äldre än JDK 9.
{{% /alert %}} 

## **Konvertera alla bildspel till bilder**

Aspose.Slides låter dig konvertera alla bilder i en presentation till bilder, vilket effektivt omvandlar hela presentationen till en serie bilder.

Denna exempelkod visar hur du konverterar alla bilder i en presentation till bilder i Java:

```java 
float scaleX = 2;
float scaleY = scaleX;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // Rendera presentationen till bilder bild för bild.
    for (int i = 0 ; i < presentation.getSlides().size(); i++)
    {
        // Hantera dolda bilder (rendera inte dolda bilder).
        if (presentation.getSlides().get_Item(i).getHidden())
            continue;

        // Konvertera sliden till en bild.
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

## **Färgrik Emoji‑rendering**

{{% alert title="Obs" color="warning" %}} 
För att rendera färgade emojis korrekt när du konverterar presentationsbilder till bilder måste de emoji‑typsnitt som används i presentationen vara installerade och tillgängliga på systemet som utför konverteringen. Till exempel, om presentationen använder **Segoe UI Emoji** och detta typsnitt saknas, kan emojis visas i monokrom i de resulterande bilderna.
{{% /alert %}} 

## **Vanliga frågor**

**Stöder Aspose.Slides renderering av bildspel med animationer?**

Nej, metoden `getImage` sparar endast en statisk bild av bildspelet, utan animationer.

**Kan dolda bildspel exporteras som bilder?**

Ja, dolda bildspel kan behandlas på samma sätt som vanliga. Se bara till att de inkluderas i bearbetningsloopen.

**Kan bilder sparas med skuggor och effekter?**

Ja, Aspose.Slides stöder renderning av skuggor, transparens och andra grafiska effekter när bildspel sparas som bilder.