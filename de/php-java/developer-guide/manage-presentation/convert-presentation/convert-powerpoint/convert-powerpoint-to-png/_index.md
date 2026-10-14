---
title: PowerPoint-Folien in PNG konvertieren in PHP
linktitle: PowerPoint zu PNG
type: docs
weight: 30
url: /de/php-java/convert-powerpoint-to-png/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Folie konvertieren
- PPT konvertieren
- PPTX konvertieren
- PowerPoint zu PNG
- Präsentation zu PNG
- Folie zu PNG
- PPT zu PNG
- PPTX zu PNG
- PPT als PNG speichern
- PPTX als PNG speichern
- PPT nach PNG exportieren
- PPTX nach PNG exportieren
- PHP
- Aspose.Slides
description: "PowerPoint-Präsentationen schnell in hochwertige PNG-Bilder konvertieren mit Aspose.Slides für PHP über Java, wobei präzise, automatisierte Ergebnisse sichergestellt werden."
---
## **Übersicht**

Dieser Artikel erklärt, wie man Präsentationsfolien mithilfe von Aspose.Slides für PHP über Java in PNG‑Bilder konvertiert. Sie können Präsentationen in Formaten wie PPT, PPTX und ODP laden, jede Folie rendern und als separates PNG‑Bild speichern.

Die nachstehenden Beispiele demonstrieren das Rendern in der Standardskala, das Erhöhen der Skalierung, das Festlegen der Ausgabedimensionen in Pixeln und das Auswählen eines Gradient‑Render‑Stils.

## **PowerPoint in PNG konvertieren**

Laden Sie eine Präsentation mit der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) und greifen Sie über die Sammlung [Presentation::getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides) auf die Folien zu. Das Beispiel rendert jede Folie mit [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) ohne Parameter, um ein Miniaturbild zu erzeugen. Anschließend wird [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save) mit [ImageFormat::Png](https://reference.aspose.com/slides/php-java/aspose.slides/imageformat/#Png) aufgerufen, um jede gerenderte Folie als PNG‑Bild zu speichern.

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
Der parameterlose [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) Überladung rendert mit einer Skalierung von 0,2. Zum Beispiel erzeugt eine Folie mit den Maßen 720 × 540 Points ein Miniaturbild von 144 × 108 Pixel. Um die Ausgabedimensionen zu steuern, verwenden Sie die Überladungen mit Skalierungsfaktoren oder einer expliziten Bildgröße, wie unten gezeigt.
{{% /alert %}}

## **PowerPoint in PNG mit benutzerdefinierten Abmessungen konvertieren**

Geben Sie horizontale und vertikale Skalierungsfaktoren an [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage), um die gerenderten Abmessungen zu steuern. In diesem Beispiel sind beide Faktoren 2, sodass eine Folie mit den Maßen 720 – 540 Points ein Bild von 1440 – 1080 Pixel erzeugt. Gleiche Skalierungsfaktoren erhalten das Seitenverhältnis der Folie. Jedes Bild wird im PNG‑Format mit [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save) gespeichert.

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

## **PowerPoint in PNG mit benutzerdefinierter Größe konvertieren**

Um die Ausgabedimensionen in Pixeln anzugeben, übergeben Sie eine Größe an [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) anstelle von Skalierungsfaktoren. Dieses Beispiel rendert jede Folie mit 960 – 720 Pixel und speichert das Ergebnis mit [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save). Wählen Sie Abmessungen, die dem Seitenverhältnis der Folie entsprechen, um ein Dehnen des Bildes zu vermeiden.

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

## **Wählen Sie einen Gradient‑Render‑Stil**

Angenommen, eine Folie enthält Farbverläufe, aber die Übergänge im exportierten PNG erscheinen heller oder anders als in PowerPoint. Sie können die Methode [SaveOptions::setGradientStyle](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setGradientStyle) verwenden, die von [RenderingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/renderingoptions/) geerbt wird, um festzulegen, wie die Verläufe gerendert werden.

Laden Sie [gradient-styles.pptx](gradient-styles.pptx) herunter und legen Sie sie im Arbeitsverzeichnis der Anwendung ab. Die erste Folie enthält zwei lineare Verläufe: Cyan zu Orange oben und Blau zu Gelb unten. Jeder Verlauf hat zwei Stopps bei 0 % und 100 %.

Das folgende Beispiel lädt diese Präsentation und rendert die gleiche erste Folie in beiden Modi mit [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage).

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

Die Bilder unten zeigen die Ausgabe derselben Folie, mit beiden Verläufen in jedem Bild:

| Default | PowerPointUI |
| --- | --- |
| ![Cyan-zu-Orange- und Blau-zu-Gelb-Verläufe gerendert mit Default](gradient-Default.png) | ![Die gleichen Verläufe gerendert mit PowerPointUI](gradient-PowerPointUI.png) |

In diesem Beispiel erzeugt `Default` hellere Zwischenfarben, während `PowerPointUI` dunklere Zwischenfarben erzeugt. Der Unterschied hängt von den Farben und Stopps im Verlauf ab.

Wählen Sie `Default`, wenn die Standardausgabe von Aspose.Slides Ihren Anforderungen entspricht. Verwenden Sie `PowerPointUI`, wenn Ihre Priorität darin besteht, das Aussehen in PowerPoint zu reproduzieren. Vergleichen Sie beide Ausgaben mit dem gewünschten Ergebnis; kein Modus ist allgemein vorzuziehen.

## **FAQ**

**Wie kann ich eine bestimmte Form, z. B. ein Diagramm oder Bild, statt der gesamten Folie exportieren?**

Aspose.Slides unterstützt das [Erzeugen von Miniaturansichten für einzelne Formen](/slides/de/php-java/create-shape-thumbnails/), wodurch Sie eine Form als PNG‑Bild rendern können.

**Wird die parallele Konvertierung auf einem Server unterstützt?**

Ja. Verwenden Sie für jeden Thread oder Prozess eine separate Präsentationsinstanz; [teilen Sie keine einzelne Instanz über Threads hinweg](/slides/de/php-java/multithreading/).

**Welche Einschränkungen gelten im Evaluierungsmodus beim Exportieren nach PNG?**

Der Evaluierungsmodus fügt den Ausgabebildern ein Wasserzeichen hinzu und wendet [weitere Einschränkungen](/slides/de/php-java/licensing/) an, bis eine Lizenz aktiviert ist.