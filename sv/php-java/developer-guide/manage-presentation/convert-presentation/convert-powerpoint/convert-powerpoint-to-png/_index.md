---
title: Konvertera PowerPoint-bilder till PNG i PHP
linktitle: PowerPoint till PNG
type: docs
weight: 30
url: /sv/php-java/convert-powerpoint-to-png/
keywords:
- konvertera PowerPoint
- konvertera presentation
- konvertera bild
- konvertera PPT
- konvertera PPTX
- PowerPoint till PNG
- presentation till PNG
- bild till PNG
- PPT till PNG
- PPTX till PNG
- spara PPT som PNG
- spara PPTX som PNG
- exportera PPT till PNG
- exportera PPTX till PNG
- PHP
- Aspose.Slides
description: "Konvertera PowerPoint-presentationer till högkvalitativa PNG‑bilder snabbt med Aspose.Slides för PHP via Java, vilket säkerställer precisa, automatiserade resultat."
---
## **Översikt**

Den här artikeln förklarar hur du konverterar presentationsbilder till PNG‑bilder med Aspose.Slides för PHP via Java. Du kan läsa in presentationer i format som PPT, PPTX och ODP, rendera varje bild och spara den som en separat PNG‑fil.

Exemplen nedan visar rendering med standardskala, ökad skala, specificering av utdimensioner i pixlar och val av en gradientrenderingsstil.

## **Konvertera PowerPoint till PNG**

Läs in en presentation med klassen [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) och kom åt dess bilder via samlingen [Presentation::getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides). Exemplet renderar varje bild med [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) utan parametrar för att skapa en miniatyrbild. Därefter anropas [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save) med [ImageFormat::Png](https://reference.aspose.com/slides/php-java/aspose.slides/imageformat/#Png) för att spara varje renderad bild som en PNG‑fil.

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
Den parameterlösa överlagringen av [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) renderar med en skala på 0,2. Till exempel ger en bild som mäter 720 × 540 punkter en miniatyr på 144 × 108 pixlar. För att kontrollera utdimensionerna, använd överlagringarna med skalningsfaktorer eller en explicit bildstorlek som visas nedan.
{{% /alert %}}

## **Konvertera PowerPoint till PNG med anpassade dimensioner**

Passera horisontella och vertikala skalningsfaktorer till [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) för att kontrollera de renderade dimensionerna. I det här exemplet är båda faktorerna 2, så en bild som mäter 720 — 540 punkter ger en bild på 1440 — 1080 pixlar. Lika skalningsfaktorer bevarar bildens bildförhållande. Varje bild sparas i PNG‑format med [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save).

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

## **Konvertera PowerPoint till PNG med anpassad storlek**

För att specificera utdimensionerna i pixlar, skicka en storlek till [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) istället för skalningsfaktorer. Detta exempel renderar varje bild med 960 — 720 pixlar och sparar resultatet med [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save). Välj dimensioner som matchar bildens bildförhållande för att undvika att bilden sträcks.

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

## **Välj en gradientrenderingsstil**

Anta att en bild innehåller gradientfyllningar, men övergångarna i den exporterade PNG‑filen ser ljusare eller på annat sätt annorlunda ut än i PowerPoint. Du kan använda metoden [SaveOptions::setGradientStyle](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setGradientStyle) som ärvs av [RenderingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/renderingoptions/) för att välja hur gradienterna renderas.

Ladda ner [gradient-styles.pptx](gradient-styles.pptx) och placera den i applikationens arbetskatalog. Dess första bild innehåller två linjära gradienter: cyan till orange högst upp och blå till gul längst ner. Varje gradient har två stopp, vid 0 % och 100 %.

Följande exempel läser in denna presentation och renderar den samma första bilden i båda lägena med [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage).

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

Bilderna nedan visar resultatet från samma bild, med båda gradienterna i varje bild:

| Default | PowerPointUI |
| --- | --- |
| ![Cyan-to-orange and blue-to-yellow gradients rendered with Default](gradient-Default.png) | ![The same gradients rendered with PowerPointUI](gradient-PowerPointUI.png) |

I det här exemplet ger `Default` ljusare mellanliggande färger, medan `PowerPointUI` ger mörkare mellanliggande färger. Skillnaden beror på färgerna och stoppen i gradienten.

Välj `Default` när den standardmässiga Aspose.Slides‑utgången passar dina behov. Prova `PowerPointUI` när ditt mål är att matcha utseendet i PowerPoint. Jämför båda resultaten med ditt önskade resultat; inget läge är generellt att föredra.

## **Vanliga frågor**

**Hur kan jag exportera en specifik form, till exempel ett diagram eller en bild, istället för hela bilden?**

Aspose.Slides stöder [generering av miniatyrer för enskilda former](/slides/sv/php-java/create-shape-thumbnails/), vilket gör att du kan rendera en form som en PNG‑bild.

**Stöds parallell konvertering på en server?**

Ja. Använd en separat presentationsinstans för varje tråd eller process; [dela inte en enda instans över trådar](/slides/sv/php-java/multithreading/).

**Vilka begränsningar finns i utvärderingsläget när du exporterar till PNG?**

Utvärderingsläget lägger till ett vattenmärke på de exporterade bilderna och tillämpar [övriga restriktioner](/slides/sv/php-java/licensing/) tills en licens har tillämpats.