---
title: Konvertera presentationsbilder till bildformat på Android
linktitle: Bild till bild
type: docs
weight: 35
url: /sv/androidjava/convert-slide/
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
- Android
- Java
- Aspose.Slides
description: "Konvertera bilder från PPT, PPTX och ODP till bildformat med Aspose.Slides för Android—snabb, högkvalitativ rendering med tydliga Java‑kodexempel."
---
## **Introduktion**

Aspose.Slides för Android via Java gör det enkelt att konvertera PowerPoint- och OpenDocument-presentationer till olika bildformat, inklusive BMP, PNG, JPG (JPEG), GIF och andra.

För att konvertera en bild till en bildfil, följ dessa steg:

1. Definiera önskade konverteringsinställningar och välj de bilder du vill exportera genom att använda:
    - [ITiffOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itiffoptions/)-gränssnittet, eller
    - [IRenderingOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/irenderingoptions/)-gränssnittet.
2. Generera bildfilen genom att anropa [getImage](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/islide/#getImage--)‑metoden.

I Aspose.Slides för Android via Java är [IImage](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iimage/)-gränssnittet ett gränssnitt som låter dig arbeta med bilder definierade av pixeldatat. Du kan använda detta gränssnitt för att spara bilder i ett brett spektrum av format (BMP, JPG, PNG osv.).

## **Konvertera bilder till bitmaps och spara bilderna i PNG**

Du kan konvertera en bild till ett bitmap‑objekt och använda det direkt i din applikation. Alternativt kan du konvertera en bild till en bitmap och sedan spara den i JPEG eller något annat föredraget format.

Den här koden demonstrerar hur du konverterar den första bilden i en presentation till ett bitmap‑objekt och sedan sparar bilden i PNG‑format:

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

## **Konvertera bilder till bildfiler med anpassade storlekar**

Du kan behöva en bild med en viss storlek. Genom att använda en överlagring av [getImage](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-), kan du konvertera en bild till en bild med specifika dimensioner (bredd och höjd).

Detta exempel visar hur du gör detta:

```java 
Size imageSize = new Size(1820, 1040);

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // Konvertera den första bilden i presentationen till en bitmap med den angivna storleken.
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

## **Konvertera bilder med anteckningar och kommentarer till bildfiler**

Vissa bilder kan innehålla anteckningar och kommentarer.

Aspose.Slides erbjuder två gränssnitt—[ITiffOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itiffoptions/) och [IRenderingOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/irenderingoptions/)—som låter dig kontrollera rendering av presentationsbilder till bildfiler. Båda gränssnitten inkluderar metoden `setSlidesLayoutOptions`, som gör det möjligt att konfigurera rendering av anteckningar och kommentarer på en bild när den konverteras till en bild.

Med klassen [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/notescommentslayoutingoptions/) kan du ange din föredragna position för anteckningar och kommentarer i den resulterande bilden.

Den här koden demonstrerar hur du konverterar en bild med anteckningar och kommentarer:

```java 
float scaleX = 2;
float scaleY = scaleX;

// Läs in en presentationsfil.
Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    NotesCommentsLayoutingOptions notesCommentsOptions = new NotesCommentsLayoutingOptions();
    notesCommentsOptions.setNotesPosition(NotesPositions.BottomTruncated);  // Ange positionen för noteringarna.
    notesCommentsOptions.setCommentsPosition(CommentsPositions.Right);      // Ange positionen för kommentarerna.
    notesCommentsOptions.setCommentsAreaWidth(500);                         // Ange bredden på kommentarsområdet.
    notesCommentsOptions.setCommentsAreaColor(Color.LTGRAY);   // Ange färgen för kommentarsområdet.

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

{{% alert title="Note" color="warning" %}} 

I någon bild‑till‑bildkonverteringsprocess kan inte [setNotesPosition](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/inotescommentslayoutingoptions/#setNotesPosition-int-)‑metoden tillämpa `BottomFull` (för att ange position för anteckningar) eftersom en antecknings text kan vara för stor för att få plats i den angivna bildstorleken.

{{% /alert %}} 

## **Konvertera bilder till bildfiler med TIFF‑alternativ**

[ITiffOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itiffoptions/)-gränssnittet ger större kontroll över den resulterande TIFF‑bilden genom att låta dig ange parametrar som storlek, upplösning, färgpalett med mera.

Den här koden demonstrerar en konverteringsprocess där TIFF‑alternativ används för att generera en svart‑vit bild med 300 DPI upplösning och en storlek på 2160 × 2800:

```java 
// Läs in en presentationsfil.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Hämta den första bilden från presentationen.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Konfigurera inställningarna för den resulterande TIFF-bilden.
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setImageSize(new Size(2160, 2880));                  // Ange bildstorleken.
    tiffOptions.setPixelFormat(ImagePixelFormat.Format1bppIndexed);  // Ange pixelformatet (svartvitt).
    tiffOptions.setDpiX(300);                                        // Ange horisontell upplösning.
    tiffOptions.setDpiY(300);                                        // Ange vertikal upplösning.

    // Konvertera bilden till en bild med de angivna alternativen.
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

## **Konvertera alla bilder till bildfiler**

Aspose.Slides låter dig konvertera alla bilder i en presentation till bildfiler, vilket effektivt omvandlar hela presentationen till en serie bilder.

Detta exempel visar hur du konverterar alla bilder i en presentation till bildfiler i Java:

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

        // Konvertera bilden till en bild.
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

**Stöder Aspose.Slides rendering av bilder med animationer?**

Nej, metoden `getImage` sparar endast en statisk bild av bilden, utan animationer.

**Kan dolda bilder exporteras som bildfiler?**

Ja, dolda bilder kan behandlas på samma sätt som vanliga. Se bara till att de inkluderas i bearbetningsloopen.

**Kan bilder sparas med skuggor och effekter?**

Ja, Aspose.Slides stödjer rendering av skuggor, transparens och andra grafiska effekter när bilder sparas som bildfiler.