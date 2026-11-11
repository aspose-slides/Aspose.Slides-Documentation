---
title: Render presentatie-dia's als SVG-afbeeldingen in PHP
linktitle: Dia naar SVG
type: docs
weight: 50
url: /nl/php-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint naar SVG
- presentatie naar SVG
- dia naar SVG
- PPT naar SVG
- PPTX naar SVG
- SVG-exportopties
- interactieve SVG
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Exporteer PowerPoint-dia's als SVG-afbeeldingen in PHP en beheer lettertypen, tekst, afbeeldingen, ID's en gebeurtenissen met Aspose.Slides."
---
## **Overzicht**

SVG is een schaalbaar XML-gebaseerd afbeeldingsformaat dat goed werkt voor webpublicatie, diavoorbeelders, toegankelijkheidsworkflows en geautomatiseerde nabewerking. Aspose.Slides exporteert elke dia naar een afzonderlijk SVG‑bestand en stelt je in staat te bepalen hoe tekst, lettertypen, afbeeldingen en SVG‑elementen worden weggeschreven.

Gebruik [SVGOptions](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/) wanneer het geëxporteerde SVG compact moet zijn, voorspelbaar over browsers, of klaar voor interactief gebruik.

## **Exporteer een dia als SVG**

Maak een [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) aan, selecteer een dia en schrijf deze naar een stream met [Slide.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#writeAsSvg). Het volgende voorbeeld exporteert elke dia in een presentatie naar een afzonderlijk SVG‑bestand.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());

    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $slideNumber = java_values($slide->getSlideNumber());
        $outputFileName = sprintf("slide-%d.svg", $slideNumber);

        $svgStream = new Java("java.io.FileOutputStream", $outputFileName);
        $slide->writeAsSvg($svgStream);
        $svgStream->close();
    }
} finally {
    $presentation->dispose();
}
```

De bestandsnaam gebruikt [Slide.getSlideNumber](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getSlideNumber) in plaats van de lusindex. Je kunt ook een individuele vorm exporteren met [Shape.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#writeAsSvg), wanneer een dia‑viewer of webpagina alleen die vorm nodig heeft.

## **Configureer SVG‑output**

[SVGOptions](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/) beheert de SVG‑rendering. Voor tekstkaders omvat [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setUseFrameSize) het tekstkader in het rendergebied, en [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setUseFrameRotation) bepaalt of de rotatie van het kader wordt toegepast. Stel [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setDisableFontLigatures) in op `true` wanneer tekst zonder ligaturen moet worden gerenderd.

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $svgOptions = new SVGOptions();
    $svgOptions->setDisableFontLigatures(true);
    $svgOptions->setUseFrameSize(true);
    $svgOptions->setUseFrameRotation(false);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "slide-with-custom-options.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

## **Beheer tekst en lettertypen**

Bij het exporteren van dia's naar SVG kun je bepalen of tekst als tekst behouden blijft of wordt geconverteerd naar vectorafbeeldingen, en hoe externe lettertypen worden opgenomen of gerefereerd. De volgende opties helpen je om visuele consistentie, tekstselectie en lettertype‑afhankelijkheden in de geëxporteerde SVG in balans te brengen.

### **Vectoriseer alle tekst**

Stel [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) in op `true` om alle dia‑tekst als vectorafbeeldingen weg te schrijven. Dit elimineert lettertype‑afhankelijkheden en maakt het visuele resultaat consistenter over browsers, maar de tekst is niet langer selecteerbaar of doorzoekbaar als SVG‑tekst.

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $svgOptions = new SVGOptions();
    $svgOptions->setVectorizeText(true);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "slide-with-vectorized-text.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

### **Kies hoe externe lettertypen worden behandeld**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setExternalFontsHandling) gebruikt een [SvgExternalFontsHandling](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/)‑waarde voor lettertypen die extern worden geladen. Kies `AddLinksToFontFiles` om naar afzonderlijke lettertypebestanden te verwijzen, `Embed` om lettertype‑gegevens in de SVG op te nemen, of `Vectorize` om alleen tekst die externe lettertypen gebruikt als afbeeldingen te renderen. Controleer de licentie van het lettertype voordat je lettertypen inbedt.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $linkedFontsOptions = new SVGOptions();
    $linkedFontsOptions->setExternalFontsHandling(SvgExternalFontsHandling::AddLinksToFontFiles);
    $linkedFontsStream = new Java("java.io.FileOutputStream", "slide-with-font-links.svg");
    try {
        $slide->writeAsSvg($linkedFontsStream, $linkedFontsOptions);
    } finally {
        $linkedFontsStream->close();
    }

    $embeddedFontsOptions = new SVGOptions();
    $embeddedFontsOptions->setExternalFontsHandling(SvgExternalFontsHandling::Embed);
    $embeddedFontsStream = new Java("java.io.FileOutputStream", "slide-with-embedded-fonts.svg");
    try {
        $slide->writeAsSvg($embeddedFontsStream, $embeddedFontsOptions);
    } finally {
        $embeddedFontsStream->close();
    }

    $vectorizedExternalFontsOptions = new SVGOptions();
    $vectorizedExternalFontsOptions->setExternalFontsHandling(SvgExternalFontsHandling::Vectorize);
    $vectorizedExternalFontsStream = new Java("java.io.FileOutputStream", "slide-with-vectorized-external-fonts.svg");
    try {
        $slide->writeAsSvg($vectorizedExternalFontsStream, $vectorizedExternalFontsOptions);
    } finally {
        $vectorizedExternalFontsStream->close();
    }
} finally {
    $presentation->dispose();
}
```

## **Verklein ingevoegde afbeeldinggrootte**

Gebruik [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setPicturesCompression) om de resolutie van ingevoegde afbeeldingen te verlagen, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) om bijgesneden brongebieden weg te laten, en [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setJpegQuality) om de JPEG‑codeerkwaliteit te regelen. Deze instellingen verkleinen de bestandsgrootte ten koste van de beeldkwaliteit of het behouden van afbeeldingsgegevens.

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $svgOptions = new SVGOptions();
    $svgOptions->setPicturesCompression(PicturesCompression::Dpi150);
    $svgOptions->setDeletePicturesCroppedAreas(true);
    $svgOptions->setJpegQuality(80);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "compressed-slide.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

## **Beheer resolutie van metafile‑rasterisatie**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setmetafilerasterizationdpi/) stelt de ondergrens voor de resolutie in bij het rasteren van metafiles tijdens SVG‑export. Gebruik dit om detail en bestandsgrootte in balans te brengen wanneer een EMF‑ of WMF‑afbeelding wordt gerasterd. Het definieert geen globale DPI voor de SVG en dwingt niet elke object op de dia om een rasterafbeelding te worden.

Download [metafile-rasterization.pptx](metafile-rasterization.pptx), die een EMF‑afbeelding bevat met dicht op elkaar staande diagonale lijnen. Het volgende voorbeeld exporteert de eerste dia op drie rasterisatie‑resoluties via [Slide.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/slide/writeassvg/). Alle andere exportinstellingen blijven identiek zodat de resultaten vergeleken kunnen worden.

```php
$presentation = new Presentation("metafile-rasterization.pptx");

try {
    foreach ([72, 150, 300] as $dpi) {
        $svgOptions = new SVGOptions();
        $svgOptions->setMetafileRasterizationDpi($dpi);
        $svgOptions->setPicturesCompression(PicturesCompression::Dpi330);
        $svgOptions->setJpegQuality(90);

        $outputFileName = sprintf("slide-%d.svg", $dpi);
        $svgStream = new Java("java.io.FileOutputStream", $outputFileName);

        try {
            $presentation->getSlides()->get_Item(0)->writeAsSvg($svgStream, $svgOptions);
        } finally {
            $svgStream->close();
        }
    }
} finally {
    $presentation->dispose();
}
```

In de output is de EMF één ingevoegde PNG in elke SVG geworden. De volgende metingen gelden voor de meegeleverde presentatie; ze vormen geen algemene formule voor het omrekenen van DPI naar pixelafmetingen.

| Metafile‑rasterisatie DPI | Ingevoegde PNG‑afmetingen | SVG‑bestandsgrootte (bytes) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

De vergelijking hieronder toont hetzelfde gebied van de ingevoegde rasterafbeelding op dezelfde vergrote weergavegrootte. De diagonale lijnen vertonen zichtbare pixelatie bij 72 DPI en gladdere randen bij hogere resoluties, terwijl het SVG‑bestand groeit. Het verhogen van de waarde verbetert niet per se elk detail of verandert elke geëxporteerde afbeelding.

![Vergrote detail van diagonale lijn bij 72, 150 en 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setpicturescompression/) regelt de vermindering van de afbeeldingsresolutie en kan het effect van het wijzigen van de metafile‑rasterisatie‑resolutie maskeren. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setjpegquality/) regelt de JPEG‑codeerkwaliteit, niet de metafile‑rasterisatie‑resolutie.

## **Ken stabiele ID's toe aan vormen en tekst**

Voorzie een opmaak‑callback aan [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setShapeFormattingController) om [SvgShape.setId](https://reference.aspose.com/slides/php-java/aspose.slides/svgshape/#setId) in te stellen voor elke SVG‑vorm. De callback kan ook [SvgTSpan.setId](https://reference.aspose.com/slides/php-java/aspose.slides/svgtspan/#setId) waarden instellen op tekst‑`tspan`‑elementen.

PhpJavaBridge kan geen PHP‑callback aanroepen vanuit `writeAsSvg` wanneer het in stream‑modus draait. Plaats de opmaaklogica in een kleine Java‑helperklasse, compileer deze en voeg het resulterende JAR‑bestand toe aan de bridge‑classpath. De helper kan [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getOfficeInteropShapeId) gebruiken, die stabiel is gedurende de levensduur van de vorm, en een herhaalbare teller voor de tekst‑spans. Zie de [Java-implementatie van `StableSvgIdController`](/slides/nl/java/render-a-slide-as-an-svg-image/#assign-stable-ids-to-shapes-and-text) voor de helper‑code.

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $shapeFormattingController = new Java("com.example.slides.StableSvgIdController");

    $svgOptions = new SVGOptions();
    $svgOptions->setShapeFormattingController($shapeFormattingController);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "slide-with-stable-ids.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

## **Voeg SVG‑event‑handlers toe**

In een opmaak‑callback roep je [SvgShape.setEventHandler](https://reference.aspose.com/slides/php-java/aspose.slides/svgshape/#setEventHandler) aan met een [SvgEvent](https://reference.aspose.com/slides/php-java/aspose.slides/svgevent/)‑waarde om een JavaScript‑event‑handler toe te voegen aan een geëxporteerde vorm. Ken de callback toe met [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setShapeFormattingController) en definieer de JavaScript‑functie in de pagina of SVG‑document dat het resultaat host.

Zoals bij stabiele ID's, implementeer de callback in een Java‑helper wanneer PhpJavaBridge stream‑modus gebruikt. De [Java-implementatie van `SvgEventController`](/slides/nl/java/render-a-slide-as-an-svg-image/#add-svg-event-handlers) kent een ID en een `OnClick`‑handler toe aan een vorm met de naam `ActionButton`. Compileer die helper, voeg deze toe aan de bridge‑classpath als `com.example.slides.SvgEventController`, en gebruik hem vanuit PHP als volgt:

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $shapeFormattingController = new Java("com.example.slides.SvgEventController");

    $svgOptions = new SVGOptions();
    $svgOptions->setShapeFormattingController($shapeFormattingController);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "interactive-slide.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

De hostpagina kan de JavaScript‑functie definiëren die door de handler wordt aangeroepen. Het toekennen van ID's en event‑handlers maakt dia‑viewers, toegankelijkheidsverbeteringen en andere interactieve SVG‑workflows mogelijk.

## **FAQ**

**Wanneer moet ik [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) gebruiken in plaats van [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/)?**

Gebruik [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) wanneer alle tekst onafhankelijk van lettertypen moet zijn. Gebruik [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/) wanneer alleen tekst die externe lettertypen gebruikt, moet worden geconverteerd naar afbeeldingen.

**Wat is de beste manier om een SVG kleiner te maken?**

Begin met het comprimeren van ingevoegde afbeeldingen, het verwijderen van bijgesneden afbeeldingsgebieden, en het kiezen van gekoppelde lettertypebestanden wanneer de doelomgeving ze kan serveren. Test het resultaat omdat een lagere beeldresolutie, lagere JPEG‑kwaliteit en gevectoriseerde tekst elk verschillende kwaliteits‑ en grootte‑afwegingen hebben.

**Kan ik geëxporteerde SVG‑elementen na export aanpassen?**

Ja. Ken ID’s toe via een opmaak‑callback en selecteer vervolgens de overeenkomstige SVG‑elementen in je nabewerkings‑tool of browserscript.