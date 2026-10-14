---
title: PowerPoint-dia's converteren naar PNG in PHP
linktitle: PowerPoint naar PNG
type: docs
weight: 30
url: /nl/php-java/convert-powerpoint-to-png/
keywords:
- PowerPoint converteren
- presentatie converteren
- dia converteren
- PPT converteren
- PPTX converteren
- PowerPoint naar PNG
- presentatie naar PNG
- dia naar PNG
- PPT naar PNG
- PPTX naar PNG
- PPT opslaan als PNG
- PPTX opslaan als PNG
- PPT exporteren naar PNG
- PPTX exporteren naar PNG
- PHP
- Aspose.Slides
description: "Converteer PowerPoint-presentaties snel naar hoogwaardige PNG-afbeeldingen met Aspose.Slides voor PHP via Java, voor nauwkeurige, geautomatiseerde resultaten."
---
## **Overzicht**

Dit artikel legt uit hoe u presentatieslides kunt converteren naar PNG‑afbeeldingen met Aspose.Slides voor PHP via Java. U kunt presentaties laden in formaten zoals PPT, PPTX en ODP, elke slide renderen en opslaan als een afzonderlijke PNG‑afbeelding.

De onderstaande voorbeelden demonstreren het renderen op de standaard schaal, het verhogen van de schaal, het specificeren van de uitvoerdimensies in pixels, en het kiezen van een gradient renderstijl.

## **PowerPoint converteren naar PNG**

Laad een presentatie met de [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) klasse en krijg toegang tot de slides via de [Presentation::getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides) collectie. Het voorbeeld rendert elke slide met [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) zonder parameters om een miniatuur te maken. Vervolgens wordt [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save) aangeroepen met [ImageFormat::Png](https://reference.aspose.com/slides/php-java/aspose.slides/imageformat/#Png) om elke gerenderde slide op te slaan als een PNG‑afbeelding.

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage();
        try {
            $image->save("slide_" . $index . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
De parameterloze [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) overload rendert op een schaal van 0.2. Bijvoorbeeld, een slide van 720 × 540 punten produceert een miniatuur van 144 × 108 pixels. Om de uitvoerdimensies te beheersen, gebruikt u de overloads met schaalfactoren of een expliciete afbeeldinggrootte zoals hieronder getoond.
{{% /alert %}}

## **PowerPoint converteren naar PNG met aangepaste afmetingen**

Geef horizontale en verticale schaalfactoren door aan [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) om de gerenderde afmetingen te regelen. In dit voorbeeld zijn beide factoren 2, dus een slide van 720 Г— 540 punten resulteert in een afbeelding van 1440 Г— 1080 pixels. Gelijke schaalfactoren behouden de beeldverhouding van de slide. Elke afbeelding wordt opgeslagen in PNG‑formaat met [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save).

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $scaleX = 2.0;
    $scaleY = $scaleX;

    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage($scaleX, $scaleY);
        try {
            $image->save("slide_" . $index . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **PowerPoint converteren naar PNG met aangepaste grootte**

Om de uitvoerdimensies in pixels op te geven, geeft u een grootte door aan [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) in plaats van schaalfactoren. Dit voorbeeld rendert elke slide op 960 Г— 720 pixels en slaat het resultaat op met [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save). Kies afmetingen die overeenkomen met de beeldverhouding van de slide om uitrekken van de afbeelding te voorkomen.

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $imageSize = new Java("java.awt.Dimension", 960, 720);

    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage($imageSize);
        try {
            $image->save("slide_" . $index . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Kies een gradient renderstijl**

Stel dat een slide gradientvullingen bevat, maar de overgangen in de geëxporteerde PNG lichter of anders lijken dan in PowerPoint. U kunt de [SaveOptions::setGradientStyle](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setGradientStyle) methode, geërfd via [RenderingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/renderingoptions/), gebruiken om te bepalen hoe de gradients worden gerenderd.

Download [gradient-styles.pptx](gradient-styles.pptx) en plaats het in de werkmap van de applicatie. De eerste slide bevat twee lineaire gradients: cyaan naar oranje bovenaan en blauw naar geel onderaan. Elke gradient heeft twee stops, op 0% en 100%.

Het volgende voorbeeld laadt deze presentatie en rendert dezelfde eerste slide in beide modi met [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage).

```php
use aspose\slides\GradientStyle;
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;
use aspose\slides\RenderingOptions;

$presentation = new Presentation("gradient-styles.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $gradientStyles = [GradientStyle::Default, GradientStyle::PowerPointUI];
    foreach ($gradientStyles as $style) {
        $options = new RenderingOptions();
        $options->setGradientStyle($style);

        $styleName = $style == GradientStyle::Default ? "Default" : "PowerPointUI";
        $image = $slide->getImage($options, 1.0, 1.0);
        try {
            $image->save("gradient-" . $styleName . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

| Default | PowerPointUI |
| --- | --- |
| ![Cyaan‑naar‑oranje en blauw‑naar‑geel gradients gerenderd met Default](gradient-Default.png) | ![Dezelfde gradients gerenderd met PowerPointUI](gradient-PowerPointUI.png) |

In dit voorbeeld geeft `Default` lichtere tussentoonkleuren, terwijl `PowerPointUI` donkerdere tussentoonkleuren produceert. Het verschil hangt af van de kleuren en stops in de gradient.

Kies `Default` wanneer de standaard Aspose.Slides output aan uw wensen voldoet. Probeer `PowerPointUI` wanneer uw prioriteit is om de weergave in PowerPoint te evenaren. Vergelijk beide resultaten met het beoogde resultaat; geen van beide modi is algemeen beter.

## **FAQ**

**Hoe kan ik een specifiek vorm, zoals een diagram of afbeelding, exporteren in plaats van de volledige slide?**

Aspose.Slides ondersteunt het [genereren van miniaturen voor individuele vormen](/slides/nl/php-java/create-shape-thumbnails/), waardoor u een vorm kunt renderen als een PNG‑afbeelding.

**Wordt parallelle conversie ondersteund op een server?**

Ja. Gebruik een aparte presentatie‑instantie voor elke thread of elk proces; [deel geen enkele instantie over threads](/slides/nl/php-java/multithreading/).

**Wat zijn de evaluatiebeperkingen bij het exporteren naar PNG?**

In de evaluatiemodus wordt er een watermerk aan de uitvoer‑afbeeldingen toegevoegd en worden [andere beperkingen](/slides/nl/php-java/licensing/) toegepast totdat een licentie is geïnstalleerd.