---
title: PowerPoint-presentaties converteren naar TIFF in PHP
titlelink: PowerPoint naar TIFF
type: docs
weight: 90
url: /nl/php-java/convert-powerpoint-to-tiff/
keywords:
- PowerPoint converteren
- OpenDocument converteren
- presentatie converteren
- dia converteren
- PPT converteren
- PPTX converteren
- PowerPoint naar TIFF
- presentatie naar TIFF
- dia naar TIFF
- PPT naar TIFF
- PPTX naar TIFF
- PPT opslaan als TIFF
- PPTX opslaan als TIFF
- PPT exporteren naar TIFF
- PPTX exporteren naar TIFF
- PHP
- Aspose.Slides
description: "Leer hoe u eenvoudig PowerPoint (PPT, PPTX) presentaties kunt omzetten naar hoogwaardige TIFF-afbeeldingen met Aspose.Slides voor PHP via Java, met code-voorbeelden."
---
## **Introductie**

TIFF (**Tagged Image File Format**) is een veelgebruikt, verliesvrij rasterafbeeldingsformaat dat bekend staat om zijn uitzonderlijke kwaliteit en gedetailleerde behoud van grafische elementen. Ontwerpers, fotografen en desktopuitgevers kiezen vaak TIFF om lagen, kleurnauwkeurigheid en oorspronkelijke instellingen in hun afbeeldingen te behouden.

Met Aspose.Slides kunt u moeiteloos uw PowerPoint‑dia’s (PPT, PPTX) en OpenDocument‑dia’s (ODP) direct omzetten naar hoogwaardige TIFF‑afbeeldingen, zodat uw presentaties maximale visuele getrouwheid behouden.

## **Presentatie naar TIFF converteren**

Met de [save](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#save)‑methode van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑klasse kunt u snel een volledige PowerPoint‑presentatie naar TIFF converteren. De resulterende TIFF‑afbeeldingen komen overeen met de standaarddia‑grootte.

Deze code laat zien hoe u een PowerPoint‑presentatie naar TIFF converteert:

```php
// Instantieer de Presentation-klasse die een presentatiedocument (PPT, PPTX, ODP, enz.) vertegenwoordigt.
$presentation = new Presentation("presentation.pptx");
try {
    // Sla de presentatie op als TIFF.
    $presentation->save("output.tiff", SaveFormat::Tiff);
} finally {
    $presentation->dispose();
}
```

## **Presentatie naar zwart-wit TIFF converteren**

De methode [setBwConversionMode](https://reference.aspose.com/slides/nl/php-java/aspose.slides/tiffoptions/#setBwConversionMode) in de [TiffOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/tiffoptions/)‑klasse stelt u in staat het algoritme te specificeren dat wordt gebruikt bij het omzetten van een gekleurde dia of afbeelding naar een zwart-wit TIFF. Let op: deze instelling is alleen van toepassing wanneer de [setCompressionType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/tiffoptions/#getCompressionType)‑methode is ingesteld op `CCITT4` of `CCITT3`.

Stel dat we een bestand “sample.pptx” hebben met de volgende dia:

![Een presentatieslide](slide_black_and_white.png)

Deze code laat zien hoe u de gekleurde dia naar een zwart‑wit TIFF converteert:

```php
$tiffOptions = new TiffOptions();
$tiffOptions->setCompressionType(TiffCompressionTypes::CCITT4);
$tiffOptions->setBwConversionMode(BlackWhiteConversionMode::Dithering);

$presentation = new Presentation("sample.pptx");
try {
    $presentation->save("output.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

Het resultaat:

![Zwart-wit TIFF](TIFF_black_and_white.png)

## **Presentatie naar TIFF met aangepaste grootte converteren**

Als u een TIFF‑afbeelding met specifieke afmetingen nodig heeft, kunt u uw gewenste waarden instellen via de methoden die beschikbaar zijn in [TiffOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/tiffoptions/). Bijvoorbeeld, de [setImageSize](https://reference.aspose.com/slides/nl/php-java/aspose.slides/tiffoptions/#getImageSize)‑methode maakt het mogelijk de grootte van de resulterende afbeelding te definiëren.

Deze code laat zien hoe u een PowerPoint‑presentatie naar TIFF‑afbeeldingen met een aangepaste grootte converteert:

```php
// Instantieer de Presentation-klasse die een presentatiebestand (PPT, PPTX, ODP, enz.) vertegenwoordigt.
$presentation = new Presentation("presentation.pptx");
try {
    $tiffOptions = new TiffOptions();

    // Stel het compressietype in.
    $tiffOptions->setCompressionType(TiffCompressionTypes::Default);
    /*
    Compressietypen:
        Default - Geeft het standaard compressieschema (LZW) aan.
        None - Geeft aan dat er geen compressie wordt toegepast.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // De diepte is afhankelijk van het compressietype en kan niet handmatig worden ingesteld.

    // Stel de DPI van de afbeelding in.
    $tiffOptions->setDpiX(200);
    $tiffOptions->setDpiY(200);

    // Stel de afbeeldingsgrootte in.
    $tiffOptions->setImageSize(new Java("java.awt.Dimension", 1728, 1078));

    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomFull);
    $tiffOptions->setSlidesLayoutOptions($notesOptions);

    // Sla de presentatie op als TIFF met de opgegeven grootte.
    $presentation->save("tiff-ImageSize.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

## **Presentatie naar TIFF met aangepast pixelformaat converteren**

Met de [setPixelFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/tiffoptions/#getPixelFormat)‑methode van de [TiffOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/tiffoptions/)‑klasse kunt u het gewenste pixelformaat voor de resulterende TIFF‑afbeelding opgeven.

Deze code laat zien hoe u een PowerPoint‑presentatie naar een TIFF‑afbeelding met een aangepast pixelformaat converteert:

```php
// Instantieer de Presentation-klasse die een presentatiebestand (PPT, PPTX, ODP, enz.) vertegenwoordigt.
$presentation = new Presentation("presentation.pptx");
try {
    $tiffOptions = new TiffOptions();

    $tiffOptions->setPixelFormat(ImagePixelFormat::Format8bppIndexed);
    /*
    ImagePixelFormat bevat de volgende waarden (zoals vermeld in de documentatie):
        Format1bppIndexed - 1 bit per pixel, geïndexeerd.
        Format4bppIndexed - 4 bits per pixel, geïndexeerd.
        Format8bppIndexed - 8 bits per pixel, geïndexeerd.
        Format24bppRgb    - 24 bits per pixel, RGB.
        Format32bppArgb   - 32 bits per pixel, ARGB.
    */

    // Sla de presentatie op als TIFF met de opgegeven afbeeldingsgrootte.
    $presentation->save("Tiff-PixelFormat.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Tip" color="primary" %}}

Bekijk de **GRATIS** PowerPoint‑naar‑poster converter van Aspose.

{{% /alert %}}

## **FAQ**

**Kan ik een individuele dia in plaats van de volledige PowerPoint‑presentatie naar TIFF converteren?**

Ja. Aspose.Slides maakt het mogelijk om individuele dia's uit PowerPoint‑ en OpenDocument‑presentaties afzonderlijk naar TIFF‑afbeeldingen te converteren.

**Is er een limiet aan het aantal dia's bij het converteren van een presentatie naar TIFF?**

Nee, Aspose.Slides stelt geen beperkingen aan het aantal dia's. U kunt presentaties van elke omvang naar TIFF‑formaat converteren.

**Worden PowerPoint‑animaties en overgangseffecten behouden bij het converteren van dia's naar TIFF?**

Nee, TIFF is een statisch beeldformaat. Daarom worden animaties en overgangseffecten niet behouden; alleen statische momentopnamen van de dia's worden geëxporteerd.