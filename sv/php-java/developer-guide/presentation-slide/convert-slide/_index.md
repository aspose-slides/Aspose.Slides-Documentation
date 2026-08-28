---
title: "Konvertera presentationsbilder till bilder i PHP"
linktitle: "Bild till bild"
type: docs
weight: 35
url: /sv/php-java/convert-slide/
keywords:
- "konvertera bild"
- "exportera bild"
- "bild till bild"
- "spara bild som bild"
- "bild till EMF"
- "bild till PNG"
- "bild till JPEG"
- "bild till bitmap"
- "bild till TIFF"
- "PowerPoint"
- "OpenDocument"
- "presentation"
- "PHP"
- "Aspose.Slides"
description: "Konvertera bilder från PPT-, PPTX- och ODP-presentationer till PNG, JPEG, GIF, TIFF, EMF och andra bildformat i PHP med Aspose.Slides."
---
## **Introduktion**

Aspose.Slides for PHP via Java kan rendera enskilda bilder från PowerPoint- och OpenDocument-presentationer som PNG, JPEG, GIF, TIFF och andra bildformat.

För att konvertera en bild till en bildfil, följ dessa steg:

1. Läs in presentationen med klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/).
2. Välj den bild du vill rendera.
3. Om nödvändigt, konfigurera rendering med klassen [RenderingOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/renderingoptions/) eller [TiffOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/tiffoptions/).
4. Anropa metoden [Slide::getImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slide/#getImage). Den returnerar ett [IImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/iimage/)‑objekt.
5. Anropa metoden [IImage::save](https://reference.aspose.com/slides/sv/php-java/aspose.slides/iimage/#save) och specificera utdataformatet med ett [ImageFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/imageformat/)‑värde.

## **Konvertera en bild till en PNG‑bild**

Den enklaste konverteringen använder standardinställningarna för rendering. Det resulterande [IImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/iimage/)-objektet kan bearbetas i minnet eller sparas till en fil.

Följande PHP‑exempel renderar den första bilden och sparar den som en PNG‑bild:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage();
    try {
        $image->save("Slide_0.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **Konvertera bilder till bilder med anpassade storlekar**

Använd den [Slide::getImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slide/#getImage)-överladdning som accepterar ett [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html)-värde för att rendera en bild med exakt pixeldimensioner.

Följande exempel skapar en 1820 × 1040 JPEG‑bild:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$imageSize = new Java("java.awt.Dimension", 1820, 1040);

$presentation = new Presentation("Presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage($imageSize);
    try {
        $image->save("Slide_0.jpg", ImageFormat::Jpeg);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **Konvertera bilder med anteckningar och kommentarer till bilder**

Som standard inkluderar bildfiler inga anteckningar eller kommentarer. Skicka ett [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/notescommentslayoutingoptions/)-objekt till metoden [RenderingOptions::setSlidesLayoutOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) för att styra var anteckningar och kommentarer visas.

Följande exempel placerar avkortade anteckningar under bilden och kommentarer till höger om den:

```php
use aspose\slides\CommentsPositions;
use aspose\slides\ImageFormat;
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\NotesPositions;
use aspose\slides\Presentation;
use aspose\slides\RenderingOptions;

$scaleX = 2;
$scaleY = $scaleX;

$commentsAreaColor = new Java("java.awt.Color", 250, 235, 215);

$layoutOptions = new NotesCommentsLayoutingOptions();
$layoutOptions->setNotesPosition(NotesPositions::BottomTruncated);
$layoutOptions->setCommentsPosition(CommentsPositions::Right);
$layoutOptions->setCommentsAreaWidth(500);
$layoutOptions->setCommentsAreaColor($commentsAreaColor);

$renderingOptions = new RenderingOptions();
$renderingOptions->setSlidesLayoutOptions($layoutOptions);

$presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage($renderingOptions, $scaleX, $scaleY);
    try {
        $image->save("Image_with_notes_and_comments_0.gif", ImageFormat::Gif);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Warning" color="warning" %}}
Vid konvertering från bild till bildfil, skicka inte [BottomFull](https://reference.aspose.com/slides/sv/php-java/aspose.slides/notespositions/) till metoden [NotesCommentsLayoutingOptions::setNotesPosition](https://reference.aspose.com/slides/sv/php-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition). Anteckningar kan innehålla mer text än den fasta bildstorleken kan rymma. Använd [BottomTruncated](https://reference.aspose.com/slides/sv/php-java/aspose.slides/notespositions/) istället.
{{% /alert %}}

## **Konvertera bilder till bilder med TIFF‑alternativ**

[TiffOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/tiffoptions/)-klassen låter dig styra storlek, upplösning och andra egenskaper för den renderade TIFF‑bilden.

Följande exempel renderar den första bilden som en 2160 × 2880 TIFF‑bild med 300 DPI:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;
use aspose\slides\TiffOptions;

$imageSize = new Java("java.awt.Dimension", 2160, 2880);

$tiffOptions = new TiffOptions();
$tiffOptions->setImageSize($imageSize);
$tiffOptions->setDpiX(300);
$tiffOptions->setDpiY(300);

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage($tiffOptions);
    try {
        $image->save("output.tiff", ImageFormat::Tiff);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Warning" color="warning" %}}
TIFF‑stöd är inte garanterat i Java‑versioner äldre än JDK 9.
{{% /alert %}}

## **Konvertera alla bilder till bilder**

Iterera genom bildsamlingen för att konvertera hela presentationen till en serie bilder. Dolda bilder inkluderas om du inte uttryckligen hoppar över dem.

Följande exempel renderar varje bild som en JPEG‑bild med horisontella och vertikala skalningsfaktorer på 2:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$scaleX = 2;
$scaleY = $scaleX;

$presentation = new Presentation("Presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage($scaleX, $scaleY);
        try {
            $image->save("Slide_" . $index . ".jpg", ImageFormat::Jpeg);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Skapa Enhanced Metafile‑utdata**

Enhanced Metafile (EMF) är användbart när vektorgrafik måste utbytas med Microsoft Office eller andra Windows‑program som stöder Windows‑metafiler. Till skillnad från en pixelerad bild kan ett EMF‑format behålla vektorritningsoperationer som skalas utan samma förlust av skärpa. EMF är dock främst ett kompatibilitetsformat för program med stöd för Windows‑metafiler, inte ett universellt utbytesformat. Dessutom kan komplext bildinnehåll, såsom bitmap‑bilder och vissa effekter, lagras som rasteriserade element i vektormetafilstoppet.

### **Exportera en bild till EMF**

Metoden [Slide::writeAsEmf](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slide/#writeAsEmf) skriver en bild till ett mål‑ström i EMF‑format. Följande exempel läser in en presentation, väljer den första bilden och skriver den till ett EMF‑filström:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $emfStream = new Java("java.io.FileOutputStream", "Slide_0.emf");
    try {
        $slide->writeAsEmf($emfStream);
    } finally {
        $emfStream->close();
    }
} finally {
    $presentation->dispose();
}
```

Anroparen äger strömmen som skickas till [Slide::writeAsEmf](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slide/#writeAsEmf) och ansvarar för att stänga den, som visas ovan.

### **Konvertera en SVG‑bild till EMF och lägg till den i en presentation**

Använd [SvgImage::writeAsEmf](https://reference.aspose.com/slides/sv/php-java/aspose.slides/svgimage/#writeAsEmf) för att konvertera SVG‑innehåll till EMF. De resulterande bytes kan läggas till i presentationen via [ImageCollection::addImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/imagecollection/#addImage) och placeras på en bild med [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shapecollection/#addPictureFrame).

Följande exempel skapar en [SvgImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/svgimage/) från SVG‑markup, konverterar den till ett EMF i minnet, infogar metafilen på den första bilden och sparar presentationen:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SvgImage;

$svgContent = '<svg xmlns="http://www.w3.org/2000/svg" width="200" height="100"><rect width="200" height="100" fill="#4472C4"/></svg>';
$svgImage = new SvgImage($svgContent);

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $emfStream = new Java("java.io.ByteArrayOutputStream");
    try {
        $svgImage->writeAsEmf($emfStream);

        $emfData = $emfStream->toByteArray();
        $image = $presentation->getImages()->addImage($emfData);
        $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 200, 100, $image);
    } finally {
        $emfStream->close();
    }

    $presentation->save("Presentation_with_emf.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

[SvgImage::writeAsEmf](https://reference.aspose.com/slides/sv/php-java/aspose.slides/svgimage/#writeAsEmf) tar inte ägarskap över målströmmen. En [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) lagrar all genererad data i minnet, så ingen positionsåterställning krävs innan `toByteArray` anropas. Den returnerade byte‑arrayen förblir giltig efter att strömmen har stängts.

EMF‑generering är tillgänglig på de operativsystem som stöds av den valda Aspose.Slides for PHP via Java och JDK‑konfiguration, men rendering kan skilja sig mellan plattformar när teckensnitt eller grafiska beroenden saknas. Installera de teckensnitt som används av källinnehållet eller konfigurera lämpliga substitutioner, följ [plattformskraven](/slides/sv/php-java/system-requirements/) för Aspose.Slides for PHP via Java och validera resultatet i den mål‑EMF‑användande applikationen. Linux‑ och macOS‑program har ofta begränsat eller inkonsekvent stöd för att visa och redigera Windows‑metafiler.

## **Färgrik Emoji‑rendering**

{{% alert title="Note" color="info" %}}
För att rendera färgade emojis korrekt vid konvertering av presentationsbilder till bilder måste de emoji‑teckensnitt som används i presentationen vara installerade och tillgängliga på systemet som utför konverteringen. Till exempel, om presentationen använder **Segoe UI Emoji** och detta teckensnitt saknas, kan emojis visas i monokrom i utdatakrafterna.
{{% /alert %}}

## **FAQ**

**Stöder Aspose.Slides rendering av bilder med animationer?**

Nej. Metoden [Slide::getImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slide/#getImage) renderar en statisk bild av bilden och exporterar inte animationer.

**Kan dolda bilder exporteras som bilder?**

Ja. Dolda bilder kan renderas som vanliga bilder. Inkludera dem i bearbetningsloopen, som visas i exemplet ovan.

**Bevaras skuggor och andra effekter i bildfiler?**

Ja. Aspose.Slides renderar skuggor, transparens och andra stödda grafiska effekter i bildfiler.