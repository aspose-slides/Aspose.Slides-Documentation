---
title: Konvertera presentationsbilder till bilder i PHP
linktitle: Bild till bild
type: docs
weight: 35
url: /sv/php-java/convert-slide/
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
- PHP
- Aspose.Slides
description: "Konvertera bilder från PPT, PPTX och ODP till bildfiler med Aspose.Slides för PHP via Java — snabb, högkvalitativ rendering med tydliga kodexempel."
---
## **Introduktion**

Aspose.Slides för PHP via Java gör det enkelt att konvertera PowerPoint‑ och OpenDocument‑presentationer till olika bildformat, inklusive BMP, PNG, JPG (JPEG), GIF och andra.

För att konvertera en bild till en bildfil, följ dessa steg:

1. Definiera önskade konverteringsinställningar och välj de bilder du vill exportera med hjälp av:
    - [TiffOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/tiffoptions/) klassen, eller
    - [RenderingOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/renderingoptions/) klassen.
2. Generera bildfilen genom att anropa [getImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slide/#getImage) metoden.

I Aspose.Slides för PHP via Java är ett [IImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/iimage/) en klass som låter dig arbeta med bilder definierade av pixeldata. Du kan använda denna klass för att spara bilder i ett brett sortiment av format (BMP, JPG, PNG osv.).

## **Konvertera bilder till bitmaps och spara bilderna i PNG**

Du kan konvertera en bild till ett bitmap‑objekt och använda det direkt i din applikation. Alternativt kan du konvertera en bild till ett bitmap‑objekt och sedan spara bilden i JPEG eller något annat föredraget format.

Denna kod demonstrerar hur du konverterar den första bilden i en presentation till ett bitmap‑objekt och sedan sparar bilden i PNG‑format:

```php
$presentation = new Presentation("Presentation.pptx");
try {
    // Konvertera den första bilden i presentationen till en bitmap.
    $image = $presentation->getSlides()->get_Item(0)->getImage();
    try {
        // Spara bilden i PNG-format.
        $image->save("Slide_0.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **Konvertera bilder till bilder med anpassade storlekar**

Du kan behöva få en bild i en viss storlek. Genom att använda en överlagring av [getImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slide/#getImage) kan du konvertera en bild till en bild med specifika dimensioner (bredd och höjd).

Denna exempelkod visar hur du gör detta:

```php
$imageSize = new Java("java.awt.Dimension", 1820, 1040);

$presentation = new Presentation("Presentation.pptx");
try {
    // Konvertera den första bilden i presentationen till en bitmap med den angivna storleken.
    $image = $presentation->getSlides()->get_Item(0)->getImage($imageSize);
    try {
        // Spara bilden i JPEG-format.
        $image->save("Slide_0.jpg", ImageFormat::Jpeg);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **Konvertera bilder med anteckningar och kommentarer till bilder**

Vissa bilder kan innehålla anteckningar och kommentarer.

Aspose.Slides tillhandahåller två klasser[TiffOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/tiffoptions/) och [RenderingOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/renderingoptions/)—som låter dig styra rendering av presentationsbilder till bildfiler. Båda klasserna innehåller metoden `setSlidesLayoutOptions`, som gör att du kan konfigurera rendering av anteckningar och kommentarer på en bild när du konverterar den till en bildfil.

Med [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/notescommentslayoutingoptions/) klassen kan du ange den föredragna positionen för anteckningar och kommentarer i den resulterande bilden.

Denna kod demonstrerar hur du konverterar en bild med anteckningar och kommentarer:

```php
$scaleX = 2;
$scaleY = $scaleX;

$presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    $notesCommentsOptions = new NotesCommentsLayoutingOptions();
    $notesCommentsOptions->setNotesPosition(NotesPositions::BottomTruncated);         // Ange positionen för anteckningarna.
    $notesCommentsOptions->setCommentsPosition(CommentsPositions::Right);             // Ange positionen för kommentarerna.
    $notesCommentsOptions->setCommentsAreaWidth(500);                                 // Ange bredden på kommentarsområdet.
    $notesCommentsOptions->setCommentsAreaColor(java("java.awt.Color")->LIGHT_GRAY);  // Ange färgen för kommentarsområdet.

    // Skapa renderingsalternativen.
    $options = new RenderingOptions();
    $options->setSlidesLayoutOptions($notesCommentsOptions);

    // Konvertera den första bilden i presentationen till en bild.
    $image = $presentation->getSlides()->get_Item(0)->getImage($options, $scaleX, $scaleY);
    try {
        // Spara bilden i GIF-format.
        $image->save("Image_with_notes_and_comments_0.gif", ImageFormat::Gif);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Note" color="warning" %}} 

I någon bild‑till‑bild‑konverteringsprocess kan inte metoden [setNotesPosition](https://reference.aspose.com/slides/sv/php-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) tillämpa `BottomFull` (för att ange position för anteckningar) eftersom en antecknings text kan vara för stor för att få plats inom den specificerade bildstorleken.

{{% /alert %}} 

## **Konvertera bilder till bilder med TIFF‑alternativ**

[TiffOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/tiffoptions/) klassen ger större kontroll över den resulterande TIFF‑bilden genom att låta dig ange parametrar såsom storlek, upplösning, färgpalett och mer.

Denna kod demonstrerar en konverteringsprocess där TIFF‑alternativ används för att producera en svart‑vit bild med 300 DPI upplösning och en storlek på 2160 × 2800:

```php
// Load a presentation file.
$presentation = new Presentation("sample.pptx");
try {
    // Get the first slide from the presentation.
    $slide = $presentation->getSlides()->get_Item(0);

    // Configure the settings of the output TIFF image.
    $options = new TiffOptions();
    $options->setImageSize(new Java("java.awt.Dimension", 2160, 2880));  // Set the image size.
    $options->setPixelFormat(ImagePixelFormat::Format1bppIndexed);       // Set the pixel format (black and white).
    $options->setDpiX(300);                                              // Set the horizontal resolution.
    $options->setDpiY(300);                                              // Set the vertical resolution.
    
    // Convert the slide to an image with the specified options.
    $image = $slide->getImage($options);
    try {
        // Save the image in TIFF format.
        $image->save("output.tiff", ImageFormat::Tiff);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Note" color="warning" %}} 

Tiff‑stöd garanteras inte i versioner tidigare än JDK 9.

{{% /alert %}} 

## **Konvertera alla bilder till bilder**

Aspose.Slides gör det möjligt att konvertera alla bilder i en presentation till bildfiler, vilket effektivt omvandlar hela presentationen till en serie bilder.

Denna exempelkod demonstrerar hur du konverterar alla bilder i en presentation till bildfiler i PHP:

```php
$scaleX = 2;
$scaleY = $scaleX;

$presentation = new Presentation("Presentation.pptx");
try {
    // Rendera presentationen till bilder bild för bild.
    for($i = 0; $i < java_values($presentation->getSlides()->size()) ; $i++) {
        // Hantera dolda bilder (rendera inte dolda bilder).
        if (java_values($presentation->getSlides()->get_Item($i)->getHidden())) {
            continue;
        }

        // Konvertera bilden till en bild.
        $image = $presentation->getSlides()->get_Item($i)->getImage($scaleX, $scaleY);
        try {
            // Spara bilden i JPEG-format.
            $image->save("Slide_" . $i . ".jpg", ImageFormat::Jpeg);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Färgrik Emoji‑rendering**

{{% alert title="Note" color="warning" %}} 
För att rendera färgade emojis korrekt när du konverterar presentationsbilder till bildfiler måste emoji‑fonterna som används i presentationen vara installerade och tillgängliga på systemet som utför konverteringen. Till exempel, om presentationen använder **Segoe UI Emoji** och detta teckensnitt saknas, kan emojis visas i monokrom i de genererade bilderna.
{{% /alert %}}

## **Vanliga frågor**

**Stöder Aspose.Slides rendering av bilder med animationer?**

Nej, `getImage`‑metoden sparar endast en statisk bild av bilden, utan animationer.

**Kan dolda bilder exporteras som bildfiler?**

Ja, dolda bilder kan behandlas precis som vanliga. Se bara till att de inkluderas i bearbetningsloopen.

**Kan bilder sparas med skuggor och effekter?**

Ja, Aspose.Slides stöder rendering av skuggor, transparens och andra grafiska effekter när bilder sparas som bildfiler.