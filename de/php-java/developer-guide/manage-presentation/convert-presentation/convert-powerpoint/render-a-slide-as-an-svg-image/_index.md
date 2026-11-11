---
title: Präsentationsfolien als SVG-Bilder in PHP rendern
linktitle: Folie zu SVG
type: docs
weight: 50
url: /de/php-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint nach SVG
- Präsentation nach SVG
- Folie nach SVG
- PPT nach SVG
- PPTX nach SVG
- SVG-Exportoptionen
- interaktives SVG
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Exportieren Sie PowerPoint-Folien als SVG-Bilder in PHP und steuern Sie Schriftarten, Text, Bilder, IDs und Ereignisse mit Aspose.Slides."
---
## **Übersicht**

SVG ist ein skalierbares XML-basiertes Bildformat, das sich gut für die Veröffentlichung im Web, Folienbetrachter, Barrierefreiheits-Workflows und automatisierte Nachbearbeitung eignet. Aspose.Slides exportiert jede Folie in eine separate SVG-Datei und ermöglicht die Kontrolle darüber, wie Text, Schriftarten, Bilder und SVG-Elemente geschrieben werden.

Verwenden Sie [SVGOptions](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/), wenn das exportierte SVG kompakt, browserübergreifend vorhersehbar oder für interaktive Nutzung bereit sein muss.

## **Eine Folie als SVG exportieren**

Erstellen Sie eine [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/), wählen Sie eine Folie aus und schreiben Sie sie mit [Slide.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#writeAsSvg) in einen Stream. Das folgende Beispiel exportiert jede Folie einer Präsentation als separate SVG-Datei.

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

Der Dateiname verwendet [Slide.getSlideNumber](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getSlideNumber) anstelle des Schleifenindex. Sie können auch eine einzelne Form mit [Shape.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#writeAsSvg) exportieren, wenn ein Folienbetrachter oder eine Webseite nur diese Form benötigt.

## **SVG-Ausgabe konfigurieren**

[SVGOptions](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/) steuert das SVG-Rendering. Für Textfelder fügt [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setUseFrameSize) das Textfeld in den Rendering-Bereich ein, und [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setUseFrameRotation) bestimmt, ob die Drehung des Rahmens angewendet wird. Setzen Sie [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setDisableFontLigatures) auf `true`, wenn Text ohne Ligaturen gerendert werden muss.

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

## **Text und Schriftarten steuern**

Beim Export von Folien nach SVG können Sie steuern, ob Text als Text erhalten bleibt oder in Vektorgrafiken umgewandelt wird und wie externe Schriftarten einbezogen oder referenziert werden. Die folgenden Optionen helfen Ihnen, visuelle Konsistenz, Textauswahl und Schriftartabhängigkeiten im exportierten SVG auszubalancieren.

### **Alle Texte vektorisieren**

Setzen Sie [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) auf `true`, um den gesamten Folientext als Vektorgrafiken zu schreiben. Dies eliminiert Schriftartabhängigkeiten und sorgt für ein visuell konsistenteres Ergebnis über verschiedene Browser hinweg, jedoch ist der Text dann nicht mehr als SVG-Text auswähl- oder durchsuchbar.

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

### **Auswahl, wie externe Schriftarten behandelt werden**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setExternalFontsHandling) verwendet einen [SvgExternalFontsHandling](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/)-Wert für Schriftarten, die extern geladen werden. Wählen Sie `AddLinksToFontFiles`, um separate Schriftdateien zu referenzieren, `Embed`, um Schriftartdaten in das SVG einzubetten, oder `Vectorize`, um nur Text, der externe Schriftarten verwendet, als Grafik zu rendern. Überprüfen Sie die Lizenzierung der Schriftarten, bevor Sie sie einbetten.

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

## **Größe eingebetteter Bilder reduzieren**

Verwenden Sie [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setPicturesCompression), um die Auflösung eingebetteter Bilder zu reduzieren, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas), um beschnittene Quellbereiche auszulassen, und [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setJpegQuality), um die JPEG‑Kodierungsqualität zu steuern. Diese Einstellungen verringern die Dateigröße zulasten der Bildtreue oder der erhaltenen Bilddaten.

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

## **Rasterisierungsauflösung von Metadateien steuern**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setmetafilerasterizationdpi/) legt die untere Auflösungsgrenze für die Rasterung von Metadateien beim SVG-Export fest. Verwenden Sie sie, um Detailgrad und Dateigröße auszubalancieren, wenn ein EMF‑ oder WMF‑Bild gerastert wird. Sie definiert kein globales DPI für das SVG und zwingt nicht jedes Objekt auf der Folie, zu einem Rasterbild zu werden.

Laden Sie [metafile-rasterization.pptx](metafile-rasterization.pptx) herunter, das ein EMF‑Bild mit eng beabstandeten Diagonallinien enthält. Das folgende Beispiel exportiert die erste Folie mit drei Rasterisierungsauflösungen über [Slide.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/slide/writeassvg/). Alle anderen Exporteinstellungen bleiben identisch, damit die Ergebnisse verglichen werden können.

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

Im Ergebnis wurde das EMF in jedem SVG zu einem eingebetteten PNG. Die folgenden Messungen beziehen sich auf die bereitgestellte Präsentation; sie stellen keine allgemeine Formel zur Umrechnung von DPI in Pixelmaße dar.

| Metadatei-Rasterisierungs-DPI | Eingebettete PNG-Abmessungen | SVG-Dateigröße (Bytes) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Der Vergleich unten zeigt denselben Bereich des eingebetteten Rasters in derselben vergrößerten Anzeigegröße. Die Diagonallinien zeigen bei 72 DPI eine sichtbare Pixelbildung und bei höheren Auflösungen glattere Kanten, während die SVG-Datei wächst. Eine Erhöhung des Wertes verbessert nicht zwingend jedes Detail oder ändert jedes exportierte Bild.

![Vergrößerte Diagonal‑Linien‑Detail bei 72, 150 und 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setpicturescompression/) steuert die Reduzierung der Bildauflösung und kann die Auswirkung einer Änderung der Metadatei‑Rasterisierungs‑Auflösung maskieren. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setjpegquality/) steuert die JPEG‑Kodierungsqualität, nicht die Metadatei‑Rasterisierungs‑Auflösung.

## **Stabile IDs für Formen und Text zuweisen**

Stellen Sie einen Formatierungs-Callback für [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setShapeFormattingController) bereit, um [SvgShape.setId](https://reference.aspose.com/slides/php-java/aspose.slides/svgshape/#setId) für jede SVG-Form festzulegen. Der Callback kann auch Werte für [SvgTSpan.setId](https://reference.aspose.com/slides/php-java/aspose.slides/svgtspan/#setId) an Text-`tspan`-Elementen setzen.

PhpJavaBridge kann keinen PHP-Callback von `writeAsSvg` aus aufrufen, wenn es im Stream-Modus läuft. Platzieren Sie die Formatierungslogik in einer kleinen Java-Hilfsklasse, kompilieren Sie sie und fügen Sie die resultierende JAR-Datei dem Bridge-Klassenpfad hinzu. Die Hilfsklasse kann [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getOfficeInteropShapeId) verwenden, das für die Lebensdauer der Form stabil ist, sowie einen wiederholbaren Zähler für deren Text-Spans. Siehe die [Java‑Implementierung von `StableSvgIdController`](/slides/de/java/render-a-slide-as-an-svg-image/#assign-stable-ids-to-shapes-and-text) für den Hilfscode.

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

## **SVG‑Ereignishandler hinzufügen**

Rufen Sie in einem Formatierungs-Callback [SvgShape.setEventHandler](https://reference.aspose.com/slides/php-java/aspose.slides/svgshape/#setEventHandler) mit einem [SvgEvent](https://reference.aspose.com/slides/php-java/aspose.slides/svgevent/)-Wert auf, um einem exportierten Shape einen JavaScript-Ereignishandler hinzuzufügen. Weisen Sie den Callback mit [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setShapeFormattingController) zu und definieren Sie die JavaScript-Funktion in der Seite oder dem SVG-Dokument, das das Ergebnis hostet.

Wie bei stabilen IDs, implementieren Sie den Callback in einer Java-Hilfsklasse, wenn PhpJavaBridge den Stream-Modus verwendet. Die [Java‑Implementierung von `SvgEventController`](/slides/de/java/render-a-slide-as-an-svg-image/#add-svg-event-handlers) weist einer Form namens `ActionButton` eine ID und einen `OnClick`-Handler zu. Kompilieren Sie diese Hilfsklasse, fügen Sie sie dem Bridge-Klassenpfad als `com.example.slides.SvgEventController` hinzu und verwenden Sie sie aus PHP wie folgt:

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

Die Host-Seite kann die vom Handler referenzierte JavaScript-Funktion definieren. Das Zuweisen von IDs und Ereignishandlern ermöglicht Folienbetrachter, Barrierefreiheitsverbesserungen und andere interaktive SVG-Workflows.

## **FAQ**

**Wann sollte ich [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) anstelle von [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/) verwenden?**

Verwenden Sie [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText), wenn der gesamte Text unabhängig von Schriftarten sein muss. Verwenden Sie [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/), wenn nur Text, der externe Schriftarten verwendet, in Grafiken umgewandelt werden soll.

**Was ist der beste Weg, ein SVG zu verkleinern?**

Beginnen Sie mit der Komprimierung eingebetteter Bilder, dem Löschen beschnittener Bildbereiche und der Wahl verknüpfter Schriftdateien, wenn die Zielumgebung sie bereitstellen kann. Testen Sie das Ergebnis, da niedrigere Bildauflösung, geringere JPEG-Qualität und vektorisierter Text jeweils unterschiedliche Kompromisse zwischen Qualität und Größe darstellen.

**Kann ich exportierte SVG-Elemente nach dem Export bearbeiten?**

Ja. Weisen Sie IDs über einen Formatierungs-Callback zu und wählen Sie dann die passenden SVG-Elemente in Ihrem Nachbearbeitungs-Tool oder Browser-Skript aus.