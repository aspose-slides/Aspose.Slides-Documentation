---
title: Render Presentatie-dia's als SVG-afbeeldingen in PHP
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
description: "Exporteer PowerPoint-dia's als SVG-afbeeldingen in PHP en beheer lettertypen, tekst, afbeeldingen, ID's en events met Aspose.Slides."
---
## **Overzicht**

SVG is een schaalbaar op XML gebaseerd afbeeldingsformaat dat goed werkt voor webpublicatie, presentatieweergave, toegankelijkheidswerkstromen en geautomatiseerde nabewerking. Aspose.Slides exporteert elke dia naar een afzonderlijk SVG‑bestand en stelt u in staat om te bepalen hoe tekst, lettertypen, afbeeldingen en SVG‑elementen worden weggeschreven.

Gebruik [SVGOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/svgoptions/) wanneer de geëxporteerde SVG compact moet zijn, voorspelbaar over browsers, of klaar voor interactief gebruik.

## **Exporteer een dia als SVG**

Maak een [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/), selecteer een dia en schrijf deze naar een stream met [Slide.writeAsSvg](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slide/#writeAsSvg). Het volgende voorbeeld exporteert elke dia in een presentatie als een afzonderlijk SVG‑bestand.

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

De bestandsnaam gebruikt [Slide.getSlideNumber](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slide/#getSlideNumber) in plaats van de lusindex. U kunt ook een individuele vorm exporteren met [Shape.writeAsSvg](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/#writeAsSvg) wanneer een presentatieweergave of webpagina alleen die vorm nodig heeft.

## **Configureer SVG‑output**

[SVGOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/svgoptions/) bepaalt de SVG‑rendering. Voor tekstkaders omvat [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/nl/php-java/aspose.slides/svgoptions/#setUseFrameSize) het tekstkader in het rendergebied, en [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/svgoptions/#setUseFrameRotation) bepaalt of de rotatie van het kader wordt toegepast. Stel [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/nl/php-java/aspose.slides/svgoptions/#setDisableFontLigatures) in op `true` wanneer tekst zonder ligaturen moet worden gerenderd.

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

### **Vectoriseer alle tekst**

Stel [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nl/php-java/aspose.slides/svgoptions/#setVectorizeText) in op `true` om alle dia‑tekst als vectorafbeeldingen te schrijven. Dit verwijdert afhankelijkheden van lettertypen en maakt het visuele resultaat consistenter over browsers, maar de tekst is niet langer selecteerbaar of doorzoekbaar als SVG‑tekst.

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

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/nl/php-java/aspose.slides/svgoptions/#setExternalFontsHandling) gebruikt een [SvgExternalFontsHandling](https://reference.aspose.com/slides/nl/php-java/aspose.slides/svgexternalfontshandling/)‑waarde voor lettertypen die extern worden geladen. Kies `AddLinksToFontFiles` om verwijzingen naar afzonderlijke lettertypebestanden op te nemen, `Embed` om lettertypegegevens in de SVG op te nemen, of `Vectorize` om alleen tekst die externe lettertypen gebruikt als grafieken te renderen. Controleer de licentie van het lettertype voordat u lettertypen insluit.

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

## **Verminder de grootte van ingesloten afbeeldingen**

Gebruik [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/nl/php-java/aspose.slides/svgoptions/#setPicturesCompression) om de resolutie van ingesloten afbeeldingen te verlagen, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/nl/php-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) om bijgesneden brongebieden weg te laten, en [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/nl/php-java/aspose.slides/svgoptions/#setJpegQuality) om de kwaliteit van JPEG‑codering te regelen. Deze instellingen verkleinen de bestandsgrootte ten koste van afbeeldingsnauwkeurigheid of behouden beeldgegevens.

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

## **Wijs stabiele ID's toe aan vormen en tekst**

Geef een formatterings‑callback aan [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/nl/php-java/aspose.slides/svgoptions/#setShapeFormattingController) om [SvgShape.setId](https://reference.aspose.com/slides/nl/php-java/aspose.slides/svgshape/#setId) in te stellen voor elke SVG‑vorm. De callback kan ook [SvgTSpan.setId](https://reference.aspose.com/slides/nl/php-java/aspose.slides/svgtspan/#setId)‑waarden instellen op tekst‑`tspan`‑elementen.

PhpJavaBridge kan geen PHP‑callback aanroepen vanuit `writeAsSvg` wanneer het in stream‑modus draait. Plaats de formatteringslogica in een kleine Java‑helperklasse, compileer deze en voeg het resulterende JAR‑bestand toe aan het bridge‑classpath. De helper kan [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/#getOfficeInteropShapeId) gebruiken, dat gedurende de levensduur van de vorm stabiel is, en een herhaalbare teller voor de tekst‑spans. Zie de [Java implementation of `StableSvgIdController`](/slides/nl/java/render-a-slide-as-an-svg-image/#assign-stable-ids-to-shapes-and-text) voor de helpercode.

Na het toevoegen van de gecompileerde `com.example.slides.StableSvgIdController`‑klasse aan het bridge‑classpath, instantiateer deze vanuit PHP en wijs hem toe aan `SVGOptions`:

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

## **Voeg SVG‑event handlers toe**

In een formatterings‑callback, roep [SvgShape.setEventHandler](https://reference.aspose.com/slides/nl/php-java/aspose.slides/svgshape/#setEventHandler) aan met een [SvgEvent](https://reference.aspose.com/slides/nl/php-java/aspose.slides/svgevent/)‑waarde om een JavaScript‑event‑handler toe te voegen aan een geëxporteerde vorm. Wijs de callback toe met [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/nl/php-java/aspose.slides/svgoptions/#setShapeFormattingController) en definieer de JavaScript‑functie in de pagina of het SVG‑document dat het resultaat host.

Net als bij stabiele ID's, implementeer de callback in een Java‑helper wanneer PhpJavaBridge stream‑modus gebruikt. De [Java implementation of `SvgEventController`](/slides/nl/java/render-a-slide-as-an-svg-image/#add-svg-event-handlers) kent een ID en een `OnClick`‑handler toe aan een vorm met de naam `ActionButton`. Compileer die helper, voeg deze toe aan het bridge‑classpath als `com.example.slides.SvgEventController`, en gebruik deze vanuit PHP als volgt:

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

De hostpagina kan de JavaScript‑functie definiëren waar de handler naar verwijst. Het toewijzen van ID's en event‑handlers maakt presentatieweergaves, toegankelijkheidsverbeteringen en andere interactieve SVG‑werkstromen mogelijk.

## **FAQ**

**Wanneer moet ik [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nl/php-java/aspose.slides/svgoptions/#setVectorizeText) gebruiken in plaats van [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/nl/php-java/aspose.slides/svgexternalfontshandling/)?**

Gebruik [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nl/php-java/aspose.slides/svgoptions/#setVectorizeText) wanneer alle tekst onafhankelijk van lettertypen moet zijn. Gebruik [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/nl/php-java/aspose.slides/svgexternalfontshandling/) wanneer alleen tekst die externe lettertypen gebruikt moet worden omgezet naar grafieken.

**Wat is de beste manier om een SVG kleiner te maken?**

Begin met het comprimeren van ingesloten afbeeldingen, het verwijderen van bijgesneden beeldgebieden, en het kiezen van gekoppelde lettertypebestanden wanneer de doelomgeving ze kan leveren. Test het resultaat omdat een lagere afbeeldingsresolutie, een lagere JPEG‑kwaliteit en gevectoriseerde tekst elk andere kwaliteit‑en‑grootte‑afwegingen hebben.

**Kan ik geëxporteerde SVG‑elementen na de export wijzigen?**

Ja. Wijs ID's toe via een formatterings‑callback, en selecteer vervolgens de overeenkomende SVG‑elementen in uw nabewerkings‑tool of browserscript.