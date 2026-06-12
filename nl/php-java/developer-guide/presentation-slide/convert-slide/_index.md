---
title: Presentatieslides naar afbeeldingen converteren in PHP
linktitle: Slide naar afbeelding
type: docs
weight: 35
url: /nl/php-java/convert-slide/
keywords:
- slide converteren
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
- PHP
- Aspose.Slides
description: "Converteer slides van PPT, PPTX en ODP naar afbeeldingen met Aspose.Slides for PHP via Java — snelle, hoogwaardige weergave met duidelijke code‑voorbeelden."
---
## **Inleiding**

Aspose.Slides for PHP via Java stelt u in staat om eenvoudig PowerPoint- en OpenDocument‑presentatieslides om te zetten naar verschillende afbeeldingformaten, waaronder BMP, PNG, JPG (JPEG), GIF en andere.

Om een slide om te zetten naar een afbeelding, volgt u deze stappen:

1. Definieer de gewenste conversie‑instellingen en selecteer de slides die u wilt exporteren door gebruik te maken van:
    - De [TiffOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/tiffoptions/) klasse, of
    - De [RenderingOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/renderingoptions/) klasse.
2. Genereer de slide‑afbeelding door de [getImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slide/#getImage) methode aan te roepen.

In Aspose.Slides for PHP via Java is een [IImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/iimage/) een klasse die u in staat stelt te werken met afbeeldingen gedefinieerd door pixelgegevens. U kunt deze klasse gebruiken om afbeeldingen op te slaan in een breed scala aan formaten (BMP, JPG, PNG, enz.).

## **Slides omzetten naar bitmap en de afbeeldingen opslaan in PNG**

U kunt een slide omzetten naar een bitmap‑object en dit direct in uw applicatie gebruiken. Alternatief kunt u een slide omzetten naar een bitmap en vervolgens de afbeelding opslaan in JPEG of een ander gewenst formaat.

Deze code laat zien hoe u de eerste slide van een presentatie omzet naar een bitmap‑object en vervolgens de afbeelding opslaat in PNG‑formaat:

```php
$presentation = new Presentation("Presentation.pptx");
try {
    // Converteer de eerste slide in de presentatie naar een bitmap.
    $image = $presentation->getSlides()->get_Item(0)->getImage();
    try {
        // Sla de afbeelding op in PNG-formaat.
        $image->save("Slide_0.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **Slides omzetten naar afbeeldingen met aangepaste afmetingen**

U wilt mogelijk een afbeelding van een bepaalde grootte verkrijgen. Met een overload van de [getImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slide/#getImage) kunt u een slide omzetten naar een afbeelding met specifieke afmetingen (breedte en hoogte).

Deze voorbeeldcode toont hoe u dit doet:

```php
$imageSize = new Java("java.awt.Dimension", 1820, 1040);

$presentation = new Presentation("Presentation.pptx");
try {
    // Converteer de eerste slide in de presentatie naar een bitmap met de opgegeven grootte.
    $image = $presentation->getSlides()->get_Item(0)->getImage($imageSize);
    try {
        // Sla de afbeelding op in JPEG-formaat.
        $image->save("Slide_0.jpg", ImageFormat::Jpeg);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **Slides met notities en opmerkingen omzetten naar afbeeldingen**

Sommige slides kunnen notities en opmerkingen bevatten.

Aspose.Slides biedt twee klassen[TiffOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/tiffoptions/) en [RenderingOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/renderingoptions/)—die u in staat stellen de weergave van presentatieslides naar afbeeldingen te beheren. Beide klassen bevatten de `setSlidesLayoutOptions`‑methode, waarmee u de weergave van notities en opmerkingen op een slide kunt configureren bij het converteren naar een afbeelding.

Met de [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/notescommentslayoutingoptions/) klasse kunt u uw gewenste positie voor notities en opmerkingen in de resulterende afbeelding aangeven.

Deze code laat zien hoe u een slide met notities en opmerkingen omzet:

```php
$scaleX = 2;
$scaleY = $scaleX;

$presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    $notesCommentsOptions = new NotesCommentsLayoutingOptions();
    $notesCommentsOptions->setNotesPosition(NotesPositions::BottomTruncated);         // Stel de positie van de notities in.
    $notesCommentsOptions->setCommentsPosition(CommentsPositions::Right);             // Stel de positie van de opmerkingen in.
    $notesCommentsOptions->setCommentsAreaWidth(500);                                 // Stel de breedte van het opmerkingengebied in.
    $notesCommentsOptions->setCommentsAreaColor(java("java.awt.Color")->LIGHT_GRAY);  // Stel de kleur van het opmerkingengebied in.

    // Maak de weergave‑opties aan.
    $options = new RenderingOptions();
    $options->setSlidesLayoutOptions($notesCommentsOptions);

    // Converteer de eerste slide van de presentatie naar een afbeelding.
    $image = $presentation->getSlides()->get_Item(0)->getImage($options, $scaleX, $scaleY);
    try {
        // Sla de afbeelding op in GIF‑formaat.
        $image->save("Image_with_notes_and_comments_0.gif", ImageFormat::Gif);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Note" color="warning" %}} 
In elk slide‑naar‑afbeelding‑conversieproces kan de [setNotesPosition](https://reference.aspose.com/slides/nl/php-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) methode `BottomFull` niet toepassen (om de positie van notities op te geven) omdat de tekst van een notitie te groot kan zijn om binnen de opgegeven afbeeldingsgrootte te passen. 
{{% /alert %}} 

## **Slides omzetten naar afbeeldingen met TIFF‑opties**

De [TiffOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/tiffoptions/) klasse biedt meer controle over de resulterende TIFF‑afbeelding door u parameters zoals grootte, resolutie, kleurenpalet en meer te laten specificeren.

Deze code toont een conversieproces waarbij TIFF‑opties worden gebruikt om een zwart‑wit‑afbeelding met een resolutie van 300 DPI en een grootte van 2160 × 2800 te genereren:

```php
// Laad een presentatiebestand.
$presentation = new Presentation("sample.pptx");
try {
    // Haal de eerste slide uit de presentatie.
    $slide = $presentation->getSlides()->get_Item(0);

    // Configureer de instellingen van de uitvoer-TIFF-afbeelding.
    $options = new TiffOptions();
    $options->setImageSize(new Java("java.awt.Dimension", 2160, 2880));  // Stel de afbeeldingsgrootte in.
    $options->setPixelFormat(ImagePixelFormat::Format1bppIndexed);       // Stel het pixelformaat in (zwart-wit).
    $options->setDpiX(300);                                              // Stel de horizontale resolutie in.
    $options->setDpiY(300);                                              // Stel de verticale resolutie in.
    
    // Converteer de slide naar een afbeelding met de opgegeven opties.
    $image = $slide->getImage($options);
    try {
        // Sla de afbeelding op in TIFF-formaat.
        $image->save("output.tiff", ImageFormat::Tiff);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Note" color="warning" %}} 
Tiff‑ondersteuning wordt niet gegarandeerd in versies ouder dan JDK 9. 
{{% /alert %}} 

## **Alle slides omzetten naar afbeeldingen**

Aspose.Slides stelt u in staat om alle slides in een presentatie om te zetten naar afbeeldingen, waardoor de volledige presentatie wordt omgezet in een reeks afbeeldingen.

Deze voorbeeldcode laat zien hoe u alle slides in een presentatie omzet naar afbeeldingen in PHP:

```php
$scaleX = 2;
$scaleY = $scaleX;

$presentation = new Presentation("Presentation.pptx");
try {
    // Render de presentatie naar afbeeldingen slide voor slide.
    for($i = 0; $i < java_values($presentation->getSlides()->size()) ; $i++) {
        // Beheer verborgen slides (render geen verborgen slides).
        if (java_values($presentation->getSlides()->get_Item($i)->getHidden())) {
            continue;
        }

        // Converteer de slide naar een afbeelding.
        $image = $presentation->getSlides()->get_Item($i)->getImage($scaleX, $scaleY);
        try {
            // Sla de afbeelding op in JPEG-formaat.
            $image->save("Slide_" . $i . ".jpg", ImageFormat::Jpeg);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Veelgestelde vragen**

**Ondersteunt Aspose.Slides het renderen van slides met animaties?**

Nee, de `getImage`‑methode slaat alleen een statische afbeelding van de slide op, zonder animaties.

**Kunnen verborgen slides worden geëxporteerd als afbeeldingen?**

Ja, verborgen slides kunnen net als gewone slides worden verwerkt. Zorg er gewoon voor dat ze zijn opgenomen in de verwerkingslus.

**Kunnen afbeeldingen worden opgeslagen met schaduwen en effecten?**

Ja, Aspose.Slides ondersteunt het renderen van schaduwen, transparantie en andere grafische effecten bij het opslaan van slides als afbeeldingen.