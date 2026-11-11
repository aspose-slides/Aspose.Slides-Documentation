---
title: "Presentatie‑dia's renderen als SVG‑afbeeldingen in PHP"
linktitle: "Dia naar SVG"
type: docs
weight: 50
url: /nl/php-java/render-a-slide-as-an-svg-image/
keywords:
- "PowerPoint naar SVG"
- "presentatie naar SVG"
- "dia naar SVG"
- "PPT naar SVG"
- "PPTX naar SVG"
- "SVG‑exportopties"
- "interactieve SVG"
- "PowerPoint"
- "presentatie"
- "PHP"
- "Aspose.Slides"
description: "Exporteer PowerPoint‑dia's als SVG‑afbeeldingen in PHP en beheer lettertypen, tekst, afbeeldingen, ID's en gebeurtenissen met Aspose.Slides."
---
## **Overzicht**

SVG is een schaalbaar XML‑gebaseerd beeldformaat dat goed werkt voor webpublicatie, presentatieweergaven, toegankelijkheidsworkflows en geautomatiseerde nabewerking. Aspose.Slides exporteert elke dia naar een apart SVG‑bestand en stelt u in staat om te bepalen hoe tekst, lettertypen, afbeeldingen en SVG‑elementen worden weggeschreven.

Gebruik [SVGOptions](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/) wanneer de geëxporteerde SVG compact moet zijn, voorspelbaar over browsers heen, of klaar voor interactief gebruik.

## **Een dia exporteren als SVG**

Maak een [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/), selecteer een dia en schrijf deze naar een stream met [Slide.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#writeAsSvg). Het volgende voorbeeld exporteert elke dia in een presentatie naar een apart SVG‑bestand.

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

De bestandsnaam gebruikt [Slide.getSlideNumber](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getSlideNumber) in plaats van de lusindex. U kunt ook een individuele vorm exporteren met [Shape.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#writeAsSvg) wanneer een presentatieweergave of webpagina alleen die vorm nodig heeft.

## **SVG‑output configureren**

[SVGOptions](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/) regelt de SVG‑rendering. Voor tekstkaders zorgt [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setUseFrameSize) ervoor dat het tekstkader in het rendergebied wordt opgenomen, en [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setUseFrameRotation) bepaalt of de rotatie van het kader wordt toegepast. Stel [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setDisableFontLigatures) in op `true` wanneer tekst zonder ligaturen moet worden gerenderd.

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

## **Bijsnijden van lijnuiteinden bij pijlpuntjes**

SVG 1.1 heeft geen marker‑inset‑instelling om op te geven waar een lijn moet stoppen onder een pijlpunt. Standaard verkort Aspose.Slides de geëxporteerde lijn zodat de lijnbreedt niet door de marker heen steekt. Roep [SVGOptions::setDisableLineEndCropping](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setdisablelineendcropping/) aan met `true` om de lijnstreek helemaal tot aan het oorspronkelijke eindpunt van de lijn te tekenen. Deze instelling heeft alleen invloed op de SVG‑output. De lijn behoudt haar positie en lengte op de dia.

Het voorbeeld tekent driehoek‑ en ruit‑pijlpuntjes op lijnen van 2 en 10 punten breed. Het exporteert dezelfde dia tweemaal, waarbij alleen de bijsnijdingsoptie wordt gewijzigd.

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\SVGOptions;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $y = 40;

    foreach ([LineArrowheadStyle::Triangle, LineArrowheadStyle::Diamond] as $style) {
        foreach ([2, 10] as $width) {
            $line = $slide->getShapes()->addAutoShape(ShapeType::Line, 40, $y, 200, 0);
            $format = $line->getLineFormat();
            $format->getFillFormat()->setFillType(FillType::Solid);
            $color = new Java("java.awt.Color", 0, 0, 139);
            $format->getFillFormat()->getSolidFillColor()->setColor($color);
            $format->setWidth($width);
            $format->setEndArrowheadStyle($style);
            $y += 50;
        }
    }

    $options = new SVGOptions();
    $options->setDisableLineEndCropping(false);
    $cropped = new Java("java.io.FileOutputStream", "cropped.svg");
    try {
        $slide->writeAsSvg($cropped, $options);
    } finally {
        $cropped->close();
    }

    $options->setDisableLineEndCropping(true);
    $uncropped = new Java("java.io.FileOutputStream", "uncropped.svg");
    try {
        $slide->writeAsSvg($uncropped, $options);
    } finally {
        $uncropped->close();
    }
} finally {
    $presentation->dispose();
}
```

De vergelijking hieronder toont hetzelfde gebied van de ingesloten raster op dezelfde vergrote weergavegrootte. De diagonale lijnen vertonen zichtbare pixelatie bij 72 DPI en gladdere randen bij hogere resoluties, terwijl het SVG‑bestand groter wordt. Het verhogen van de waarde verbetert niet per se elk detail of wijzigt elke geëxporteerde afbeelding.

![Enlarged 10-point triangle with a sharp tip when cropping is enabled and a flat end when cropping is disabled](line-end-cropping.png)

In de andere lijnen uit het voorbeeld is de uitsteekende lijn minder zichtbaar op de 2‑punt driehoek. Het gevulde ruit bedekt het einde van de lijn op beide breedtes.

## **Tekst en lettertypen beheren**

Bij het exporteren van dia's naar SVG kunt u bepalen of tekst behouden blijft als tekst of wordt omgezet naar vectorafbeeldingen, en hoe externe lettertypen worden opgenomen of gerefereerd. De volgende opties helpen u een evenwicht te vinden tussen visuele consistentie, tekstselectie en lettertype‑afhankelijkheden in de geëxporteerde SVG.

### **Alle tekst vectoriseren**

Stel [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) in op `true` om alle dia‑tekst als vectorafbeeldingen weg te schrijven. Hierdoor verdwijnen lettertype‑afhankelijkheden en wordt het visuele resultaat consistenter over browsers heen, maar is de tekst niet langer selecteerbaar of doorzoekbaar als SVG‑tekst.

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

### **Kies hoe externe lettertypen worden verwerkt**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setExternalFontsHandling) gebruikt een [SvgExternalFontsHandling](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/)‑waarde voor lettertypen die extern worden geladen. Kies `AddLinksToFontFiles` om aparte lettertype‑bestanden te refereren, `Embed` om lettertype‑data in de SVG op te nemen, of `Vectorize` om alleen tekst die externe lettertypen gebruikt als grafische weergave te renderen. Controleer de licentie van het lettertype voordat u lettertypen embedt.

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

## **Grootte van ingesloten afbeeldingen verkleinen**

Gebruik [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setPicturesCompression) om de resolutie van ingesloten afbeeldingen te verlagen, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) om bijgesneden brongebieden weg te laten, en [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setJpegQuality) om de JPEG‑coderingskwaliteit te regelen. Deze instellingen verkleinen de bestandsgrootte ten koste van de beeldfidelity of behouden afbeeldingsdata.

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

## **Resolutie van metafile‑rasterisatie beheersen**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setmetafilerasterizationdpi/) stelt de ondergrens voor de resolutie bij het rasteren van metafiles tijdens SVG‑export in. Gebruik dit om detail en bestandsgrootte in balans te houden wanneer een EMF‑ of WMF‑afbeelding wordt gerasterd. Het definieert geen globale DPI voor de SVG en dwingt niet elk object op de dia tot een raster‑afbeelding.

Download [metafile-rasterization.pptx](metafile-rasterization.pptx), dat een EMF‑afbeelding bevat met nauw opeenvolgende diagonale lijnen. Het volgende voorbeeld exporteert de eerste dia op drie rasterisatie‑resoluties via [Slide.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/slide/writeassvg/). Alle andere exportinstellingen blijven identiek zodat de resultaten vergeleken kunnen worden.

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

In de output is de EMF omgezet naar één ingesloten PNG in elke SVG. De volgende metingen zijn voor de meegeleverde presentatie; ze vormen geen algemene formule voor het omzetten van DPI naar pixelafmetingen.

| Metafile‑rasterisatie‑DPI | Ingesloten PNG‑afmetingen | SVG‑bestandsgrootte (bytes) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

De vergelijking hieronder toont hetzelfde gebied van de ingesloten raster op dezelfde vergrote weergavegrootte. De diagonale lijnen vertonen zichtbare pixelatie bij 72 DPI en gladdere randen bij hogere resoluties, terwijl het SVG‑bestand groter wordt. Het verhogen van de waarde verbetert niet per se elk detail of wijzigt elke geëxporteerde afbeelding.

![Vergrote diagonale‑lijndetail bij 72, 150 en 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setpicturescompression/) regelt de vermindering van de afbeeldingsresolutie en kan het effect van het wijzigen van de metafile‑rasterisatie‑resolutie maskeren. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setjpegquality/) regelt de JPEG‑coderingskwaliteit, niet de metafile‑rasterisatie‑resolutie.

## **Stabiele ID's toewijzen aan vormen en tekst**

Geef een formatterings‑callback door aan [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setShapeFormattingController) om [SvgShape.setId](https://reference.aspose.com/slides/php-java/aspose.slides/svgshape/#setId) voor elke SVG‑vorm in te stellen. De callback kan ook [SvgTSpan.setId](https://reference.aspose.com/slides/php-java/aspose.slides/svgtspan/#setId)‑waarden op tekst‑`tspan`‑elementen instellen.

PhpJavaBridge kan geen PHP‑callback aanroepen vanuit `writeAsSvg` wanneer het in stream‑modus draait. Plaats de formatteringslogica in een kleine Java‑helperklasse, compileer deze en voeg het resulterende JAR‑bestand toe aan het bridge‑classpath. De helper kan [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getOfficeInteropShapeId) gebruiken, dat stabiel is gedurende de levensduur van de vorm, en een herhaalbare teller voor de tekst‑spans. Zie de [Java‑implementatie van `StableSvgIdController`](/slides/nl/java/render-a-slide-as-an-svg-image/#assign-stable-ids-to-shapes-and-text) voor de helpercode.

Nadat de gecompileerde klasse `com.example.slides.StableSvgIdController` aan het bridge‑classpath is toegevoegd, maakt u een instantie aan vanuit PHP en wijst u deze toe aan `SVGOptions`:

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

## **SVG‑eventhandlers toevoegen**

In een formatterings‑callback roept u [SvgShape.setEventHandler](https://reference.aspose.com/slides/php-java/aspose.slides/svgshape/#setEventHandler) aan met een [SvgEvent](https://reference.aspose.com/slides/php-java/aspose.slides/svgevent/)‑waarde om een JavaScript‑eventhandler toe te voegen aan een geëxporteerde vorm. Wijs de callback toe met [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setShapeFormattingController) en definieer de JavaScript‑functie in de pagina of SVG‑document die het resultaat host.

Net als bij stabiele ID's implementeert u de callback in een Java‑helper wanneer PhpJavaBridge stream‑modus gebruikt. De [Java‑implementatie van `SvgEventController`](/slides/nl/java/render-a-slide-as-an-svg-image/#add-svg-event-handlers) kent een ID en een `OnClick`‑handler toe aan een vorm met de naam `ActionButton`. Compileer die helper, voeg deze toe aan het bridge‑classpath als `com.example.slides.SvgEventController`, en gebruik deze vanuit PHP als volgt:

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

De host‑pagina kan de JavaScript‑functie definiëren die door de handler wordt aangeroepen. Het toewijzen van ID's en eventhandlers maakt slide‑viewers, toegankelijkheidsverbeteringen en andere interactieve SVG‑workflows mogelijk.

## **Veelgestelde vragen**

**Wanneer moet ik [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) gebruiken in plaats van [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/)?**

Gebruik [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) wanneer alle tekst onafhankelijk van lettertypen moet zijn. Gebruik [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/) wanneer alleen tekst die externe lettertypen gebruikt, moet worden omgezet naar grafische weergave.

**Wat is de beste manier om een SVG kleiner te maken?**

Begin met het comprimeren van ingesloten afbeeldingen, het verwijderen van bijgesneden afbeeldingsgebieden, en het kiezen van gekoppelde lettertype‑bestanden wanneer de doelomgeving ze kan leveren. Test het resultaat omdat een lagere beeldresolutie, lagere JPEG‑kwaliteit en gevectoriseerde tekst elk verschillende afwegingen tussen kwaliteit en grootte hebben.

**Kan ik geëxporteerde SVG‑elementen aanpassen na export?**

Ja. Ken ID's toe via een formatterings‑callback en selecteer vervolgens de overeenkomstige SVG‑elementen in uw nabewerkings‑tool of browserscript.