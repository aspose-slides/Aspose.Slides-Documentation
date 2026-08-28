---
title: Presentatiedia's omzetten naar afbeeldingen in PHP
linktitle: Dia naar afbeelding
type: docs
weight: 35
url: /nl/php-java/convert-slide/
keywords:
- dia omzetten
- dia exporteren
- dia naar afbeelding
- dia opslaan als afbeelding
- dia naar EMF
- dia naar PNG
- dia naar JPEG
- dia naar bitmap
- dia naar TIFF
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Zet dia's van PPT-, PPTX- en ODP-presentaties om naar PNG, JPEG, GIF, TIFF, EMF en andere afbeeldingsformaten in PHP met Aspose.Slides."
---
## **Inleiding**

Aspose.Slides for PHP via Java kan individuele dia's uit PowerPoint‑ en OpenDocument‑presentaties weergeven als PNG, JPEG, GIF, TIFF en andere beeldformaten.

Om een dia om te zetten naar een afbeelding, volg deze stappen:

1. Laad de presentatie met de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑klasse.
2. Selecteer de dia die u wilt weergeven.
3. Indien nodig, configureer de weergave met de [RenderingOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/renderingoptions/)‑ of [TiffOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/tiffoptions/)‑klasse.
4. Roep de [Slide::getImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slide/#getImage)‑methode aan. Deze retourneert een [IImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/iimage/)‑object.
5. Roep de [IImage::save](https://reference.aspose.com/slides/nl/php-java/aspose.slides/iimage/#save)‑methode aan en geef het uitvoerformaat op met een [ImageFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/imageformat/)‑waarde.

## **Een dia omzetten naar een PNG‑afbeelding**

De eenvoudigste conversie gebruikt de standaard weergave‑instellingen. Het resulterende [IImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/iimage/)‑object kan in het geheugen worden verwerkt of naar een bestand worden opgeslagen.

De volgende PHP‑voorbeeldcode rendert de eerste dia en slaat deze op als een PNG‑afbeelding:

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

## **Dia's omzetten naar afbeeldingen met aangepaste afmetingen**

Gebruik de [Slide::getImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slide/#getImage)‑overload die een [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html)‑waarde accepteert om een dia met exacte pixelafmetingen te renderen.

Het volgende voorbeeld maakt een JPEG‑afbeelding van 1820 × 1040 pixels:

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

## **Dia's met notities en opmerkingen omzetten naar afbeeldingen**

Standaard bevatten dia‑afbeeldingen geen notities of opmerkingen. Geef een [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/notescommentslayoutingoptions/)‑object door aan de [RenderingOptions::setSlidesLayoutOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions)‑methode om te bepalen waar notities en opmerkingen worden weergegeven.

Het volgende voorbeeld plaatst ingekorte notities onder de dia en opmerkingen rechts ervan:

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

{{% alert title="Waarschuwing" color="warning" %}}
Voor dia‑naar‑afbeelding‑conversie moet u geen [BottomFull](https://reference.aspose.com/slides/nl/php-java/aspose.slides/notespositions/) doorgeven aan de [NotesCommentsLayoutingOptions::setNotesPosition](https://reference.aspose.com/slides/nl/php-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition)‑methode. Notities kunnen meer tekst bevatten dan de vaste afbeeldingsgrootte aankan. Gebruik in plaats daarvan [BottomTruncated](https://reference.aspose.com/slides/nl/php-java/aspose.slides/notespositions/).
{{% /alert %}}

## **Dia's omzetten naar afbeeldingen met TIFF‑opties**

De [TiffOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/tiffoptions/)‑klasse stelt u in staat de grootte, resolutie en andere eigenschappen van de gerenderde TIFF‑afbeelding te regelen.

Het volgende voorbeeld rendert de eerste dia als een TIFF‑afbeelding van 2160 × 2880 pixels met 300 DPI:

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

{{% alert title="Waarschuwing" color="warning" %}}
TIFF‑ondersteuning wordt niet gegarandeerd in Java‑versies ouder dan JDK 9.
{{% /alert %}}

## **Alle dia's omzetten naar afbeeldingen**

Itereer door de dia‑collectie om de volledige presentatie om te zetten naar een reeks afbeeldingen. Verborgen dia's worden meegenomen tenzij u ze expliciet overslaat.

Het volgende voorbeeld rendert elke dia als een JPEG‑afbeelding met horizontale en verticale schaalfactoren van 2:

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

## **Verbeterde Metafile‑output maken**

Enhanced Metafile (EMF) is nuttig wanneer vector‑gebaseerde graphics moeten worden uitgewisseld met Microsoft Office of andere Windows‑toepassingen die Windows‑metabestanden ondersteunen. In tegenstelling tot een pixel‑gebaseerde afbeelding kan een EMF vector‑tekenbewerkingen behouden die schalen zonder verlies van scherpte. EMF is echter primair een compatibiliteitsformaat voor applicaties met Windows‑metabestandondersteuning, geen universeel uitwisselingsformaat. Bovendien kan complexe dia‑inhoud, zoals bitmap‑afbeeldingen en sommige effecten, als gerasterde elementen in de vector‑metabestandcontainer worden opgeslagen.

### **Een dia exporteren naar EMF**

De [Slide::writeAsEmf](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slide/#writeAsEmf)‑methode schrijft een dia naar een doel‑stream in EMF‑formaat. Het volgende voorbeeld laadt een presentatie, selecteert de eerste dia en schrijft deze naar een EMF‑filestream:

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

De aanroeper is eigenaar van de stream die aan [Slide::writeAsEmf](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slide/#writeAsEmf) wordt doorgegeven en is verantwoordelijk voor het sluiten ervan, zoals hierboven getoond.

### **Een SVG‑afbeelding omzetten naar EMF en toevoegen aan een presentatie**

Gebruik [SvgImage::writeAsEmf](https://reference.aspose.com/slides/nl/php-java/aspose.slides/svgimage/#writeAsEmf) om SVG‑inhoud naar EMF te converteren. De resulterende bytes kunnen aan de presentatie worden toegevoegd via [ImageCollection::addImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/imagecollection/#addImage) en op een dia worden geplaatst met [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapecollection/#addPictureFrame).

Het volgende voorbeeld maakt een [SvgImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/svgimage/) van SVG‑markup, converteert deze naar een EMF‑bestand in het geheugen, voegt het metabestand in de eerste dia in en slaat de presentatie op:

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

[SvgImage::writeAsEmf](https://reference.aspose.com/slides/nl/php-java/aspose.slides/svgimage/#writeAsEmf) neemt geen eigendom van de bestemmings‑stream over. Een [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) slaat alle gegenereerde data in het geheugen op, zodat er geen positie‑reset nodig is vóór het aanroepen van `toByteArray`. Het geretourneerde byte‑array blijft geldig nadat de stream is gesloten.

EMF‑generatie is beschikbaar op de besturingssystemen die worden ondersteund door de gekozen Aspose.Slides for PHP via Java‑ en JDK‑configuratie, maar de weergave kan per platform verschillen wanneer lettertypen of grafische afhankelijkheden ontbreken. Installeer de in de broninhoud gebruikte lettertypen of configureer geschikte substituties, volg de [platform‑vereisten](/slides/nl/php-java/system-requirements/) voor Aspose.Slides for PHP via Java en controleer het resultaat in de EMF‑consumerende toepassing. Linux‑ en macOS‑toepassingen bieden vaak beperkte of inconsistente ondersteuning voor het weergeven en bewerken van Windows‑metabestanden.

## **Kleuren‑emoji‑weergave**

{{% alert title="Opmerking" color="info" %}}
Om kleuren‑emoji’s correct weer te geven bij het converteren van presentatiedia’s naar afbeeldingen, moeten de emoji‑lettertypen die in de presentatie worden gebruikt, geïnstalleerd en beschikbaar zijn op het systeem dat de conversie uitvoert. Bijvoorbeeld, als de presentatie **Segoe UI Emoji** gebruikt en dit lettertype ontbreekt, kunnen emoji’s in monokleur verschijnen in de uitvoer‑afbeeldingen.
{{% /alert %}}

## **FAQ**

**Ondersteunt Aspose.Slides het renderen van dia’s met animaties?**

Nee. De [Slide::getImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slide/#getImage)‑methode rendert een statische afbeelding van de dia en exporteert geen animaties.

**Kunnen verborgen dia’s als afbeeldingen worden geëxporteerd?**

Ja. Verborgen dia’s kunnen worden gerenderd net als reguliere dia’s. Neem ze op in de verwerkingslus, zoals getoond in het voorbeeld hierboven.

**Worden schaduwen en andere effecten behouden in dia‑afbeeldingen?**

Ja. Aspose.Slides rendert schaduwen, transparantie en andere ondersteunde grafische effecten in dia‑afbeeldingen.